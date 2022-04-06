using System;
namespace StoreApplication.Logic
{
	//Location is the store
	public class Location
	{
		//Fields
		private int inventory;
		private int LocationID;
		
		
		//Cunstructor
		public Location(){}

		public Location(int inventory)
        {
			this.inventory = inventory;
        }

		public Location(int LocationID, int Inventory )
        {
			this.LocationID = LocationID;
			this.inventory = Inventory;
        }

		//Methods

		//update inventory


		//reject orders that can not be fulfield with the remaining inventory


	}
}

