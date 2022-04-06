namespace Store.Logic
{
    public class Customer
    {
        string orderNumber;
        int customerID;
        string firstName;
        string lastName;
        string location;
        string username;
        string password;
        private string storeLocation;
        string item;
        int quantity;
        DateTime time;

        public Customer()
        {

        }

        public Customer(string orderNumber, string fName, string lName, string storeLocation, string item, int quanity, DateTime time)
        {
            this.orderNumber = orderNumber;
            this.firstName = fName;
            this.lastName = lName;
            this.storeLocation = storeLocation;
            this.item = item;
            this.quantity = quanity;
            this.time = time;
        }

        public Customer(string firstName, string lastName) //New customers
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Customer(int customerID, string firstName, string lastName)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Customer(int customerID, string firstName, string lastName, string storeLocation, string item, int quantity, DateTime time) : this(customerID, firstName, lastName)
        {
            this.storeLocation = storeLocation;
            this.item = item;
            this.quantity = quantity;
            this.time = time;
        }

        public Customer(int customerID, string firstName, string lastName, string v1, string v2, string v3) : this(customerID, firstName, lastName) //**************
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = v1;
            this.password = v2;
            this.location = v3;

        }

        public int GetCustomerID()
        {
            return this.customerID;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public string GetPassword()
        {
            return this.password;
        }

        //--------
        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetLocation(string location)
        {
            this.location = location;
        }

        public string GetLocation()
        {
            return this.location;
        }


      


    }
}