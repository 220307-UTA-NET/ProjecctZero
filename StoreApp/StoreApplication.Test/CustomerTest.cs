using System.Collections.Generic;
using StoreApplication.DataInfrustructure
using StoreApplication.Logic;
using StoreApplication;
using System;
using Xunit;
using Moq;


namespace StoreApplication.Test
{
    public class CustomerTest
    {
        [Fact]
        public void CreateCusomerObject_ValidCustomer()
        {
            //Arange
            Customer expected = new Customer("Bahar", "Farahani", 01, "Ghasroddash AVE");

            //Act

            Customer actual = new Customer("Bahar", "Farahani", 01, "Ghasroddash AVE");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void School_GetStudent_ValidStudent()
        {

            // arrange
            Mock<IRepository> mockRepo = new();

            // lamda expression syntax: like an anonymous classless method (delegate)
            // the Mock class sets up its inner object using these methods calls (Setup, Returns) **Reflection
            mockRepo.Setup(x => x.GetCustomertName(4)).Returns("");
            var school = new App.StoreApplication(mockRepo.Object);

            // act
            Customer test = StoreApplication.GetCustomer(4);
            string actual = test.GetName();

            // assert
            string expected = "";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StoreApplication_AllCustomers_FormattedString()
        {
            // arrange
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllCustomers()).Returns(System.Array.Empty<Customer>());
            var store = new App.School(mockRepo.Object);

            // act
            string actual = store.AllCustomers();

            // assert
            string expected = "********** Reporting all Customers of the Store! ********\n\r\n";
            Assert.Equal(expected, actual);
        }


    }


}












      

        
