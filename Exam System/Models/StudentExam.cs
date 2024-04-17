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
    public class StudentExam
    {
        //CompositeK

        [Key, Column(Order = 0)]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        public int ExamId { get; set; }
        [AllowNull]

        public double Grade { get; set; }

        public virtual Student Student{ get; set; }
        public virtual Exam Exam { get; set; }

    }
}
