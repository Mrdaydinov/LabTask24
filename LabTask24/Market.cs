using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LabTask24
{
    internal class Market
    {
        public Product[] Products { get; set; }

        public void Kassa(Customer customer, Product product)
        {
            //написано для одного продукта исправить на несколько, исправить чтобы можно было вводить нужный продукт через консоль,
            //не добавлена проверка баланса при покупке, добавить интерактивный вывод информации
            while (true)
            {
                Products = customer.InBasket(product);
                if (Products.Length > product.AvailableCount)
                {
                    if (Products.Length > product.InStockCount + product.AvailableCount)
                    {
                        continue;
                    }
                }

            label1:
                Console.WriteLine("Want to buy : \"Yes\" or \"No\"");
                string buyOrNot = Console.ReadLine();

                if (buyOrNot.ToLower() == "no")
                    continue;
                else if (buyOrNot.ToLower() != "yes" && buyOrNot.ToLower() != "no")
                    goto label1;

                
            label2:
                Console.WriteLine("Select payment method: \"Cash\" or \"Credit card\"");
                string paymentMethod = Console.ReadLine();
                if (paymentMethod == null)
                    goto label2;

                decimal basketPrice = 0;
                foreach (var item in Products)
                {
                    basketPrice += item.Price;
                }


                switch (paymentMethod.ToLower())
                {
                    case "cash":
                        customer.CashBalance -= basketPrice;
                        break;
                    case "credit card":
                        customer.CardBalance -= basketPrice;
                        break;
                    default:
                        goto label2;
                }

                label3:
                Console.WriteLine("Want to exit market: \"Yes\" or \"No\" ?");
                string exitBool = Console.ReadLine();
                if (exitBool == null)
                    goto label3;
                else if (exitBool.ToLower() == "yes")
                    Environment.Exit(0);
                else if (exitBool.ToLower() == "no")
                    continue;
                else
                    goto label3;
            }
        }
    }
}
