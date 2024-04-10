namespace LabTask24
{
    internal class Market
    {
        public Product[] Products { get; set; }


        public Market(params Product[] products)
        {
            Products = products;
        }


        public void Kassa(Customer customer)
        {
            //написано для одного продукта исправить на несколько, исправить чтобы можно было вводить нужный продукт через консоль,
            //добавить интерактивный вывод информации
            while (true)
            {
                contin:
                Product[] productsList = new Product[0];

                while (true)
                {
                    Console.WriteLine("Available products:");
                    foreach (var c in Products)
                    { Console.Write($"{c.Name}\t"); }

                    Console.WriteLine("\nProducts in your basket:");
                    foreach (var item in productsList)
                    { Console.Write($"{item.Name}\t"); }

                    label0:
                    Console.WriteLine("\nChoose the product");
                    string product = Console.ReadLine();
                    if (product == null)
                        goto label0;
                    
                    foreach (var c in Products)
                    {
                        if (c.Name.ToLower() == product.ToLower())
                        {
                            productsList = Customer.InBasket(productsList ,c);
                            Console.WriteLine("Product added");
                            int count = 0;
                            foreach (var c2 in productsList)
                            {
                                if (c2.Name.ToLower() == product.ToLower())
                                    count++;
                            }

                            if (count > c.AvailableCount)
                            {
                                if (count > c.InStockCount + c.AvailableCount)
                                {
                                    goto contin;
                                }
                            }
                            break;
                        }
                    }

                    label4:
                    Console.WriteLine("\nWant to add more products? \"Yes\" or \"No\"");
                    string exitCheck = Console.ReadLine();
                    if (exitCheck == null)
                        goto label4;
                    else if (exitCheck.ToLower() == "yes")
                        continue;
                    else if (exitCheck.ToLower() == "no")
                        break;
                    else
                        goto label4;
                }

                Console.WriteLine("Products in your basket:");
                foreach (var item in productsList)
                { Console.Write($"{item.Name}\t"); }


            label1:
                Console.WriteLine("\nWant to buy : \"Yes\" or \"No\"");
                string buyOrNot = Console.ReadLine();

                if (buyOrNot.ToLower() == "no")
                    continue;
                else if (buyOrNot.ToLower() != "yes" && buyOrNot.ToLower() != "no")
                    goto label1;


                label2:
                Console.WriteLine($"\nYour cash balance = {customer.CashBalance}");
                Console.WriteLine($"Your credit card balance = {customer.CardBalance}");
                Console.WriteLine("\nSelect payment method: \"Cash\" or \"Credit card\"");
                string paymentMethod = Console.ReadLine();
                if (paymentMethod == null)
                    goto label2;

                decimal basketPrice = 0;
                foreach (var item in productsList)
                {
                    basketPrice += item.Price;
                }


                switch (paymentMethod.ToLower())
                {
                    case "cash":
                        if (basketPrice > customer.CashBalance)
                        {
                            Console.WriteLine("Not enough money");
                            goto label2;
                        }
                        else
                        {
                            customer.CashBalance -= basketPrice;
                            Console.WriteLine($"Your new cash balance = {customer.CashBalance}");
                        }
                            break;
                    case "credit card":
                        if (basketPrice > customer.CardBalance)
                        {
                            Console.WriteLine("Not enough money");
                            goto label2;
                        }
                        else
                        {
                            customer.CardBalance -= basketPrice;
                            Console.WriteLine($"Your new credit card balance = {customer.CardBalance}");
                        }
                            break;
                    default:
                        goto label2;
                }
                Console.WriteLine("Purchase completed successfully");


            label3:
                Console.WriteLine("\nWant to exit market: \"Yes\" or \"No\" ?");
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
