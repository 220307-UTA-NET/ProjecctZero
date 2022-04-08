using System;
using Store.Logic;
using Store.DataInfrastructure;


namespace StoreServices;

class Program
{

	static void Main(string[] args)
	{
		string connectionString = (@"Server=tcp:220307-rev-projects.database.windows.net,1433;Initial Catalog=RevProjects;Persist Security Info=False;User ID=Aure70;Password={RevRhino7070!!};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		IRepository repo = new SqlRepository(connectionString);


		Console.WriteLine("Welcome to Store Services!");

		while (true)
		{
			Console.WriteLine("Please choose Service: ");
			Console.WriteLine("[1] - Create A New Customer");
			Console.WriteLine("[2] - List Locations");
			Console.WriteLine("[3] - Check Store Order History");
			Console.WriteLine("[4] - Check Customer Order History");
			Console.WriteLine("[5] - Place An Order");
			Console.WriteLine("[0] - Exit");
			string userSelect = Console.ReadLine();

			switch (userSelect)
			{
				case "0":

					Console.WriteLine("[0] selected.");
					Console.WriteLine("Application Closing.");
					Console.ReadLine();
					Console.Clear();
					return;

				case "1":
					Console.WriteLine("[1] selected");
					string FirstName = Console.ReadLine();
					string LastName = Console.ReadLine();
					repo.CreateNewCustomer(FirstName, LastName);
					break;

				case "2":
					Console.WriteLine("[2] Selected.");
					IEnumerable<Location> allLocations = repo.GetAllLocations();

					foreach (Location newLocation in allLocations)
					{
						Console.WriteLine(newLocation.ListLocation());
					}
					Console.WriteLine("***pull locations from DB and print them here***");
					break;

				case "3":
					Console.WriteLine("[3] selected");
					Console.WriteLine("Enter store ID");
					break;

				case "4":
					Console.WriteLine("[4] selected");
					Console.WriteLine("Enter customer ID");
					break;

				case "5":
					Console.WriteLine("[1] selected.");
					Console.WriteLine("Enter customer ID: ");
					break;

				default:
					Console.WriteLine("Bad input: Input was not a valid option.");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					Console.Clear();
					break;
			}
		}

	}
}
	

