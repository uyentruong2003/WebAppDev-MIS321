namespace mis321_finalexam_pt2_uyentruong2003
{
    public class HamSandwichFactory : ISandwichFactory
    {
        public Sandwich createSandwich() {
            return new Ham();
        }
    }
}