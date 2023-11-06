namespace BallGamesWindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.manyBalls = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manyBalls
            // 
            this.manyBalls.Location = new System.Drawing.Point(685, 44);
            this.manyBalls.Name = "manyBalls";
            this.manyBalls.Size = new System.Drawing.Size(122, 23);
            this.manyBalls.TabIndex = 0;
            this.manyBalls.Text = "Создать Шарики";
            this.manyBalls.UseVisualStyleBackColor = true;
            this.manyBalls.Click += new System.EventHandler(this.manyBalls_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(544, 44);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(135, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "Остановить шарики";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(355, 44);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(183, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "СоздатьДвигающиеся шарики";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.manyBalls);
            this.Name = "MainForm";
            this.Text = "Мячики";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button manyBalls;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button createButton;
    }
}

