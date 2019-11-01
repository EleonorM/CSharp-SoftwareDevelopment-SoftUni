namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Hospital;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePatientEntity(modelBuilder);
            ConfigureVisitationEntity(modelBuilder);
            ConfigureDiagnoseEntity(modelBuilder);
            ConfigureMedicamentEntity(modelBuilder);
            ConfigurePatientMedicamentEntity(modelBuilder);
            ConfigureDoctor(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasKey(d => new { d.Id});

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .HasMany(d=>d.Visitations)
                .WithOne(d=>d.Doctor)
                .HasForeignKey(d=>d.DoctorId);
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.PatientId);


            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(m => m.MedicamentId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Medicament>()
                 .HasKey(m => m.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode();
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Diagnose>()
                 .HasKey(d => d.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient);

            modelBuilder
              .Entity<Patient>()
              .HasMany(p => p.Diagnoses)
              .WithOne(d => d.Patient);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.LastName)
               .HasMaxLength(50)
               .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder
              .Entity<Patient>()
              .Property(p => p.Email)
              .HasMaxLength(80);
        }
    }
}

