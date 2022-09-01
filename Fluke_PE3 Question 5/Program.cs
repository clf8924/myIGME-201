using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE3_Question_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt for first interval
            Console.Write("Please enter an integer: ");
            int firstInt = Convert.ToInt32(Console.ReadLine());

            // Prompt for second interval
            Console.Write("Please enter another integer: ");
            int secondInt = Convert.ToInt32(Console.ReadLine());

            // Prompt for third interval
            Console.Write("Please enter a third integer: ");
            int thirdInt = Convert.ToInt32(Console.ReadLine());

            // Prompt for fourth interval
            Console.Write("Please enter the last integer: ");
            int fourthInt = Convert.ToInt32(Console.ReadLine());

            // Add and display the product of the 4 integers
            Console.WriteLine("The product of the integers you entered is: " + (firstInt * secondInt * thirdInt * fourthInt));
        }
    }
}
