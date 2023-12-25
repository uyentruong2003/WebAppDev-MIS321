using DesignPatterns;

Dog sophie = new Dog(){Name = "Sophie", Breed = "Rat Terrier"};
sophie.BarkBehavior.Bark(); //BarkBehavior is from Dog class; Bark is from the subclasses Woof, Bowwow, etc.
sophie.BarkBehavior = new Woof();
sophie.BarkBehavior.Bark();