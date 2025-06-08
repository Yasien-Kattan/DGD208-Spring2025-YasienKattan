using System;
using System.Collections.Generic;

class Program
{
    static List<Pet> pets = new List<Pet>();
    static Pet? playerPet = null;

    static void Main()
    {
        Console.Title = "C# Pet Simulator";

        while (true)
        {
            Console.Clear();
            string[] mainOptions = { "Start Game", "Credits", "Exit" };
            var mainMenu = new Menu(mainOptions, 2, 2);
            int mainChoice = mainMenu.Run();

            switch (mainChoice)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    ShowCredits();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("C# Pet Simulator");
        Console.WriteLine("Created by Yaseen Kattan");
        Console.WriteLine("Course: DGD208 - Programming II");
        Console.WriteLine("Ricardo Gerbaudo's Interactive Menu in Console App Using C# from Youtube");
        Console.WriteLine("https://www.youtube.com/watch?v=YyD1MRJY0qI&t=21s");
        Console.WriteLine("GPT-4 for accsi art and fixing the Interactive Menu");
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

    static void StartGame()
    {
        bool inGame = true;
        while (inGame)
        {
            Console.Clear();
            string[] startOptions = {
                "Create New Pet",
                "Play With My Pet",
                "View All Pet Stats",
                "Return to Main Menu"
            };
            var gameMenu = new Menu(startOptions, 2, 2);
            int gameChoice = gameMenu.Run();

            switch (gameChoice)
            {
                case 0:
                    CreatePet();
                    break;
                case 1:
                    if (pets.Count > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Choose a pet to interact with:\n");

                        string[] petOptions = new string[pets.Count];
                        for (int i = 0; i < pets.Count; i++)
                        {
                            petOptions[i] = $"{pets[i].Name} the {pets[i].Species}";
                        }

                        var petMenu = new Menu(petOptions, 2, 2);
                        int selectedPetIndex = petMenu.Run();

                        InteractWithPet(pets[selectedPetIndex]);
                    }
                    else
                    {
                        Console.WriteLine("\n\u001b[31mNo pets have been created yet!\u001b[0m");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    ShowAllPetStats();
                    break;
                case 3:
                    inGame = false;
                    break;
            }
        }
    }

    static void CreatePet()
    {
        Console.Clear();
        Console.WriteLine("Choose species: Dog, Cat, Rabbit, Squirrel");
        Console.Write("Species: ");
        string species = Console.ReadLine()?.Trim() ?? "Dog";

        Console.Write("Choose a name for your pet: ");
        string name = Console.ReadLine()?.Trim() ?? "Buddy";

        playerPet = new Pet(name, species);
        pets.Add(playerPet);

        Console.WriteLine($"\n\u001b[32mYou created {name} the {species}!\u001b[0m");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ShowAllPetStats()
    {
        Console.Clear();
        Console.WriteLine("\u001b[36mAll Created Pets:\u001b[0m\n");

        if (pets.Count == 0)
        {
            Console.WriteLine("\u001b[31mNo pets have been created yet.\u001b[0m");
        }
        else
        {
            foreach (var pet in pets)
            {
                pet.Status();
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    static void InteractWithPet(Pet pet)
    {
        bool interacting = true;
        while (interacting)
        {
            Console.Clear();

            // Display status
            Console.WriteLine($"{pet.Name}'s Status ({pet.Species}):");
            Console.WriteLine($"Hunger: {pet.Hunger}/10");
            Console.WriteLine($"Happiness: {pet.Happiness}/10");
            Console.WriteLine($"Energy: {pet.Energy}/10");
            Console.WriteLine();

            // Display ASCII art
            pet.DisplayArt();

            // Add blank lines to separate from menu
            Console.WriteLine();
            Console.WriteLine();

            // Menu starts below the art
            string[] actions = { "Feed", "Play", "Rest", "Back" };
            var actionMenu = new Menu(actions, 10, 2); // Ensure enough vertical space
            int choice = actionMenu.Run();

            switch (choice)
            {
                case 0:
                    pet.Feed();
                    break;
                case 1:
                    pet.Play();
                    break;
                case 2:
                    pet.Rest();
                    break;
                case 3:
                    interacting = false;
                    break;
            }

            if (interacting)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
