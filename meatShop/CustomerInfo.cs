using System;
using System.Collections.Generic;
using System.Text;
using meatShop.DataInfrastructure;
using meatShop.Logic;

namespace meatShop
{
    public class CustomerInfo
    {

        IRepository repo;

        public CustomerInfo(IRepository repo)
        {
            this.repo = repo;
        }

        public Customer GetCustomer(int ID)
        {
            return new Customer(ID, this.repo.GetCustomerFirstName(ID), this.repo.GetCustomerLastName(ID), 10, "Not Available");
        }

        public string IntroduceAllStores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*Introducing the Stores of the Butcher Terminal! *\n");
            IEnumerable<Store> Stores = repo.GetAllStores();
            foreach (Store store in Stores)
            {
                sb.AppendLine(store.Introduce());
            }
            return sb.ToString();
        }
    }
}
