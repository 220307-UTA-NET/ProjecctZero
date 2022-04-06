using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStore.Logic
{
    public class Location
    {
        // Fields
        int storeId;
        string storeAddr;
        string storeCity;


        //Constructor
        public Location() { }
        public Location( int ID, string Addr, string City)
        {
            this.storeId = ID;
            this.storeAddr = Addr;
            this.storeCity = City;
        }


        // Methods
        public int GetstoreId()
        { return this.storeId; }

        public string GetstoreAddr()
        { return this.storeAddr; }

        public string GetstoreCity()
        { return this.storeCity; }

        public string ListLocation()
        {
           StringBuilder sb = new StringBuilder();
           sb.Append($"[storeId]: {this.storeId}      [storeAddr]: {this.storeAddr}       [storeCity]: {this.storeCity}");
           return sb.ToString();
        }
    }
}
