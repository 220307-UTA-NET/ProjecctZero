
using System.Data.SqlClient;
using StoreApplication.Logic;
using System;


namespace StoreApplication.Infrastructure
{
    public class SqlRepository : InterfaceRepo
    {
        // Fields
        private readonly string _connectionString;

        public SqlRepository(string connectionString) { 
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Method display all the products in the inventory
        public IEnumerable<Product> GetAllProducts() {
            List<Product> productList = new();

            //using (SqlConnection connection = new SqlConnection(this._connectionString)) ;
            //connection.Open();

            //using SqlCommand cmd = new(
            //    "Select ProductID, ProductType, ProductName, Quantity, Cost" +
            //    "FROM StoreApp.Product;", connection);

            //using SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    int ID = reader.GetInt32(0);
            //    string ProductType = reader.GetString(1);
            //    string ProductName = reader.GetString(2);
            //    int Quantity = reader.GetInt32(3);
            //    double Cost = reader.GetDouble(4);
            //    productList.Add(new(ID, ProductType, ProductName, Quantity, Cost));
            //}

            //connection.Close();
            //return productList;

            string queryString ="Select ProductID, ProductType, ProductName, Quantity, Cost FROM StoreApp.Product;";

            using (SqlConnection connection =
                       new SqlConnection(this._connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string ProductType = reader.GetString(1);
                    string ProductName = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    decimal Cost = reader.GetDecimal(4);
                    productList.Add(new(ID, ProductType, ProductName, Quantity, Cost));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return productList;
        }

        // This method returns all order histories of a store location
        public IEnumerable<Orders> GetAllOrdersLoc(string Location)
        {
            List<Orders> ordersList = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select OrderID, CustomerID, ProductID, Location, Time FROM StoreApp.Orders  WHERE Location = @location ORDER BY Time;", connection);

            cmd.Parameters.AddWithValue("@location", Location);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int OrderID = reader.GetInt32(0);
                int CustomerID = reader.GetInt32(1);
                int ProductID = reader.GetInt32(2);
                string Locate = reader.GetString(3);
                DateTime Time = reader.GetDateTime(4);

                ordersList.Add(new(OrderID, CustomerID, ProductID, Locate, Time));
            }

            connection.Close();
            return ordersList;
        }



        public void AddCustomer(Customer customer) {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            int CustomerID = customer.GetCustomerID();
            string FirstName = customer.GetFirstName();
            string LastName = customer.GetLastName();
            string PhoneNumber = customer.GetPhoneNumber();
            //string StreetNumber = customer.GetStreetNumber();
            string Zipcode = customer.GetZipcode();

            string cmdText =
                @"INSERT INTO StoreApp.Customer (CustomerID, FirstName, LastName, PhoneNumber, StreetNumber, Zipcode)
                VALUES
                (@customerID, @firstName, @lastName, @phoneNumber, @streetNumber, @zipcode);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@customerID", CustomerID);
            cmd.Parameters.AddWithValue("@firstName", FirstName);
            cmd.Parameters.AddWithValue("@lastName", LastName);
            cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
            //cmd.Parameters.AddWithValue("@streetNumber", StreetNumber);
            cmd.Parameters.AddWithValue("@zipcode", Zipcode);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public Customer GetCustomer(string FirstName, string LastName)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText = @"SELECT CustomerID, FirstName, LastName, PhoneNumber, Zipcode FROM StoreApp.Customer WHERE FirstName = @firstName AND LastName = @lastName;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@firstName", FirstName);
            cmd.Parameters.AddWithValue("@lastName", LastName);

            using SqlDataReader reader = cmd.ExecuteReader();

            Customer tmpCustomer;
            while (reader.Read())
            {
                return tmpCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                        reader.GetString(3), reader.GetString(4));
            }
            connection.Close();
            Customer noCustomer = new();
            return noCustomer;
        }

        public Product GetOrderDetails(int CustomerID)
        {
            //throw new NotImplementedException();
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText = @"SELECT ProductID, ProductType, ProductName, Quantity, Cost FROM StoreApp.Product WHERE ProductID = (SELECT ProductID FROM StoreAPP.Orders WHERE CustomerID = @customerID);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@customerID", CustomerID);

            using SqlDataReader reader = cmd.ExecuteReader();

            Product tmpProduct;
            while (reader.Read())
            {
                return tmpProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                        reader.GetInt32(3), reader.GetDecimal(4));
            }
            connection.Close();
            Product noProduct = new();
            return noProduct;
        }


        // This methods display all order history by a customer ID
        public IEnumerable<Orders> GetAllOrdersCust(int CustomerID)
        {
            List<Orders> ordersList = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "Select OrderID, CustomerID, ProductID, Location, Time FROM StoreApp.Orders WHERE CustomerID = @customerID ORDER BY Time;", connection);

            cmd.Parameters.AddWithValue("@customerID", CustomerID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int OrderID = reader.GetInt32(0);
                int ID = reader.GetInt32(1);
                int ProductID = reader.GetInt32(2);
                string Location = reader.GetString(3);
                DateTime Time = reader.GetDateTime(4);

                ordersList.Add(new(OrderID, ID, ProductID, Location, Time));
            }

            connection.Close();
            return ordersList;
        }

        Orders InterfaceRepo.AddOrders(Orders orders)
        {
            throw new NotImplementedException();
        }
    }
}