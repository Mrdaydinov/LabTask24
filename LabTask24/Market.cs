using System.Runtime.CompilerServices;

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
            Console.WriteLine("Welcome " + customer.Name + "\n");
            while (true)
            {
                Product[] productsList = new Product[0];

                while (true)
                {
                contin:
                    Console.WriteLine("AVAILABLE PRODUCTS:");
                    foreach (var c in Products)
                    { Console.Write($"Name: {c.Name}\t, Price: {c.Price}, Available count: {c.AvailableCount}, In stock count:{c.InStockCount}\n"); }

                    Console.WriteLine("\nPRODUCTS IN YOUR BASKET:");
                    foreach (var item in productsList)
                    { Console.Write($"{item.Name}\t"); }

                label0:
                    Console.WriteLine("\n***************************************************");

                    Console.WriteLine("\nChoose the product (or write \"n\" if you dont want to buy)");
                    string product = Console.ReadLine();
                    if (product == null)
                        goto label0;
                    else if (product.ToLower() == "n")
                        goto label1;

                    bool notFound = true;
                    foreach (var c in Products)
                    {
                        if (c.Name.ToLower() == product.ToLower())
                        {
                            notFound = false;

                            if (c.AvailableCount > 0)
                            {
                                c.AvailableCount -= 1;
                                productsList = Customer.InBasket(productsList, c);
                                Console.WriteLine("\n\tProduct added");
                            }
                            else if (c.AvailableCount + c.InStockCount > 0)
                            {
                                c.InStockCount -= 1;
                                productsList = Customer.InBasket(productsList, c);
                                Console.WriteLine("\n\tProduct added");
                            }
                            else
                            {
                                Console.WriteLine("Not enough count");
                                Console.WriteLine("\n");
                                goto contin;
                            }

                            break;
                        }
                    }
                    if (notFound)
                    {
                        Console.WriteLine("Wrong product name");
                        goto label0;
                    }

                label4:
                    Console.WriteLine("\n***************************************************");
                    Console.WriteLine("\nWant to add more products? \"Yes\" or \"No\"");
                    string exitCheck = Console.ReadLine();

                    if (exitCheck.ToLower() == "yes" || exitCheck.ToLower() == "y")
                    {
                        Console.WriteLine("\n");
                        continue;
                    }
                    else if (exitCheck.ToLower() == "no" || exitCheck.ToLower() == "n")
                    {
                        Console.WriteLine("\n");
                        break;
                    }
                    else
                        goto label4;
                }


            label1:

                Console.WriteLine("\n***************************************************");
                Console.WriteLine("\nProducts in your basket:");
                foreach (var item in productsList)
                { Console.Write($"{item.Name}\t"); }

                decimal basketPrice = 0;
                foreach (var item in productsList)
                {
                    basketPrice += item.Price;
                }

                Console.WriteLine($"\nYour products total price = {basketPrice}");

                Console.WriteLine("\nWant to buy : \"Yes\" or \"No\"");
                string buyOrNot = Console.ReadLine();

                if (buyOrNot.ToLower() == "no" || buyOrNot.ToLower() == "n")
                    continue;
                else if (buyOrNot.ToLower() != "yes" && buyOrNot.ToLower() != "no" && buyOrNot.ToLower() != "y" && buyOrNot.ToLower() != "n")
                    goto label1;


                label2:

                Console.WriteLine("\n***************************************************");

                Console.WriteLine($"\nYour cash balance = {customer.CashBalance}");
                Console.WriteLine($"Your credit card balance = {customer.CardBalance}");

                Console.WriteLine("\nSelect payment method: \"Cash\" or \"Credit card\" (or Run)");

                string paymentMethod = Console.ReadLine();

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
                    case "run":
                        Random random = new();
                        switch (random.Next(2))
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have been arrested!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Environment.Exit(0);
                                break;
                            case 1:
                                Console.WriteLine("You successfully escaped!");
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    default:
                        goto label2;
                }
                Console.WriteLine("Purchase completed successfully");


            label3:

                Console.WriteLine("\n***************************************************");

                Console.WriteLine("\nWant to exit market: \"Yes\" or \"No\" ?");
                string exitBool = Console.ReadLine();
                if (exitBool == null)
                    goto label3;
                else if (exitBool.ToLower() == "yes" || exitBool.ToLower() == "y")
                    Environment.Exit(0);
                else if (exitBool.ToLower() == "no" || exitBool.ToLower() == "n")
                    continue;
                else
                    goto label3;
            }
        }
    }
}
