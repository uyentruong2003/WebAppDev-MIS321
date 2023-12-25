using System;
using System.IO;
namespace Polymorphism
{
    public class Dog : Animal // Dog is Animal's subclass
    {
        public override void Speak() { // override the virtual method Speak()
            System.Console.WriteLine($"Hello, my name is {Name}. Woof woof");
        }
    }
}