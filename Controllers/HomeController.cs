using System;
using System.Collections.Generic;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }
        
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
                new Product {Name = "Kayak100", Price = 300},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Cornet flag", Price = 34.50M}
            };
            Func<Product, bool> nameFilter = delegate(Product prod)
            {
                return prod?.Name?[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
            decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();
            
            return View("Index", new string[] {$"Total: {cartTotal:C2}",
                $"Array total: {priceFilterTotal:C2}",
                $"Array total where items start with S: {nameFilterTotal:C2}"
            });
        }
    }
}