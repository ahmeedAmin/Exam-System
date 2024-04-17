using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string Option4 { get; set; }

        public int CorrectAnswer { get; set; }

        public int Mark { get; set; }

        // Foreign key for one-to-many relationship with Subject
        public int SubjectId { get; set; }

        // Navigation property for one-to-many relationship with Subject
        public virtual Subject Subject { get; set; }
        // Foreign key for one-to-many relationship with Exam
        public int ExamId { get; set; }

        // Navigation property for one-to-many relationship with Exam
        public virtual Exam Exam { get; set; }

    }
}
