using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0
            int i = 0; // compile-time error: Missing a semi-colon

            // declare string to hold all numbers
            string allNumbers = null; // compile-time error: allNumbers needs to be declared outside of loop

            // loop through the numbers 1 through 10
            // for (i = 1; i < 10; ++i)
            for (i = 1; i < 11; ++i) // logic-error: change 10 to 11 in order to process 10
            {
                // declare string to hold all numbers
                // string allNumbers = null;

                // output explanation of calculation
                // Console.Write(i + "/" + i - 1 + " = "); 
                Console.Write(i + "/" + (i - 1) + " = "); // compile-time error: needs paranthesis around "i - 1"

                // output the calculation based on the numbers
                // Console.WriteLine(i / (i - 1));
                int x = (i - 1); 
                if (x == 0)
                    {
                        Console.WriteLine("Undefined");
                    } 
                else 
                    {
                        Console.WriteLine((double)i / (double)x);
                    }

                // Compile, logic, run errors: Entire above if/else statement and new "x" variable added to handle undefined, double added to handle decimals

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // i = i + 1;
                // unecessary increase since the for loop already does it
            }

            // output all numbers which have been processed
            // Console.WriteLine("These numbers have been processed: " allNumbers); 
            Console.WriteLine("These numbers have been processed: " + allNumbers); // compile-time error: missing + operator
        }
    }
}
