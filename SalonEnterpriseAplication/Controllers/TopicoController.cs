using SalonEnterpriseAplication.Filtros;
using SalonEnterpriseAplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{
    [AutorizacaoFilter]
    public class TopicoController : Controller
	{
		[Authorize]
		public ActionResult Criar()
		{
			return View();
		}

		[HttpPost]
		[Authorize]
		public ActionResult Criar(TopicoCriarViewModel modelo)
		{
			return View();
		}
	}
}