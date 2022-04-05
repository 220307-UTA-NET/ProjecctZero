using System;

namespace StoreApplication
{
    class Locations: Location
    {
        List<Location> locationList = new List<Location>();

        // Console.WriteLine("Chose your store location\n 1 - DC store\n 2 - maryland store");
        
        public void AddLocation()
        {
             
           while(true)
           {
            try
            {
            Console.WriteLine("Enter location Id ");
            int lId = int.Parse(Console.ReadLine());
             
           

            Console.WriteLine("Enter location location name");
            string lName = Console.ReadLine();

            Console.WriteLine("Enter location details ");
            string detail = Console.ReadLine();

            
            
                  
                  this.setLocationId(lId);
                  this.setLocationName(lName);
                  this.setDetail(detail);
              
                  
            Location location = new Location(lId,lName, detail);
            this.locationList.Add(location);
             }
            catch(Exception e)
            {
                Console.WriteLine("Invalid entry ");
            }
        }
        }
        public void DisplayLocation()
        {
            
            
                Console.WriteLine("L_ID " + "L_Name " + "Details");

                foreach(Location item in this.locationList)
                {
                Console.WriteLine(item.getLocationId()+ "      "+item.getLocationName()+ "     " +item.getDetail());
          
         }  
        }
        //display}
}
}
