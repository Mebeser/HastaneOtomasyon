using Microsoft.EntityFrameworkCore;
using HastaneOtomasyon.Models;

namespace HastaneOtomasyon.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1435; Database=HastaneOtomasyon_db; User Id=sa; Password=Password123*; TrustServerCertificate=True;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Billing> Billings { get; set; }

        // SQL SERVER'IN KAFASINI KARIŞTIRAN DÖNGÜYÜ ÇÖZÜYORUZ
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fatura ve Hasta arasındaki silme işlemini "Durdur (NoAction)" yapıyoruz
            modelBuilder.Entity<Billing>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Billings)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}