namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringStudent(modelBuilder);

            OnConfiguringCourse(modelBuilder);

            OnConfguringResource(modelBuilder);

            OnConfguringHomework(modelBuilder);

            OnConfguringStudentCourse(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnConfguringStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                      .Entity<StudentCourse>(entity =>
                      {
                          entity.HasKey(k => new { k.StudentId, k.CourseId });

                          entity
                          .HasOne(p => p.Student)
                          .WithMany(p => p.CourseEnrollments)
                          .HasForeignKey(k => k.StudentId);

                          entity
                          .HasOne(p => p.Course)
                          .WithMany(p => p.StudentsEnrolled)
                          .HasForeignKey(k => k.CourseId);
                      });
        }

        private void OnConfguringHomework(ModelBuilder modelBuilder)
        {
            modelBuilder
                   .Entity<Homework>(entity =>
                   {
                       entity.HasKey(k => k.HomeworkId);

                       entity
                        .Property(p => p.Content)
                        .IsRequired();

                       entity
                        .Property(p => p.ContentType)
                        .IsRequired();

                       entity
                       .Property(p => p.SubmissionTime)
                       .IsRequired();

                       entity
                       .Property(p => p.StudentId)
                       .IsRequired();

                       entity
                       .Property(p => p.CourseId)
                       .IsRequired();

                       entity
                       .HasOne(e => e.Student)
                       .WithMany(e => e.HomeworkSubmissions)
                       .HasForeignKey(k => k.StudentId);

                       entity
                       .HasOne(e => e.Course)
                       .WithMany(e => e.HomeworkSubmissions)
                       .HasForeignKey(k => k.CourseId);
                   });
        }

        private static void OnConfiguringStudent(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity =>
                {
                    entity.HasKey(k => k.StudentId);

                    entity
                     .Property(p => p.Name)
                     .HasMaxLength(100)
                     .IsUnicode()
                     .IsRequired();

                    entity
                     .Property(p => p.PhoneNumber)
                     .HasColumnType("CHAR(10)");

                    entity
                    .Property(p => p.RegisteredOn)
                    .IsRequired();
                });
        }

        private static void OnConfiguringCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>(entity =>
                {
                    entity.HasKey(k => k.CourseId);

                    entity
                     .Property(p => p.Name)
                     .HasMaxLength(80)
                     .IsUnicode()
                     .IsRequired();

                    entity
                     .Property(p => p.Description)
                     .IsUnicode();

                    entity
                    .Property(p => p.StartDate)
                    .IsRequired();

                    entity
                    .Property(p => p.EndDate)
                    .IsRequired();

                    entity
                    .Property(p => p.Price)
                    .HasColumnType("DECIMAL(15,2)")
                    .IsRequired();
                });
        }

        private static void OnConfguringResource(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Resource>(entity =>
              {
                  entity.HasKey(k => k.ResourceId);

                  entity
                   .Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

                  entity
                   .Property(p => p.Url)
                   .IsRequired();

                  entity
                  .Property(p => p.ResourceType)
                  .IsRequired();

                  entity
                  .Property(p => p.CourseId)
                  .IsRequired();

                  entity
                  .HasOne(p => p.Course)
                  .WithMany(c => c.Resources)
                  .HasForeignKey(k => k.CourseId);
              });
        }
    }
}
