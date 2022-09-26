using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function 
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY  Compile error: forgot semicolon breaker
            int nY;
            int nAnswer;

            // Console.WriteLine(This program calculates x ^ y.); Compile error: forgot quotations
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                // Console.ReadLine();  Compile error: didn't assign sNumber before calling
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } // while (int.TryParse(sNumber, out nX));  logic error: need to assign nY instead of nX, and needs an ! before int
            while (!int.TryParse(sNumber, out nY));

            // compute the exponent of the number using a recursive function 
            nAnswer = Power(nX, nY);

            // Console.WriteLine("{nX}^{nY} = {nAnswer}");  Runtime error: needs $
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }

        // int Power(int nBase, int nExponent)  Compile error: needs to be static
        static int Power(int nBase, int nExponent) 
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1) 
            if (nExponent == 0)
            {
                // return the base case and do not recurse 
                // returnVal = 0;  Logic error: should return 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case 
                // nextVal = Power(nBase, nExponent + 1);  Logic error: says to use nExponent - 1
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values 
                returnVal = nBase * nextVal;
            }

            // returnVal; Compile error: needs to have return keyword
            return returnVal;
        }
    }
}
