

namespace Space
{
    public partial class Form2 : Form
    {
        private int score;
        private Form1 formOne;

        public Form2(int finalScore)
        {
            
            InitializeComponent();
            score = finalScore;
            label2.Text = "FINAL SCORE: " + score;
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}