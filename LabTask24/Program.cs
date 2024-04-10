namespace LabTask24
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Customer customer = new Customer("customer1", "customer1", 1000, 2000);

            Product product = new Product("product1", 200, 3, 4);

            Market market = new Market();
            market.Kassa(customer, product);
        }
    }
}
