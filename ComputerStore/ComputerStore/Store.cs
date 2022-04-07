using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore
{
    public class Store
    {
        public List<Computer>  ComputerList { get; set; }
        public List<Computer> ShoppingList { get; set; }
        public List<Customer> CustomerList { get; set; }


        public Store()
        {
            ComputerList = new List<Computer>();
            ShoppingList = new List<Computer>();
            CustomerList = new List<Customer>();
        }

        public decimal CheckOut()
        {
            decimal totalCost = 0;
            foreach (var c in ShoppingList)
            {
                totalCost += c.ComputerPrice;
            }

            ShoppingList.Clear();
            return totalCost;
        }
    }
}
