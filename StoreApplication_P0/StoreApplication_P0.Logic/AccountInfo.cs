using System;
using System.Collections.Generic;  //accountinfor
using System.IO;

namespace StoreApplication_P0.Logic
{
    public class AccountInfo
    {
        // Fields
        protected string firstName;
        protected string lastName;
        protected string DOB;
        protected string email;
        protected string username;
        protected string password;
        protected string default_location;


        // Methods
        protected void setfirstName(string firstNameParam)
        { this.firstName = firstNameParam; }

        public string getfirstName()
        { return this.firstName; }
        public string getUsername()
        { return this.username; }

        protected void setlastName(string lastNameParam)
        { this.lastName = lastNameParam; }

        public string getlastName()
        { return this.lastName; }

        protected void setemail(string emailParam)
        { this.email = emailParam; }

        protected void setUserName(string UserNameParam)
        { this.username = UserNameParam; }


        protected void setPassword(string passwordParam)
        { this.password = passwordParam; }

        protected void setDOB(int month, int day, int year)
        {
            string birthday = month + "-" + day + "-" + year;
            this.DOB = birthday;
        }
    }
}
