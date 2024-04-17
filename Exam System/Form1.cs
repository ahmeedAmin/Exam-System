using Exam_System.Models;

namespace Exam_System
{
    public partial class Form1 : Form
    {
        ExamContext _context = new ExamContext();
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
            var UserName = textBox1.Text;
            var Password = textBox2.Text;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Both username and password are required.");
            }
            else
            {
                Student student = _context.Students.FirstOrDefault(s => s.UserName == UserName);
                if (student != null && student.Password == Password)
                {
                    MessageBox.Show("Login successful!");
                    Form2 form2 = new Form2(student);
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
