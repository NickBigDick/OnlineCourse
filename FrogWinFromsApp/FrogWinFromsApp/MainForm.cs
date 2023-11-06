using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogWinFromsApp
{
    public partial class MainForm : Form
    {
        public int counter = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void rightPictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox) sender);
            if (WinnerCombination())
            {
                MessageBox.Show($"Поздравляем, Вы победили за {counter} шага(ов)");
            }
        }

        private void Swap(PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distance > 2)
            {
                MessageBox.Show("Так нельзя");
            }
            else
            {
                var location = clickedPicture.Location;
                clickedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                counter += 1;
                counterLabel.Text = $"Количество шагов - {counter}";
            }
        }

        private bool WinnerCombination()
        {
            var border = emptyPictureBox.Location.X;
            if (leftPictureBox1.Location.X > border &&
                leftPictureBox2.Location.X > border &&
                leftPictureBox3.Location.X > border &&
                leftPictureBox4.Location.X > border &&
                rightPictureBox1.Location.X < border &&
                rightPictureBox2.Location.X < border &&
                rightPictureBox3.Location.X < border &&
                rightPictureBox4.Location.X < border )

            {
                return true;
            }
            return false;
        }
    }
}
