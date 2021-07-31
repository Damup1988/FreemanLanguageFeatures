using System.Collections.Generic;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach (var p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                string category = p?.Category ?? "<None>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                bool inStock = p?.InStock ?? false;
                results.Add(string.Format($"Name: {name}, Category: {category}, Price: {price}, Related: {relatedName}, InStock: {inStock}"));
            }
            
            return View(results);
        }
    }
}