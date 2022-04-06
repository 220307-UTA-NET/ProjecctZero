using Store.Logic;
using Xunit;

namespace Store.Test
{
    public class LogicTests
    {
        [Fact]
        public void Customer_CreateCustomerObject_ValidLastName()
        {
            //Arrange
            Customer test = new Customer("Steve", "Dave");
            //Act
            string actual = test.GetLastName();
            //Assert
            string expected = "Dave";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Customer_CreateCustomerObject_ValidFirstName()
        {
            //Arrange
            Customer test = new Customer("Steve", "Dave");
            //Act
            string actual = test.GetFirstName();
            //Assert
            string expected = "Steve";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Customer_CreateCustomerObject_ValidLocationID()
        {
            //Arrange
            Customer test = new Customer(3, "Steve", "Dave", 2);
            //Act
            int actual = test.GetLocation();
            //Assert
            int expected = 2;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Customer_CreatCustomerObject_ValidCustomerID()
        {
            //Arrange
            Customer test = new Customer(1, "Steve", "Dave");
            //Act
            int actual = test.GetCustID();
            //Assert
            int expected = 1;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreateOrderObject_ValidLocationID()
        {
            //Arrange
            Orders test = new Orders(4);
            //Act
            int actual = test.GetLocationID();
            //Assert
            int expected = 4;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreatOrderObject_ValidCustomerID()
        {
            //Arrange
            Orders test = new Orders(1,100,2,3,4);
            //Act
            int actual = test.GetCustomerID();
            //Assert
            int expected = 100;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreatOrderObject_ValidItemID()
        {
            //Arrange
            Orders test = new Orders(1, 100, 2, 3, 4);
            //Act
            int actual = test.GetOrderID();
            //Assert
            int expected = 4;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreatOrderObject_ValidQuantity()
        {
            //Arrange
            Orders test = new Orders(1, 100, 2, 3, 4);
            //Act
            int actual = test.GetQuantity();
            //Assert
            int expected = 3;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreatOrderObject_ValidOrderID()
        {
            //Arrange
            Orders test = new Orders(1, 100, 2, 3, 4);
            //Act
            int actual = test.GetOrderID();
            //Assert
            int expected = 4;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Orders_CreateOrderObject_ValidDateTime()
        {
            //Arrange
            Orders test = new Orders(5, 1, 100, System.DateTime.Now, 2, 3, 4);
            //Act
            int actual = test.GetOrderLine();
            //Assert
            var expected = 5;
            Assert.Equal(expected, actual);
        }

        //Orders(int locationID, int customerID, int itemID, int quantity, int orderID)


        /*[Fact]
        public void Store_GetID_ValidID()
        {
            //Arrange  //This "Mock" and "App." wouldn't recognize for me, couldn't find resources to help.
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetCustomerID("Frank", "Herbert")).Returns(13);
            var store = new App.Store(mockRepo.Object);
            //Act
            Customer test = store.GetCustomerID("Frank", "Herbert");
            int actual = test.GetCustID();
            //Assert
            int expected = 13;
            Assert.Equal(expected, actual);
        }*/
    }
}