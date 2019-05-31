using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public DateTime DataServico { get; set; }
        public DateTime HoraInicial { get; set; }
        public String Descricao { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

       
    }

    
}