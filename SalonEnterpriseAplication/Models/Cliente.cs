using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Telefone { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        public String Endereco { get; set; }
        [Required]
        public String Sexo { get; set; }
        [Required]
        public String Rg { get; set; }
        [Required]
        public String Cpf { get; set; }

    }
}