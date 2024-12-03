using Microsoft.EntityFrameworkCore;

namespace WPFMobile.Services
{
    // DBContext is a class that represents the database and is used to manage the connection to the database
    // DbSet is a property that represents a table in the database
    //It is recommended to instanciate the class for each interaction with the database
    internal class AppDBContext : DbContext
    {
        // DbSet property to represent the tables in the database
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

        // Method to configure the connection to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLExpress; " +
                "Initial Catalog=MobileDB; Integrated Security=True; " +
                "TrustServerCertificate=True;");
        }

        // Method to configure the model of the database
        // Model is a class that represents the structure of the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .Property(c => c.ConsultaId)
                .ValueGeneratedOnAdd();

            // ModelBuilder is a class that is used to configure the model of the database
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente).WithMany()
                .HasForeignKey(c => c.PacienteId);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico).WithMany()
                .HasForeignKey(c => c.MedicoId);
        }
    }
}