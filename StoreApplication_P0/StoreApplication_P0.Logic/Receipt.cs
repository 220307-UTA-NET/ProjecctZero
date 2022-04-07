using System;
using System.Collections.Generic;
using System.IO;

namespace StoreApplication_P0.Logic
{
    public class Order
    {
        // Fields
        protected string storeLocation;
        protected DateTime OrderDate;
        protected decimal prices;
        protected decimal Total;
        protected int NoBostonCreamPie;
        protected int NoStrawberryShortcake;
        protected int NoChocolateCake;
        protected int NoTiramisu;
        protected int NoRedVelvet;
        protected int item;



        // Constructors
        public Order() { }
        //{
        //    //this.storeLocation = storeLocation;
        //    //this.customerId = customerId;
        //    this.orderNumber = orderNumber;
        //    //this.OrderDate = OrderDate;

        //    //this.item = item;
        //    ////this.prices = prices;
        //    //this.orderQuantity = orderQuantity;
        //    //this.Total = Total;
        //    //}

        //    //storeInventory = new Dictionary<item, price>();
        //}

        //    // Methods
        //    public string GetItem()
        //{ return this.item; }
        //public decimal GetOrderQnty()
        //{ return this.orderQuantity; }

        public int addBostonCreamPie(int num)
        {
            NoBostonCreamPie = num;
            return this.NoBostonCreamPie;
        }

        public int addChocolateCake(int num)
        {
            NoChocolateCake = num;
            return this.NoChocolateCake;
        }

        public int addStrawberryShortcake(int num)
        {
            NoStrawberryShortcake = num;
            return this.NoStrawberryShortcake;
        }


        public int addRedVelvet(int num)
        {
            NoRedVelvet = num;
            return this.NoRedVelvet;
        }

        public int addTiramisu(int num)
        {
            NoTiramisu = num;
            return this.NoTiramisu;
        }
        //public CalculateTotal()
        //{

        //};

        //public string StoreLocation { get; set; }
        //public void changeStoreInventory(string item, int orderQuantity)
        //{
        //    StoreInventory?.Add(item, orderQuantity);

        //}

    }
}

