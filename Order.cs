using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication
{
 public class Order : Customer
  {
       
    //Constructor
    public Order(string date,string orderID,string firstname,string lastname,string phone,string product, string location, string amountspent)
           :base (firstname, lastname, phone)
        {
           DateTime = date;  
           OrderID = orderID;
           Product = product;
           Location = location;
           AmountSpent = amountspent;
        }  
         //Fields
   public string Location {get; set;}
   public string Product {get; set;}
   public string OrderID {get; set;} 
   public string AmountSpent {get; set;}

   public string DateTime {get; set;}
   
    //Methods
   // public override string ToString() =>
    //   $"Order {{ {this.OrderID} {this.FirstName} {this.LastName} {this.PhoneNumber} {this.Product} {this.Location} {this.AmountSpent}}}";
   
       public override string ToString()    
        {
        return
        String.Format(
         "date {0}\n OrderID {1}\n FirstName {2}\n LastName {3}\n" +
         "PhoneNumber {4}\n Product {5}\n Location {6}\n AmountSpent {7}", DateTime, OrderID, FirstName, LastName, PhoneNumber, 
         Product, Location, AmountSpent  );

        } 
   /* public void Record()//string CustomerRecords)
        {
           // DateTime Current = DateTime.Now;
            string[] content = {(Current.ToString("F"))  + "\t" + this.OrderID + "\t" + this.FirstName + "\t" + this.LastName + "\t" + this.PhoneNumber + "\t" + this.Product + "\t" + this.Location + "\t" + this.AmountSpent};
  
            string path = @".\CustomerRecords.txt";
           // Console.WriteLine(path);
            if(!File.Exists(path))
            {
                
                //create and write to new file 
                File.WriteAllLines(path, content);
                //File.Copy(path, content);
            }
            else 
            {
                // append the existing file    
             File.AppendAllLines(path, content);
            }
            foreach(string s in content)
            {
               // Console.WriteLine(s);
            }
        }
        public void Record1()//string CustomerRecords)
        {
            DateTime Current = DateTime.Now;
            string[] content = {this.OrderID + "\t" + this.FirstName + "\t" + this.LastName + "\t" + this.PhoneNumber + "\t" + this.Product + "\t" + this.Location + "\t" + this.AmountSpent};
  
            string path = @".\CustomerRecords2.txt";
           // Console.WriteLine(path);
            if(!File.Exists(path))
            {
                
                //create and write to new file 
                File.WriteAllLines(path, content);
                //File.Copy(path, content);
            }
            else 
            {
                // append the existing file    
             File.AppendAllLines(path, content);
            }
            foreach(string s in content)
            {
               // Console.WriteLine(s);
            }
        }
  */   
 }

}



