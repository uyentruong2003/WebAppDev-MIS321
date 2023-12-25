namespace StrategyPattern
{
    public class Lefty : Pitcher
    {
        // instantiate the object
        public Lefty() {
            this.Throws = "Left";
            this.pitchBehavior = new Curveball();
        }
    }
}