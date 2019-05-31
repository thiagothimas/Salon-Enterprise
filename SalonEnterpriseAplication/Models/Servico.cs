using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Servico
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public String Nome { get; set; }
        [Required]
        public String Tipo { get; set; }
        [Required]
        public double Valor { get; set; }

    }
}