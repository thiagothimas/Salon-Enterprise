using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.DAO
{
	public class MovimentacaoDAO
	{
		private SalonEnterpriseContext context;

		public MovimentacaoDAO(SalonEnterpriseContext context)
		{
			this.context = context;
		}

		public void Adiciona(Movimentacao movimentacao)
		{
			context.Movimentacoes.Add(movimentacao);
			context.SaveChanges();
		}

		public IList<Movimentacao> Lista()
		{
			return context.Movimentacoes.ToList();
		}

		public IList<Movimentacao> BuscaPorFuncionario(int? funcionarioId)
		{
			return context.Movimentacoes.Where(m => m.FuncionarioId == funcionarioId).ToList();
		}

		public IList<Movimentacao> Busca(decimal? valorMinimo, decimal? valorMaximo, DateTime? dataMinima, DateTime? dataMaxima, Tipo? tipo, int? funcionarioId)
		{
			IQueryable<Movimentacao> busca = context.Movimentacoes;
			if (valorMinimo.HasValue)
			{
				busca = busca.Where(m => m.Valor >= valorMinimo);
			}
			if (valorMaximo.HasValue)
			{
				busca = busca.Where(m => m.Valor <= valorMaximo);
			}
			if (dataMinima.HasValue)
			{
				busca = busca.Where(m => m.Data >= dataMinima);
			}
			if (dataMaxima.HasValue)
			{
				busca = busca.Where(m => m.Data <= dataMaxima);
			}
			if (tipo.HasValue)
			{
				busca = busca.Where(m => m.Tipo == tipo);
			}
			if (funcionarioId.HasValue)
			{
				busca = busca.Where(m => m.FuncionarioId == funcionarioId);
			}
			return busca.ToList();
		}
	}
}