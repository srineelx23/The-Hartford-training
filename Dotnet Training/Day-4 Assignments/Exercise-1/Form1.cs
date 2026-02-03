namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Name: " + textBox1.Text;
            str += "\nFather's Name: " + textBox2.Text;
            str += "\nDate Of Birth: " + dateTimePicker1.Text;
            str += "\nPreferences in Life: " + comboBox1.Text;
            MessageBox.Show(str);
        }
    }
}
