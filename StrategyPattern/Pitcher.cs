namespace StrategyPattern
{
    public class Pitcher
    {
        public string Name {get; set;}
        public string Team {get; set;}
        public string Throws {get; set;}
        public IPitch pitchBehavior {get;set;}
        
        //instantiate the object
        public Pitcher(){
            this.pitchBehavior = new Fastball();
        }


    }
}