using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
	public class BuscaMovimentacoesModel
	{
		public decimal? ValorMinimo { get; set; }

		public decimal? ValorMaximo { get; set; }

		public DateTime? DataMinima { get; set; }

		public DateTime? DataMaxima { get; set; }

		public Tipo? Tipo { get; set; }

		public int? FuncionarioId { get; set; }

		public IList<Movimentacao> Movimentacoes { get; set; }

		public IList<Funcionario> funcionarios { get; set; }
	}
}