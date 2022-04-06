using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalFlowStore.Logic
{
    public class StoreLocation
    {
        //Fields
        private int Location_ID;
        private string Location;
        private string Country;
        private string Address;
        private string StateProvinceArea;
        private string PhoneNumber;
        private string Email;

        //Constructor

        public StoreLocation(int Location_ID, string Location, string Country, string Address, string StateProvinceArea, string PhoneNumber, string Email)
        {
            this.Location_ID = Location_ID;
            this.Location = Location;
            this.Country = Country;
            this.Address = Address;
            this.StateProvinceArea = StateProvinceArea;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;

        }

        //Methods
        public int GetLocation_ID()
        { return this.Location_ID; }
        public string GetLocation()
        { return this.Location;  }
        public string GetCountry()
        { return this.Country; }
        public string GetAddress()
        { return this.Address; }
        public string GetStateProvinceArea()
        { return this.StateProvinceArea; }
        public string GetPhoneNumber()
        { return this.PhoneNumber; }
        public string GetEmail()
        { return this.Email; }

        public void SetAddress(string Address)
        { this.Address = Address; }
        public void SetStateProvinceArea(string StateProvinceArea)
        { this.StateProvinceArea = StateProvinceArea; }
        public void SetPhoneNumber(string PhoneNumber)
        { this.PhoneNumber = PhoneNumber; }


        public string Welcome()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello! Welcome to EternalFlow {this.Location}!");
            return sb.ToString();
        }


    }
}