using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_Final_Q2
{
    public class MyQueue
    {
        public List<int> myQueue = new List<int>();

        public void Enqueue(int i)
        {
            myQueue.Insert(0, i);
        }

        public int? Peek()
        {
            if (myQueue.Count > 0)
            {
                return myQueue[0];
            } 
            else 
            {
                return null;
            }
            
        }

        public int? Dequeue()
        {
            if (myQueue.Count > 0)
            {
                int? i = myQueue[0];
                myQueue.RemoveAt(0);
                return i;
            } 
            else 
            {
                return null;
            }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
