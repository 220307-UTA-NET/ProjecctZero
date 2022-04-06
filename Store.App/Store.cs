using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DataInfrastructure;
using Store.Logic;

namespace Store.App
{
    internal class Store
    {
        //Fields
        IRepository repo;

        //Constructor
        public Store(IRepository repo)
        {
            this.repo = repo;
        }

        //Methods
        public Customer GetCustomerID(string fName, string lName)
        {
            return new Customer(this.repo.GetCustomerID(fName,lName), fName, lName);
        }

    }
}
