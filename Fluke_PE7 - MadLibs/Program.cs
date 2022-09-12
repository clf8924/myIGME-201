using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fluke_PE7___MadLibs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome and prompt for name
            Console.WriteLine("Do you want to play MadLibs? Y or N.");
            string yesNo = Console.ReadLine();
            if (yesNo != "Y" || yesNo != "N")
            {
                Console.WriteLine("Please enter Y or N.");
                string yesNo = Console.ReadLine();
            } else if (yesNo == "N")
            {
                Console.WriteLine("Goodbye.");
                // I don't know what the command is to exit the application and I can't find it on Google
            } else if (yesNo == "Y") { } //Continues on

            Console.WriteLine("Let's play Mad Libs! Please enter your name.");
            string name = Console.ReadLine();

            int storyCount = 0;

            // Open file and read lines
            StreamReader file;
            file = new StreamReader("c:\\templates\\MadLibsTemplate.txt");
            string line = null;
            while ((line = file.ReadLine()) != null)
            {
                ++storyCount;
            }
            file.Close();

            // Add a number of strings into the array for how many "stories" (lines) there are
            string[] madLibs = new string[storyCount];
            file = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            int count = 0;
            line = null;
            while ((line = file.ReadLine()) != null)
            {
                madLibs[count] = line;\
                madLibs[count] = madLibs[count].Replace("\\n", "\n");
                ++count;
            }
            file.Close();

            // Prompt for story selection
            Console.WriteLine("Great! Choose a story from 1 to " + storyCount + ".");
            int storyNum = Convert.ToInt32(Console.ReadLine());
            if (storyNum > storyCount || storyNum < 0)
            {
                Console.WriteLine("Please enter a valid story.");
                storyNum = int.Parse(Console.ReadLine());
            } else
            {
                Console.WriteLine("You have chosen story " + storyNum + ".");
            }

            string[] words = madLibs[storyNum].Split(' ');

            string[] result = null;

            foreach (string word in words)
            {
                if ()
                {
                    string prompt = word.Replace("_", " ");
                    Console.WriteLine("Enter a word that is a " + prompt + "."); // Confused about how to deliniate what's a placeholder and what isn't
                    string userInput = Console.ReadLine();
                    userInput += result;
                }
                
            }

            Console.WriteLine(madLibs[storyNum]);
        }
    }
}