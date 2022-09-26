using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Fluke_Exam1_Q4
{
    internal class Program
    {
        static System.Timers.Timer TimeOutTimer;
        static bool timeUp = false;

        static string answer = "";

        static void Main(string[] args)
        {
            string question = "";
            string userAns = "";
            int qAns = 0;

            start:
            Console.WriteLine("");
            Console.Write("Choose your question (1-3): ");
            qAns = Convert.ToInt32(Console.ReadLine());

            if (qAns == 1)
            {
                question = "What is your favorite color?";
                answer = "black";
            } else if (qAns == 2)
            {
                question = "What is the answer to life, the universe and everything?";
                answer = "42";
            } else if (qAns == 3)
            {
                question = "What is the airspeed velocity of an unladen swallow?";
                answer = "What do you mean? African or European swallow?";
            } else
            {
               Console.WriteLine("Please enter a number 1-3.");
               goto start;
            }

            Console.WriteLine("You have 5 seconds to answer the following question:");
            TimeOutTimer = new System.Timers.Timer(5000);
            TimeOutTimer.Elapsed += new ElapsedEventHandler(TimeUp);
            TimeOutTimer.Start();

            Console.WriteLine(question);
            userAns = Console.ReadLine();

            TimeOutTimer.Stop();

            if (userAns == answer && !timeUp)
            {
                Console.WriteLine("Well Done!");
            }
            else if (!timeUp)
            {
                Console.WriteLine("Wrong! The answer is: " + answer);
            }

            Console.Write("Play again? ");
            string qAgain = Console.ReadLine();
            if (qAgain.StartsWith("y"))
            {
                goto start;
            } else if (qAgain.StartsWith("n"))
            {
                return; // Even with google I cannot for the life of me find out how to exit the console without getting the "press any key" to pop up
            }
        }
        public static void TimeUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: " + answer);
            Console.WriteLine("Please press enter.");
            TimeOutTimer.Stop();
            timeUp = true;
        }
    }
}
