using ComputerStore;
using System;


namespace ComputerStore
{
    public class Computer
    {
        public int Id { get; set; }
        public string ComputerMake { get; set; }
        public string ComputerGeneration { get; set; }
        public string ComputerType { get; set; }    
        public decimal ComputerPrice { get; set; }

        public Computer()
        {
            this.ComputerMake = "DELL";
            this.ComputerGeneration = "Third Generation";
            this.ComputerType = "Laptop/Desktop";
            this.ComputerPrice = 100.00M;
        }

        public Computer(string Make, string Generation, string Type, decimal Price)
        {
            this.ComputerMake= Make;
            this.ComputerGeneration= Generation;
            this.ComputerType = Type;
            this.ComputerPrice = Price;
        }

        override public string ToString()
        {
            return "ComputerMake: " + this.ComputerMake + "|| ComputerGeneration: " + this.ComputerGeneration + "|| ComputerType: " + this.ComputerType + "|| Computer Price: $" + this.ComputerPrice;
        }
    }
}