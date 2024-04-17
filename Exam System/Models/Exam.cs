using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }

        public int NumberOfQ { get; set; }

        // Foreign key for one-to-many relationship with Subject
        public int SubjectId { get; set; }

        // Navigation property for one-to-many relationship with Subject
        public virtual Subject Subject { get; set; }

        // Navigation property for many-to-many relationship with Student
        public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
        public virtual ICollection<Question> Quetions { get; set; } = new List<Question>();




    }
}
