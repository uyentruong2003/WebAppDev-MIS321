using DecoratorPattern;

// deep-dish pizza
Pizza deepDishPizza = new DeepDish();
deepDishPizza.setSize("Large");

// double cheese
Cheese cheeseDeepDishPizza = new Cheese(deepDishPizza);
Cheese doubleCheeseDeepDishPizza = new Cheese(cheeseDeepDishPizza);

// print description & cost
System.Console.WriteLine("Description: " + doubleCheeseDeepDishPizza.getDescription());
System.Console.WriteLine("Cost: $" + doubleCheeseDeepDishPizza.Cost());




