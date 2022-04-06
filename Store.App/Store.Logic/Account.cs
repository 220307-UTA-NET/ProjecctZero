using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Logic
{
    public class Account
    {
        //IRepository repo;
        string firstname;
        string lastname;

        public Account()
        {

        }

        public Account(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string GetFirstName()
        {
            return firstname;
        }

        public string GetLastName()
        {
            return lastname;
        }













        //public Customer CustomerLogIn()
        //{
        //   Console.WriteLine("\nPlease sign in below: ");
        //  Console.Write("Username: ");
        //   string username = Console.ReadLine();
        ////  Console.Write("Password: ");
        //  string password = Console.ReadLine();

        //  List<Customer> customers = new();
        //  IRepository repo2 = new SQLRepo(db_connect);
        //  IEnumerable<Customer> customer = repo2.CustomerSearch(fname, lname);
        //}






    }
}



/*
 * 
 *  //IRepository repo4 = new SQLRepo(db_connect);
                        //IEnumerable<Customer> customerP = repo4.CustomerLogIn();
                        ////foreach (Customer customerO in customerP)
                        //{
                        ////    Console.WriteLine("\tCustomer " + customerO.GetUsername() + " " + customerO.GetLastName() + " was located " + count + " time. Returning to main menu");
                        //    Console.ReadKey();
                        //    Console.Clear();
                       // }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */