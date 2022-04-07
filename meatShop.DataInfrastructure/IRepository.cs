using System;
using System.Collections.Generic;
using System.Text;
using meatShop.Logic;

namespace meatShop.DataInfrastructure
{
    public interface IRepository
    {


        ///<params>
        ///CRUD is going here
        ///</params>
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Store> GetAllStores();
        IEnumerable<UltimateWarrior> GetAllOrders();

        Customer CreateNewCustomer(string FirstName, string LastName, int HistoryId, string PrimaryStore);
        Order CreateNewOrder(int OrderId, int StoreId, int CustomerId, string OrderPlaced, string ProductName, int ProductAmount, int ItemListId);
        string GetCustomerFirstName(int ID);
        string GetCustomerLastName(int ID);
       
    }
}
