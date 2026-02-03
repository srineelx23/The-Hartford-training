namespace Exercise_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dob = DateOfBirth.Value;
            TimeSpan tm = DateTime.Now - dob;
            int age = (tm.Days / 365);
            Age.Text += age.ToString() + "Yrs\n"+"TimeSpan is: "+tm+"\ndob is: "+dob;
        }
    }
}
