namespace DesignPatterns
{
    public class Dog
    {
        public string Name {get; set;}
        public string Breed {get; set;}

        public IBark BarkBehavior {get; set;}

        public Dog() {
            BarkBehavior = new Bowwow();
        }
    }
}