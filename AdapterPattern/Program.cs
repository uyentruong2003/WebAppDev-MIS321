using AdapterPattern;

Shirt blueShirt = new Shirt();
Rice jasmineRice = new Rice();
ProductAdapter jasmineRiceAdapted = new ProductAdapter(new Rice());

// Target:
System.Console.WriteLine("Shirt's printed out with the target code structure:");
blueShirt.getUnitPrice(32.5);
blueShirt.getQuantitySold(150);
System.Console.WriteLine(" ");

// Adaptee:
System.Console.WriteLine("Rice's printed out with an incompatible code structure: ");
jasmineRice.getPricePerPound(5.99);
jasmineRice.getTotalPoundsSold(1340);
System.Console.WriteLine(" ");

// Adapter:
System.Console.WriteLine("Rice's printed out with the adapted code structure:");
jasmineRiceAdapted.getUnitPrice(5.99);
jasmineRiceAdapted.getQuantitySold(1340);
