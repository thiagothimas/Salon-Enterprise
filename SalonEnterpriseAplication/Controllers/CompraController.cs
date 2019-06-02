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
    public class CompraController : Controller
    {


        // GET: Compra
        public ActionResult Index()
        {
            CompraDAO dao = new CompraDAO();
            IList<Compra> compra = dao.Lista();

            FornecedorDAO forn = new FornecedorDAO();
            var fornecedor = forn.Lista();
            ViewBag.Fornecedores = fornecedor;

            return View(compra);

        }

        public ActionResult Form()
        {
            FornecedorDAO forn = new FornecedorDAO();
            var fornecedor = forn.Lista();
            ViewBag.Fornecedores = fornecedor;
            return View();
        }

        public ActionResult Adiciona(Compra compra)
        {

            if (ModelState.IsValid)
            {
                var dao = new CompraDAO();
                dao.Adiciona(compra);

                return RedirectToAction("Index", "Compra");
            }
            else
            {

                return View("Form");

            }

        }

        public ActionResult Visualiza(int id)
        {
            var dao = new CompraDAO();
            Compra compra = dao.BuscaPorId(id);
            ViewBag.Compra = compra;
            return View();


        }

        public ActionResult RemoverCompra(int id)
        {
            CompraDAO compra = new CompraDAO();
            compra.RemoverCompra(id);
            return RedirectToAction("Index");
        }


    }
}