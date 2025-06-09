using System;

namespace PetSimulator
{
    public class Menu
    {
        private readonly string[] _options;
        private readonly int _left;
        private readonly int _top;
        private int _selectedIndex;

        public Menu(string[] options, int left, int top)
        {
            _options = options;
            _left = left;
            _top = top;
            _selectedIndex = 0;
        }

        public int Run()
        {
            ConsoleKeyInfo key;
            bool isSelected = false;
            Console.CursorVisible = false;

            DrawMenu();

            while (!isSelected)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        _selectedIndex = (_selectedIndex + 1) % _options.Length;
                        DrawMenu();
                        break;
                    case ConsoleKey.UpArrow:
                        _selectedIndex = (_selectedIndex - 1 + _options.Length) % _options.Length;
                        DrawMenu();
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
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
                Console.Write(new string(' ', Console.WindowWidth - _left));
                Console.SetCursorPosition(_left, _top + i);

                if (i == _selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(_options[i].PadRight(Console.WindowWidth - _left));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(_options[i]);
                }
            }
        }
    }
}
