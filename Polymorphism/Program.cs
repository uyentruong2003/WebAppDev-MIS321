using System;
using System.Collections.Generic; //needed when using List

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Animal(){Name = "generic"};
            Dog spot = new Dog(){Name = "Spot"};
            Cat ellen = new Cat(){Name = "Ellen"};

            // List of parent class Animal can contain elements of subclasses Dog, Cat
            List<Animal> animalKingdom = new List<Animal>();
            animalKingdom.Add(myAnimal);
            animalKingdom.Add(spot);
            animalKingdom.Add(ellen);
            animalKingdom.Add(new Dog(){Name = "Sophie"});

            // when the Speak() method is called, it polymorphes accordingly to the (sub)class of the element
            foreach(Animal localAnimal in animalKingdom){
                localAnimal.Speak();
            }
        }
    }
}
