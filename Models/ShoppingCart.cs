using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IProductSelection
    {
        private readonly List<Product> _products = new List<Product>();

        public ShoppingCart(params Product[] prods)
        {
            _products.AddRange(prods);
        }
        
        public IEnumerable<Product> Products
        {
            get => _products;
        }
    }
}