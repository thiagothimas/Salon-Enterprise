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
            return View(compra);

        }
    }
}