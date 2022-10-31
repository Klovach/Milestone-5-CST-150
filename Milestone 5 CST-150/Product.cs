using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_5_CST_150
{
    internal class Product
    {
        //Declare variables
        private string name;
        private double price;
        private int quantity;

        //Product Constructor 
        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }


        //Getters and Setters 
        public string Name
        {
            get => name;
            set => name = value;
        }
        public double Price
        {
            get => price;
            set => price = value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        /* This method calculate the total value of a product in stock.*/
        public double TotalPrice
        {
            get => this.quantity * this.price;
            set => TotalPrice = value;
        }


        // Override ToString() 
        public override string ToString()
        {
            return "Product Name: " + name + "\n Unit Price: " + price + "\n Quantity: " + quantity;
        }
    }
}
