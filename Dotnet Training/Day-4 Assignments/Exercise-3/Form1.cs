using System.Windows.Forms.VisualStyles;

namespace Exercise_3
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

        private void CountryListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Enter valid Country");
                return;
            }
            ListViewItem item = new ListViewItem(textBox1.Text);
            CountryListView.Items.Add(item);
            comboBox1.Items.Add(textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void RemoveCountryButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in CountryListView.CheckedItems)
            {
                CountryListView.Items.Remove(item);
            }
        }

        private void RemoveStateButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Select A State", "Information", MessageBoxButtons.OK);
                return;
            }
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            comboBox1.SelectedIndex = 0;
        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            if (Male.Checked == true)
            {
                if (PostalMail.Checked == true || EmailCheckBox.Checked == true) 
                {
                    MessageBox.Show("Hello Mr, You will Contacted By USPS or E-Mail","Information",MessageBoxButtons.OKCancel);
                }
                else
                {
                    MessageBox.Show("Hello Mr, Select an option to communicate", "Information", MessageBoxButtons.OKCancel);
                }
            }
            else if(Female.Checked == true)
            {

                if (PostalMail.Checked == true || EmailCheckBox.Checked == true)
                {
                    MessageBox.Show("Hello Ms, You will Contacted By USPS or E-Mail", "Information", MessageBoxButtons.OKCancel);
                }
                else
                {
                    MessageBox.Show("Hello Ms, Select an option to communicate", "Information", MessageBoxButtons.OKCancel);
                }
            }
            else
            {
                MessageBox.Show("Hello Select a Valid Option", "Information", MessageBoxButtons.OKCancel);
            }
        }
    }
}
