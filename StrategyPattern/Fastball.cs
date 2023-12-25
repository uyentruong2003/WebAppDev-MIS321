namespace StrategyPattern
{
    public class Fastball : IPitch
    {
        public void Pitch() {
            System.Console.WriteLine("A 94mph fastball was thrown");
        }
        
    }
}