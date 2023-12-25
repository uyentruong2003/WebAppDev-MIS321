namespace Interface
{
    public class Square : IShape
    {
        public int Side {get; set;}
        public string ShapeType{get; set;}

        public int GetArea() {
            return Side * Side;
        }

        public int GetPerimeter() {
            return Side*4;
        }
    }
}