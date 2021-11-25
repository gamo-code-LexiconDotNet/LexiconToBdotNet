using System;
using System.IO;
using System.Text;
using static System.Console;

namespace LexiconTestTasksCsharp
{
    class Task
    {
        public static void Run()
        {
            bool show = true;
            while (show)
                show = Menu();

            Environment.Exit(0);
        }

        public static bool Menu()
        {
            WriteLine("\nLexicon Test and Assessment - C#.Net Programming");

            Write("Choose what to to:\n" +
                "1)  Hello World.\n" +
                "2)  Input info.\n" +
                "3)  Change terminal color.\n" +
                "4)  Todays date.\n" +
                "5)  Max of two numbers.\n" +
                "6)  Guess a number.\n" +
                "7)  Save text to file.\n" +
                "8)  Read text from file.\n" +
                "9)  Do some math.\n" +
                "10) Print multiplication table\n" +
                "11) Sort an array\n" +
                "12) Test palindrome\n" +
                "13) Print range\n" +
                "14) Odd or even numbers\n" +
                "15) Sum numbers\n" +
                "16) Game character\n" +
                "0)  Exit\n" +
                "> "
            );

            string input = ReadLine();
            Clear();
            switch (input)
            {
                case "0": return false;
                case "1": HelloWorld(); return true;
                case "2": Name(); return true;
                case "3": TerminalColor(); return true;
                case "4": Today(); return true;
                case "5": Max(); return true;
                case "6": GuessNumber(); return true;
                case "7": SaveToFile(); return true;
                case "8": ReadFromFile(); return true;
                case "9": Calculate(); return true;
                case "10": MultiplicationTable(); return true;
                case "11": SortArray(); return true;
                case "12": TestPalindrome(); return true;
                case "13": PrintRange(); return true;
                case "14": OddEven(); return true;
                case "15": Sum(); return true;
                case "16": GameCharacter(); return true;
                default: return true;
            }
        }

        private static void HelloWorld()
        {
            WriteLine("Hello World!");
        }

        private static void Name()
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

        private static void Today()
        {
            WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private static void Max()
        {
            int a, b;

            try
            {
                Write("Input a number\n> ");
                a = Convert.ToInt32(ReadLine());
                Write("Input another number\n> ");
                b = Convert.ToInt32(ReadLine());
            }
            catch {
                WriteLine("You must input two numbers.");
                return;
            }

            WriteLine((a < b ? b : a));
        }

        private static void GuessNumber()
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

        private static void SaveToFile()
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

        private static void ReadFromFile()
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

        private static void Calculate()
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

        private static void TestPalindrome()
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

        private static void PrintRange()
        {
            int a, b;
            try
            {
                Write("Input a number\n> ");
                a = Convert.ToInt32(ReadLine());
                Write("Input another number\n> ");
                b = Convert.ToInt32(ReadLine());
            }
            catch
            {
                WriteLine("You must input two numbers.");
                return;
            }

            if (a < b)
                for (int i = a + 1; i < b; i++)
                     Write("{0} ", i);
            else
                for (int i = a - 1; i > b; i--)
                    Write("{0} ", i);
            WriteLine();
        }

        private static void OddEven()
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

        private static void Sum()
        {
            int sum = 0;
            int[] numbers = ReadCommaSeparatedInput();

            if (numbers.Length == 0) return;

            foreach (int num in numbers)
                sum += num;

            WriteLine(sum);
        }

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

        private static void GameCharacter()
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

        private static string fileName = "file.txt";
        private static ConsoleColor terminalColor;
        private static Random random = new Random();
    }
}
