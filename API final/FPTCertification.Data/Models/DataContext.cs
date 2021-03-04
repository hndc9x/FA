using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCertification.Data.Models
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<CertificationSkill> CertificationSkills { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<EnrollPaper> EnrollPapers { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionPaper> QuestionPapers { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<RecordQuestion> RecordQuestions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<TestPaper> TestPapers { get; set; }
        public virtual DbSet<QuizHTML>QuizHTMLs{ get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //// seeding
            //var i = 1;
            //var personsToSeed = A.ListOf<Person>(26);
            //personsToSeed.ForEach(x => x.Id = i++);
            //modelBuilder.Entity<Person>().HasData(personsToSeed);
            modelBuilder.Entity<Category>()
                        .HasOne(m => m.ParentCategory)
                        .WithMany(e => e.ChildCategories)
                        .HasForeignKey(e => e.ParentCategoryId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Question>()
                        .HasOne(m => m.ParentQuestion)
                        .WithMany(m => m.ChildQuestion)
                        .HasForeignKey(e => e.ParentId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RecordQuestion>()
                        .HasOne<Record>(m => m.Record)
                        .WithMany(e => e.RecordQuestions)
                        .HasForeignKey(e => e.RecordId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EnrollPaper>()
                        .HasOne<TestPaper>(m => m.TestPaper)
                        .WithMany(e => e.EnrollPapers)
                        .HasForeignKey(e => e.TestPaperId)
                        .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Record>()
            //           .HasOne<EnrollPaper>(m => m.EnrollPaper)
            //           .WithMany(e => e.Records)
            //           .HasForeignKey(e => e.EnrollPaperId)
            //           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CertificationSkill>().HasKey(cs => new { cs.CertificationId, cs.SkillId });
            
        }

    }
}
