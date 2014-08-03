namespace EarTrainer
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noteButton = new System.Windows.Forms.Button();
            this.intervalButton = new System.Windows.Forms.Button();
            this.repeatButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.note1Box = new System.Windows.Forms.ComboBox();
            this.intervalBox = new System.Windows.Forms.ComboBox();
            this.directionBox = new System.Windows.Forms.ComboBox();
            this.showTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // noteButton
            // 
            this.noteButton.Location = new System.Drawing.Point(30, 28);
            this.noteButton.Name = "noteButton";
            this.noteButton.Size = new System.Drawing.Size(71, 23);
            this.noteButton.TabIndex = 0;
            this.noteButton.Text = "Note";
            this.noteButton.UseVisualStyleBackColor = true;
            this.noteButton.Click += new System.EventHandler(this.noteButton_Click);
            // 
            // intervalButton
            // 
            this.intervalButton.Location = new System.Drawing.Point(107, 12);
            this.intervalButton.Name = "intervalButton";
            this.intervalButton.Size = new System.Drawing.Size(50, 39);
            this.intervalButton.TabIndex = 1;
            this.intervalButton.Text = "Interval";
            this.intervalButton.UseVisualStyleBackColor = true;
            this.intervalButton.Click += new System.EventHandler(this.intervalButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.Location = new System.Drawing.Point(21, 73);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(69, 32);
            this.repeatButton.TabIndex = 2;
            this.repeatButton.Text = "Repeat";
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(107, 82);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(50, 34);
            this.showButton.TabIndex = 3;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(205, 82);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(59, 34);
            this.playButton.TabIndex = 4;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // note1Box
            // 
            this.note1Box.FormattingEnabled = true;
            this.note1Box.Items.AddRange(new object[] {
            "C4",
            "C#4",
            "D4",
            "D#4",
            "E4",
            "F4",
            "F#4",
            "G4",
            "G#4",
            "A4",
            "A#4",
            "B4",
            "C5"});
            this.note1Box.Location = new System.Drawing.Point(12, 135);
            this.note1Box.Name = "note1Box";
            this.note1Box.Size = new System.Drawing.Size(78, 21);
            this.note1Box.TabIndex = 5;
            this.note1Box.Text = "C4";
            // 
            // intervalBox
            // 
            this.intervalBox.FormattingEnabled = true;
            this.intervalBox.Items.AddRange(new object[] {
            "P0",
            "m2",
            "M2",
            "m3",
            "M3",
            "P4",
            "A4",
            "P5",
            "m6",
            "M6",
            "m7",
            "M7",
            "P8",
            "No interval"});
            this.intervalBox.Location = new System.Drawing.Point(107, 145);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(80, 21);
            this.intervalBox.TabIndex = 6;
            this.intervalBox.Text = "P1";
            // 
            // directionBox
            // 
            this.directionBox.FormattingEnabled = true;
            this.directionBox.Items.AddRange(new object[] {
            "Up",
            "Down"});
            this.directionBox.Location = new System.Drawing.Point(205, 163);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(93, 21);
            this.directionBox.TabIndex = 7;
            this.directionBox.Text = "Up";
            // 
            // showTextBox
            // 
            this.showTextBox.Location = new System.Drawing.Point(182, 31);
            this.showTextBox.Name = "showTextBox";
            this.showTextBox.Size = new System.Drawing.Size(132, 20);
            this.showTextBox.TabIndex = 8;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 242);
            this.Controls.Add(this.showTextBox);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.intervalBox);
            this.Controls.Add(this.note1Box);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.intervalButton);
            this.Controls.Add(this.noteButton);
            this.Name = "Gui";
            this.Text = "EarTrainer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noteButton;
        private System.Windows.Forms.Button intervalButton;
        private System.Windows.Forms.Button repeatButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ComboBox note1Box;
        private System.Windows.Forms.ComboBox intervalBox;
        private System.Windows.Forms.ComboBox directionBox;
        private System.Windows.Forms.TextBox showTextBox;
    }
}