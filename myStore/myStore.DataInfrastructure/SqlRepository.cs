using myStore.Logic;
using System.Data.SqlClient;

namespace myStore.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // Will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        // Methods

        public IEnumerable<Location> GetAllLocations()
        {
            List<Location> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT storeId, storeAddr, storeCity FROM myStore.Location", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string Addr = reader.GetString(1);
                string City = reader.GetString(2);
                result.Add(new(ID, Addr, City));
            }

            connection.Close();
            return result;
        }

        public string GetCustomerName(int ID)
        {
            string? name = "";
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText = @"SELECT customerName
                FROM myStore.Customer
                WHERE customerId = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                name = reader.GetString(1);
            }

            connection.Close();

            if (name != null)
            { return name; }
            return null;
        }

        public int CreateNewCustomer(Customer newCustomer)
        {
            int id = -1;
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"INSERT INTO myStore.Customer(firstName, lastName) VALUES (@firstName, @lastName);"
                , connection);

            cmd.Parameters.AddWithValue("@firstName", newCustomer.GetFirstName());
            cmd.Parameters.AddWithValue("@lastName", newCustomer.GetLastName());

            cmd.ExecuteNonQuery();

            using SqlCommand cmd2 = new(
                @"SELECT Customer_Id FROM myStore.Customer WHERE firstName = @firstName AND lastName = @lastName;", connection);
            cmd2.Parameters.AddWithValue("@firstName", newCustomer.GetFirstName());
            cmd2.Parameters.AddWithValue("@lastName", newCustomer.GetLastName());
            
            using SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                 id = reader.GetInt32(0);
            }
            connection.Close();
            return id;

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT Customer_Id, firstName, lastName FROM myStore.Customer", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string first = reader.GetString(1);
                string last = reader.GetString(2);
                result.Add(new(ID, first, last));
            }

            connection.Close();
            return result;
        }

        public IEnumerable<Inventory> GetSanDiegoInventory()
        {
            List<Inventory> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new("SELECT itemId, itemName, itemPrice, qtySD FROM myStore.SanDiegoInventory", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int qty = reader.GetInt32(3);
                result.Add(new(ID, name, price, qty));
            }

            connection.Close();
            return result;
        }

        public IEnumerable<Inventory> GetPhoenixInventory()
        {
            List<Inventory> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new("SELECT itemId, itemName, itemPrice, qtyPH FROM myStore.PhoenixInventory", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int qty = reader.GetInt32(3);
                result.Add(new(ID, name, price, qty));
            }

            connection.Close();
            return result;
        }

        public IEnumerable<Inventory> GetSeattleInventory()
        {
            List<Inventory> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new("SELECT itemId, itemName, itemPrice, qtySEA FROM myStore.SeattleInventory", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int qty = reader.GetInt32(3);
                result.Add(new(ID, name, price, qty));
            }

            connection.Close();
            return result;
        }

        public string displayOrder(int CustID, int storeID, int productID)
        {
            string fullName = "";
            string itemName = "";
            decimal itemPrice = 0;
            int itemID = productID;
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"SELECT firstName + ' ' + lastName AS fullName FROM myStore.Customer WHERE Customer_Id = @ID;", connection);
            cmd.Parameters.AddWithValue("@firstName", CustID);

            using SqlCommand cmd2 = new(
                @"SELECT itemName, itemPrice FROM myStore.Products WHERE itemId = @productID;", connection);
            cmd.Parameters.AddWithValue("@firstName", productID);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fullName = reader.GetString(0);
            }

            using SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader.Read())
            {
                itemName = reader2.GetString(0);
                itemPrice = reader2.GetDecimal(1);
            }
            connection.Close();

            string output = $"{itemName} purchased for {fullName} from location {storeID} for {itemPrice}";
            return output;

        }
    }
}