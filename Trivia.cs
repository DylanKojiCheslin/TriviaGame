using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Trivia
    {
        public string question     {get; set;}
        public string answer { get; set; }
        public string type { get; set; }

        public Trivia(string question, string anwser, string type)
        {
            this.answer = anwser;
            this.question = question;
            this.type = type;
        }
    }
}
