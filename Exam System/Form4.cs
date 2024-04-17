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
    public partial class Form4 : Form
    {
        Student Student = new Student();
        ExamContext _context = new ExamContext();
        public Form4(Student student)
        {
            InitializeComponent();
            this.Student = student;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var StudentSubject = _context.StudentSubjects.Where(s => s.StudentId == Student.Id).ToList();
            if (StudentSubject != null)
            {
                foreach (var Subject in StudentSubject)
                {
                    var subjecttable = _context.Subjects.FirstOrDefault(s => s.Id == Subject.SubjectId);
                    if (Subject != null)
                    {
                        string result = (Subject.Grade == null) ? "Not tested yet" : Subject.Grade.ToString();
                        if(result == "Not tested yet")
                        {
                            label1.Text += $"{subjecttable.Name} => {result}\n" +
                                       $"------------------------------------------------------\n";
                        }
                        else
                        {
                        label1.Text += $"{subjecttable.Name} => {result}%\n" +
                                       $"------------------------------------------------------\n";
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
