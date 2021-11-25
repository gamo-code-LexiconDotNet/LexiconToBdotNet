using System;
using System.IO;
using System.Text;
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
            string fname, lname, age;
            Write("First name: ");
            fname = ReadLine();
            Write("Last name: ");
            lname = ReadLine();
            Write("Age name: ");
            age = ReadLine();

            WriteLine($"Your name is {fname} {lname} and you are {age} old");
        }

        // 3
        public static void TerminalColor()
        {
            if (terminalColor == 0)
            {
                terminalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
            } else
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

            if (!ReadTwoNumbers(out a, out b))
                return;

            WriteLine((a < b ? b : a));
        }

        // 6
        public static void GuessNumber()
        {
            int number = random.Next(1, 100);
            int guesses = 0;
            int guess;

            while (true)
            {
                Write("Guess {0}\n> ", (guesses < 1 ? "a number between 1 and 100" : "again"));
                try
                {
                    guess = Convert.ToInt32(ReadLine());
                } catch
                {
                    WriteLine("You must guess a number.");
                    break;
                }

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
                File.WriteAllText(fileName, input);
            } 
            catch
            {
                WriteLine("Could not write to file.");
                return;
            }
            WriteLine("Saved.");
        }

        // 8
        public static void ReadFromFile()
        {
            try
            {
                string text = File.ReadAllText(fileName);
                WriteLine(text);
            }
            catch
            {
                WriteLine("Could not read from file.");
                return;
            }
        }

        // 9
        public static void Calculate()
        {
            Write("Input a number\n> ");
            int num = 0;
            
            try
            {
                num = Convert.ToInt32(ReadLine());
            } catch
            {
                WriteLine("You must input a number.");
                return;
            }

            WriteLine("{0}\n{1}\n{2}", Math.Sqrt(num), Math.Pow(num, 2), Math.Pow(num, 10));
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

            int i = 0;
            int j = input.Length - 1;
            for (; i < j ; i++, j--)
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

            if (!ReadTwoNumbers(out a, out b))
                return;

            if (a < b)
                for (int i = a + 1; i < b; i++)
                     Write("{0} ", i);
            else
                for (int i = a - 1; i > b; i--)
                    Write("{0} ", i);

            WriteLine();
        }

        // 14
        public static void OddEven()
        {
            string odd = "", even = "";
            int[] numbers = ReadCommaSeparatedInput();

            if (numbers.Length == 0) return;

            foreach (int num in numbers)
                if (num % 2 == 0)
                    even += num.ToString() + " ";
                else
                    odd += num.ToString() + " ";

            WriteLine(even);
            WriteLine(odd);
        }

        // 15
        public static void Sum()
        {
            int sum = 0;
            int[] numbers = ReadCommaSeparatedInput();

            if (numbers.Length == 0) return;

            foreach (int num in numbers)
                sum += num;

            WriteLine(sum);
        }

        // 16
        public static void GameCharacter()
        {
            Write("Input a character name\n> ");
            string input = ReadLine();

            Character character;

            try
            {
                character = new Character(input);
            }
            catch
            {
                WriteLine("Could not create character.");
                return;
            }

            WriteLine("The following character was created:");
            character.PrintCharacter();
        }

        // input helper
        private static int[] ReadCommaSeparatedInput()
        {
            Write("Input numbers (comma separated)\n> ");
            string input = ReadLine();
            int[] numbers;

            try
            {
                numbers = Array.ConvertAll(input.Split(','), int.Parse);
            }
            catch
            {
                WriteLine("Input only comma separated numbers.");
                return Array.Empty<int>();
            }

            return numbers;
        }

        // input helper
        private static bool ReadTwoNumbers(out int a, out int b)
        {
            try
            {
                Write("Input a number\n> ");
                a = Convert.ToInt32(ReadLine());
                Write("Input another number\n> ");
                b = Convert.ToInt32(ReadLine());
            }
            catch
            {
                a = b = 0;
                WriteLine("You must input two numbers.");
                return false;
            }

            return true;
        }

        private static string fileName = "file.txt";
        private static ConsoleColor terminalColor;
        private static Random random = new Random();
    }
}
