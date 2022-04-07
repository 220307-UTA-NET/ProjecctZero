using System;
using System.Text;


namespace meatShop.Logic
{
    public class Customer
    {

        //Fields
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        int HistoryId { get; set; }

        string PrimaryStore { get; set; }



        //Constructor

        public Customer() { }

        public Customer(int Id, string FirstName, string LastName, int HistoryID, string PrimaryStore)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.HistoryId = HistoryID;
            this.PrimaryStore = PrimaryStore;


        }

        //Methods



        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my name is {this.FirstName} {this.LastName} , and I am Customer {this.Id}, my primary store is {this.PrimaryStore}");
            return sb.ToString();
        }



    }
}

