using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EternalFlowStore.Logic;

namespace EternalFlowStore.DataInfrastructure
{
    public interface IRepository
    {
        void NewCustomer(Customers newCustomer);

        bool CustomerVerification(Customers customerVerification);

        //List<Inventory> GetInventoryId(int Inventory_ID);

        //IEnumerable<StoreLocation> GetAllLocations();
        
        //public void OrderItems(int Order_ID, DateOnly DateOfOrder, TimeOnly TimeOfOrder, string LocationOfOrder, string CustomerName, string ItemsOrdered, int NumberOfItemsOrdered, string OrderDescription);

    }
}
