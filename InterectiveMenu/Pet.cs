using System;

public class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }

    public Pet(string name, string species)
    {
        Name = name;
        Species = species;
        Hunger = 5;
        Happiness = 5;
        Energy = 5;
    }

    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Happiness = Math.Min(10, Happiness + 1);
        Console.WriteLine($"\n\u001b[32mYou fed {Name}. Hunger decreased, happiness increased!\u001b[0m");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Energy = Math.Max(0, Energy - 1);
        Console.WriteLine($"\n\u001b[32mYou played with {Name}. Happiness increased, energy decreased!\u001b[0m");
    }

    public void Rest()
    {
        Energy = Math.Min(10, Energy + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"\n\u001b[32m{Name} rested. Energy increased, hunger slightly increased!\u001b[0m");
    }

    public void Status()
    {
        Console.WriteLine($"\n\u001b[36m{Name}'s Status ({Species}):\u001b[0m");
        Console.WriteLine($"Hunger: {Hunger}/10");
        Console.WriteLine($"Happiness: {Happiness}/10");
        Console.WriteLine($"Energy: {Energy}/10");
    }

    public void Update()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Energy = Math.Max(0, Energy - 1);
        if (Hunger >= 8)
        {
            Happiness = Math.Max(0, Happiness - 1);
        }
    }

    public void DisplayArt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (Species == "Dog")
        {
            if (Happiness >= 7)
                Console.WriteLine(@"
  / \__
 (    @\___
 /         O
/   (_____/
/_____/   U
");
            else if (Hunger >= 7)
                Console.WriteLine(@"
  / \__
 (    @\___
 /         ~
/   (_____/
/_____/   U
");
            else if (Energy <= 3)
                Console.WriteLine(@"
  / \__
 (    @\___
 /         z
/   (_____/
/_____/   U
");
            else
                Console.WriteLine(@"
  / \__
 (    @\___
 /         O
/   (_____/
/_____/   U
");
        }
        else if (Species == "Cat")
        {
            if (Happiness >= 7)
                Console.WriteLine(@"
 /\_/\
( ^.^ )
 > ^ <
");
            else if (Hunger >= 7)
                Console.WriteLine(@"
 /\_/\
( o.o )
 > ~ <
");
            else if (Energy <= 3)
                Console.WriteLine(@"
 /\_/\
( -.- )
 > _ <
");
            else
                Console.WriteLine(@"
 /\_/\
( o.o )
 > ^ <
");
        }
        Console.ResetColor();
    }
}