using System;

namespace PetSimulator
{
    class Program
    {
        static void Main()
        {
            Console.Title = "C# Pet Simulator";
            var game = new Game();
            game.Run();
        }
    }
}
