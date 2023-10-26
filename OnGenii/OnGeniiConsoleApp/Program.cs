using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGeniiConsoleApp
{
    internal class Program
    {
        public class User
        {
            public string Name { get; }
            public UserResultStorage Storage { get; }

            public void AddResult(string result)
            {
                Storage.Results.Add(result);
            }

            public void ShowResults()
            {
                foreach(string result in Storage.Results)
                {
                    Console.WriteLine(result);
                }
            }

            public User(string name)
            {
                Name = name;
                Storage = new UserResultStorage(this);

            }
        }

        public class UserResultStorage
        {
            public User User { get; }
            public List<string> Results { get; set; }
            public UserResultStorage(User user)
            {
                User = user;
                Results = new List<string>();
            }
        }
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
        public class QuestionStorage
        {
            public List<Question> Questions { get; set; }
            public QuestionStorage()
            {
                Questions = new List<Question>()
                {
                    new Question("Сколько будет два плюс два умноженное на два?", 6),
                    new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                    new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                    new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                    new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
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

        }
        static (string[], int[]) GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;

            string[] shufQuestions = new string[countQuestions];
            int[] shufAnswers = new int[countQuestions];

            int[] shufIndexes = {-1, -1, -1, -1, -1};
            Random random = new Random();
            for (int i = 0; i < questions.Length; i++)
            {
                int index = random.Next(countQuestions);
                while (shufIndexes.Contains(index))
                {
                    index = random.Next(countQuestions);
                }
                shufIndexes[i] = index;
                shufQuestions[i] = questions[index];
                shufAnswers[i] = answers[index];
            }

            return (shufQuestions, shufAnswers);
        }


        static string GetDiagnoses(int rightAnswers, int totalQuestions)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гении";

            double percentage =  (double) rightAnswers / totalQuestions;
            int index = (int) Math.Round(percentage * 6.0);
            return diagnoses[index];

        }

        //static void Main(string[] args)
        //{
        //    QuestionStorage questionStorage = new QuestionStorage();
        //    User user = new User("Коля");
        //    user.AddResult("вот первый результат");
        //    user.ShowResults();
        //    questionStorage.AddQuestion(new Question("Сколько ног у коровы?", 4));
        //    questionStorage.AddQuestion(new Question("Сколько ног у коровы?", 4));
        //    questionStorage.RemoveQuestion("Сколько ног у коровы?");
        //    foreach (Question question in questionStorage.Questions)
        //    {
        //        Console.WriteLine(question.Quest);
        //    }
        //}

        static void Main(string[] args)
        {
            bool work_flag = true;
            Console.WriteLine("Введите Ваше имя?");
            User user = new User(Console.ReadLine());
            int countRightAnswers = 0;
            int countQuestions = 5;
            while (work_flag)
            {


                QuestionStorage questionStorage = new QuestionStorage();
                foreach (Question question in questionStorage.Questions)
                {
                    Console.WriteLine(question.Quest);
                    bool isInputCorrect = false;
                    double userAnswer = 0;
                    while (isInputCorrect == false)
                    {
                        string userInput = Console.ReadLine();
                        isInputCorrect = double.TryParse(userInput, out userAnswer);
                        if (isInputCorrect == false)
                        {
                            Console.WriteLine("Пожалуйста, введите число!");
                            Console.WriteLine(question.Quest);
                        }
                        int rightAnswer = question.Answer;
                        if (userAnswer == rightAnswer)
                        {
                            countRightAnswers++;
                        }
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                string diagnose = GetDiagnoses(countRightAnswers, countQuestions);
                Console.WriteLine($"Дорогой {user.Name}, Ваш диагноз:" + diagnose);



                //запись результата игры
                using (FileStream fstream = new FileStream("results.txt", FileMode.Append))
                {
                    string result = string.Format("|| {0, -15} || {1, 5} || {2, 10}||\n", user.Name, countRightAnswers, diagnose);
                    user.AddResult(result);

                    byte[] buffer = Encoding.Default.GetBytes(result);

                    fstream.Write(buffer, 0, buffer.Length);
                }
                user.ShowResults();

                Console.WriteLine("Пройдем тест снова? y/n");
                if (Console.ReadLine() == "n") { work_flag = false; }
                //комментарий новые по разному всякое
            }
        }
    }
}
