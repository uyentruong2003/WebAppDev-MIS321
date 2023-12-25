using mis321_exam1_uyentruong2003;
using System;

Animal myAnimal = new Animal();

// Choose your animal:
List<string> choices = new List<string>{"Cat","Dog","Bunny"};
Menu chooseAnimal = new Menu(){NumChoices=choices.Count(), Choices=choices};
chooseAnimal.DisplayChoice();
string playerChoice = chooseAnimal.GetChoice("Enter your animal choice: ");
System.Console.WriteLine($"You chose {playerChoice}");

if (playerChoice == "Cat"){
    myAnimal = new Cat();
} else if (playerChoice == "Dog"){
    myAnimal = new Dog();
} else {
    myAnimal = new Bunny();
}

System.Console.Write($"What's your {playerChoice}'s name? ");
myAnimal.Name = Console.ReadLine();
System.Console.Write($"What's your {playerChoice}'s fur color? ");
myAnimal.FurColor = Console.ReadLine();

System.Console.WriteLine($"My {playerChoice}'s name is {myAnimal.Name}. Its fur is {myAnimal.FurColor}.");

List<string> actions = new List<string>{"Walk","Talk","Collect Gems"};
Menu chooseAction = new Menu(){NumChoices=actions.Count(), Choices=actions};
chooseAction.DisplayChoice();
string playerAction = chooseAction.GetChoice($"What do you want your {playerChoice} to do? ");

if (playerAction == "Walk"){
    myAnimal.SetActBehavior(new Walk());
} else if (playerAction == "Talk"){
    myAnimal.SetActBehavior(new Talk());
} else {
    myAnimal.SetActBehavior(new CollectGem());
}

System.Console.WriteLine($"{myAnimal.Name}'s response: ");
myAnimal.ActBehavior.Action();

