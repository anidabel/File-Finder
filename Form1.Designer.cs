﻿namespace lab01
{
    partial class Form1
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
            this.templateBox = new System.Windows.Forms.CheckBox();
            this.templateText = new System.Windows.Forms.TextBox();
            this.substringBox = new System.Windows.Forms.CheckBox();
            this.substringText = new System.Windows.Forms.TextBox();
            this.directoryBox = new System.Windows.Forms.CheckBox();
            this.directoryText = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // templateBox
            // 
            this.templateBox.AutoSize = true;
            this.templateBox.Location = new System.Drawing.Point(8, 20);
            this.templateBox.Margin = new System.Windows.Forms.Padding(2);
            this.templateBox.Name = "templateBox";
            this.templateBox.Size = new System.Drawing.Size(181, 17);
            this.templateBox.TabIndex = 0;
            this.templateBox.Text = "поиск по заданнному шаблону";
            this.templateBox.UseVisualStyleBackColor = true;
            this.templateBox.CheckedChanged += new System.EventHandler(this.templateBox_CheckedChanged);
            // 
            // templateText
            // 
            this.templateText.Location = new System.Drawing.Point(247, 14);
            this.templateText.Margin = new System.Windows.Forms.Padding(2);
            this.templateText.Name = "templateText";
            this.templateText.Size = new System.Drawing.Size(262, 20);
            this.templateText.TabIndex = 1;
            this.templateText.TextChanged += new System.EventHandler(this.templateText_TextChanged);
            // 
            // substringBox
            // 
            this.substringBox.AutoSize = true;
            this.substringBox.Location = new System.Drawing.Point(8, 41);
            this.substringBox.Margin = new System.Windows.Forms.Padding(2);
            this.substringBox.Name = "substringBox";
            this.substringBox.Size = new System.Drawing.Size(146, 17);
            this.substringBox.TabIndex = 2;
            this.substringBox.Text = "содержащие подстроку";
            this.substringBox.UseVisualStyleBackColor = true;
            this.substringBox.CheckedChanged += new System.EventHandler(this.substringBox_CheckedChanged);
            // 
            // substringText
            // 
            this.substringText.Location = new System.Drawing.Point(247, 39);
            this.substringText.Margin = new System.Windows.Forms.Padding(2);
            this.substringText.Name = "substringText";
            this.substringText.Size = new System.Drawing.Size(262, 20);
            this.substringText.TabIndex = 3;
            this.substringText.TextChanged += new System.EventHandler(this.substringText_TextChanged);
            // 
            // directoryBox
            // 
            this.directoryBox.AutoSize = true;
            this.directoryBox.Location = new System.Drawing.Point(8, 62);
            this.directoryBox.Margin = new System.Windows.Forms.Padding(2);
            this.directoryBox.Name = "directoryBox";
            this.directoryBox.Size = new System.Drawing.Size(218, 17);
            this.directoryBox.TabIndex = 4;
            this.directoryBox.Text = "начиная с определенного директория";
            this.directoryBox.UseVisualStyleBackColor = true;
            this.directoryBox.CheckedChanged += new System.EventHandler(this.directoryBox_CheckedChanged);
            // 
            // directoryText
            // 
            this.directoryText.Location = new System.Drawing.Point(247, 62);
            this.directoryText.Margin = new System.Windows.Forms.Padding(2);
            this.directoryText.Name = "directoryText";
            this.directoryText.Size = new System.Drawing.Size(262, 20);
            this.directoryText.TabIndex = 5;
            this.directoryText.TextChanged += new System.EventHandler(this.directoryText_TextChanged);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Lime;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(15, 389);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 33);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(15, 97);
            this.listBox.Margin = new System.Windows.Forms.Padding(2);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(494, 277);
            this.listBox.TabIndex = 9;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Red;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Location = new System.Drawing.Point(419, 389);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 33);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Silver;
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.Location = new System.Drawing.Point(146, 389);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(90, 33);
            this.pauseButton.TabIndex = 11;
            this.pauseButton.Text = "PAUSE";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.BackColor = System.Drawing.Color.Silver;
            this.resumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resumeButton.Location = new System.Drawing.Point(278, 389);
            this.resumeButton.Margin = new System.Windows.Forms.Padding(2);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(90, 33);
            this.resumeButton.TabIndex = 12;
            this.resumeButton.Text = "RESUME";
            this.resumeButton.UseVisualStyleBackColor = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(534, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTheAuthorToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // aboutTheAuthorToolStripMenuItem
            // 
            this.aboutTheAuthorToolStripMenuItem.Name = "aboutTheAuthorToolStripMenuItem";
            this.aboutTheAuthorToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aboutTheAuthorToolStripMenuItem.Text = "About author";
            this.aboutTheAuthorToolStripMenuItem.Click += new System.EventHandler(this.aboutTheAuthorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 431);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.directoryText);
            this.Controls.Add(this.directoryBox);
            this.Controls.Add(this.substringText);
            this.Controls.Add(this.substringBox);
            this.Controls.Add(this.templateText);
            this.Controls.Add(this.templateBox);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(550, 470);
            this.MinimumSize = new System.Drawing.Size(550, 470);
            this.Name = "Form1";
            this.Text = "Form";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox templateBox;
        private System.Windows.Forms.TextBox templateText;
        private System.Windows.Forms.CheckBox substringBox;
        private System.Windows.Forms.TextBox substringText;
        private System.Windows.Forms.CheckBox directoryBox;
        private System.Windows.Forms.TextBox directoryText;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheAuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

    }
}

