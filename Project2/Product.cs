﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Product
    {
        
        private int id;
        private string name;
        private double price;

        public int Id 
        { 
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        
        public Product()
        {
            
        }
        public Product(int id, string name,double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
