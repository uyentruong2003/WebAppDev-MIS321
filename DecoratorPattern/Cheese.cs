namespace DecoratorPattern
{
    public class Cheese : PizzaDecorator
    {
        private Pizza pizza;
        public Cheese (Pizza pizza) {
            this.pizza = pizza;
        }
        public override string getDescription() {
            return pizza.getDescription() + ", add cheese";
        }

        public override string getSize() {
            return pizza.Size;
        }
        public override void setSize(string size)
        {
            pizza.setSize(size);
            this.Size = size;
        }
        public override double Cost() {
            return pizza.Cost() + 0.25;
        }
    }
}