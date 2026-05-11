using Magaz.Enum;
using Magaz.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Magaz.Sklad
{
    public class OrderCalculator
    {
        public decimal Order(Product product, int quantity = 1)
        {
            decimal basePrice = product.Price * quantity;
            decimal discountPercent = CatyghoryTavar(product.Category);

            decimal discountAmount = basePrice * (discountPercent / 100m);
            return basePrice - discountAmount;
        }

        public decimal Order(IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (var p in products)
            {
                decimal price = p.Price;
                decimal discount = CatyghoryTavar(p.Category);
                total += price - (price * discount / 100);
            }
            return total;
        }

        public decimal CatyghoryTavar(Category category)
        {
            switch (category)
            {
                case Category.Game: return 30;
                case Category.Food: return 40;
                case Category.Fish: return 50;
                default: return 0;
            }
        }
    }
}