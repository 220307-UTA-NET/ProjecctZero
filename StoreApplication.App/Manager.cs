using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Generic;
using StoreApplication.Infrastructure;
using StoreApplication.Logic;

namespace StoreApplication.App
{
    public class Manager
    {
        // Fields
        InterfaceRepo repo;

        // Constructor
        public Manager(InterfaceRepo repo)
        {
            this.repo = repo;
        }

        public void addCustomer(string phoneNumber)
        {
            //Customer customer = new Customer("Jackie", "Jane", "240-550");
            var rand = new Random();

            Console.Write("Enter first name => ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name => ");
            string lname = Console.ReadLine();
            Console.Write("Enter the street number and name => ");
            string street = Console.ReadLine();
            Console.Write("Enter the zipcode of the customer => ");
            string zipcode = Console.ReadLine();
            Customer customer = new Customer(rand.Next(100, 501), fname, lname, phoneNumber, zipcode);
            this.repo.AddCustomer(customer);
        }

        public void placeOrder()
        {
       
        }

        public void searchCustomer()
        {
            Console.WriteLine("\nSearch a customer by name");
            Console.Write("Enter first name => ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name => ");
            string lname = Console.ReadLine();

            Customer customer = this.repo.GetCustomer(fname, lname);

            if (customer.GetCustomerID() == 0)
            {
                Console.WriteLine("\nThe customer does not exist");
            }
            else
            {
                string str = "";
                Console.WriteLine("\nThe customer information");
                str += customer.GetCustomerID() + "\t" + customer.GetFirstName() + "\t" + customer.GetLastName();
                str += "\t" + customer.GetPhoneNumber() + "\t" + customer.GetZipcode();
                Console.WriteLine(str);
            }
        }

        public void displayOrder()
        {
            //Order order = new Order();
            Console.WriteLine("\nDisplay details of an order");
            Console.Write("Enter a customer ID => ");
            int id = int.Parse(Console.ReadLine());
            Product product = this.repo.GetOrderDetails(id);
            Console.WriteLine(product.getProduct());
        }

        // display all order history of a customer
        public void displayOrder(string str1, string str2)
        {
            Console.WriteLine("\nDISPLAY ALL ORDER HISTORY OF A CUSTOMER");
            Console.Write("Enter the ID of a customer =>  ");
            int id = int.Parse(Console.ReadLine());

            IEnumerable<Orders> orders = this.repo.GetAllOrdersCust(id);
            bool isIn = true;
            string str;
            while (!orders.Any()) {
                Console.WriteLine("Invalid customer ID. Enter the ID of a customer");
                Console.WriteLine("You may Press [enter] to exit");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str)) { 
                    isIn = false; 
                    break; 
                }
                id = int.Parse(str);
                orders = this.repo.GetAllOrdersCust(id);
            }
            if (isIn == true)
            {
                foreach (Orders order in orders)
                {
                    Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                             + "\t" + order.GetLocation() + "\t" + order.GetTime());
                }
            }
        }


        // display all orders history of a store location
        public void displayOrder(string str1, string str2, string str3)
        {
            
            int[] opts = { 1, 2, 3, 4, 5 };
            Console.WriteLine("\nDISPLAY ALL ORDER HISTORY OF A STORE LOCATION");
           
            Console.WriteLine("\npress [1] to display of the store located at 12 Orchestra Terrace Germantown 99362");
            Console.WriteLine("press [2] to display of the store located at 89 Jefferson Way Portland 97201");
            Console.WriteLine("press [3] to display of the store located at 87 Polk St San Francisco 94117");
            Console.WriteLine("press [4] to display of the store located at 722 DaVinci Blvd Kirkland 98034");
            Console.WriteLine("press [5] to display of the store located at 50 Chiro Rd Portland 97219");

            Console.Write("Enter the name the store =>  ");
            int opt = int.Parse(Console.ReadLine());
            while (!Array.Exists(opts, x => x == opt))
            {
                Console.Write("Input error. Enter a valid input => ");
                opt = int.Parse(Console.ReadLine());
            }

            // Switch statement
            IEnumerable<Orders> orders;

            switch (opt)
            {
                case 1:
                    orders = this.repo.GetAllOrdersLoc("12 Orchestra Terrace Germantown 99362");
                    foreach (Orders order in orders)
                    {
                        Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                                 + "\t" + order.GetLocation() + "\t" + order.GetTime());
                    }
                    break;

                case 2:
                    orders = this.repo.GetAllOrdersLoc("89 Jefferson Way Portland 97201");
                    foreach (Orders order in orders)
                    {
                        Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                                 + "\t" + order.GetLocation() + "\t" + order.GetTime());
                    }
                    break;

                case 3:
                    orders = this.repo.GetAllOrdersLoc("87 Polk St San Francisco 94117");
                    foreach (Orders order in orders)
                    {
                        Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                                 + "\t" + order.GetLocation() + "\t" + order.GetTime());
                    }
                    break;

                case 4:
                    orders = this.repo.GetAllOrdersLoc("722 DaVinci Blvd Kirkland 98034");
                    foreach (Orders order in orders)
                    {
                        Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                                 + "\t" + order.GetLocation() + "\t" + order.GetTime());
                    }
                    break;

                case 5:
                    orders = this.repo.GetAllOrdersLoc("50 Chiro Rd Portland 97219");
                    foreach (Orders order in orders)
                    {
                        Console.WriteLine(order.GetOrderID() + "\t" + order.GetCustomerID() + "\t" + order.GetProductID()
                                 + "\t" + order.GetLocation() + "\t" + order.GetTime());
                    }
                    break;
            }    
        }

        public void displayAllProduct()
        {
            IEnumerable<Product> produList= this.repo.GetAllProducts();
            Console.WriteLine("Product ID \t Product type \t Product name \t Quantity \t Price\n");
            foreach (Product product in produList)
            {
                Console.WriteLine(product.GetProductID() + "\t" + product.GetProductType() + "\t" + product.GetProductName()
                     + "\t" + product.GetQuantity() + "\t" + product.GetCost());
            }
        }

        //public void displaySubOrder()
        //{
        //    Product product = new Product();
        //    string str = "";
        //    //str += 
        //}
    }
}