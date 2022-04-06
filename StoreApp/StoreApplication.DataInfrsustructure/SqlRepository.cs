using System.Data.SqlClient;
using StoreApplication.Logic;

namespace StoreApplication.DataInfrsustructure
{
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;

        //List<Customer> customerList = new List<Customer>();

        //Constructor
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
                "Select CustomerID, Name " +
                "FROM StoreApplication.Customer;", connection);

            

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                string FirstName = reader.GetString(0);
                string LastName = reader.GetString(1);
                int ID = reader.GetInt32(2);
                string address = reader.GetString(3);
                result.Add(new(FirstName, LastName, ID, address));
            }

            // reader.??? is parsing the response form the database to C# datatypes

            connection.Close();
            return result;
        }


        //adding new customer
        public Customer AddNewCustomer(string firstName, string lastName, string address)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                @"INSERT INTO StoreApplication.Customer (firstName,lastName,address)
                VALUES
                (@FirstName,@LastName,@Address);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Address", address);

            cmd.ExecuteNonQuery();

            cmdText =
                $"SELECT CustomerID, FirstName, LastName, Address FROM StoreApplication.Customer WHERE FirstName = '{firstName}' and LastName = '{lastName}';";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            //cmd.Parameters.AddWithValue("@FirstName", firstName);
            //cmd.Parameters.AddWithValue("@LastName", lastName);
            // cmd.Parameters.AddWithValue("@Address", address);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer = new Customer();
            while (reader.Read())
            {
                Console.WriteLine("Added!");
                tmpCustomer.SetCustomerID(reader.GetInt32(0));
                tmpCustomer.SetFirstName(reader.GetString(1));
                tmpCustomer.SetLastName(reader.GetString(2));
                tmpCustomer.SetAddress(reader.GetString(3));
            }
            connection.Close();
            // Customer noCustomer = new();
            return tmpCustomer;
        }

        public string GetCustomerName(int ID)
        {
            string? name = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            string cmdText = @"SELECT Name
                FROM StoreApplication.Customer
                WHERE CustomerID = @ID;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@ID", ID);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                name = reader.GetString(0);
            }

            connection.Close();

            if (name != null)
            { return name; }
            return null;
        }



        //searching a customer by name
        public Customer SearchCustomerByName(string s)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

           

         

            string cmdText =
            $"SELECT CustomerID, FirstName, LastName, Address FROM StoreApplication.Customer WHERE FirstName = '{s}' or LastName = '{s}';";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            //cmd.Parameters.AddWithValue("@FirstName", firstName);
            //cmd.Parameters.AddWithValue("@LastName", lastName);
            // cmd.Parameters.AddWithValue("@Address", address);

            using SqlDataReader reader = cmd2.ExecuteReader();

            Customer tmpCustomer = new Customer();
            while (reader.Read())
            {
                Console.WriteLine("Found!");
                tmpCustomer.SetCustomerID(reader.GetInt32(0));
                tmpCustomer.SetFirstName(reader.GetString(1));
                tmpCustomer.SetLastName(reader.GetString(2));
                tmpCustomer.SetAddress(reader.GetString(3));
            }
            connection.Close();
            // Customer noCustomer = new();
            return tmpCustomer;
        }


        IEnumerable<Customer> IRepository.GetAllCustomers()
        {
            throw new NotImplementedException();
        }

      

        string IRepository.GetCustomerName(int ID)
        {
            throw new NotImplementedException();
        }
    }
}






