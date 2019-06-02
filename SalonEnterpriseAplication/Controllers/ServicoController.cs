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
    public class ServicoController : Controller
    {
        // GET: Servico
        //[Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {

            ServicoDAO dao = new ServicoDAO();
            IList<Servico> servico = dao.Lista();
            return View(servico);

        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
    
        public ActionResult Adiciona(Servico servico)
        {
            //int IdInformatica = 1;
            //if (produto.CategoriaId.Equals(IdInformatica) && produto.Valor < 100)
            //{
            //    ModelState.AddModelError("produto.Invalido", "Informatica com preco abaixo de 100 reias");
            //}

            if (ModelState.IsValid)
            {
                var dao = new ServicoDAO();
                dao.Adiciona(servico);

                return RedirectToAction("Index", "Servico");
            }
            else
            {
                //-------- Lista CategoriasDAO para utilizar no comboBox --------
                //CategoriasDAO categoriasDAO = new CategoriasDAO();
                //ViewBag.Categorias = categoriasDAO.Lista();


                //------- Utilização da variavel produto para tratar mensagens de validação --------
                //ViewBag.Produto = produto;
                return View("Form");
            }

        }

        //[Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            var dao = new ServicoDAO();
            Servico servico = dao.BuscaPorId(id);
            ViewBag.Servico = servico;
            return View();


        }

        //public ActionResult DecrementaQtd(int id)
        //{
        //    var dao = new ProdutoDAO();
        //    var produto = dao.BuscaPorId(id);
        //    produto.Quantidade--;
        //    dao.Atualiza(produto);
        //    return Json(produto);
        //}


        public ActionResult RemoverServico(int id)
        {
            var dao = new ServicoDAO();
            dao.RemoverServico(id);
            return RedirectToAction("Index", "Servico");

        }
    }
}