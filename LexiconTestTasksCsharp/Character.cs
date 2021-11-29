using System;

namespace LexiconTestTasksCsharp
{
    class Character
    {
        public Character(string name)
        {
            Name = name;
            InitializeStatistics();
        }

        private void InitializeStatistics()
        {
            Health = random.Next(20, 30);
            Strength = random.Next(10, 15);
            Luck = random.Next(0, 5);
        }

        public void PrintCharacter()
        {
            Console.WriteLine(
                $"[{Name}]\n" +
                $" Health: {Health}\n" +
                $" Strength: {Strength}\n" +
                $" Luck: {Luck}"
                );
        }

        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Luck { get; private set; }

        private static Random random = new Random();
    }
}
