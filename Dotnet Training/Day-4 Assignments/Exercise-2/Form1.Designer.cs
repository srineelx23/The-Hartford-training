namespace Exercise_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DateOfBirth = new DateTimePicker();
            label1 = new Label();
            Age = new Label();
            CalculateButton = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // DateOfBirth
            // 
            DateOfBirth.Location = new Point(310, 110);
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.Size = new Size(250, 27);
            DateOfBirth.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 117);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter DOB";
            label1.Click += label1_Click;
            // 
            // Age
            // 
            Age.AutoSize = true;
            Age.Location = new Point(226, 163);
            Age.Name = "Age";
            Age.Size = new Size(69, 20);
            Age.TabIndex = 2;
            Age.Text = "Your Age";
            Age.Click += label2_Click;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(310, 204);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(94, 29);
            CalculateButton.TabIndex = 3;
            CalculateButton.Text = "Calculate";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(552, 350);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 4;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(CalculateButton);
            Controls.Add(Age);
            Controls.Add(label1);
            Controls.Add(DateOfBirth);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker DateOfBirth;
        private Label label1;
        private Label Age;
        private Button CalculateButton;
        private Button button2;
    }
}
