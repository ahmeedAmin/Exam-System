using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System.Models
{
    public class ExamContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Minoo;Database=ExamSystem;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite Key in StudentExam Table
            modelBuilder.Entity<StudentExam>().HasKey(sc => new { sc.StudentId, sc.ExamId });
            //Composite Key in StudentSubject Table
            modelBuilder.Entity<StudentSubject>().HasKey(sc => new { sc.StudentId, sc.SubjectId });
            modelBuilder.Entity<Question>()
            .HasOne(q => q.Exam)
            .WithMany(e => e.Quetions)
            .HasForeignKey(q => q.ExamId)
            .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(modelBuilder);

        }
    }
}
