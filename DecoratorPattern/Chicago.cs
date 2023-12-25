namespace DecoratorPattern
{
    public class Chicago : Pizza
    {
        public Chicago() {
           this.Description = "Chicago Style Pizza";
        }
        public override double Cost() {
            if (this.Size == "Small") {
                return 10.99;
            } else if (this.Size == "Medium") {
                return 12.99;
            } else {
                return 14.99;
            }
        }
    }
}