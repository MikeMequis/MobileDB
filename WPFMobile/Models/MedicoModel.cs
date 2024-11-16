using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPFMobile
{
    public class MedicoModel
    {
        [Key]
        public int medicoId { get; set; }
        public string medicoNome { get; set; }
        public string medicoCrm { get; set; }
        public string medicoEspecialidade { get; set; }
        public string medicoTelefone { get; set; }
    }
}