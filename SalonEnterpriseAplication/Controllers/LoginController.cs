using SalonEnterpriseAplication.DAO;
using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(String login, String senha)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            Funcionario usuario = dao.Busca(login, senha);

            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Senha.Errada", "O nome do usuario ou a senha estão incorretos");
                return RedirectToAction("Index");
            }
        }
    }
}