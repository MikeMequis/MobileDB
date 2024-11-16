using System.ComponentModel.DataAnnotations;

namespace WPFMobile
{
    public class PacienteModel
    {
        [Key]
        public int pacienteId { get; set; }
        public string pacienteNome { get; set; }
        public string pacienteCpf { get; set; }
        public string pacienteTelefone { get; set; }
        public string pacienteEmail { get; set; }
        public int pacienteIdade { get; set; }
        public string pacienteSexo { get; set; }
    }
}
