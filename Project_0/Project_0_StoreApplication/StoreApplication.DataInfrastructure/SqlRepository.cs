using System;
using StoreApplication.Logic;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace StoreApplication.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        //Methods
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select * " +
                "FROM Customer;", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string FName = reader.GetString(1);
                string LName = reader.GetString(2);
                string DStore = reader.GetString(3);
                result.Add(new(ID, FName, LName, DStore));
            }
            connection.Close();
            return result;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            List<Orders> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select * " +
                "FROM Orders;", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int orderID = reader.GetInt32(0);
                string product = reader.GetString(1);
                int quantity = reader.GetInt32(2);
                string customer = reader.GetString(3);
                string storeLocation = reader.GetString(4);
                result.Add(new(orderID, product, quantity, customer, storeLocation));
            }
            connection.Close();
            return result;
        }

        public IEnumerable<StoreLocation> GetAllStores()
        {
            List<StoreLocation> result = new();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select * " +
                "FROM Stores;", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string product = reader.GetString(0);
                int Inventory = reader.GetInt32(1);
                int quantityOrdered = reader.GetInt32(2);
                string storeLocation = reader.GetString(3);
                result.Add(new(product, Inventory, quantityOrdered, storeLocation));
            }
            connection.Close();
            return result;
        }

        public Customer CreateNewCustomer(string FirstName, string LastName, string DefualtStore)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Customer (FirstName,LastName,DefualtStore)
                VALUES
                (@name, @lastname, @dstore);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@name", FirstName);
            cmd.Parameters.AddWithValue("@lastname", LastName);
            cmd.Parameters.AddWithValue("@dstore", DefualtStore);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT *
                FROM Customer";
                //WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@name", FirstName);
            cmd2.Parameters.AddWithValue("@lastname", LastName);
            cmd2.Parameters.AddWithValue("@", DefualtStore);
            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer;
            while (reader.Read())
            {
                return tmpCustomer = new Customer(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            connection.Close();
            Customer noCustomer = new();
            return noCustomer;
        }

        public Orders CreateNewOrder(string product, int quantity, string customer, string storelocation)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO Orders(Product,Quantity,Customer,Store)
                VALUES
                (@product, @quantity, @customer,@store);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@product", product);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@customer", customer);
            cmd.Parameters.AddWithValue("@store", storelocation);
            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT *
                FROM Orders";
            //WHERE Name = @name;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@product", product);
            cmd2.Parameters.AddWithValue("@quantity", quantity);
            cmd2.Parameters.AddWithValue("@customer", customer);
            cmd2.Parameters.AddWithValue("@store", storelocation);
            using SqlDataReader reader = cmd2.ExecuteReader();

            Orders tmpOrder;
            while (reader.Read())
            {
                return tmpOrder = new Orders(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
            }
            connection.Close();
            Orders noOrder = new();
            return noOrder;
        }
    }
}
