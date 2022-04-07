using System.Data.SqlClient;
using Store.Logic;

namespace Store.DataInfrastructure
{
    public class StoreRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;

        // Constructor
        public StoreRepository (string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString)); 
        }


        // Methods
        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT Customer_ID, FirstName, LastName " +
                "FROM Store.Customer; ", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                customers.Add(new(ID, FirstName, LastName));
            }
                connection.Close();
                return customers;
            
        }

        public Customer CreateNewCustomer(string FirstName, string LastName)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string cmdText = 
                @"INSERT INTO Store.Customer (FirstName, LastName)
                VALUES
                (@FirstName, @LastName);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT Customer_ID, FirstName, LastName
                FROM Store.Customer
                WHERE FirstName = @FirstName AND LastName = @LastName";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@FirstName", FirstName);
            cmd2.Parameters.AddWithValue("@LastName", LastName);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer;

            while(reader.Read())
            {
                return tmpCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }

            connection.Close();
            Customer noCustomer = new();
            return noCustomer;
        }
   
        public string GetCustomer(int ID)
        {
            string? FirstName = "";
            using SqlConnection connection = new(this._connectionString);
            connection.Open();

            string cmdText =
                @"SELECT FirstName, LastName
                FROM Store.Customer
                WHERE Customer_ID = @ID;";
            
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();  

            while(reader.Read())
            {
                FirstName = reader.GetString(0);
            }

            connection.Close();

            if (FirstName != null)
            { return FirstName; }
            return null;    
        }
    }
}


