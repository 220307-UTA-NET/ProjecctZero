using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Logic;

namespace Store.DataInfrastructure
{
    public interface IRepository
    {
        void CreateNewCustomer(string fName, string lName);
        void CreateNewOrder(int locationID, int customerId, int itemID, int quantity, int orderID);
        void MakeNewCustomer(string fName, string lName, int storeId);
        int GetCustomerID(string firstName, string lastName);
        IEnumerable<Customer> GatherAllCustomers();
        IEnumerable<Customer> GatherOneCustomer(string fName, string lName);
        IEnumerable<Orders> GatherAllOrders();
        IEnumerable<Orders> GatherCustOrders(int custID);        
        IEnumerable<Orders> GatherLocOrders(int locationID);        
        IEnumerable<Orders> GatherIdOrders(int orderID);
    }
}
