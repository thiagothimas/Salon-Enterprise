using SalonEnterpriseAplication;
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
    public class ProdutoController : Controller
    {
        // GET: Produto
        //[Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {

            
            ProdutoDAO dao = new ProdutoDAO();
            IList<Produto> prod = dao.Lista();
            foreach (var item in prod)
            {
                item.ValorTotal = item.Quantidade * item.Valor;
            }
            return View(prod);
                                   
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
    
        public ActionResult Adiciona(Produto produto)
        {
            //int IdInformatica = 1;
            //if (produto.CategoriaId.Equals(IdInformatica) && produto.Valor < 100)
            //{
            //    ModelState.AddModelError("produto.Invalido", "Informatica com preco abaixo de 100 reias");
            //}

            if (ModelState.IsValid)
            {
                var dao = new ProdutoDAO();
                dao.Adiciona(produto);

                return RedirectToAction("Index", "Produto");
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
            var dao = new ProdutoDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();


        }

        public ActionResult DecrementaQtd(int id)
        {
            var dao = new ProdutoDAO();
            var produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return RedirectToAction("Index");
        }


        public ActionResult RemoverProduto(int id)
        {
            var dao = new ProdutoDAO();
            dao.RemoverProduto(id);
            return RedirectToAction("Index");

        }



    }
    
}