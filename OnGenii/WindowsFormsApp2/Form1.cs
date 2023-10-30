using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLibrary ;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int countQuestions;
        public int countRightAnswers;
        public int questionNumber;
        public bool endGame;
        private User user;

        public bool DontHaveQuestions(List<Question> questions)
        {
            return questions.Count == 0;
        }

        public void SaveResult(string result)
        {
            using (FileStream fstream = new FileStream("result.txt", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(result + "\n");
                fstream.Write(buffer, 0, buffer.Length);
            }
        }

        public void ReadResults()
        {
            using (FileStream fstream = File.OpenRead("result.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                MessageBox.Show(textFromFile);
            }
        }

        public void NewGame()
        {
            questions = new QuestionStorage().Questions;
            countQuestions = questions.Count;
            questionNumber = 0;
            countRightAnswers = 0;
            user = new User("Неизвестно");
            ShowNextQuestion();
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        private void ShowNextQuestion()
        {
            if (DontHaveQuestions(questions))
            {
                MessageBox.Show("Извините, список вопросов пуст! Начните игру заново");
            }
            else
            {
                questionNumber++;
                questionNumberLabel.Text = $"Вопрос №{questionNumber.ToString()}";
                Random random = new Random();
                int randomIndex = random.Next(questions.Count);
                currentQuestion = questions[randomIndex];
                questionTextLabel.Text = currentQuestion.Quest;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (DontHaveQuestions(questions))
            {
                MessageBox.Show("Извините, список вопросов пуст! Начните игру заново");
                return;
            }

            double userAnswer;
            bool isInputCorrect = double.TryParse(userAnswerTextBox.Text, out userAnswer);
            if (isInputCorrect == false)
            {
                MessageBox.Show($"Пожалуйста, введите число!");
            }
            else
            {
                int rightAnswer = currentQuestion.Answer;
                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
                questions.Remove(currentQuestion);
                if (DontHaveQuestions(questions))
                {
                    user.SetDiagnose(countRightAnswers, countQuestions);
                    string result = $"{user.Name}, Количество правильных ответов: {countRightAnswers} из {countQuestions}, Диагноз: {user.Diagnose}";
                    MessageBox.Show(result);
                    SaveResult(result);
                    return;
                }
                else
                {
                    ShowNextQuestion();
                    
                }
            }
        }


        private void newgameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showresultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadResults();
        }
    }
}
