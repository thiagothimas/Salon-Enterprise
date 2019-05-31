using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
	public class Movimentacao
	{
		public int Id { get; set; }
		public decimal Valor { get; set; }
		public DateTime Data { get; set; }
		public Tipo Tipo { get; set; }
		public int FuncionarioId { get; set; }
		public Funcionario funcionario { get; set; }
	}
}