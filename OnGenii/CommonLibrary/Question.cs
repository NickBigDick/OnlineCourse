using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Question
    {
        public string Quest { get; set; }
        public int Answer { get; set; }
        public Question(string question, int answer)
        {
            Quest = question;
            Answer = answer;
        }
    }
}
