using System;

namespace StoreApplication
{
    class Product
    {
      public int productId;
      public string productName;
      public string productCatagory;

      public Product()
      {}

      public Product(int ProductId, string ProductNmae, string  ProductCatagory)
      {
        this.productId = ProductId;
        this.productName = ProductNmae;
        this.productCatagory = ProductCatagory;
      }

      
}


}