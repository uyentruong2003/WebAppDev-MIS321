using System;
using System.IO;
namespace Polymorphism
{
    public class Animal
    {
        public string Name {get; set;}
        public virtual void Speak() { // 'virtual' is added to be used later for polymorphism
            System.Console.WriteLine($"Hello, my name is {Name}.");
        }
    }
}