using Fluke_PE11_Q5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles

namespace Fluke_PE11_Q6
{
    internal class Program
    {
        public void AddPassenger(IPassengerCarrier carrier)
        {
            carrier.LoadPassenger()
            Console.WriteLine(carrier.ToString());
        }

        static void Main(string[] args)
        {
            
        }
    }
}
