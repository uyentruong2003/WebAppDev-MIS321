namespace AdapterPattern
{
    public class Rice
    {
        public Rice() {} //instantiate
        public void getPricePerPound(double price) {
            System.Console.WriteLine($"The rice costs ${price} per pound");
        }
        public void getTotalPoundsSold (int number) {
            System.Console.WriteLine($"Total pounds sold: ${number} pounds");
        }
    }
}