using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabTask24
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Payment Payment { get; set; }
        public decimal CashBalance { get; set; }
        public decimal CardBalance { get; set; }

        public Customer(string name, string surname, decimal cashBalance, decimal cardBalance)
        {
            Name = name;
            Surname = surname;
            CashBalance = cashBalance;
            CardBalance = cardBalance;
        }


        //public void InBasket(Product[] products)
        //{
        //    Products = products;
        //}


        public Product[] InBasket(Product product)
        {
            Product[] Add(Product[] products, Product product)
            {
                Product[] newProducts = new Product[products.Length + 1];

                for (int i = 0; i < products.Length; i++)
                {
                    newProducts[i] = products[i];
                }

                newProducts[^1] = product;

                return newProducts;
            }

            Product[] products = new Product[0];
            return Add(products, product);
        }
    }
}
