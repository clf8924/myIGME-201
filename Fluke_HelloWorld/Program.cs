using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prints given string; in this case, my name
            Console.WriteLine("Collin Fluke");

            // Prints a blank paragraph?
            ObsoleteAttribute x = null; // Note: cannot use quatations to print string in place of null
            Console.WriteLine(x);
        }
    }
}
