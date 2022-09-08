using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);
            int tries = 8;

            Console.WriteLine(randomNumber);

            Console.WriteLine("A random integer from 0 to 100 has been generated. Take a guess!");
            Console.WriteLine("You have " + tries + " tries remaining.");
            int guess = Convert.ToInt32(Console.ReadLine());
            
            while (tries >= 0) {
                if (guess > 100 || guess < 0)
                {
                    Console.WriteLine("Please enter a valid number.");
                    guess = int.Parse(Console.ReadLine());
                }
                else if (tries == 0)
                {
                    Console.WriteLine("You've run out of tries, sorry!");
                    Console.WriteLine("The number was " + randomNumber + ".");
                    tries = -1;
                }
                else
                {
                    if (guess == randomNumber)
                    {
                        tries -= 1;
                        Console.WriteLine("That was correct, congratulations!");
                        if ((8 - tries) == 1)
                        {
                            Console.WriteLine("You won the game in 1 try!"); // Change the value of x in "(x - tries)" to alter how many guesses the user gets
                        } 
                        else 
                        {
                            Console.WriteLine("You won the game in " + (8 - tries) + " tries!"); // Change the value of x in "(x - tries)" to alter how many guesses the user gets
                        }
                        tries = -1;
                    } 
                    else if (guess > randomNumber)
                    {
                        tries -= 1;
                        Console.WriteLine("Close, but too high!");
                        Console.WriteLine("You have " + tries + " tries remaining.");
                        guess = int.Parse(Console.ReadLine());
                    } 
                    else if (guess < randomNumber)
                    {
                        tries -= 1;
                        Console.WriteLine("Close, but too low!");
                        Console.WriteLine("You have " + tries + " tries remaining.");
                        guess = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
    }
}
