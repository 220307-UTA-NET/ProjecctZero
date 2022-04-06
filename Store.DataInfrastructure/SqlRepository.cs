using Store.Logic;
using System.Data.SqlClient;

namespace Store.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        //Fields
        private readonly string _connectionString;

        //Constructor
        public SqlRepository (string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        //Methods
        public void CreateNewCustomer(string fName, string lName)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO Store.Customers ([First Name], [Last Name]) 
            VALUES (@fName, @lName);";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.ExecuteNonQueryAsync();
            connection.Close();
            return;
        }
        public void CreateNewOrder(int locationID, int customerID, int itemID, int quantity, int orderID)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO Store.Orders ([Location ID], [Customer ID], [Item ID], [Quantity], [Order ID]) "+
            "VALUES ( @locationID , @customerID , @itemID , @quantity , @orderID );";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);        
            cmd.Parameters.AddWithValue("@locationID", locationID);
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@itemID", itemID);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.ExecuteNonQueryAsync();
            connection.Close();
            return;
        }
        public void MakeNewCustomer(string fName, string lName, int storeId)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(@"INSERT INTO Store.Customers ([First Name], [Last Name], [Home Store]) VALUES(@fName, @lName, @storeId);", connection);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@storeId", storeId);
            cmd.ExecuteNonQueryAsync();
            connection.Close();
            return;
        }
        public int GetCustomerID(string firstName, string lastName)
        {
            int custID = 7;
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            string cmdText = @"SELECT * FROM Store.Customers WHERE [First Name] = @firstName AND [Last Name] = @lastName;";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                custID = Convert.ToInt32(reader.GetInt32(0));
            }
            connection.Close();
            return custID;
        }
        public IEnumerable<Customer> GatherAllCustomers()
        {
            List<Customer> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new("Select * FROM Store.Customers", connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string fName = reader.GetString(1);
                string lName = reader.GetString(2);
                int locationCode = reader.GetInt32(3);
                result.Add(new(ID, fName, lName, locationCode));
            }
            connection.Close();
            return result;
        }
        public IEnumerable<Customer> GatherOneCustomer(string fName, string lName)
        {
            List<Customer> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"Select * FROM Store.Customers WHERE [First Name] = @fName AND [Last Name] = @lName;", connection);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@lName", lName);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);
                int locationCode = reader.GetInt32(3);
                result.Add(new(ID, firstName, lastName, locationCode));
            }
            connection.Close();
            return result;
        }
        public IEnumerable<Orders> GatherAllOrders()
        {           
            List<Orders> orders = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new("Select * FROM Store.Orders", connection);            
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderLine = reader.GetInt32(0);
                int locationID = reader.GetInt32(1);
                int customerID = reader.GetInt32(2);
                DateTime orderPlaced = reader.GetDateTime(3);
                int itemID = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                int orderID = reader.GetInt32(6);
                orders.Add(new(orderLine, locationID, customerID, orderPlaced, itemID, quantity, orderID));
            }
            connection.Close();
            return orders;
        }        
        public IEnumerable<Orders> GatherCustOrders(int custID)
        {
            custID = Convert.ToInt32(custID);
            List<Orders> final = new(custID);
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"Select * FROM Store.Orders WHERE [Customer ID] = @custID", connection);
            cmd.Parameters.AddWithValue("@custID", custID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderLine = reader.GetInt32(0);
                int locationID = reader.GetInt32(1);
                int customerID = reader.GetInt32(2);
                DateTime orderPlaced = reader.GetDateTime(3);
                int itemID = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                int orderID = reader.GetInt32(6);
                final.Add(new(orderLine, locationID, customerID, orderPlaced, itemID, quantity, orderID));
            }
            connection.Close();
            return final;
        }
        public IEnumerable<Orders> GatherLocOrders(int locationID)
        {
            locationID = Convert.ToInt32(locationID);
            List<Orders> final = new(locationID);
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"Select * FROM Store.Orders WHERE [Location ID] = @locationID", connection);
            cmd.Parameters.AddWithValue("@locationID", locationID);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderLine = reader.GetInt32(0);
                locationID = reader.GetInt32(1);
                int customerID = reader.GetInt32(2);
                DateTime orderPlaced = reader.GetDateTime(3);
                int itemID = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                int orderID = reader.GetInt32(6);
                final.Add(new(orderLine, locationID, customerID, orderPlaced, itemID, quantity, orderID));
            }
            connection.Close();
            return final;
        }
        public IEnumerable<Orders> GatherIdOrders(int orderIDv)
        {
            orderIDv = Convert.ToInt32(orderIDv);
            List<Orders> final = new(orderIDv);
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new(@"Select * FROM Store.Orders WHERE [Order ID] = @orderID", connection);
            cmd.Parameters.AddWithValue("@orderID", orderIDv);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int orderLine = reader.GetInt32(0);
                int locationID = reader.GetInt32(1);
                int customerID = reader.GetInt32(2);
                DateTime orderPlaced = reader.GetDateTime(3);
                int itemID = reader.GetInt32(4);
                int quantity = reader.GetInt32(5);
                int orderID = reader.GetInt32(6);
                final.Add(new(orderLine, locationID, customerID, orderPlaced, itemID, quantity, orderID));
            }
            connection.Close();
            return final;
        }
        
        
    }
}