using Store.Logic;
using Xunit;
using Moq;
using Store.DataInfrastructure;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Customer_CreateCustomer_ValidCustomer()
        {
            //Arrange
            int customerID = 1;
            string first_name = "Barry";
            string last_name = "Smith";
            string username = "bsmith";
            string password = "pass123";
            string location = "Atlanta";
            //Act
            Customer test = new Customer(1, "Barry", "Smith", "bsmith", "pass123", "Atlanta");
            //Assert
            Assert.Equal(customerID, test.GetCustomerID());
            Assert.Equal(first_name, test.GetFirstName());
            Assert.Equal(last_name, test.GetLastName());
            Assert.Equal(username, test.GetUsername());
            Assert.Equal(password, test.GetPassword());
            Assert.Equal(location, test.GetLocation());
        }

        [Fact]
        public void Customer_AddCustomerToDatabase_Success()
        {
            //Arrange
            Mock<IRepository> m_repo = new();
            //Act

            //Assert



        }

        [Fact]
        public void ConnectionString_TestValid_Success()
        {

        }

        [Fact]
        public void Account_CreateAccount_ValidAccount()
        {
            //Arrange
            Account account = new Account("Mark", "Walters");
            
            //Act
            string actual_1 = account.GetFirstName();
            string actual_2 = account.GetLastName();

            //Assert
            string expected_1 = "Mark";
            string expected_2 = "Walters";
            Assert.Equal(expected_1, actual_1);
            Assert.Equal(expected_2, actual_2);
        }

 






    }
}