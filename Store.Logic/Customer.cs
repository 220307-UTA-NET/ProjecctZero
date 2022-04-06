using System.Text;

namespace Store.Logic
{
    public class Customer
    {
        //Fields
        private int custID;
        private string fName;
        private string lName;
        private int locationCode;

        //Constructor
        public Customer() { }
        public Customer(string fName, string lName)
        {
            this.fName = fName;
            this.lName = lName;
        }
        public Customer(int custID, string fName, string lName)
        {
            this.custID = custID;
            this.fName = fName;
            this.lName = lName;
        }
            public Customer(int custID, string fName, string lName, int locationCode)
        {
            this.custID = custID;
            this.fName = fName;
            this.lName = lName;
            this.locationCode = locationCode;
        }

        //Methods
        public int GetCustID() { return this.custID; }
        public string GetFirstName() { return this.fName; }
        public string GetLastName() { return this.lName; }
        public int GetLocation() { return this.locationCode; }
        public void SetName(string fName) { this.fName = fName; }
        public void SetLastName(string lName) { this.lName = lName; }
        public void SetLocation(int newLocation) { this.locationCode = newLocation; }

        public string GiveDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The customer {this.fName} {this.lName} has the Id#{this.custID} and Location Id#{this.locationCode}.");
            return sb.ToString();
        }
        public string GiveCTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.custID}            {this.fName}          {this.lName}        {this.locationCode}");
            return sb.ToString();
        }


    }
}