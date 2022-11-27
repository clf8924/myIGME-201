using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fluke_PE13
{
    public class Pets
    {
        public List<Pet> petList = new List<Pet>();
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }
        public int r
        {
            get
            {
                return this.petList.Count;
            }
        }
        public void Add(Pet pet)
        {
            petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
    }
    public abstract class Pet
    {
        private string name;
        public int age;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }
        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

        public Pet()
        {

        }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine(this.Name + " tries to take a treat, but accidently bites your finger.");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + "grabs a fluffy mouse toy and brings it to you.");
        }
        public void Scratch()
        {
            Console.WriteLine("Your hand now has a new scar... Bad " + this.Name + "!");
        }
        public void Purr()
        {
            Console.WriteLine("After giving " + this.Name + " a scratch on the head, they purr happily.");
        }
        public override void GotoVet()
        {
            Console.WriteLine("It takes you well over 20 minutes to get " + this.Name + " into the car.");
        }
    }
    public class Dog : Pet, IDog
    {
        public string license;

        public override void Eat()
        {
            Console.WriteLine(this.Name + " digs in rather violently, even after being fed this morning.");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + " bumps a tennis ball towards your feet with its nose. You should probably throw it.");
        }
        public void Bark()
        {
            Console.WriteLine("The mailman walked by the front window, and 5 minutes later " + this.Name + " is still barking.");
        }
        public void NeedWalk()
        {
            Console.WriteLine(this.Name + " brings their leash to you and whines.");
        }
        public override void GotoVet()
        {
            Console.WriteLine("After happily jumping in the car at first, " + this.Name + " now refuses to get out after seeing you were in fact not going to the park.");
        }
        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 0; i < 50; i++) {

                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    string inputName = "";
                    int inputAge;
                    string inputLicense = "";

                    if (rand.Next(0, 2) == 1)
                    {
                        Console.WriteLine("\nCongrats, you bought a dog!");

                        Console.Write("Name? ");
                        inputName = Console.ReadLine();

                        Console.Write("License ID? ");
                        inputLicense = Console.ReadLine();

                        Console.Write("Age? ");
                        inputAge = int.Parse(Console.ReadLine());

                        dog = new Dog(inputLicense, inputName, inputAge);
                        pets.Add(dog);
                    }
                    else
                    {
                        Console.WriteLine("\nCongrats, you bought a cat!");

                        Console.Write("Name? ");
                        inputName = Console.ReadLine();

                        Console.Write("Age? ");
                        inputAge = int.Parse(Console.ReadLine());

                        cat = new Cat();

                        cat.Name = inputName;
                        cat.age = inputAge;

                        pets.Add(cat);
                    }
                }
                else if (pets.r != 0)
                {
                    thisPet = pets[rand.Next(0, pets.r)];

                    if (thisPet.GetType() == typeof(Cat))
                    {
                        iCat = (ICat)thisPet;
                        switch (rand.Next(0, 4))
                        {
                            case 0:
                                iCat.Eat();
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                iCat.Purr();
                                break;
                            case 3:
                                iCat.Scratch();
                                break;
                        }
                    }
                    else if (thisPet.GetType() == typeof(Dog))
                    {
                        iDog = (IDog)thisPet;
                        switch (rand.Next(0, 5))
                        {
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Play();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                iDog.GotoVet();
                                break;
                        }
                    }
                }
            }
        }
    }
}