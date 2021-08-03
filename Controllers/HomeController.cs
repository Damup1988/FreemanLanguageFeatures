using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));
        public async Task<ViewResult> Index()
        {
            var products = new[]
            {
                new {Name = "Kayak", Price = 150M},
                new {Name = "Lifejacket", Price = 200M},
                new {Name = "Soccer ball", Price = 50.50M},
                new {Name = "Corner glaf", Price = 10M}
            };
            return View(products.Select(p => 
                $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}