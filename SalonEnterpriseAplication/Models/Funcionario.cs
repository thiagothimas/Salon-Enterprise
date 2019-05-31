using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        
        public String Nome { get; set; }
       
        public String Telefone { get; set; }
      
        public DateTime DataDeNascimento { get; set; }
       
        public String Endereco { get; set; }
     
        public String Sexo { get; set; }
     
        public String Rg { get; set; }
      
        public String Cpf { get; set; }
  
        public String  Cargo { get; set; }


    }
}