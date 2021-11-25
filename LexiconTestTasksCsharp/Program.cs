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

            Environment.Exit(0);
        }

        private static bool Menu()
        {
            WriteLine("\nLexicon Test and Assessment - C#.Net Programming\n");

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
    }
}
