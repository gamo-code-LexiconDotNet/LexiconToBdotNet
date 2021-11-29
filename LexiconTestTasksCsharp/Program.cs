using System;
using static LexiconTestTasksCsharp.Task;
using static System.Console;

namespace LexiconTestTasksCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            bool show = true;
            while (show)
                show = Menu();
        }

        private static bool Menu()
        {
            WriteLine("Lexicon Test and Assessment - C#.Net Programming\n");

            Write("Choose what to to:\n" +
                "1)  Hello World\n" +
                "2)  Input info\n" +
                "3)  Change terminal color\n" +
                "4)  Todays date.\n" +
                "5)  Max of two numbers\n" +
                "6)  Guess a number\n" +
                "7)  Save text to file\n" +
                "8)  Read text from file\n" +
                "9)  Do some math\n" +
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
                case "1": HelloWorld(); return HoldForInput();
                case "2": Name(); return HoldForInput();
                case "3": TerminalColor(); return HoldForInput();
                case "4": Today(); return HoldForInput();
                case "5": Max(); return HoldForInput();
                case "6": GuessNumber(); return HoldForInput();
                case "7": SaveToFile(); return HoldForInput();
                case "8": ReadFromFile(); return HoldForInput();
                case "9": Calculate(); return HoldForInput();
                case "10": MultiplicationTable(); return HoldForInput();
                case "11": SortArray(); return HoldForInput();
                case "12": TestPalindrome(); return HoldForInput();
                case "13": PrintRange(); return HoldForInput();
                case "14": OddEven(); return HoldForInput();
                case "15": Sum(); return HoldForInput();
                case "16": GameCharacter(); return HoldForInput();
                default: return true;
            }
        }

        private static bool HoldForInput(string msg = "\n\tPress any key to continue...")
        {
            Write(msg);
            ReadKey();
            Clear();
            return true;
        }
    }
}
