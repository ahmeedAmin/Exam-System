using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System.Models
{
    public class Subject
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation property for many-to-many relationship with Student
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();


        // Navigation property for one-to-many relationship with Quetion
        public virtual ICollection<Question> Quetions { get; set; } = new List<Question>();

        // Navigation property for one-to-many relationship with Exam
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>(); // Ensure this property is defined correctly

    }
}
