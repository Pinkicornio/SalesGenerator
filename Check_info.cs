using System;
using System.Collections.Generic;
using System.Text;

namespace SalesGenerator
{
    class Check_info
    {
        string name;
        string brand;
        float price;
        int amount;
        int market_stock;
        int id;
        DateTime date;



        public Check_info(string name, int id, int amount, float price, string brand, DateTime date, int market_stock)
        {
            this.name = name;
            this.id = id;
            this.amount = amount;
            this.price = price;
            this.brand = brand;
            this.date = date;
            this.market_stock = market_stock;
        }

        public Check_info()
        {

        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public float Price { get => price; set => price = value; }
        public string Brand { get => brand; set => brand = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Market_stock { get => market_stock; set => market_stock = value; }
    }
}
