﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLanguageFeatures.Models
{
    public class Product
    {
        private int productID;
        private string name;
        private string description;
        private decimal price;
        private string category;
                
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}