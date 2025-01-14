﻿namespace LabTask24
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


        public static Product[] InBasket(Product[] products, Product product)
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

            
            return Add(products, product);
        }
    }
}
