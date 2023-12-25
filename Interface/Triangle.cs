namespace Interface
{
    public class Triangle : IShape
    {
        public int Side1 {get; set;}
        public int Side2 {get; set;}
        public int Base {get; set;}
        public int Height {get; set;}
        public string ShapeType{get; set;}
        public int GetArea(){
            return (Base*Height)/2;
        }
        public int GetPerimeter(){
            return Base + Side1 + Side2;
        }
    }
}