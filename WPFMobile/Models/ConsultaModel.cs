using System.ComponentModel.DataAnnotations;

namespace WPFMobile
{
    public class ConsultaModel
    {
        // Annotation used to define the primary key of the table in the database
        [Key]
        public int ConsultaId { get; set; }
        public DateTime ConsultaData { get; set; }
        public string ConsultaHora { get; set; } = string.Empty;

        public int PacienteId { get; set; }
        public PacienteModel Paciente { get; set; } = null!;

        public int MedicoId { get; set; }
        public MedicoModel Medico { get; set; } = null!;
    }
}