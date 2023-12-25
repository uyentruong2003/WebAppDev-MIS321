using StrategyPattern;

// See https://aka.ms/new-console-template for more information
Pitcher standardPitcher = new Pitcher();
standardPitcher.pitchBehavior.Pitch();

Pitcher leftyPitcher = new Lefty();
leftyPitcher.pitchBehavior.Pitch();

// Call the pitchBehavior setter to set the pitchBehavior to Slider
leftyPitcher.pitchBehavior = new Slider();
leftyPitcher.pitchBehavior.Pitch();