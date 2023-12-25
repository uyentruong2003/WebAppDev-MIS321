namespace mis321_exam1_uyentruong2003
{
    public class Animal
    {
        public string Name {get; set;}
        public string FurColor {get; set;}
        public IAct ActBehavior;
        
        // Constructor for a Animal:
        public Animal(){
            ActBehavior = new Talk();
        }

        public void SetActBehavior(IAct action){
            ActBehavior = action;
        }
    }
}