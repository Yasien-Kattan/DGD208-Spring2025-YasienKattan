using System;

public class Menu
{
    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Pet Simulator ===");
        Console.WriteLine("1. Start New Game");
        Console.WriteLine("2. Load Game");
        Console.WriteLine("3. Instructions");
        Console.WriteLine("4. Exit");
        Console.Write("Select an option (1-4): ");
    }
}