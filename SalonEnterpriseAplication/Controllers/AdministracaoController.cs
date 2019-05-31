using SalonEnterpriseAplication.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{
	[Authorize(Roles = RolesNomes.ADMINISTRADOR)]
    [AutorizacaoFilter]
    public class AdministracaoController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}