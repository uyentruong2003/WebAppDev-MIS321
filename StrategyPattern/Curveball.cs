namespace StrategyPattern
{
    public class Curveball : IPitch
    {
        public void Pitch() {
            System.Console.WriteLine("An 80mph curveball was thrown");
        }
    }
}