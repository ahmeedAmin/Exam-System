using Exam_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_System
{
    public partial class Form2 : Form
    {
        ExamContext _context = new ExamContext();
        public Student CurrentStudent { get; set; }
        public Form2(Student _currentstudent)
        {
            InitializeComponent();
            CurrentStudent = _currentstudent;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = $"Name : {CurrentStudent.Name}";
            label2.Text = $"UserName : {CurrentStudent.UserName}";
            label3.Text = $"Hello {CurrentStudent.Name},";
            try
            {
                var subjects = (from ss in _context.StudentSubjects
                                join s in _context.Subjects on ss.SubjectId equals s.Id
                                where ss.StudentId == CurrentStudent.Id
                                select s).ToList();

                if (subjects.Any())
                {
                    comboBox1.DataSource = subjects;
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("No subjects found for the current student.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}");
            }
            //foreach (var subject in subjects)
            //{
            //    comboBox1.Items.Add(subject);
            //}


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sublectid = (int)comboBox1.SelectedValue;
            var existingExam = _context.StudentExams
            .Any(se => se.StudentId == CurrentStudent.Id && se.Exam.SubjectId == sublectid);
            if (existingExam)
            {
                MessageBox.Show("You have already taken this exam.");
            }
            else
            {
                Form3 form3 = new Form3(sublectid, CurrentStudent);
                this.Hide();
                form3.Show();
            }
            //Form3 form3 = new Form3(sublectid, CurrentStudent);
            //this.Hide();
            //form3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(CurrentStudent);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
            
        }
    }
}
