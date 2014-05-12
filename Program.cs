using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //the number of right answers
            int right = 0;
            //the number of wrong answers
            int wrong = 0;
            //bool to tell if the user wants to keep playing
            bool playing = true;
            //loops until the user quits
            while (playing)
            {
                //makes a list of trivia objs from trivia.text
                List<Trivia> trivias = GetTriviaList();
                //say intro instrucions
                sayIntro();
                //makes trivia obj for current iteration of game
                Trivia myQA = getQA(trivias);
                //assigns answer from trivia obj
                string answer = askQ(myQA.question);
                //gets users guess and compares it to answer
                if (answerIsRight(myQA, answer))
                {
                    //tells user they are right and increments the number of right guesses
                    sayRight();
                    right++;
                }
                else
                {
                    //tells user they are wrong and increments the number of wrong guesses
                    sayWrong();
                    wrong++;
                }
                //tells the user how many times they have been right and how many time they have been wrong
                Console.WriteLine("you been right " + right + " and you have been wrong " + wrong + " times");
                //asks if the user wants to keep playing and assigns the value to playing
                playing = askKeepPlaying();
            }
        }
        /// <summary>
        /// returns a bool telling if the guess was right
        /// </summary>
        /// <param name="QA">trivia obj that holds answer</param>
        /// <param name="guess">string the users guess</param>
        /// <returns>bool if the users' guess was right</returns>
        static bool answerIsRight(Trivia QA, string guess)
        {
            bool returnValue = false;
            if (QA.answer.ToLower() == guess.ToLower())
            {
                returnValue = true;
            }
            return returnValue;
        }
        /// <summary>
        /// returns a random Trivia obj from list of Trivia parameter
        /// </summary>
        /// <param name="triv">List<Trivia></Trivia></param>
        /// <returns>Trivia obj randomly selected from list</returns>
        static Trivia getQA(List<Trivia> triv)
        {
            var r = new Random();
            return triv[r.Next(1, triv.Count())];
        }
        /// <summary>
        /// asks the user a question and returns a string of the users input
        /// </summary>
        /// <param name="question">string question to ask user</param>
        /// <returns>string users answer</returns>
        static string askQ(string question)
        {
            Console.WriteLine(question);
            string saying = Console.ReadLine();
            return saying;
        }
        /// <summary>
        /// converts text file into a list of Trivia objs and returns the list
        /// </summary>
        /// <returns>List<Trivia></returns>
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r","").Split('\n').ToList();
            //Each item in list "contents" is now one line of the Trivia.txt document.
            List<Trivia> returnlist = new List<Trivia>();
            foreach (var item in contents)
            {
                //empty string to hold type value
                string type = "";
                //if the string has a ":" it has a category at start of the string
                if (item.Contains(":")) 
                    //splits the string and assigns the category to type
                    { type = item.Split(':')[0]; }
                //if the string doesn't have a : it is assigned the default value
                else 
                    { type = "default"; }
                //splits the string at *
                //the first half is the question
                string question = item.Split('*')[0];
                //the second half is the answer
                string answer = item.Split('*')[1];
                //adds a new trivia obj to a list
                returnlist.Add(new Trivia (question, answer, type));
            }
            return returnlist;
        }
        /// <summary>
        /// tells the user about the game
        /// </summary>
        static void sayIntro()
        {
            Console.WriteLine("welcome to the Trivia Game! You will be asked questions, try to answer correctly");
        }
        /// <summary>
        /// tells the user if they guessed right 
        /// </summary>
        static void sayRight()
        {
            Console.WriteLine("You got it right! Pat yourself on the back. You are one sharp cookie!");
        }
        /// <summary>
        /// tells the user if they guessed wrong
        /// </summary>
        static void sayWrong()
        {
            Console.WriteLine("Wrong answer, try harder next time");
        }
        /// <summary>
        /// asks the user if they want to keep playing and returns a bool value of their answer
        /// </summary>
        /// <returns>bool true if they want to play more false otherwise</returns>
        static bool askKeepPlaying()
        {
            //defaults to continue playing
            bool returnValue = true;
            //asks the users if they want to play more
            Console.WriteLine("Do you want to quit? if so type yes or quit");
            //gets input
            string saying = Console.ReadLine();
            //tests input against quiting values, and if same sets returnValue to false
            if (saying.ToLower() == "y" || saying.ToLower() == "yes" || saying.ToLower() == "quit")
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}
