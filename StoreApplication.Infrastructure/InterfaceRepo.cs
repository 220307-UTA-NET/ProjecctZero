using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApplication.Logic;

namespace StoreApplication.Infrastructure
{
    public interface InterfaceRepo
    {
        Customer GetCustomer(string fname, string lname);
        Product GetOrderDetails(int CustomerID);
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Orders> GetAllOrdersLoc(string Location);

        IEnumerable<Orders> GetAllOrdersCust(int CustomerID);  
        
        void AddCustomer(Customer customer);
        Orders AddOrders(Orders orders);
    }
}
