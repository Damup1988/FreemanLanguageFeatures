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
            List<string> output = new List<string>();
            await foreach(long? len in MyAsyncMethods.GetPageLength(
                output,
                "apress.com",
                "microsoft.com",
                "amazon.com"))
            {
                output.Add($"Page length: {len}");
            }

            return View(output);
        }
    }
}