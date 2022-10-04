using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass dClass = new MyDerivedClass(); // New instance of the derived class
            Console.WriteLine(dClass.GetString());
        }
    }
    public class MyClass // Original class with the purpose of setting a string to be outputted
    {
        private string myString;
        public string MyString
        {
            set // Makes MyString write-only
            {
                this.myString = value;
            }
        }
        public virtual string GetString()
        {
            return this.myString;
        }
    }
    public class MyDerivedClass : MyClass // Derived from MyClass with the purpose of adding a string onto the original output
    {
        override public string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }
    }
}
