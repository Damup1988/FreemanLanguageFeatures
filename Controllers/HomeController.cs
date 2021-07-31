using System.Collections.Generic;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // List<string> results = new List<string>();
            //
            // foreach (var p in Product.GetProducts())
            // {
            //     string name = p?.Name ?? "<No Name>";
            //     string category = p?.Category ?? "<None>";
            //     decimal? price = p?.Price ?? 0;
            //     string relatedName = p?.Related?.Name ?? "<None>";
            //     bool inStock = p?.InStock ?? false;
            //     results.Add(string.Format($"Name: {name}, Category: {category}, Price: {price}, Related: {relatedName}, InStock: {inStock}"));
            // }

            ShoppingCart cart = new ShoppingCart
            {
                Products = Product.GetProducts()
            };
            decimal cartTotal = cart.TotalPrices();

            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 120, Category = "Somecat"},
                new Product {Name = "Kayak100", Price = 300}
            };
            decimal arrayTotal = productArray.TotalPrices();
            
            return View("Index", new string[] {$"Total: {cartTotal:C2}", $"Array total: {arrayTotal:C2}"});
        }
    }
}