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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteDAO dao = new ClienteDAO();
            IList<Cliente> cliente = dao.Lista();
            return View(cliente);
        }

        public ActionResult Form()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Adiciona(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                var dao = new ClienteDAO();
                dao.Adiciona(cliente);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {          
                
                return View("Form");

            }

        }

        public ActionResult Visualiza(int id)
        {
            var dao = new ClienteDAO();
            Cliente cliente = dao.BuscaPorId(id);
            ViewBag.Cliente = cliente;
            return View();

        }


        public ActionResult RemoverCliente(int id)
        {
            var dao = new ClienteDAO();
            dao.RemoverCliente(id);
            return RedirectToAction("Index");

        }
    }
}