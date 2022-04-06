using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace StoreApplication.Logic;

public class Customer
{
	//Fields
	private string? firstName;
	private string? lastName;
	private string? address;
	private int customerID;
	//default store location

	//Constructor
	public Customer() { }
	public Customer(string firstName, string lastName, int customerID, string address)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.customerID = customerID;
		this.address = address;
	}
	
	//Methods

	public string GetFirstName()
	{
		{ return this.firstName; }
	}

	public void SetFirstName(string firstName)
	{ this.firstName = firstName; }

	public string GetLastName()
	{ return this.lastName; }

	public void SetLastName(string lastName)
	{ this.lastName = lastName; }

	public int GetCustomerID()
	{ return this.customerID; }

	public void SetCustomerID(int customerID)
	{ this.customerID = customerID; }


	public string GetAddress()
	{ return this.address; }

	public void SetAddress(string address)
	{ this.address = address; }

	public string Introduce()
	{
		StringBuilder sb = new StringBuilder();
		sb.Append($"Hello, my name is {this.firstName},{this.lastName},and my ID is {this.customerID}, and my address is at {this.address}");
		return sb.ToString();
	}



	//public void PurchaseHistory (int CustomerID)
	//{
	//	Console.WriteLine("The customer with " + CustomerID + " has this purchase history:");
	//}

}

