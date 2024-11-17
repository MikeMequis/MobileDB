using System.ComponentModel.DataAnnotations;
using WPFMobile;

public class ConsultaModel
{
    [Key]
    public int ConsultaId { get; set; }
    public DateTime ConsultaData { get; set; }
    public string ConsultaHora { get; set; } = string.Empty;

    public int PacienteId { get; set; }
    public PacienteModel Paciente { get; set; } = null!;

    public int MedicoId { get; set; }
    public MedicoModel Medico { get; set; } = null!;
}