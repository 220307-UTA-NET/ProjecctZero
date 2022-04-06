using System;
using StoreApplication.Logic;

namespace StoreApplication.DataInfrsustructure
{
	public interface IRepository
	{
		IEnumerable<Customer> GetAllCustomers();


		public string GetCustomerName(int ID);
		public Customer AddNewCustomer(string firstName, string lastName, string address);
		//public List<Customer> GetAllCustomers();
		//public void PlaceOrderToStore(Order order, Location location);
		//public List<Customer> SearchCustomersByName(String name);
		//public Order GetOrderDetails(int id);
		//public List<Order> GetOrdersByStoreLocation(int id);
		//public List<Order> GetOrdersByCustomer(int id);


	}
}

