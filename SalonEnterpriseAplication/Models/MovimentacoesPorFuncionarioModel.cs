using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
	public class MovimentacoesPorFuncionarioModel
	{
		public int? FuncionarioId { get; set; }

		public IList<Movimentacao> Movimentacoes { get; set; }

		public IList<Funcionario> funcionarios{ get; set; }
	}
}