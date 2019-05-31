using SalonEnterpriseAplication.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{
    [AutorizacaoFilter]
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Index()
        {
            return View();
        }
    }
}