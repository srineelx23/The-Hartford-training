using System.Windows.Forms.VisualStyles;

namespace Exercise_3
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
            CountryLabel = new Label();
            textBox1 = new TextBox();
            StateLabel = new Label();
            textBox2 = new TextBox();
            PostalMail = new CheckBox();
            EmailCheckBox = new CheckBox();
            Male = new RadioButton();
            Female = new RadioButton();
            AddButton = new Button();
            RemoveCountryButton = new Button();
            RemoveStateButton = new Button();
            ShowDetailsButton = new Button();
            CountryListView = new ListView();
            Country = new ColumnHeader();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(22, 38);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(60, 20);
            CountryLabel.TabIndex = 1;
            CountryLabel.Text = "Country";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(99, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 27);
            textBox1.TabIndex = 2;
            // 
            // StateLabel
            // 
            StateLabel.AutoSize = true;
            StateLabel.Location = new Point(39, 87);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new Size(43, 20);
            StateLabel.TabIndex = 3;
            StateLabel.Text = "State";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(99, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(192, 27);
            textBox2.TabIndex = 4;
            // 
            // PostalMail
            // 
            PostalMail.AutoSize = true;
            PostalMail.Location = new Point(22, 144);
            PostalMail.Name = "PostalMail";
            PostalMail.Size = new Size(103, 24);
            PostalMail.TabIndex = 5;
            PostalMail.Text = "Postal Mail";
            PostalMail.UseVisualStyleBackColor = true;
            // 
            // EmailCheckBox
            // 
            EmailCheckBox.AutoSize = true;
            EmailCheckBox.Location = new Point(22, 187);
            EmailCheckBox.Name = "EmailCheckBox";
            EmailCheckBox.Size = new Size(74, 24);
            EmailCheckBox.TabIndex = 6;
            EmailCheckBox.Text = "E-Mail";
            EmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // Male
            // 
            Male.AutoSize = true;
            Male.Location = new Point(131, 144);
            Male.Name = "Male";
            Male.Size = new Size(63, 24);
            Male.TabIndex = 7;
            Male.TabStop = true;
            Male.Text = "Male";
            Male.UseVisualStyleBackColor = true;
            // 
            // Female
            // 
            Female.AutoSize = true;
            Female.Location = new Point(131, 186);
            Female.Name = "Female";
            Female.Size = new Size(78, 24);
            Female.TabIndex = 8;
            Female.TabStop = true;
            Female.Text = "Female";
            Female.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(22, 246);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(103, 29);
            AddButton.TabIndex = 9;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // RemoveCountryButton
            // 
            RemoveCountryButton.Location = new Point(150, 246);
            RemoveCountryButton.Name = "RemoveCountryButton";
            RemoveCountryButton.Size = new Size(141, 29);
            RemoveCountryButton.TabIndex = 10;
            RemoveCountryButton.Text = "Remove Country";
            RemoveCountryButton.UseVisualStyleBackColor = true;
            RemoveCountryButton.Click += RemoveCountryButton_Click;
            // 
            // RemoveStateButton
            // 
            RemoveStateButton.Location = new Point(307, 246);
            RemoveStateButton.Name = "RemoveStateButton";
            RemoveStateButton.Size = new Size(166, 29);
            RemoveStateButton.TabIndex = 11;
            RemoveStateButton.Text = "Remove State";
            RemoveStateButton.UseVisualStyleBackColor = true;
            RemoveStateButton.Click += RemoveStateButton_Click;
            // 
            // ShowDetailsButton
            // 
            ShowDetailsButton.Location = new Point(505, 246);
            ShowDetailsButton.Name = "ShowDetailsButton";
            ShowDetailsButton.Size = new Size(166, 29);
            ShowDetailsButton.TabIndex = 12;
            ShowDetailsButton.Text = "Show Details";
            ShowDetailsButton.UseVisualStyleBackColor = true;
            ShowDetailsButton.Click += ShowDetailsButton_Click;
            // 
            // CountryListView
            // 
            CountryListView.CheckBoxes = true;
            CountryListView.Columns.AddRange(new ColumnHeader[] { Country });
            CountryListView.Location = new Point(351, 12);
            CountryListView.Name = "CountryListView";
            CountryListView.Size = new Size(301, 156);
            CountryListView.TabIndex = 13;
            CountryListView.UseCompatibleStateImageBehavior = false;
            CountryListView.View = View.Details;
            CountryListView.SelectedIndexChanged += CountryListView_SelectedIndexChanged;
            // 
            // Country
            // 
            Country.Tag = "Country";
            Country.Text = "Country";
            Country.Width = 120;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(351, 183);
            comboBox1.Name = "comboBox1";
            comboBox1.Items.Insert(0, "Select State");
            comboBox1.SelectedIndex = 0;
            comboBox1.Size = new Size(301, 28);
            comboBox1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 339);
            Controls.Add(comboBox1);
            Controls.Add(CountryListView);
            Controls.Add(ShowDetailsButton);
            Controls.Add(RemoveStateButton);
            Controls.Add(RemoveCountryButton);
            Controls.Add(AddButton);
            Controls.Add(Female);
            Controls.Add(Male);
            Controls.Add(EmailCheckBox);
            Controls.Add(PostalMail);
            Controls.Add(textBox2);
            Controls.Add(StateLabel);
            Controls.Add(textBox1);
            Controls.Add(CountryLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label CountryLabel;
        private TextBox textBox1;
        private Label StateLabel;
        private TextBox textBox2;
        private CheckBox PostalMail;
        private CheckBox EmailCheckBox;
        private RadioButton Male;
        private RadioButton Female;
        private Button AddButton;
        private Button RemoveCountryButton;
        private Button RemoveStateButton;
        private Button ShowDetailsButton;
        private ListView CountryListView;
        private ComboBox comboBox1;
        private ColumnHeader Country;
    }
}
