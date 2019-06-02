using SalonEnterpriseAplication.DAO;
using SalonEnterpriseAplication.Filtros;
using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{
    [AutorizacaoFilter]
    public class MovimentacaoController : Controller
    {
		private MovimentacaoDAO movimentacaoDAO;
		private FuncionarioDAO funcionarioDAO;

		public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, FuncionarioDAO funcionarioDAO)
		{
			this.movimentacaoDAO = movimentacaoDAO;
			this.funcionarioDAO = funcionarioDAO;
		}

        // GET: Movimentacao
        public ActionResult Form()
        {
			ViewBag.Funcionarios = funcionarioDAO.Lista();
            return View();
        }

		public ActionResult Adiciona(Movimentacao movimentacao)
		{
            // var funcionario = funcao_que_pega_um_funcionario_por_id(movimentacao.FuncionarioId);
            // mavumentacao.funcionario = funcionario;

            // OU

            // movimentacao.funcionario.nome = funcao_que_pega_nome_de_um_funcionario_por_id(movimentacao.FuncionarioId);
            

            if (ModelState.IsValid)
			{
                
				movimentacaoDAO.Adiciona(movimentacao);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Funcionarios = funcionarioDAO.Lista();
				return View("Form", movimentacao);
			}
		}

		public ActionResult Index()
		{
            var funcionario = funcionarioDAO.Lista();
            ViewBag.Funcionarios = funcionario;
            IList<Movimentacao> movimentacoes = movimentacaoDAO.Lista();
			return View(movimentacoes);
		}

		public ActionResult MovimentacoesPorFuncionario(MovimentacoesPorFuncionarioModel model)
		{
            var funcionario = funcionarioDAO.Lista();
            ViewBag.Funcionarios = funcionario;
            model.funcionarios = funcionarioDAO.Lista();
			model.Movimentacoes = movimentacaoDAO.BuscaPorFuncionario(model.FuncionarioId);
			return View(model);
		}

		public ActionResult Busca(BuscaMovimentacoesModel model)
		{
            var funcionario = funcionarioDAO.Lista();
            ViewBag.Funcionarios = funcionario;
            model.funcionarios = funcionarioDAO.Lista();
			model.Movimentacoes = movimentacaoDAO.Busca(model.ValorMinimo, model.ValorMaximo,
														model.DataMinima, model.DataMaxima,
														model.Tipo, model.FuncionarioId);
			return View(model);
		}
	}
}