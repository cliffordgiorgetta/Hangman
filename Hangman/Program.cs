using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "";
            Console.WriteLine("Hello!, what is your name?");
            name = Console.ReadLine();
            Console.WriteLine("Welcome " + name + " to my awesome hangman game!");
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Today you will be guessing letters of a word");
            Console.WriteLine("until you can guess the word or all of the letters");
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Are you ready to begin?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Yes");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" or ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No");
            Console.ResetColor();
            Console.WriteLine();

            string yesorno = Console.ReadLine();
            if (yesorno.ToLower() == "yes")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lets begin! :-)");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (yesorno.ToLower() == "no")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry for wasting your time! :-(");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }

            var wordList = new List<string>() { "strawberry", "pineapple", "hangman" + name + "professionalism", "seedpaths" };
            var lettersGuessed = new List<string>() { };
            var guessAmount = 8;
            var numGuesses = 0;
            bool playing = true;
            var random = new Random();



            while (playing)
            {
                var wordPicked = wordList[random.Next(0, wordList.Count)];
                bool beenGuessed = false;
                while (numGuesses < guessAmount && !beenGuessed)
                {
                    MaskedWord(lettersGuessed, wordPicked);
                    //printing out letters with a space in between
                    Console.WriteLine(string.Join(" ", lettersGuessed));
                    Console.WriteLine(guessAmount - numGuesses);
                    string input = Console.ReadLine();
                    lettersGuessed.Add(input);
                    bool foundaletter = false;
                    foreach (var L in wordPicked)
                    {
                        if (input == L.ToString())
                        {
                            foundaletter = true;

                        }
                    }

                    if (foundaletter == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Found a letter! :-)");
                        Console.ResetColor();
                    }
                    else
                    {
                        numGuesses++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect guess :-(");
                        Console.ResetColor();

                    }
                }



            }
        }
        static void Guessing()
        {
            var beenGuessed = 0;
            for (var i = 0; i <= 8; i--)
            {
                Console.WriteLine(i);
            }
            if (beenGuessed == 7)
            {
                Console.WriteLine("You have 7 guesses left");
            }
            else if (beenGuessed == 6)
            {
                Console.WriteLine("You have 6 guesses left");
            }
            else if (beenGuessed == 5)
            {
                Console.WriteLine("You have 5 guesses left");
            }
            else if (beenGuessed == 4)
            {
                Console.WriteLine("You have 4 guesses left");
            }
            else if (beenGuessed == 3)
            {
                Console.WriteLine("You have 3 guesses left");
            }
            else if (beenGuessed == 2)
            {
                Console.WriteLine("You have 2 guesses left");
            }
            else if (beenGuessed == 1)
            {
                Console.WriteLine("You have 1 guesses left");
            }
            else if (beenGuessed == 0)
            {
                Console.WriteLine("You have 0 guesses left");
                Console.WriteLine("GOODBYE");
                Environment.Exit(0);
            }


        }


        static void MaskedWord(List<string> letterGuessed, string theWord)
        {

            string returnstring = "";

            int i = 0;
            while (i < theWord.Length)
            {
                var letter = theWord[i].ToString();
                bool foundaletter = false;
                foreach (var guess in letterGuessed)
                {
                    if (guess == letter)
                    {

                        foundaletter = true;
                    }

                }
                if (foundaletter)
                {

                    returnstring += letter + " ";
                }
                else
                {
                    returnstring += "_ ";
                }

                i++;
            }

            Console.WriteLine(returnstring);

            Console.ReadKey();

        }
    }
}

