using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using StoreApplication.Logic;

namespace StoreApplication.DataInfrastructure
{
        //repository design pattern : implement basic CRUD operations
        //                              CRUD - create, read, update, delete
        //operations that the rest of the app may need, but we can abstract the implementation details.
        //advantage: it makes the rest of the program more unit-testable
    public interface IRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Orders> GetAllOrders();
        IEnumerable<StoreLocation> GetAllStores();

        Customer CreateNewCustomer(string Name, string LName, string DStore);
        Orders CreateNewOrder(string product, int quantity, string customer, string storelocation);
    }
}
