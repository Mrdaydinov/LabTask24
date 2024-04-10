namespace LabTask24
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Customer customer = new Customer("Customer1", "customer1", 1000, 2000);

            Product product = new Product("product1", 200, 3, 4);
            Product product1 = new Product("product2", 400, 4, 8);
            Product product2 = new("product3", 700, 2, 1);

            Market market = new Market(product, product1, product2);

            market.Kassa(customer);
        }
    }
}
