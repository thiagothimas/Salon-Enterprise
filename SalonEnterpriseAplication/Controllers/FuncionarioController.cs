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
    public class FuncionarioController : Controller
    {
       
        public ActionResult Index()
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            IList<Funcionario> funcionario = dao.Lista();
            return View(funcionario);
        }

        public ActionResult Form()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Adiciona(Funcionario funcionario)
        {

            if (ModelState.IsValid && funcionario.Senha == funcionario.ConfirmaSenha)
            {
                
                var dao = new FuncionarioDAO();
                dao.Adiciona(funcionario);

                return RedirectToAction("Index", "Funcionario");
            }
            else
            {
                ModelState.AddModelError("Senha.Invalida", "A senha não está igual a senha informada");
                return View("Form");


            }

        }

        public ActionResult Visualiza(int id)
        {
            var dao = new FuncionarioDAO();
            Funcionario funcionario = dao.BuscaPorId(id);
            ViewBag.Funcionario = funcionario;
            return View();

        }


        public ActionResult RemoverFuncionario(int id)
        {
            var dao = new FuncionarioDAO();
            dao.RemoverFuncionario(id);
            return RedirectToAction("Index");

        }
    }
}