namespace AdapterPattern
{
    public class ProductAdapter : IProduct
    {
        Rice rice = new Rice();
        public ProductAdapter(Rice rice) {
            this.rice = rice;
         }

        public void getUnitPrice(double price) {
            rice.getPricePerPound(price);
        }
        public void getQuantitySold(int number) {
            rice.getTotalPoundsSold(number);
        }
    }
}