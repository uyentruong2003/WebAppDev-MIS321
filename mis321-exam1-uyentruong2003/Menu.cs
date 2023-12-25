
namespace mis321_exam1_uyentruong2003
{
    public class Menu
    {
        public int NumChoices;
        public List<string> Choices = new List<string>();

        //Display the choices on screen:
        public void DisplayChoice(){
            int i = 1;
            foreach(string choice in this.Choices){
                System.Console.WriteLine($"{i}. {choice}");
                i++;
            }
        }
        
        // Get the user choice:
        public string GetChoice(string message)
        {
            System.Console.Write(message);
            string choice = System.Console.ReadLine();
            int numChoice;

            while (!int.TryParse(choice, out numChoice) || numChoice < 1 || numChoice > this.Choices.Count)
            {
                System.Console.Write("Invalid input. Please try again: ");
                choice = System.Console.ReadLine();
            }

            return this.Choices[numChoice - 1];
        }

    }
}