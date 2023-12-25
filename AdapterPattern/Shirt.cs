namespace AdapterPattern
{
    public class Shirt : IProduct
    {
        public Shirt() {} //instantiate
        public void getUnitPrice(double price) {
            System.Console.WriteLine($"This item costs ${price} per item");
        }

        public void getQuantitySold(int number) {
            System.Console.WriteLine($"Total number of items sold: ${number} items");
        }
    }
}