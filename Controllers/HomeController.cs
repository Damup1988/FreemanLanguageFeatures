using System;
using System.Collections.Generic;
using System.Linq;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));
        public ViewResult Index()
        {
            IProductSelection cart = new ShoppingCart(
                new Product {Name = "Kayak", Price = 120M},
                new Product {Name = "Lifejacket", Price = 50.50M},
                new Product {Name = "Soccer ball", Price = 30.50M},
                new Product {Name = "Corner flag", Price = 100M}
            );
            return View(cart.Names);
        }
    }
}