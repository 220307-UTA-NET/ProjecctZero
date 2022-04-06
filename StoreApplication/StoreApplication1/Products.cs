using System;

namespace StoreApplication1
{
    class Products: Product
    {
        List<Product> productList = new List<Product>();
        public void AddProduct()
        {
                Console.WriteLine("Enter product ID ");
                int productId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product name ");
                string productName = Console.ReadLine();

                Console.WriteLine("Enter product catacgory ");
                string productCatagory = Console.ReadLine();
                  
                
                Product product = new Product(productId, productName, productCatagory);
                this.productList.Add(product);
        }
        public void dispalyProduct()

        {
               
               Console.WriteLine("P_ID |" + "P_Name|" + " P_catagory");
               //Console.WriteLine("____________________________________  ");
        
                foreach(Product item in this.productList)
                {
                Console.WriteLine(item.productId+ "      "+item.productName+ "      " +item.productCatagory);
                Console.WriteLine("                                            ");
          
                 }
        
         {

         }
     }
    
    }
}
