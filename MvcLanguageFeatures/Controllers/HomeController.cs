using MvcLanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                Products = new List<Product>()
                {
                    new Product { Name="Kayak", Price=275M },
                    new Product { Name="Lifejacket", Price=48.95M },
                    new Product { Name="Soccer Ball", Price=19.50M },
                    new Product { Name="Corner Flag", Price=39.95M },
                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart()
            {
                Products = new List<Product>
                {
                    new Product { Name = "Kayak", Price=275M },
                    new Product { Name = "Lifejacket", Price=48.95M },
                    new Product { Name = "Soccer ball", Price=19.50M },
                    new Product { Name = "Corner flag", Price=34.95M }
                }
            };

            Product[] productArray =
            {
                new Product { Name = "Kayak", Price=275M },
                new Product { Name = "Lifejacket", Price=48.95M },
                new Product { Name = "Soccer ball", Price=19.50M },
                new Product { Name = "Corner flag", Price=34.95M }
            };

            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result", (object)String.Format("Cart Total: {0}, Array Total: {1}", cartTotal, arrayTotal));
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                { "apple", 10 }, { "orange", 20 }, { "plum", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product();

            myProduct.ProductID = 100;
            myProduct.Name = "Kayak";
            myProduct.Description = "A boat for one person";
            myProduct.Price = 275M;
            myProduct.Category = "Watersports";

            return View("Result", (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Soccer"))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }
    }
}