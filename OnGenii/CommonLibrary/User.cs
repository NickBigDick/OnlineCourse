using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonLibrary
{
    public class User
    {
        public string Name { get; }
        public string Diagnose { get; set; }
        public UserResultStorage Storage { get; }

        public void AddResult(string result)
        {
            Storage.Results.Add(result);
        }

        public void ShowResults()
        {
            foreach (string result in Storage.Results)
            {
                Console.WriteLine(result);
            }
        }

        public User(string name)
        {
            Name = name;
            Storage = new UserResultStorage(this);

        }

        public void SetDiagnose(int rightAnswers, int totalQuestions)
        {
            int index;
            string[] diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гении";
            if (rightAnswers > 0)
            {

                double percentage = (double)rightAnswers / totalQuestions;
                index = (int)Math.Round(percentage * 6.0) - 1;
            }
            else
            {
                index = 0;
            }
            Diagnose = diagnoses[index];

        }
    }
}
