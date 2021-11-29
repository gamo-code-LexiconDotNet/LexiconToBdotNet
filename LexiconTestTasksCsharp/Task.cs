using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using static System.Console;

namespace LexiconTestTasksCsharp
{
    class Task
    {
        // 1
        public static void HelloWorld()
        {
            WriteLine("Hello World!");
        }

        // 2
        public static void Name()
        {
            string fname, lname;
            int age;

            WriteLine("Please input your...");
            Write("First name\n> ");
            fname = ReadLine();
            Write("Last name\n> ");
            lname = ReadLine();
            age = ReadNumber<int>("Age", "Your age must be a number");

            WriteLine($"Your name is {fname} {lname} and you are {age} years old");
        }

        // 3
        public static void TerminalColor()
        {
            if (terminalColor == 0)
            {
                terminalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = terminalColor;
                terminalColor = 0;
            }
        }

        // 4
        public static void Today()
        {
            WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        // 5
        public static void Max()
        {
            int a, b;

            a = ReadNumber<int>();
            b = ReadNumber<int>(msg: "Input another number");

            WriteLine((a < b ? b : a));
        }

        // 6
        public static void GuessNumber()
        {
            int number = random.Next(1, 101);
            int guesses = 0;
            int guess;

            while (true)
            {
                guess = ReadNumber<int>(msg: string.Format("Guess {0}",
                    (guesses < 1 ? "a number between 1 and 100" : "again")));

                guesses++;

                if (guess == number)
                {
                    WriteLine("Correct after {0} guesses.", guesses);
                    break;
                }
                else if (number < guess)
                    WriteLine("The number is smaller.");
                else
                    WriteLine("The number is bigger.");
            }
        }

        // 7
        public static void SaveToFile()
        {
            Write("Input text to save to file\n> ");
            string input = ReadLine();

            try
            {
                File.WriteAllText(path, input);
            }
            catch
            {
                WriteLine("Could not write to file.");
                return;
            }
            WriteLine("Saved to " + path.ToString());
        }

        // 8
        public static void ReadFromFile()
        {
            string text;
            try
            {
                text = File.ReadAllText(path);
            }
            catch
            {
                WriteLine("Could not read from file.");
                return;
            }
            WriteLine("Text in file " + path.ToString());
            WriteLine(text);
        }

        // 9
        public static void Calculate()
        {
            float num = ReadNumber<float>(
                "Input a decimal number.",
                "You must input a decimal number.");

            WriteLine("{0}\n{1}\n{2}",
                Math.Sqrt(num), Math.Pow(num, 2), Math.Pow(num, 10));
        }

        // 10
        public static void MultiplicationTable()
        {
            StringBuilder table = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    table.AppendFormat("{0, 4}", i * j);
                }
                table.Append("\n");
            }
            WriteLine(table.ToString());
        }

        // 11
        public static void SortArray()
        {
            int arraySize = 10;
            int[] src = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
                src[i] = random.Next(-arraySize * 10, arraySize * 10);

            int[] dst = src.Clone() as int[];

            int swap;
            for (int i = 0; i < arraySize; i++)
                for (int j = i + 1; j < arraySize; j++)
                    if (dst[j] < dst[i])
                    {
                        swap = dst[i];
                        dst[i] = dst[j];
                        dst[j] = swap;
                    }

            WriteLine("{0, 4}", string.Join(" ", src));
            WriteLine("{0, 4}", string.Join(" ", dst));
        }

        // 12
        public static void TestPalindrome()
        {
            Write("Input a word\n> ");
            string input = ReadLine();
            input = input.ToLower();

            int i = 0;
            int j = input.Length - 1;
            for (; i < j; i++, j--)
                if (input[i] != input[j])
                {
                    WriteLine("Not a palindrome");
                    return;
                }

            WriteLine("Palindrome");
        }

        // 13
        public static void PrintRange()
        {
            int a, b;
            a = ReadNumber<int>();
            b = ReadNumber<int>(msg: "Input another number");

            if (a < b)
                for (int i = a + 1; i < b; i++)
                    Write("{0}{1}", i, (i < b - 1 ? ", " : ""));
            else
                for (int i = a - 1; i > b; i--)
                    Write("{0}{1}", i, (i > b + 1 ? ", " : ""));

            WriteLine();
        }

        // 14
        public static void OddEven()
        {
            string odd = "", even = "";
            int[] numbers = ReadCommaSeparatedNumbers();

            if (numbers.Length == 0) return;

            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] % 2 == 0)
                    even += numbers[i].ToString() + ", ";
                else
                    odd += numbers[i].ToString() + ", ";

            WriteLine(even.TrimEnd(',', ' '));
            WriteLine(odd.TrimEnd(',', ' '));
        }

        // 15
        public static void Sum()
        {
            int sum = 0;
            int[] numbers = ReadCommaSeparatedNumbers();

            if (numbers.Length == 0) return;

            foreach (int num in numbers)
                sum += num;

            WriteLine(sum);
        }

        // 16
        public static void GameCharacter()
        {
            Write("Input a character name\n> ");
            string input1 = ReadLine();
            Write("Input another character name\n> ");
            string input2 = ReadLine();

            Character character1;
            Character character2;

            try
            {
                character1 = new Character(input1);
                character2 = new Character(input2);
            }
            catch
            {
                WriteLine("Could not create character.");
                return;
            }

            WriteLine("The following characters where created:");
            character1.PrintCharacter();
            character2.PrintCharacter();
        }

        // input helper for comma separated strings
        private static int[] ReadCommaSeparatedNumbers()
        {
            Write("Input comma separated numbers\n> ");
            string input;
            int[] numbers;

            while (true)
            {
                input = ReadLine();
                try
                {
                    numbers = Array.ConvertAll(input.Split(','), int.Parse);
                    break;
                }
                catch
                {
                    Write("Input only comma separated numbers\n> ");
                }
            }

            return numbers;
        }

        // input helper for numbers
        private static T ReadNumber<T>(
            string msg = "Input a number",
            string err = "You must input a number"
            )
        {
            T num;
            string input;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            Write("{0}\n> ", msg);
            while (true)
            {
                input = ReadLine();
                try
                {
                    num = (T)converter.ConvertFromString(input);
                    return num;
                }
                catch
                {
                    Write("{0}\n> ", err);
                }
            }
        }

        static string path = AppDomain.CurrentDomain.BaseDirectory + "file.txt";
        private static ConsoleColor terminalColor;
        private static Random random = new Random();
    }
}
