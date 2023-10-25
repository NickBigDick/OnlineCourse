using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGeniiConsoleApp
{
    internal class Program
    {
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
        //    string[] d = GetDiagnoses();
        //}

        static void Main(string[] args)
        {
            bool work_flag = true;
            while (work_flag)
            {

                Console.WriteLine("Введите Ваше имя?");
                string username = Console.ReadLine();

                int countRightAnswers = 0;
                int countQuestions = 5;

                string[] questions = GetQuestions(countQuestions).Item1;
                int[] answers = GetQuestions(countQuestions).Item2;

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    Console.WriteLine(questions[i]);
                    bool isInputCorrect = false;
                    double userAnswer = 0;
                    while (isInputCorrect == false)
                    {
                        string userInput = Console.ReadLine();
                        isInputCorrect = double.TryParse(userInput, out userAnswer);
                        if (isInputCorrect == false)
                        {
                            Console.WriteLine("Пожалуйста, введите число!");
                            Console.WriteLine("Вопрос №" + (i + 1));
                            Console.WriteLine(questions[i]);
                        }

                    }

                    int rightAnswer = answers[i];
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    Console.WriteLine("Количество правильных ответов: " + countRightAnswers);

                    string diagnose = GetDiagnoses(countRightAnswers, countQuestions);

                    Console.WriteLine($"Дорогой {username}, Ваш диагноз:" + diagnose);
                }
                Console.WriteLine("Пройдем тест снова? y/n");
                if (Console.ReadLine() == "n") { work_flag = false; }
                //комментарий новые по разному всякое
            }
        }
    }
}
