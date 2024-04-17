using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } // Assuming PasswordPropertyText is a custom validation attribute

        // Navigation property for many-to-many relationship with Subject
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();


        // Navigation property for many-to-many relationship with Exam
        public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    }
}
