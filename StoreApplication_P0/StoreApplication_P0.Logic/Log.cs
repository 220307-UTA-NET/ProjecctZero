using System;
using System.Collections.Generic;
using System.IO;

namespace StoreApplication_P0.App
{
    public class Log
    {
        protected string item;
        protected decimal price;
        protected DateTime OrderDate;

        public Log() { }
        public Log(string item, decimal prices)
        {
            this.item = item;
            this.price = prices;
        }
    }
}