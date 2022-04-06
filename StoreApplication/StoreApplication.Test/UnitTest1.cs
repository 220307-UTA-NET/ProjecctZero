using System;
using Xunit;
using Xunit.Sdk;
using StoreApplication1;

namespace StoreApplication1.Test
{


public class StoreApplicationtest
{
//    [Fact] 
   //  public void TestCustomerID()
   //  {
   //      int expected = 22;

   //      var customer = new Customer();
   //      // int id = "22";

   //      //customer.customerId = "22";
                                             
   //     Assert.Equal( customer.customerId, expected);
   //  }

 


    [Fact]

    public void cstomerName()
    {
      var customer = new Customer(1, "test", "bruk");
            string expected = "bruk";
           int ExpectedID = 1;
           string Expected = "test" ;
        Assert.Equal( customer.getLastName(), expected);
        Assert.Equal (customer.getId(), ExpectedID);
        Assert.Equal (customer.getFirstName(), Expected);

    }
    // public void Ce()
    // // {
    // //   var customer = new Customer("test");
    // //         string expected = "testName";
    // //     Assert.Equal( customer.customerName, expected);

    // // }
}}