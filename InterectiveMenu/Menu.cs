using System;

public class Menu
{
    private readonly string[] _options;
    private readonly int _left;
    private readonly int _top;
    private int _selectedIndex;
    private int _lastIndex;

    public Menu(string[] options, int left, int top)
    {
        _options = options;
        _left = left;
        _top = top;
        _selectedIndex = 0;
        _lastIndex = -1;
    }

    public int Run()
    {
        ConsoleKeyInfo key;
        bool isSelected = false;
        Console.CursorVisible = false;

        DrawMenu();

        while (!isSelected)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        _selectedIndex = (_selectedIndex + 1) % _options.Length;
                        break;

                    case ConsoleKey.UpArrow:
                        _selectedIndex = (_selectedIndex - 1 + _options.Length) % _options.Length;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

                if (!isSelected)
                    DrawMenu();
            }
        }

        Console.CursorVisible = true;
        return _selectedIndex;
    }

    private void DrawMenu()
    {
        for (int i = 0; i < _options.Length; i++)
        {
            Console.SetCursorPosition(_left, _top + i);

            string line = new string(' ', Console.WindowWidth - _left - 1); // Clear old content
            Console.Write(line);

            Console.SetCursorPosition(_left, _top + i);

            if (i == _selectedIndex)
            {
                Console.Write($"✔   \u001b[32m{_options[i]}\u001b[0m");
            }
            else
            {
                Console.Write($"    {_options[i]}");
            }
        }
    }
}
