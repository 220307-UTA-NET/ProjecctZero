
using System.Text;

namespace EternalFlowStore.Logic
{
    public class Customers
    {
        // Fields
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string stateProvinceArea;
        private string country;
        private string phoneNumber;
        private string email;

        // Constructor 
        public Customers(string A, string B, string C, string D, string E, string F, string H, string I)
        {
            this.firstName = A;
            this.lastName = B;
            this.address = C;
            this.city = D;
            this.stateProvinceArea = E;
            this.country = F;
            this.phoneNumber = H;
            this.email = I;

        }
        public Customers(string A, string B)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //Methods
        public string GetFirstName()
        { return this.firstName; }
        public string GetLastName()
        { return this.lastName; }
        public string GetAddress()
        { return this.address; }
        public string GetCity()
        { return this.city; }
        public string GetStateProvinceArea()
        { return this.stateProvinceArea; }
        public string GetCountry()
        { return this.country; }
        public string GetPhoneNumber()
        { return this.phoneNumber; }
        public string GetEmail()
        { return this.email; }


        public void SetFirstName(string firstName)
        { this.firstName = firstName; }
        public void SetLastName(string lastName)
        { this.lastName = lastName; }
        public void SetAddress(string address)
        { this.address = address; }
        public void SetCity(string city)
        { this.city = city; }
        public void SetStateProvinceArea(string stateProvinceArea)
        { this.stateProvinceArea = stateProvinceArea; }
        public void SetPhoneNumber(string phoneNumber)
        { this.phoneNumber = phoneNumber; }
        public void SetEmail(string email)
        { this.email = email; }


       

    }
}