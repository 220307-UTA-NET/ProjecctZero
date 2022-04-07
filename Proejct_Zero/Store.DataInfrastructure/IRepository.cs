using Store.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataInfrastructure
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAllCustomers(); 

        Customer CreateNewCustomer(string FirstName, string LastName);

        string GetCustomer(int ID);
    }
}
