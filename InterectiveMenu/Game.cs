using System;
using System.Collections.Generic;

namespace PetSimulator
{
    public class Game
    {
        private List<Pet> pets = new();
        private Pet? playerPet = null;

        public void Run()
        {
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

        private void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("C# Pet Simulator");
            Console.WriteLine("Created by Yaseen Kattan");
            Console.WriteLine("Student Number: [Your Student Number]");
            Console.WriteLine("Course: DGD208 - Programming II");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        private void StartGame()
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
                            ChooseAndInteractPet();
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

        private void CreatePet()
        {
            Console.Clear();
            Console.WriteLine("Choose species: Dog, Cat, Rabbit, Squirrel");
            Console.Write("Species: ");
            string input = Console.ReadLine()?.Trim() ?? "Dog";

            PetType species = Enum.TryParse(input, true, out PetType pt) ? pt : PetType.Dog;

            Console.Write("Choose a name for your pet: ");
            string name = Console.ReadLine()?.Trim() ?? "Buddy";

            playerPet = new Pet(name, species);
            pets.Add(playerPet);

            Console.WriteLine($"\n\u001b[32mYou created {name} the {species}!\u001b[0m");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ChooseAndInteractPet()
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

        private void ShowAllPetStats()
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

        private void InteractWithPet(Pet pet)
        {
            bool interacting = true;
            while (interacting)
            {
                Console.Clear();

                Console.WriteLine($"{pet.Name}'s Status ({pet.Species}):");
                Console.WriteLine($"Hunger: {pet.Hunger}");
                Console.WriteLine($"Sleep: {pet.Sleep}");
                Console.WriteLine($"Fun: {pet.Fun}");
                Console.WriteLine();

                pet.DisplayArt();
                Console.WriteLine();

                string[] actions = { "Feed", "Play", "Rest", "Back" };
                var actionMenu = new Menu(actions, 10, 2);
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
}
