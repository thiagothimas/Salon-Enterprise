using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Cnpj { get; set; }

    }
}