using System;
using meatShop.Logic;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace meatShop.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        ///<params>
        ///hold all the communication to and from database
        ///</params>
         // will hold all of the communication to and from the database

        // Fields

        private readonly string _connectionString;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Methods
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select CustomerID, FirstName, Lastname FROM Dagoba.Customer;", connection);

            // index     0     1     2     3
            // column   id    name
            // row 1    1     Naruto
            // row 2    2     Saksuke

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                result.Add(new(ID, FirstName, LastName, 4, "Some store"));
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            return result;
        }

        public Customer CreateNewCustomer(string FirstName, string LastName, int HistoryId, string PrimaryStore)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Dagoba.Customer (FirstName, LastName, HistoryId, PrimaryStore)
                VALUES
                (@Firstname, @Lastname, @HistoryId, @PrimaryStore);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@Firstname", FirstName);
            cmd.Parameters.AddWithValue("@Lastname", LastName);
            cmd.Parameters.AddWithValue("@HistoryId", HistoryId);
            cmd.Parameters.AddWithValue("@PrimaryStore", PrimaryStore);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT CustomerId, FirstName, LastName, HistoryId, PrimaryStore
                FROM Dagoba.Customer
                WHERE FirstName = @Firstname;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@Firstname", FirstName);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer;
            while (reader.Read())
            {
                return tmpCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
            }
            connection.Close();
            Customer nocustomer = new();
            return nocustomer;
        }
        public Order CreateNewOrder(int OrderId, int StoreId, int CustomerId, string OrderPlaced, string ProductName, int ProductAmount, int ItemListId)
        {
           
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Dagoba.OrderMaker (OrderId, StoreId, CustomerId, OrderPlaced, ProductName, ProductAmount, ItemListId)
                VALUES
                (@OrderId, @StoreId, @CustomerId, @date1, @ProductName, @ProductAmount, @ItemListId);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.Parameters.AddWithValue("@StoreId", StoreId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@date1", OrderPlaced);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@ProductAmount", ProductAmount);
            cmd.Parameters.AddWithValue("@ItemListId", ItemListId);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT UniId, OrderId, StoreId, CustomerId, OrderPlaced, ProductName, ProductAmount, ItemListId
                FROM Dagoba.OrderMaker
                WHERE OrderPlaced = @OrderPlaced;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@OrderPlaced", OrderPlaced);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Order result = new();
            while (reader.Read())
            {
                int Idtemp = reader.GetInt32(0);
                int OrderIdtemp = reader.GetInt32(1);
                int StoreIdtemp = reader.GetInt32(2);
                int CustIdtemp = reader.GetInt32(3);
                string Datetemp = reader.GetString(4);
                string ProductNametemp = reader.GetString(5);
                int ProductAmounttemp = reader.GetInt32(6);
                int ItemListIdtemp = reader.GetInt32(7);
                return result = new Order(Idtemp,OrderIdtemp, StoreIdtemp, CustIdtemp, Datetemp, ProductNametemp, ProductAmounttemp, ItemListIdtemp);
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            Order nocustomer = new();
            return nocustomer;
           
        }

        public string GetCustomerFirstName(int ID)
        {
            string? FirstName = "";

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            string cmdText = @"SELECT FirstName
                FROM Dagoba.Customer
                WHERE CustomerId = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FirstName = reader.GetString(0);

            }

            connection.Close();

            if (FirstName != null)
            { return FirstName; }
            return null;
        }

        public string GetCustomerLastName(int ID)
        {
            string? LastName = "";

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            string cmdText = @"SELECT LastName
                FROM Dagoba.Customer
                WHERE CustomerId = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LastName = reader.GetString(0);

            }

            connection.Close();

            if (LastName != null)
            { return LastName; }
            return null;
        }



        public IEnumerable<Store> GetAllStores()
        {
            List<Store> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select StoreId, StoreName, Location, StoreHistoryId, ItemListId FROM Dagoba.Store;", connection);

            // index     0     1     2     3
            // column   id    name
            // row 1    1     Naruto
            // row 2    2     Saksuke

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string StoreName = reader.GetString(1);
                string Location = reader.GetString(2);
                int StoreHistoryId = reader.GetInt32(3);
                int ItemListId = reader.GetInt32(4);
                result.Add(new(ID, StoreName, Location, StoreHistoryId, ItemListId));
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            return result;
        }
        public IEnumerable<UltimateWarrior> GetAllOrders()
        {
            List<UltimateWarrior> result = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT * FROM Dagoba.OrderMaker JOIN Dagoba.Store ON OrderMaker.StoreId = Store.StoreId;", connection);

            // index     0     1     2     3
            // column   id    name
            // row 1    1     Naruto
            // row 2    2     Saksuke

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                int OrderId = reader.GetInt32(1);
                int StoreId = reader.GetInt32(2);
                int CustomerId = reader.GetInt32(3);
                string OrderPlaced = reader.GetString(4);
                string ProductName = reader.GetString(5);
                int ProductAmount = reader.GetInt32(6);
                int ItemListId = reader.GetInt32(7);
                int StoreId2 = reader.GetInt32(8);
                string StoreName = reader.GetString(9);
                string Location = reader.GetString(10);
                int StoreHistoryId = reader.GetInt32(11);
                int ItemList2 = reader.GetInt32(12);

                result.Add(new(ID, OrderId, StoreId, CustomerId, OrderPlaced, ProductName, ProductAmount, ItemListId, StoreId2, StoreName, Location, StoreHistoryId, ItemList2 ));
            }
            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            return result;
        }
    }
}
