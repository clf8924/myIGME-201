using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_Exam2_Q10
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public abstract class Chainmail
    {
        public int linkCount;
        public int weight;
        public virtual void addLink()
        {

        }
        public abstract void pattern();
    }
    public interface Weave
    {
        void typeOf();
    }
    public interface Pattern
    {
        void metal();
    }
    public class Shirt : Chainmail
    {
        public override void pattern()
        {

        }
        public void metal()
        {

        }
        public void typeOf()
        {

        }
    }
    public class Glove :Chainmail, Weave, Pattern
    {
        public override void pattern()
        {

        }
        public void metal()
        {

        }
        public void typeOf()
        {

        }
    }
}
