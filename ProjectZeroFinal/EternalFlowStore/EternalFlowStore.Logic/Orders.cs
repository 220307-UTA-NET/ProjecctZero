using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalFlowStore.Logic
{
    public class Orders
    {
        // Fields
        private int Order_ID;
        private DateOnly DateOfOrder;
        private TimeOnly TimeOfOrder;
        private string LocationOfOrder;
        private string CustomerName;
        private string ItemsOrdered;
        private int NumberOfItemsOrdered;
        private string OrderDescription;


        //Constructor
        public Orders(int Order_ID, DateOnly DateOfOrder, TimeOnly TimeOfOrder, string LocationOfOrder, string CustomerName, string ItemsOrdered, int NumberOfItemsOrdered, string OrderDescription)
        {
            this.Order_ID = Order_ID;
            this.DateOfOrder = DateOfOrder;
            this.TimeOfOrder = TimeOfOrder;
            this.LocationOfOrder = LocationOfOrder;
            this.CustomerName = CustomerName;
            this.ItemsOrdered = ItemsOrdered;
            this.NumberOfItemsOrdered = NumberOfItemsOrdered;
            this.OrderDescription = OrderDescription;

        }

        // Methods
        public int GetOrder_ID()
        { return this.Order_ID; }
        public DateOnly GetDateOfOrder()
        { return this.DateOfOrder; }
        public TimeOnly GetTimeOfOrder()
        { return this.TimeOfOrder; }
        public string GetLocationOfOrder()
        { return this.LocationOfOrder; }
        public string GetCustomerName()
        { return this.CustomerName; }
        public string GetItemsOrdered()
        { return this.ItemsOrdered; }
        public int GetNumberOfItemsOrdered()
        { return this.NumberOfItemsOrdered; }
        public string GetOrderDescription()
        { return this.OrderDescription; }

        public void SetLocationOfOrder(string LocationOfOrder)
        { this.LocationOfOrder = LocationOfOrder; }
        public void SetItemsOrdered(string ItemsOrdered)
        { this.ItemsOrdered = ItemsOrdered; }
        public void SetNumberOfItemsOrdered(int NumberOfItemsOrdered)
        { this.NumberOfItemsOrdered = NumberOfItemsOrdered; }


    }
}
