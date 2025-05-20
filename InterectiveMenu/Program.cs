using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the C# world!");
            Console.ResetColor();
            Console.WriteLine("Use ⬆ and ⬇ arrow keys to navigate the menu and press the \u001b[32mEnter/Return\u001b[0m key to select.");

            Menu mainMenu = new Menu(new[] { "Start Game", "Settings", "Exit" }, 0, 5);
            int mainChoice = mainMenu.Run();

            switch (mainChoice)
            {
                case 0:
                    HandleGameMenu();
                    break;
                case 1:
                    HandleSettings();
                    break;
                case 2:
                    exit = true;
                    break;
            }
        }

        Console.WriteLine("\n\u001b[32mGoodbye!\u001b[0m");
    }

    private static void HandleGameMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game Menu");
            Console.ResetColor();
            Console.WriteLine("Choose your game option:");

            Menu gameMenu = new Menu(new[] { "New Game", "Load Game", "Back" }, 0, 5);
            int gameChoice = gameMenu.Run();

            switch (gameChoice)
            {
                case 0:
                    StartNewGame();
                    break;
                case 1:
                    Console.WriteLine("\n\u001b[32mLoad Game functionality under construction...\u001b[0m");
                    Console.WriteLine("Press any key to return to the game menu.");
                    Console.ReadKey();
                    break;
                case 2:
                    back = true;
                    break;
            }
        }
    }

    private static void StartNewGame()
    {
        Console.Clear();
        Console.WriteLine("\u001b[36mEnter your pet's name:\u001b[0m");
        string petName = Console.ReadLine();

        Pet pet = new Pet(petName);
        bool exitPetMenu = false;

        while (!exitPetMenu)
        {
            pet.Update();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Pet Simulation: {pet.Name}");
            Console.ResetColor();
            Console.WriteLine("Choose an action:");

            Menu petMenu = new Menu(new[] { "Feed", "Play", "Rest", "Status", "Exit" }, 0, 5);
            int petChoice = petMenu.Run();

            switch (petChoice)
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
                    pet.Status();
                    break;
                case 4:
                    exitPetMenu = true;
                    break;
            }

            if (!exitPetMenu)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private static void HandleSettings()
    {
        Console.Clear();
        Console.WriteLine("\u001b[32mSettings menu under construction...\u001b[0m");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
}