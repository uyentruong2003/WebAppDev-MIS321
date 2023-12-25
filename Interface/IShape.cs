namespace Interface
{
    public interface IShape
    {
        public string ShapeType{get; set;}
        public int GetArea();
        public int GetPerimeter();


    }
}