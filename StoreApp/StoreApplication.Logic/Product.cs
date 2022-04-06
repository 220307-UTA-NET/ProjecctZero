using System;
namespace StoreApplication.Logic
{
	public class Product
	{
		//Fields

		private int productID;
		private double price;
		string productName;
		private int numberOfItems;
		


		//Constructor

		public Product() { }

		public Product(int productID, double price, int numberOfItems, string productName)
		{
			this.productID = productID;
			this.price = price;
			this.numberOfItems = numberOfItems;
			this.productName = productName;
		}

		//methods

		public int ProductID
		{
			get{return productID;}
			set{productID = value;}
		}


		public string Name
		{
			get
			{return productName;}
			set{productName = value;}
		}


		public double Price
		{
			get{return price;}
			set
			{price = value;}
		}


		public int NumberOfItems
		{
			get
			{return numberOfItems;}
			set
			{numberOfItems = value;}
		}


	}
}

