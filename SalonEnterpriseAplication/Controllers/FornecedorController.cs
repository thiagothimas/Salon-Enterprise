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
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {

            FornecedorDAO dao = new FornecedorDAO();
            IList<Fornecedor> forn = dao.Lista();
            return View(forn);

        }

        public ActionResult Form()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Adiciona(Fornecedor fornecedor)
        {
       
            if (ModelState.IsValid)
            {
                var dao = new FornecedorDAO();
                dao.Adiciona(fornecedor);

                return RedirectToAction("Index", "Fornecedor");
            }
            else
            {
                
                return View("Form");

            }

        }

        //[Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            var dao = new FornecedorDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            ViewBag.Fornecedor = fornecedor;
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


        public ActionResult RemoverFornecedor(int id)
        {
            var dao = new FornecedorDAO();
            dao.RemoverFornecedor(id);
            return RedirectToAction("Index");

        }
    }
}