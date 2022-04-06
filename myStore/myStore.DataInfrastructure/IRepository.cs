using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myStore.Logic;

namespace myStore.DataInfrastructure
{
    public interface IRepository
    {
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Inventory> GetSanDiegoInventory();
        IEnumerable<Inventory> GetPhoenixInventory();
        IEnumerable<Inventory> GetSeattleInventory();
        public string displayOrder(int CustID, int storeID, int productID);
        public int CreateNewCustomer(Customer newCustomer);

    }
}
