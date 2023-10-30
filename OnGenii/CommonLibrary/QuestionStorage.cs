using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CommonLibrary
{
    public class QuestionStorage
    {
        public List<Question> Questions { get; set; }
        public QuestionStorage()
        {
            Questions = new List<Question>()
                {
                    new Question("Сколько будет два плюс два умноженное на два?", 6),
                    //new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                    //new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                    //new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                    //new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
                };
        }
        public void AddQuestion(Question quest)
        {
            Questions.Add(quest);
        }

        public void RemoveQuestion(string quest)
        {
            bool r = Questions.RemoveAll(q => q.Quest == quest) == 0;
            if (r) { Console.WriteLine("Вопрос не найден"); } else { Console.WriteLine("Вопрос удален"); }
        }

        public List<Question> GetQuestions()
        {
            return Questions;
        }
    }
}
