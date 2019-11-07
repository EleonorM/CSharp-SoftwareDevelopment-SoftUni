namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;

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

        public DbSet<Homework> HomeworkSubmissions { get; set; }

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

                          entity.HasData(
                              new StudentCourse { StudentId = 2, CourseId = 1 },
                              new StudentCourse { StudentId = 2, CourseId = 2 },
                              new StudentCourse { StudentId = 3, CourseId = 2 }
                              );
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

                       entity.HasData(
                       new Homework { HomeworkId = 1, Content = "Homework1", CourseId = 2, StudentId = 1, ContentType = ContentType.Application, SubmissionTime = DateTime.Now },
                       new Homework { HomeworkId = 2, Content = "Homework2", CourseId = 3, StudentId = 3, ContentType = ContentType.Application, SubmissionTime = DateTime.Now },
                       new Homework { HomeworkId = 3, Content = "Homework3", CourseId = 1, StudentId = 2, ContentType = ContentType.Application, SubmissionTime = DateTime.Now }
                       );
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


                    entity.HasData(
                        new Student { StudentId = 1, Name = "Student1", RegisteredOn = DateTime.Now },
                        new Student { StudentId = 2, Name = "Student2", RegisteredOn = DateTime.Now },
                        new Student { StudentId = 3, Name = "Student3", RegisteredOn = DateTime.Now },
                        new Student { StudentId = 4, Name = "Student4", RegisteredOn = DateTime.Now });

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
                    .Property(p => p.Price)
                    .HasColumnType("DECIMAL(15,2)")
                    .IsRequired();

                    entity.HasData(
                        new Course { CourseId = 1, Name = "Course1", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(1), Price = 10.20m },
                        new Course { CourseId = 2, Name = "Course2", StartDate = DateTime.Now.AddDays(-2), EndDate = DateTime.Now.AddDays(1), Price = 10.20m },
                        new Course { CourseId = 3, Name = "Course3", StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now.AddDays(1), Price = 10.20m }
                        );
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

                  entity.HasData(
                       new Resource { ResourceId = 1, Name = "Resource1", ResourceType = ResourceType.Document, CourseId = 2, Url = "url1" },
                       new Resource { ResourceId = 2, Name = "Resource2", ResourceType = ResourceType.Document, CourseId = 1, Url = "url2" },
                       new Resource { ResourceId = 3, Name = "Resource3", ResourceType = ResourceType.Document, CourseId = 3, Url = "url3" }
                       );
              });
        }
    }
}
