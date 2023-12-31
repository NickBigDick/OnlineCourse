﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] LabelsMap;
        private const int mapSize = 4;
        private static Random random = new Random();
        private int score = 0;
        private int bestScore = (int) Properties.Settings.Default["theBestScore"];

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
            ShowScore();
            ShowBestScore();

        }

        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }

        private void ShowBestScore()
        {
            if (score > bestScore)
            {
                bestScore = score;
                Properties.Settings.Default["theBestScore"] = bestScore;
                Properties.Settings.Default.Save();
            }
            bestScoreLabel.Text = bestScore.ToString();

        }

        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexCol = randomNumberLabel % mapSize;
                if (LabelsMap[indexRow, indexCol].Text == string.Empty)
                {
                    string[] generativeNumbers = { "2", "2", "2", "4"};
                    var randomValueIndex = random.Next(4);
                    LabelsMap[indexRow, indexCol].Text = generativeNumbers[randomValueIndex];
                    break;
                }
                
            }
        }

        private void InitMap()
        {
            LabelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    LabelsMap[i, j] = newLabel;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Name = "label1";
            label.Size = new Size(70, 70);
            label.TabIndex = 0;
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            label.Location = new Point(x, y);
            return label;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (LabelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j -1; k >= 0; k--)
                            {
                                if (LabelsMap[i, k].Text != string.Empty)
                                {
                                    if (LabelsMap[i, j].Text == LabelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(LabelsMap[i, j].Text);
                                        score += number * 2;
                                        LabelsMap[i, j].Text = (number * 2).ToString();
                                        LabelsMap[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (LabelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (LabelsMap[i, k].Text != string.Empty)
                                {
                                    LabelsMap[i, j].Text = LabelsMap[i, k].Text;
                                    LabelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }            
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (LabelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (LabelsMap[i, k].Text != string.Empty)
                                {
                                    if (LabelsMap[i, j].Text == LabelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(LabelsMap[i, j].Text);
                                        score += number * 2;
                                        LabelsMap[i, j].Text = (number * 2).ToString();
                                        LabelsMap[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (LabelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (LabelsMap[i, k].Text != string.Empty)
                                {
                                    LabelsMap[i, j].Text = LabelsMap[i, k].Text;
                                    LabelsMap[i, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }            
            if (e.KeyCode == Keys.Up)
            {

                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (LabelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (LabelsMap[k, j].Text != string.Empty)
                                {
                                    if (LabelsMap[i, j].Text == LabelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(LabelsMap[i, j].Text);
                                        score += number * 2;
                                        LabelsMap[i, j].Text = (number * 2).ToString();
                                        LabelsMap[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (LabelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (LabelsMap[k, j].Text != string.Empty)
                                {
                                    LabelsMap[i, j].Text = LabelsMap[k, j].Text;
                                    LabelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }            
            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (LabelsMap[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (LabelsMap[k, j].Text != string.Empty)
                                {
                                    if (LabelsMap[i, j].Text == LabelsMap[k, j].Text)
                                    {
                                        var number = int.Parse(LabelsMap[i, j].Text);
                                        score += number * 2;
                                        LabelsMap[i, j].Text = (number * 2).ToString();
                                        LabelsMap[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (LabelsMap[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (LabelsMap[k, j].Text != string.Empty)
                                {
                                    LabelsMap[i, j].Text = LabelsMap[k, j].Text;
                                    LabelsMap[k, j].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            GenerateNumber();
            ShowScore();
            ShowBestScore();

        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Label label in LabelsMap)
            {
                label.Text = string.Empty;
            }
            score = 0;
            GenerateNumber();
            ShowScore();
            changeLabelColor();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь описаны главные правила игры в 2048!", "Правила игры");
        }

        private void changeLabelColor()
        {

            foreach (Label label in LabelsMap)
            {

                int.TryParse(label.Text, out int labelValue);
                int alphaColor = labelValue / 1000 * 256;
                label.BackColor = Color.Azure;
            }
        }

    }
}
