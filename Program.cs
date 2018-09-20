using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();
            GreetUser();

            while (true)
            {
                Random random = new Random();
                int correctNumber = random.Next(1, 11);
                int guess = 0;

                Console.WriteLine("Guess a number between 1 and 10");

                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an integer between 1 and 10.");
                        continue;
                    }

                    guess = Int32.Parse(input);

                    if (guess != correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Wrong number, please try again.");
                    }
                }

                PrintColorMessage(ConsoleColor.Yellow, "You guessed it!");

                bool playAgain = false;

                while (!playAgain)
                {
                    Console.WriteLine("Play Again? [Y or N]");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                    {
                        playAgain = true;
                        Console.Clear();
                        continue;
                    }
                    else if (answer == "N")
                    {
                        PrintColorMessage(ConsoleColor.DarkCyan, "\n//***** Thanks for playing! *****//\n");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        playAgain = false; 
                    }
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Eric Price";

            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }

        static void GreetUser()
        {
            Console.WriteLine("What is your name?");

            string inputName = Console.ReadLine();

            Console.WriteLine("\nHello {0}, let's play a game...\n", inputName);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}