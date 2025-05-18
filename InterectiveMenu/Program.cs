
Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Welcome to the C# world!");
Console.ResetColor();

Console.WriteLine("Use ⬆ and ⬇ arrow keys to navigate the menu and press the \u001b[32mEnter/Return\u001b[0m key to select.");

ConsoleKeyInfo key;
int option = 1;
bool isSelected = false;

// Manually define a safe starting position
int left = 0;
int top = 5;

Console.CursorVisible = false;

while (!isSelected)
{
    // Move cursor back to the start of the menu
    Console.SetCursorPosition(left, top);

    for (int i = 1; i <= 3; i++)
    {
        Console.SetCursorPosition(left, top + i - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(left, top + i - 1);

        string prefix = (option == i) ? "✔   \u001b[32m" : "    ";
        Console.WriteLine($"{prefix}Option {GetOptionText(i)}\u001b[0m");
    }

    key = Console.ReadKey(true);

    switch (key.Key)
    {
        case ConsoleKey.DownArrow:
            option = (option == 3) ? 1 : option + 1;
            break;

        case ConsoleKey.UpArrow:
            option = (option == 1) ? 3 : option - 1;
            break;

        case ConsoleKey.Enter:
            isSelected = true;
            break;
    }
}

Console.WriteLine($"\n\u001b[32mYou selected option: {option} - {GetOptionText(option)}\u001b[0m");

// Helper method
string GetOptionText(int i)
{
    return i switch
    {
        1 => "Start Game 1",
        2 => "Settings 2",
        3 => "Exit 3",
        _ => "Unknown"
    };
}
