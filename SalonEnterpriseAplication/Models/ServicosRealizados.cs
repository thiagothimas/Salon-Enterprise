using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class ServicosRealizados
    {
        public int Id { get; set; }
        public double Comissao { get; set; }
        //public int FuncionarioId { get; set; }
        //public Funcionario Funcionario { get; set; }
        public int OrdemServicoId { get; set; }
        public OrdemServico OrdemServico { get; set; }

        

    }
}