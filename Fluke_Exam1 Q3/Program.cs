using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_Exam1_Q3
{
    internal class Program
    {
        delegate double MyRound(double a);  
        static void Main(string[] args)
        {
            MyRound myRound;
            myRound = new MyRound(Math.Round);
            Console.WriteLine("Please enter a decimal to be rounded to an integer.");
            double input = Convert.ToDouble(Console.ReadLine());
            double result = myRound(input);
            Console.WriteLine("Your rounded decimal is: " + result + ".");
        }
    }
}
