using System;
namespace StoreApplication.Logic
{
	public class Order
	{
		//Fields
		private int orderID;
		private int CustomerID;
		private DateTime orderTime;

		//List<Product> products;


		//Constructor
		public Order(){}

		public Order(int orderID, int CustomerID, DateTime orderTime)
		{
			this.orderID = orderID;
			this.CustomerID = CustomerID;
			this.orderTime = orderTime;	
		}


		//Methods

		public DateTime GetOderTime()
		{ return this.orderTime;}

		public int GetOrderID()
		{ return this.orderID; }

		public int GetCustomerID()
		{ return this.CustomerID;}


		internal List<Order> AllOrders = new List<Order>();

		protected void OrderHistory()
		{
			DateTime timeNow = DateTime.Now;
			string[] s = { };
			string path = @".\OrderHistory.txt";

		
		}

	}
}

