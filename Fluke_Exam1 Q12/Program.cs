using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_Exam1_Q12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;
            sName = Console.ReadLine();
            if (sName == "Collin" || sName == "collin")
            {
                GiveRaise(sName, ref dSalary);
            }
            
        }
        static bool GiveRaise(string name, ref double salary)
        {
            
        }
    }
}
