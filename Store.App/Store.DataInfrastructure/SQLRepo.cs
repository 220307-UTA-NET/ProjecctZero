using Store.Logic;
using System.Data.SqlClient;

namespace Store.DataInfrastructure
{
    public class SQLRepo : IRepository //Holds all communication to and from the database
    {

        //Fields
        private readonly string connection;
        string sql = null;
        string Inventory_1;
        string Inventory_2;
        string Inventory_3;
        int requested_quantity;
        string location = default;
        string inventory_1;
        string inventory_2;
        int quantity_2 = 0;
        string inventory_3;
        int quantity_3 = 0;
        int quantity = 0;
        



        //constructor
        public SQLRepo(string connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection)); //Throw exception if null
        }

        //Methods (All methods here are implementations of signatures in IRepository)

        public void NewCustomer(string firstName, string lastName, string username, string password, string location)
        {
            using SqlConnection conn = new(connection);
            conn.Open();
            string query = "INSERT INTO CustomerM(First_Name, Last_Name, Username, Password, Location) VALUES (@firstName, @lastName, @username, @password, @location);";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@location", location);
            int completion = command.ExecuteNonQuery();
            if (completion == 0)
            {
                Console.WriteLine("A new customer was not created");
            }
            conn.Close();
        }


        public IEnumerable<Customer> CustomerSearch(string firstName, string lastName)
        {
            List<Customer> customers = new();
            using SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            string query = "SELECT * FROM CustomerM WHERE First_Name = @firstName AND Last_Name = @lastName;";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int custID = reader.GetInt32(0);
                string fName = reader.GetString(1);
                string lName = reader.GetString(2);
                customers.Add(new(custID, fName, lName));
            }
            conn.Close();

            using SqlConnection conn2 = new SqlConnection(connection);
            conn2.Open();
            string query2 = "SELECT * FROM Orders2 WHERE First_Name = @firstName AND Last_Name = @lastName;";
            using SqlCommand command2 = new SqlCommand(query2, conn2);
            command2.Parameters.AddWithValue("@firstName", firstName);
            command2.Parameters.AddWithValue("@lastName", lastName);
            using SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                int orderNumber = reader2.GetInt32(0);
                string fName = reader2.GetString(2);
                string lName = reader2.GetString(3);
                string storeLocation = reader2.GetString(4);
                string item_1 = reader2.GetString(5);
                int quantity_1 = reader2.GetInt32(6);
                string item_2 = reader2.GetString(7);
                int quantity_2 = reader2.GetInt32(8);
                string item_3 = reader2.GetString(9);
                int quantity_3 = reader2.GetInt32(10);
                DateTime time = reader2.GetDateTime(11);
                string description_1 = reader2.GetString(12);
                string description_2 = reader2.GetString(13);
                string description_3 = reader2.GetString(14);
                List<object> list = new List<object>();
                list.Add("Order Number: " + orderNumber);
                //list.Add(firstName);
                //list.Add(lastName);
                list.Add("Store Location: " + storeLocation);
                list.Add("Clocks Purchased: " + quantity_1);
                list.Add("Paintings Purchased: " + quantity_2);
                list.Add("Books Purchased: " + quantity_3);
                list.Add("Time of Purchase: " + time);
                list.Add("Description of Clocks: " + description_1);
                list.Add("Description of Paintings: " + description_2);
                list.Add("Description of Books: " + description_3);
                Console.WriteLine(" ");
                foreach (var customer in list)
                {
                    Console.WriteLine("\t" + customer);
                    Console.WriteLine("\t ");
                }
            }
            conn2.Close(); 
            return customers;
        }

        public void NewOrder(string firstName, string lastName)
        {
            int quantity_1 = 0;
            int quantity_2 = 0;
            int quantity_3 = 0;
            int c_input = 0;
            int p_input = 0;
            int b_input = 0;
            int new_quantity_c = 0;
            int new_quantity_p = 0;
            int new_quantity_b = 0;

            using SqlConnection conn = new(connection);
            conn.Open();
            string query = "SELECT * FROM CustomerM WHERE First_Name = @firstName AND Last_Name = @lastName;";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                location = reader.GetString(5);
            }
            conn.Close();

            using SqlConnection conn2 = new(connection);
            conn2.Open();
            string query2 = "SELECT * FROM Locations WHERE Location = @location;";
            using SqlCommand command2 = new SqlCommand(query2, conn2);
            command2.Parameters.AddWithValue("@location", location);
            command2.Parameters.AddWithValue("@firstName", firstName);
            command2.Parameters.AddWithValue("@lastName", lastName);
            using SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                location = reader2.GetString(1);
                inventory_1 = reader2.GetString(2);
                quantity_1 = reader2.GetInt32(3);
                inventory_2 = reader2.GetString(4);
                quantity_2 = reader2.GetInt32(5);
                inventory_3 = reader2.GetString(6);
                quantity_3 = reader2.GetInt32(7);
                List<object> list = new List<object>();
                list.Add("Store Location: " + location);
                //list.Add("Clock Inventory: " + inventory_1);
                list.Add("Clocks Remaining: " + quantity_1);
                //list.Add("Paintings Inventory: " + inventory_2);
                list.Add("Paintings Remaining: " + quantity_2);
                //list.Add("Books Inventory: " + inventory_3);
                list.Add("Books Remaining: " + quantity_3);

                foreach (var item in list)
                {
                    Console.WriteLine("\t" + item);
                    Console.WriteLine("\t ");
                }
            }
            conn2.Close();


            do
            {
                Console.WriteLine("Please enter the number of clocks you wish to purchase: ");
                c_input = int.Parse(Console.ReadLine());
                if (c_input < quantity_1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nRequested amount is more than what's available; please enter another request\n");
                }
            }
            while (c_input > quantity_1);

            do
            {
                Console.WriteLine("Please enter the number of paintings you wish to purchase: ");
                p_input = int.Parse(Console.ReadLine());

                if (p_input < quantity_2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nRequested amount is more than what's available; please enter another request\n");
                }
            }
            while (p_input > quantity_2);

            do
            {
                Console.WriteLine("Please enter the number of books you wish to purchase: ");
                b_input = int.Parse(Console.ReadLine());

                if (b_input < quantity_3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nRequested amount is more than what's available; please enter another request\n");
                }
            }
            while (b_input > quantity_3);
  
            using SqlConnection conn14 = new(connection);
            conn14.Open();
            string query14 = "SELECT * FROM Locations WHERE Location = @location;";
            using SqlCommand command14 = new SqlCommand(query14, conn14);
            command14.Parameters.AddWithValue("@location", location);
            using SqlDataReader reader14 = command14.ExecuteReader();
            while (reader14.Read())
            {
                Inventory_1 = reader14.GetString(2);
                quantity_1 = reader14.GetInt32(3);
                string Inventory_2 = reader14.GetString(4);
                quantity_2 = reader14.GetInt32(5);
                string Inventory_3 = reader14.GetString(6);
                quantity_3 = reader14.GetInt32(7);  
            }
            new_quantity_c = quantity_1 - c_input;
            new_quantity_p = quantity_2 - p_input;
            new_quantity_b = quantity_3 - b_input;
            conn14.Close();

            using SqlConnection conn5 = new(connection);
            conn5.Open();
            string query5 = "UPDATE Locations SET I_1_Quantity = @quantity_1, I_2_Quantity = @quantity_2, I_3_Quantity = @quantity_3 WHERE Location = @location;";
            SqlCommand command5 = new SqlCommand(query5, conn5);
            command5.Parameters.AddWithValue("@quantity_1", new_quantity_c);
            command5.Parameters.AddWithValue("@quantity_2", new_quantity_p);
            command5.Parameters.AddWithValue("@quantity_3", new_quantity_b);
            command5.Parameters.AddWithValue("@location", location);
            command5.ExecuteNonQuery();
            conn5.Close();

            string description_1 = "1860s robust and stylish clocks for the rich and famous";
            string description_2 = "rustic paintings with a drastic flair";
            string description_3 = "Dusty Legends for the ages";
            string item_1 = "Clocks";
            string item_2 = "Paintings";
            string item_3 = "Books";
            using SqlConnection conn6 = new(connection);
            conn6.Open();
            string query6 = "INSERT INTO Orders2(First_Name,Last_Name, Store_Location, Item_1, Quantity_1, Item_2, Quantity_2, Item_3, Quantity_3, Item1_Description, Item2_Description, Item3_Description) VALUES(@firstName, @lastName, @location, @inventory_1, @quantity_1, @inventory_2, @quantity_2, @inventory_3, @quantity_3, @description_1, @description_2, @description_3);";
            //string query6 = "UPDATE Orders2 SET First_Name = @firstName, Last_Name = @lastName, Store_Location = @location, Item_1 = @inventory_1, Quantity_1 = @quantity_1, Item_2 = @inventory_2, Quantity_2 = @quantity_2, Item_3 = @inventory_3, Quantity_3 = quantity_3, Item1_Description = @description_1, Item2_Description = @description_2, Item3_Description = @description_3 WHERE Store_Location = @location;";
            SqlCommand command6 = new SqlCommand(query6, conn6);
            command6.Parameters.AddWithValue("@firstName", firstName);
            command6.Parameters.AddWithValue("@lastName", lastName);
            command6.Parameters.AddWithValue("@location", location);
            command6.Parameters.AddWithValue("@inventory_1", item_1);
            command6.Parameters.AddWithValue("@quantity_1", c_input);
            command6.Parameters.AddWithValue("@inventory_2", item_2);
            command6.Parameters.AddWithValue("@quantity_2", p_input);
            command6.Parameters.AddWithValue("@inventory_3", item_3);
            command6.Parameters.AddWithValue("@quantity_3", b_input);
            //command5.Parameters.AddWithValue("@time", firstName);
            command6.Parameters.AddWithValue("@description_1", description_1);
            command6.Parameters.AddWithValue("@description_2", description_2);
            command6.Parameters.AddWithValue("@description_3", description_3);
            command6.ExecuteNonQuery();



            conn6.Close();
            Console.WriteLine("\nAt the " + location + " location, the following items are in inventory:");
                Console.WriteLine(new_quantity_c + " left");
                Console.WriteLine(new_quantity_p + " left");
                Console.WriteLine(new_quantity_b + " left");
            
        }
        //string query5 = "UPDATE Locations SET I_1_Quantity = @quantity_1, I_2_Quantity = @quantity_2, I_3_Quantity = quantity_3;";

        public void ChangeLocation(string firstName, string lastName)
        {
            string location = "default";
            using SqlConnection conn = new(connection);
            conn.Open();
            string query = "SELECT * FROM CustomerM WHERE First_Name = @firstName AND Last_Name = @lastName;";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                location = reader.GetString(5); //Index position 5
            }
            conn.Close();
            Console.WriteLine("Your current store location is: " + location);
            Console.WriteLine("Please select a location to change to: ");
            Console.WriteLine("Atlanta   - [1]");
            Console.WriteLine("New York  - [2]");
            Console.WriteLine("Michigan  - [3]");
            Console.WriteLine("Kansas    - [4]");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    conn.Open();
                    string query2 = "UPDATE CustomerM SET location = 'Atlanta' WHERE First_Name = @fName AND Last_Name = @lName;";
                    SqlCommand command2 = new SqlCommand(query2, conn);
                    command2.Parameters.AddWithValue("@fName", firstName);
                    command2.Parameters.AddWithValue("@lName", lastName);
                    command2.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("\tLocation updated to Atlanta\n");
                    break;
                case "2":
                    conn.Open();
                    string query3 = "UPDATE CustomerM SET location = 'New York' WHERE First_Name = @fName AND Last_Name = @lName;";
                    SqlCommand command3 = new SqlCommand(query3, conn);
                    command3.Parameters.AddWithValue("@fName", firstName);
                    command3.Parameters.AddWithValue("@lName", lastName);
                    command3.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("\nLocation updated to New York");
                    break;
                case "3":
                    conn.Open();
                    string query4 = "UPDATE CustomerM SET location = 'Michigan' WHERE First_Name = @fName AND Last_Name = @lName;";
                    SqlCommand command4 = new SqlCommand(query4, conn);
                    command4.Parameters.AddWithValue("@fName", firstName);
                    command4.Parameters.AddWithValue("@lName", lastName);
                    command4.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("\nLocation updated to Michigan");
                    break;
                case "4":
                    conn.Open();
                    string query5 = "UPDATE CustomerM SET location = 'Kansas' WHERE First_Name = @fName AND Last_Name = @lName;";
                    SqlCommand command5 = new SqlCommand(query5, conn);
                    command5.Parameters.AddWithValue("@fName", firstName);
                    command5.Parameters.AddWithValue("@lName", lastName);
                    command5.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("\nLocation updated to Kansas");
                    break;
                default:
                    Console.WriteLine("That is not a valid location. Please try again.\n");
                    NewOrder(firstName, lastName);
                    break;
            }
        }

        public void DisplayStoreInventory(string location)
        {  
            Console.Clear();
            using SqlConnection conn = new(connection);
            conn.Open();
            string query = "SELECT * FROM Locations WHERE Location = @location;";
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@location", location);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Inventory_1 = reader.GetString(2);
                int quantity_1 = reader.GetInt32(3);
                string Inventory_2 = reader.GetString(4);
                int quantity_2 = reader.GetInt32(5);
                string Inventory_3 = reader.GetString(6);
                int quantity_3 = reader.GetInt32(7);

                Console.WriteLine("\nAt the " + location + " location, the following items are in inventory:");
                Console.WriteLine("\t" + Inventory_1 + "      " + quantity_1 + " left");
                Console.WriteLine("\t" + Inventory_2 + "   " + quantity_2 + " left");
                Console.WriteLine("\t" + Inventory_3 + "       " + quantity_3 + " left");
            }          
            conn.Close();

            Console.WriteLine("\nThis is the order history for the " + location + " location (if applicable) ");
            using SqlConnection conn2 = new(connection);
            conn2.Open();
            string query2 = "SELECT * FROM Orders2 WHERE Store_Location = @location;";
            using SqlCommand command2 = new SqlCommand(query2, conn2);
            command2.Parameters.AddWithValue("@location", location);
            using SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                int orderNumber = reader2.GetInt32(0);
                string storeLocation = reader2.GetString(4);
                string item_1 = reader2.GetString(5);
                int quantity_1 = reader2.GetInt32(6);
                string item_2 = reader2.GetString(7);
                int quantity_2 = reader2.GetInt32(8);
                string item_3 = reader2.GetString(9);
                int quantity_3 = reader2.GetInt32(10);
                DateTime time = reader2.GetDateTime(11);
                List<object> list = new List<object>();
                list.Add("Order Number: " + orderNumber);
                list.Add("Store Location: " + storeLocation);
                list.Add("Clocks Purchased: " + quantity_1);
                list.Add("Paintings Purchased: " + quantity_2);
                list.Add("Books Purchased: " + quantity_3);
                list.Add("Time of Purchase: " + time);

                foreach (var order in list)
                {
                    Console.WriteLine("\t" + order);
                    Console.WriteLine("\t ");
                }
            }           
            conn2.Close();
        }
    }
}