using System;

namespace PetSimulator
{
    public class Pet
    {
        public string Name { get; }
        public PetType Species { get; }
        public int Hunger { get; private set; }
        public int Sleep { get; private set; }
        public int Fun { get; private set; }
        public PetState State { get; private set; }

        public Pet(string name, PetType species)
        {
            Name = name;
            Species = species;
            Hunger = 50;
            Sleep = 50;
            Fun = 50;
            State = PetState.Alive;
        }

        public void Feed()
        {
            if (State == PetState.Dead) return;
            Hunger = Math.Min(100, Hunger + 20);
            Console.WriteLine($"{Name} has been fed. Hunger increased!");
        }

        public void Play()
        {
            if (State == PetState.Dead) return;
            Fun = Math.Min(100, Fun + 20);
            Hunger = Math.Max(0, Hunger - 10);
            Sleep = Math.Max(0, Sleep - 10);
            Console.WriteLine($"{Name} played and had fun!");
            CheckIfDead();
        }

        public void Rest()
        {
            if (State == PetState.Dead) return;
            Sleep = Math.Min(100, Sleep + 20);
            Hunger = Math.Max(0, Hunger - 10);
            Console.WriteLine($"{Name} rested well.");
            CheckIfDead();
        }

        public void DecreaseStats()
        {
            if (State == PetState.Dead) return;

            Hunger = Math.Max(0, Hunger - 1);
            Sleep = Math.Max(0, Sleep - 1);
            Fun = Math.Max(0, Fun - 1);

            CheckIfDead();
        }

        private void CheckIfDead()
        {
            if (Hunger == 0 || Sleep == 0 || Fun == 0)
            {
                State = PetState.Dead;
                Console.WriteLine($"\n\u001b[31mSadly, {Name} has died.\u001b[0m");
            }
        }

        public void Status()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Species: {Species}");
            Console.WriteLine($"Hunger: {Hunger}");
            Console.WriteLine($"Sleep: {Sleep}");
            Console.WriteLine($"Fun: {Fun}");
            Console.WriteLine($"State: {State}");
        }

        public void DisplayArt()
        {
            switch (Species)
            {
                case PetType.Dog:
                    Console.WriteLine(" /\\_/\\\n( o.o )\n > ^ <");
                    break;
                case PetType.Cat:
                    Console.WriteLine(" /\\_/\\\n( =^.^= )\n (\")_(\")");
                    break;
                case PetType.Rabbit:
                    Console.WriteLine(" (\\_/)\n ( . .)\n c(\")(\")");
                    break;
                case PetType.Squirrel:
                    Console.WriteLine(" (\\_/) \n (o.o)\n > ^ <");
                    break;
                default:
                    Console.WriteLine("Pet art unavailable.");
                    break;
            }
        }
    }
}
