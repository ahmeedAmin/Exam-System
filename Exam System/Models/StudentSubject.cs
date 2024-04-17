using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Exam_System.Models
{
    public class StudentSubject
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        public int SubjectId { get; set; }
        [AllowNull]
        public double? Grade { get; set; }


        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
