using EternalFlowStore.Logic;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace EternalFlowStore.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        //will hold all the communinication to and from the database

        //Fields
        //readonly cannot be modified
        private readonly string connectionString;


        //Constructor 
        public SqlRepository(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));  // testing  if the connection we're being sent is null, ensure that connection always have a value
        }

        //Methods
        //New customer registration
        public void NewCustomer(string FirstName, string LastName, string Address, string City, string StateProvinceArea, string Country, string PhoneNumber, string Email)

        {

            using SqlConnection connect = new SqlConnection(this.connectionString);
            connect.Open();

            string cmdText = @"INSERT INTO EternalFlowStore.Customers(FirstName,LastName,Address,City,StateProvinceArea,Country,PhoneNumber,Email) VALUES(@FirstName,@LastName,@Address,@City,@StateProvinceArea,@Country,@PhoneNumber,@Email);";
            using SqlCommand cmd = new SqlCommand(cmdText, connect);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@StateProvinceArea", StateProvinceArea);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Email", Email);

            cmd.ExecuteNonQuery();
            connect.Close();
        }



        //Creating a new customer
        public bool CustomerSignIn(string FirstName, string LastName)

        {
            using SqlConnection connect = new SqlConnection(this.connectionString);
            connect.Open();

            string query = @"SELECT FirstName, LastName FROM EternalFlowStore.Customers = @FirstName, @LastName;";
            SqlCommand cmd = new(query, connect);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())

            {

                string CustomerId = reader.GetString(1);
                return true;

            }
            connect.Close();
            return false;

        }


        //Pulling the data from SQL showcase the inventory
        public List<Inventory> GetInventoryId(int Inventory_ID)

        {
            List<Inventory> result = new List<Inventory>();

            using SqlConnection connect = new SqlConnection(this.connectionString);
            connect.Open();

            string query = @"SELECT Inventory_ID FROM EternalFLowStore.Inventory = @Inventory_ID";
            SqlCommand cmd = new SqlCommand(query, connect);

            cmd.Parameters.AddWithValue("@Inventory_ID", Inventory_ID);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())

            {

                int Inventory_Id = reader.GetInt32(0);
                string NameOfItem = reader.GetString(1);
                int Quantity = reader.GetInt32(3);
                int Price = reader.GetInt32(4);
                DateTime InventoryDateIn = reader.GetDateTime(5);
                DateTime InventoryDateOut = reader.GetDateTime(6);


                result.Add(new(Inventory_ID, NameOfItem, Quantity, Price, InventoryDateIn, InventoryDateOut));

            }

            reader.Close();
            return result;


            //IEnumerable<StoreLocation> GetAllLocations()
            //{
            //List<StoreLocation> result = new();

            //using SqlConnection connection = new SqlConnection(this.connectionString);
            //connection.Open();


            //SqlCommand cmd = new(
            // @"SELECT * FROM EternalFlowStore.Location", connection);

            // SqlDataReader reader = cmd.ExecuteReader();


            // while (dr.Read())
            // {

            // int Location_ID = reader.GetInt32(0);
            // string Location = reader.GetString(1);
            // string Country = reader.GetString(2);
            // string Address = reader.GetString(3);
            // string StateProvinceArea = reader.GetString(4);
            // string PhoneNumber = reader.GetString(5);
            // string Email = reader.GetString(6);

            // result.Add(new(Location_ID, Location, Country, Address, StateProvinceArea, PhoneNumber, Email));


            // }




        }

    }
}