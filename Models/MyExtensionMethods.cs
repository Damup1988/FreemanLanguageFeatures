using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product product in products)
            {
                total += product?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimalPrice)
        {
            foreach (var prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimalPrice)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, char firstLetter)
        {
            foreach (var prod in productEnum)
            {
                if (prod?.Name[0] == firstLetter)
                {
                    yield return prod;
                }
            }
        }
    }
}