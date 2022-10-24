using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE4_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in two integers.");
            Console.WriteLine("One must be greater than 10 and the other must be less than or equal to 10.");
            int num1 = Int32.Parse(Console.ReadLine());
            int num2 = Int32.Parse(Console.ReadLine());
            if (!((num1 > 10)^(num2 > 10)))
            {
                Retry:
                Console.WriteLine("Please re-enter your numbers, one or both did not fit the required formatting.");
                Console.WriteLine("Reminder: One input must be greater than 10 and the other must be less than or equal to 10.");
                num1 = Int32.Parse(Console.ReadLine());
                num2 = Int32.Parse(Console.ReadLine());
                if (!((num1 > 10) ^ (num2 > 10)))
                {
                    goto Retry;
                }
                else { }
            }
            Console.WriteLine("The numbers you entered were: \n Number 1: " + num1 + "\n Number 2: " + num2);
        }
    }
}
