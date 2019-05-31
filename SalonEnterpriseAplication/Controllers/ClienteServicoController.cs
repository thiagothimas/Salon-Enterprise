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
    //[AutorizacaoFilter]
    //public class ClienteServicoController : Controller
    //{
    //    //GET : ClienteServico
    //    public ActionResult Index()
    //    {
    //        ClienteServicoDAO dao = new ClienteServicoDAO();
    //        IList<ClienteServico> clienteServico = dao.Lista();
    //        return View(clienteServico);
    //    }

    //    public ActionResult Form()
    //    {
    //        ClienteDAO cliente = new ClienteDAO();
    //        var listaCliente = cliente.Lista();
    //        ViewBag.Clientes = listaCliente;

    //        //ServicosRealizadosDAO servico = new ServicosRealizadosDAO();
    //        //var listaServico = servico.Lista();
    //        //ViewBag.ServicosRealizados = listaServico;
    //        return View();
    //    }


      
    //    [HttpPost]
    //    public ActionResult Adiciona(ClienteServico clienteServico)
    //    {

    //        if (ModelState.IsValid)
    //        {
    //            var dao = new ClienteServicoDAO();
    //            //dao.Adiciona(clienteServico);

    //            return RedirectToAction("Index", "ClienteServico");
    //        }
    //        else
    //        {

    //            return View("Form");

    //        }

    //    }
    //}
}