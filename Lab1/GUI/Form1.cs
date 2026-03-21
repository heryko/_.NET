using Lab1;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {

            bool isNValid = int.TryParse(textBox1.Text, out int n);
            bool isSeedValid = int.TryParse(textBox2.Text, out int seed);
            bool isCapValid = int.TryParse(textBox3.Text, out int capacity); 

            if (isNValid && isSeedValid && isCapValid)
            {

                button1.BackColor = Color.LightGreen;

                Problem problem = new Problem(n, seed);
                Result result = problem.Solve(capacity);

                textBox4.Text = result.ToString();
            }
            else
            {

                button1.BackColor = Color.Red;

                MessageBox.Show("Wpisz poprawne liczby");
            }
        }


    }
}
