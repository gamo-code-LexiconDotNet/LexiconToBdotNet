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
                "\n {0}\n" +
                "  Health: {1}\n" +
                "  Strength: {2}\n" +
                "  Luck: {3}\n",
                Name, Health, Strength, Luck);
        }

        public string Name { get => name; private set => name = value; }
        public int Health { get => health; private set => health = value; }
        public int Strength { get => strength; private set => strength = value; }
        public int Luck { get => luck; private set => luck = value; }

        private string name;
        private int health;
        private int strength;
        private int luck;

        private Random random = new Random();
    }

}
