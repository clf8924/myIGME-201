using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    public interface IMood
    {
        string Mood 
        { 
            get; 
        }
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public HotDrink() 
        {

        }

        public HotDrink(string brand)
        {

        }

        public virtual void AddSugar(byte amount) 
        {

        }

        public abstract void Steam();
    }

    public interface ITakeOrder
    {
        void TakeOrder();
    }

    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get 
            { 
                return "Happy"; 
            }
        }

        public void ServeCustomer(HotDrink cup) 
        {

        }
    }

    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood
        {
            get
            { 
                return "Eager"; 
            }
        }
    }

    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;
        public CupOfCoffee()
        {

        }

        public CupOfCoffee(string brand) : base(brand) 
        { 

        }

        override public void Steam() 
        {

        }

        public void TakeOrder() 
        {

        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;
        public CupOfTea() 
        {

        }

        public CupOfTea(bool customerIsWealthy) 
        {

        }

        override public void Steam() 
        {

        }

        public void TakeOrder() 
        {

        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source
        {
            set 
            { 
                source = value; 
            }
        }

        override public void Steam() 
        {

        }

        override public void AddSugar(byte amount) 
        {

        }

        public void TakeOrder() 
        {

        }

        public CupOfCocoa() : this(false) 
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand") 
        {

        }
    }
}
