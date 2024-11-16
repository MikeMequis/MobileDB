using Microsoft.EntityFrameworkCore;

namespace WPFMobile.Services
{
    internal class AppDBContext : DbContext
    {
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLExpress; " +
                "Initial Catalog=MobileDB; Integrated Security=True; " +
                "TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .Property(c => c.ConsultaId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente).WithMany()
                .HasForeignKey(c => c.PacienteId);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico).WithMany()
                .HasForeignKey(c => c.MedicoId);
        }
    }
}