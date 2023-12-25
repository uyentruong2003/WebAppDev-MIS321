namespace DecoratorPattern
{
    public class DeepDish : Pizza
    {
        public DeepDish () {
           this.Description = "Deep Dish Pizza";
        }
        public override double Cost() {
            if (this.Size == "Small") {
                return 11.99;
            } else if (this.Size == "Medium") {
                return 13.99;
            } else {
                return 15.99;
            }
        }
    }
}