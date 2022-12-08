using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace Fluke_PE27_TriviaApp
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        Start:

            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = " https://opentdb.com/api.php?amount=1&type=multiple";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            Console.WriteLine(trivia.results[0].question);
            Console.WriteLine("(Enter the full answer, not the number)");

            Random rand = new Random();
            int randNum = rand.Next(4);
            bool isCorrect = false;

            for (int i = 0; i < 4; ++i)
            {
                string choice = "";

                if (i == randNum)
                {
                    choice = trivia.results[0].correct_answer;
                    isCorrect |= true;
                }
                else
                {
                    if (isCorrect)
                    {
                        choice = trivia.results[0].incorrect_answers[i - 1];
                    }
                    else
                    {
                        choice = trivia.results[0].incorrect_answers[i];
                    }
                }

                Console.WriteLine(i.ToString() + ". " + choice);
            }

            Console.Write("Your Answer: ");
            string input = Console.ReadLine();

            if (input.ToUpper() == trivia.results[0].correct_answer.ToUpper())
            {
                Console.WriteLine("Correct!");
                goto Start;
            }
            else
            {
                Console.WriteLine("Incorrect. The answer was " + trivia.results[0].correct_answer);
                goto Start;
            }
        }
    }
}
