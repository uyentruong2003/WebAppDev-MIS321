namespace DecoratorPattern
{
    public class ThinCrust : Pizza
    {
        public ThinCrust() {
           this.Description = "Thin Crust Pizza";
        }
        public override double Cost() {
            if (this.Size == "Small") {
                return 9.99;
            } else if (this.Size == "Medium") {
                return 11.99;
            } else {
                return 13.99;
            }
        }
    }
}