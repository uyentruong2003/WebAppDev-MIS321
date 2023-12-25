namespace Interface
{
    public class Rectangle : IShape
    {
        public int Length {get; set;}
        public int Width {get; set;}
        public string ShapeType{get; set;}
        public int GetArea(){
            return Length*Width;
        }
        public int GetPerimeter(){
            return (Length + Width)*2;
        }
    }
}