using System;
using System.IO;
namespace Polymorphism
{
    public class Cat : Animal // Cat is Animal's subclass
    {
        public override void Speak(){
            System.Console.WriteLine($"Hello, my name is {Name}. Meow");
        }
    }
}