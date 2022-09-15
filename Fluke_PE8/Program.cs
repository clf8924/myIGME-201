using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE8_Question_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            double[] precipitation = new double[4] {0.45, 2.78, 0.04, 1.22};
            Console.WriteLine(precipitation);
            */

            /*
            int[] ascendingNumbers = new int[5];
            for (int i = 0; i < ascendingNumbers.Length; i++)
            {
                ascendingNumbers[i] = 1+i;
            }
            Console.WriteLine("[{0}]", string.Join(", ", ascendingNumbers));
            */

            /*
            z = 3y2 + 2x - 1
            - 1 <= x <= 1 in 0.1 increments
              1 <= y <= 4 in 0.1 increments

            double[,,] comp1 = new double[1, 2, 3];
            */

            Console.WriteLine("Enter a string to be reversed.");
            string str = Console.ReadLine();

            int x = str.Length - 1;
            string str1 = "";
            for (int i = x; i >= 0; i--)
            {
                str1 = str1 + str[i];
            }
            Console.WriteLine("Reversed: {0}", str1);
        }
    }
}
