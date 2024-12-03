namespace WPFMobile.Services
{
    using Microsoft.EntityFrameworkCore;

    public class SeedDataBase
    {
        // Method to seed the database with initial data
        public static void Seed()
        {
            // Create a new instance of the AppDBContext class
            // The Using method guarantees that the context is disposed of after the block of code is executed
            using (var context = new AppDBContext())
            {
                // EnsureCreated method creates the database if it does not exist
                context.Database.EnsureCreated();

                // ExecuteSqlRaw method is used to execute raw SQL queries
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Pacientes', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Medicos', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Consultas', RESEED, 0)");

                // If the Pacientes table is empty, add the initial data
                if (context.Pacientes != null && !context.Pacientes.Any())
                {
                    context.Pacientes.AddRange(
                        new PacienteModel
                        {
                            pacienteNome = "Carlos",
                            pacienteCpf = "12345678901",
                            pacienteTelefone = "1111111111",
                            pacienteEmail = "carlos1@example.com",
                            pacienteIdade = 30,
                            pacienteSexo = "M"
                        },
                        new PacienteModel
                        {
                            pacienteNome = "Ana",
                            pacienteCpf = "23456789012",
                            pacienteTelefone = "2222222222",
                            pacienteEmail = "ana@example.com",
                            pacienteIdade = 25,
                            pacienteSexo = "F"
                        }
                    );
                }

                if (context.Medicos != null && !context.Medicos.Any())
                {
                    context.Medicos.AddRange(
                        new MedicoModel
                        {
                            medicoNome = "Dr. João",
                            medicoCrm = "123456",
                            medicoEspecialidade = "Cardiologista",
                            medicoTelefone = "3333333333"
                        },
                        new MedicoModel
                        {
                            medicoNome = "Dra. Maria",
                            medicoCrm = "234567",
                            medicoEspecialidade = "Pediatra",
                            medicoTelefone = "4444444444"
                        }
                    );                    
                }
                // Saves the changes to the database
                context.SaveChanges();
            }
        }
    }

}
