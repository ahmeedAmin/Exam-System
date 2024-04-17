using Exam_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Exam_System
{
    public partial class Form3 : Form
    {
        ExamContext _context = new ExamContext();
        Student CurrentStudent = new Student();
        Subject Subject = new Subject();
        Exam Exam = new Exam();
        List<Question> Questions;
        int userResponse = 0;
        int count = 0;
        List<int> UserAnswer;

        public Form3(int subjectid, Student student)
        {
            InitializeComponent();
            Subject.Id = subjectid;
            CurrentStudent = student;
            Exam = _context.Exams.FirstOrDefault(e => e.SubjectId == Subject.Id);
            Questions = _context.Questions
                        .Where(q => q.ExamId == Exam.Id)
                        .OrderBy(q => Guid.NewGuid())
                        .Take(5)
                        .ToList();
            UserAnswer = new List<int>(new int[Questions.Count]);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Exam != null)
            {
                if (Questions != null && Questions.Count > 0)
                {
                    DisplayQuestion(Questions[count]);
                }
                else
                {
                    MessageBox.Show("No questions found in the exam");
                }
            }
            else
            {
                MessageBox.Show("No exam found for the subject");
            }
        }
        private void DisplayQuestion(Question question)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            label1.Text = question.Body;
            radioButton1.Text = question.Option1;
            radioButton2.Text = question.Option2;
            radioButton3.Text = question.Option3;
            radioButton4.Text = question.Option4;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                radiochecked();
                count--;
                DisplayQuestion(Questions[count]);
            }
            else
            {
                MessageBox.Show("This is the first question");
            }
            SetRadioButtonStates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radiochecked();
            if (count < Questions.Count - 1)
            {
                count++;
                DisplayQuestion(Questions[count]);
            }
            else
            {
                MessageBox.Show("This is the last question");
            }
            SetRadioButtonStates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int correctCount = 0;
            int totalQuestions = Questions.Count;

            for (int i = 0; i < totalQuestions; i++)
            {
                int? userAnswer = UserAnswer[i];
                int correctAnswer = Questions[i].CorrectAnswer;
                if (userAnswer == correctAnswer)
                {
                    correctCount++;
                }
            }

            double grade = (double)correctCount / totalQuestions * 100;
            StudentExam studentExam = _context.StudentExams.FirstOrDefault(se => se.StudentId == CurrentStudent.Id && se.ExamId == Exam.Id);
            StudentSubject studentSubject = _context.StudentSubjects.FirstOrDefault(se => se.StudentId == CurrentStudent.Id && se.SubjectId == Exam.SubjectId);
            if (studentExam != null)
            {
                MessageBox.Show("You have been tested before");
            }
            else
            {
                studentExam = new StudentExam
                {
                    StudentId = CurrentStudent.Id,
                    ExamId = Exam.Id,
                    Grade = grade
                };
                if (studentSubject.Grade != null)
                {
                    studentSubject.Grade += grade;
                }
                else
                {
                    studentSubject.Grade = grade;
                }
                _context.StudentExams.Add(studentExam);
                _context.SaveChanges();
            };
            Form2 form2 = new Form2(CurrentStudent);
            this.Hide();
            form2.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UserAnswer[count] = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UserAnswer[count] = 2;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UserAnswer[count] = 3;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                UserAnswer[count] = 4;
            }
        }
        private void SetRadioButtonStates()
        {
            if (UserAnswer[count] == 1)
            {
                radioButton1.Checked = true;
            }
            else if (UserAnswer[count] == 2)
            {
                radioButton2.Checked = true;
            }
            else if (UserAnswer[count] == 3)
            {
                radioButton3.Checked = true;
            }
            else if (UserAnswer[count] == 4)
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }
        private void radiochecked()
        {
            if (radioButton1.Checked)
            {
                UserAnswer[count] = 1;
            }
            if (radioButton2.Checked)
            {
                UserAnswer[count] = 2;
            }
            if (radioButton3.Checked)
            {
                UserAnswer[count] = 3;
            }
            if (radioButton4.Checked)
            {
                UserAnswer[count] = 4;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
