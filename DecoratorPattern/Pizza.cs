namespace DecoratorPattern
{
    public abstract class Pizza
    {
        public string Description;
        public string Size;
        public Pizza(){
            this.Description = "Unknown Pizza";
        }
        public virtual string getDescription(){
            return Size + " " + Description;
        }
        
        public virtual string getSize() {
            return Size;
        }

        public virtual void setSize(string size){
            this.Size = size;
        }

        public abstract double Cost();
    }
}