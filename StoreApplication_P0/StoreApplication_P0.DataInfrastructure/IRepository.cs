using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApplication_P0.Logic;
using System.Data.SqlClient;


namespace StoreApplication_P0.DataInfrastructure
{
    public interface IRepository
    {
        //~~~~~~~~~~   Naming Convention   ~~~~~~~~~~
        //Access-Modifier Return-Type Method-Name (Parameter types/names)


        IEnumerable<CustomerAccount> GetAllCustomerAccounts();  // Full list of all customer account


        CustomerAccount CreateNewCustomerAccount(string UserName, string userPassword, string FirstName, string LastName, string Email, string DefaultStore);

        //public Receipt CreateReceiptList(string item, decimal prices);

        string findUsername(string UserName);

        //PlaceOrder CreateNewOrder(string Name);

        // Update quantity
        //void inventoryLeft(int orderQuantity);
        //public int FindCurrent(string item);






    }
}



