using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstClass fancy = new FirstClass();
            Coach bigBanana = new Coach();

            MyMethod(fancy);
            MyMethod(bigBanana);
        }
        public static void MyMethod(object theObject)
        {
            IFly obj = (IFly)theObject;
            obj.Method();
        }
    }
    public class FirstClass : IFly
    {
        public void Method()
        {
            Console.WriteLine("Champagne and escargo");
        }
    }
    public class Coach : IFly
    {
        public void Method()
        {
            Console.WriteLine("Spirit Airlines");
        }
    }
    interface IFly
    {
        void Method();
    }
}
