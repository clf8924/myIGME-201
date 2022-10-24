using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestQ14
{
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthday;
        public string address;

        public Friend(string name, string greeting, DateTime birthday, string address)
        {
            this.name = name;
            this.greeting = greeting;
            this.birthday = birthday;
            this.address = address;
        }
        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Friend friend;
            Friend enemy;

            friend = new Friend("Charlie Sheen", "Dear Charlie", DateTime.Parse("1967-12-25"), "123 Any Street, NY NY 12202");

            enemy = (Friend)friend.Shallowcopy();

            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}