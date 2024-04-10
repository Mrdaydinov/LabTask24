using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask24
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public int InStockCount { get; set; }

        public Product(string name, decimal price, int availableCount, int inStockCount)
        {
            Name = name;
            Price = price;
            AvailableCount = availableCount;
            InStockCount = inStockCount;
        }
    }
}
