using System;
using System.Data;
using System.Data.SqlClient;
using StoreApplication.DataInfrsustructure;
using StoreApplication.Logic;


namespace StoreApplication
{
    class Program
    {
        static void Main()
        {
            string connectionString = File.ReadAllText(@"conn.txt");

            IRepository repo = new SqlRepository(connectionString);

            List<Customer> customerList = new List<Customer>();


            //string str = @"conn.txt";
            //ReadOrderData(str);
            Console.WriteLine("\n");
            Console.WriteLine("Welcome to MyOnlineStore! We have the following Departments:");
            Console.WriteLine("1:Produce, 2:Meat & Seafood, 3:Deli, 4:Bakery, 5:Dairy & Eggs ");
            Console.WriteLine("\n");

            Console.WriteLine("--Add Customer--");
            string firstName = Prompt("First Name");
            string lastName = Prompt("Last Name");
            string address = Prompt("Address");
            Customer c = repo.AddNewCustomer(firstName, lastName, address);
            //Console.WriteLine("Customer ID:" + c.GetCustomerID());
            Console.WriteLine(c.Introduce());

            //while (true)
            //{
            //    Console.WriteLine("Enter 1 to add a customer");
            //    Console.WriteLine("Enter 2 to list customers");
            //    Console.WriteLine("exit - quit the program");
            //    string input = Console.ReadLine();

            //    if ("1".Equals(input))
            //    {
            //        Console.WriteLine("--Add Customer--");
            //        string firstName = Prompt("First Name");
            //        string lastName = Prompt("Last Name");
            //        string address = Prompt("Address");
            //        Customer c = repo.AddNewCustomer(firstName, lastName, address);
            //        Console.WriteLine(c.Introduce());
            //    }
            //    if ("2".Equals(input))
            //    {
            //        Console.WriteLine("--CUSTOMERS--");
            //        foreach (Customer c in repo.GetAllCustomers())
            //        {
            //            Console.WriteLine(c.GetFirstName());
            //        }
            //    }
            //    if ("exit".Equals(input))
            //    {
            //        break;
            //    }
            //    Console.WriteLine();
            //}



        }

        public static SqlConnection ConnectToSql()
        {
            string connectionString = File.ReadAllText(@"conn.txt");
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                Connection.Open();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            return Connection;
        }

        public static void addNewCustomer(Customer customer)
        {
            string connectionString = File.ReadAllText(@"conn.txt");
            SqlConnection connection = new SqlConnection(connectionString);
        }


        public static string Prompt(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }

    }


}


