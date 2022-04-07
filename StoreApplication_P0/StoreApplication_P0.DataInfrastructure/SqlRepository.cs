using StoreApplication_P0.Logic;
using System.Data.SqlClient;


namespace StoreApplication_P0.DataInfrastructure
{
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;

        // Constructors
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        // Methods

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~   Retrieve Llst of all customer accounts from SQL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public IEnumerable<CustomerAccount> GetAllCustomerAccounts()
        {
            List<CustomerAccount> AccountList = new();

            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                "SELECT *" +
                "FROM BakeryApp.Customer;", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int CustomerID = reader.GetInt32(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                string firstName = reader.GetString(3);
                string lastName = reader.GetString(4);
                string email = reader.GetString(5);
                string default_location = reader.GetString(6);
                AccountList.Add(new(CustomerID, username, password, firstName, lastName, email, default_location));
            }
            connection.Close();
            return AccountList;
        }




        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~~~~~~~~~~~~~~~~~~   Creating a new customer account and sending to SQL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public CustomerAccount CreateNewCustomerAccount(string UserName, string userPassword, string FirstName, string LastName, string Email, string DefaultStore)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText =
                $@"INSERT INTO BakeryApp.Customer(Username,userPassword, FirstName, LastName, Email, DefaultStore)
                VALUES 
                (@Username, @userPassword, @FirstName, @LastName, @Email, @DefaultStore);";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@Username", UserName);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DefaultStore", DefaultStore);

            cmd.ExecuteNonQuery();

            cmdText =
                @"SELECT * 
                FROM BakeryApp.Customer 
                WHERE Username = @Username;";

            using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

            cmd2.Parameters.AddWithValue("@Username", UserName);
            cmd2.Parameters.AddWithValue("@userPassword", userPassword);
            cmd2.Parameters.AddWithValue("@FirstName", FirstName);
            cmd2.Parameters.AddWithValue("@LastName", LastName);
            cmd2.Parameters.AddWithValue("@Email", Email);
            cmd2.Parameters.AddWithValue("@DefaultStore", DefaultStore);

            using SqlDataReader reader = cmd2.ExecuteReader();

            CustomerAccount newCustomerAcct;
            while (reader.Read())
            {
                return newCustomerAcct = new CustomerAccount(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
            }

            connection.Close();
            CustomerAccount emptyAcct = new();
            return emptyAcct;

        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        //~~~~~~~~~~~~~~~~~~~   Check for username existance and associated password   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public string findUsername(string usernameInput)
        {
            string SQLusername = "";
            string SQLpassword = "";

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string cmdText3 =
                @"SELECT Username
                FROM BakeryApp.Customer
                WHERE Username = @usernameInput;";

            using SqlCommand cmd3 = new SqlCommand(cmdText3, connection);
            cmd3.Parameters.AddWithValue("@usernameInput", usernameInput);
            using SqlDataReader reader = cmd3.ExecuteReader();

            while (reader.Read())
            {
                SQLusername = reader.GetString(0);
            }

            connection.Close();

            if (SQLusername != null)
            { return SQLusername; }
            else
            { return null; }

        }

        ////    ~~~~~~~~~~  Find Current Inventory quantity     ~~~~~~~~~~  
        //public int FindCurrent(string item)
        //{
        //    //int QntyNum;
        //    using SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();

        //    string cmdText3 =
        //        @"SELECT Washington_DC_Stockpile
        //        FROM BakeryApp.Inventory
        //        WHERE Item = @item;";

        //    using SqlCommand cmd = new SqlCommand(cmdText3, connection);
        //    cmd.Parameters.AddWithValue("@item", item);
        //    using SqlDataReader reader = cmd.ExecuteReader();
        //    //int currentQnt;
        //    while (reader.Read())
        //    {
        //        int QntyNum = reader.GetInt32(0);
        //        return QntyNum;
        //        //return currentQnt;
        //        //return currentSqlQnt = ;
        //    }
        //    //return QntyNum;
        //    connection.Close();

        //    //Console.WriteLine(QntyNum);
        //    //if (QntyNum != null)
        //    //{ return QntyNum; }
        //    //


        //}



        //public void inventoryRemaining(string item, int orderQuantity)
        //{
        //    int SqlInventory;
        //    using SqlConnection connection = new SqlConnection(this._connectionString);
        //    connection.Open();

        //    string SQLQuery =
        //        @"UPDATE BakeryApp.Inventory
        //        SET Washington_DC_Stockpile = '@orderQuantity'
        //        WHERE Item = @selectedItem;";


        //    using SqlCommand cmd = new SqlCommand(SQLQuery, connection);

        //    cmd.Parameters.AddWithValue("@selectedItem", item);
        //    cmd.Parameters.AddWithValue("@orderQuantity", orderQuantity);

        //    using SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        return reader.GetInt32(0);
        //    }



        //}






        //    public PlaceOrder CreateNewOrder(string Name)
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        ////~~~~~~~~~~~~~~~~~~~   Creating a new customer account and sending to SQL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //public Receipt CreateReceiptList(string item, decimal prices)
        //{
        //    using SqlConnection connection = new SqlConnection(_connectionString);
        //    connection.Open();

        //    string cmdText =
        //        $@"INSERT INTO BakeryApp.Customer(item, prices)
        //        VALUES 
        //        (@Username, @userPassword, @FirstName, @LastName, @Email, @DefaultStore);";

        //    using SqlCommand cmd = new SqlCommand(cmdText, connection);

        //    cmd.Parameters.AddWithValue("@Username", UserName);
        //    cmd.Parameters.AddWithValue("@userPassword", userPassword);
        //    cmd.Parameters.AddWithValue("@FirstName", FirstName);
        //    cmd.Parameters.AddWithValue("@LastName", LastName);
        //    cmd.Parameters.AddWithValue("@Email", Email);
        //    cmd.Parameters.AddWithValue("@DefaultStore", DefaultStore);

        //    cmd.ExecuteNonQuery();

        //    cmdText =
        //        @"SELECT * 
        //        FROM BakeryApp.Customer 
        //        WHERE Username = @Username;";

        //    using SqlCommand cmd2 = new SqlCommand(cmdText, connection);

        //    cmd2.Parameters.AddWithValue("@Username", UserName);
        //    cmd2.Parameters.AddWithValue("@userPassword", userPassword);
        //    cmd2.Parameters.AddWithValue("@FirstName", FirstName);
        //    cmd2.Parameters.AddWithValue("@LastName", LastName);
        //    cmd2.Parameters.AddWithValue("@Email", Email);
        //    cmd2.Parameters.AddWithValue("@DefaultStore", DefaultStore);

        //    using SqlDataReader reader = cmd2.ExecuteReader();

        //    CustomerAccount newCustomerAcct;
        //    while (reader.Read())
        //    {
        //        return newCustomerAcct = new CustomerAccount(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
        //    }

        //    connection.Close();
        //    CustomerAccount emptyAcct = new();
        //    return emptyAcct;

    }










}





