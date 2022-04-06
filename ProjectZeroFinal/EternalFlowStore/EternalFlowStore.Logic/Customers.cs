
using System.Text;

namespace EternalFlowStore.Logic
{
    public class Customers
    {
        // Fields
        private string FirstName;
        private string LastName;
        private string Address;
        private string City;
        private string StateProvinceArea;
        private string Country;
        private string PhoneNumber;
        private string Email;

        // Constructor 
        public Customers(string FirstName, string LastName, string Address, string City, string StateProvinceArea, string Country, string PhoneNumber, string Email)
        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.StateProvinceArea = StateProvinceArea;
            this.Country = Country;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }

        //Methods
        public string GetFirstName()
        { return this.FirstName; }
        public string GetLastName()
        { return this.LastName; }
        public string GetAddress()
        { return this.Address; }
        public string GetCity()
        { return this.City; }
        public string GetStateProvinceArea()
        { return this.StateProvinceArea; }
        public string GetCountry()
        { return this.Country; }
        public string GetPhoneNumber()
        { return this.PhoneNumber; }
        public string GetEmail()
        { return this.Email; }


        public void SetFirstName(string FirstName)
        { this.FirstName = FirstName; }
        public void SetLastName(string LastName)
        { this.LastName = LastName; }
        public void SetAddress(string Address)
        { this.Address = Address; }
        public void SetCity(string City)
        { this.City = City; }
        public void SetStateProvinceArea(string StateProvinceArea)
        { this.StateProvinceArea = StateProvinceArea; }
        public void SetPhoneNumber(string PhoneNumber)
        { this.PhoneNumber = PhoneNumber; }
        public void SetEmail(string Email)
        { this.Email = Email; }


       

    }
}