﻿using SalonEnterpriseAplication.Models;
using SalonEnterpriseAplication.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SalonEnterpriseAplication.Controllers
{

    public class ContaController : Controller
    {
		private UserManager<UsuarioAplicacao> _userManager;
		public UserManager<UsuarioAplicacao> UserManager
		{
			get
			{
				if(_userManager == null)
				{
					var contextOwin = HttpContext.GetOwinContext();
					_userManager = contextOwin.GetUserManager<UserManager<UsuarioAplicacao>>();
				}
				return _userManager;
			}
			set
			{
				_userManager = value;
			}
		}

		private SignInManager<UsuarioAplicacao, string> _signInManager;
		public SignInManager<UsuarioAplicacao, string> SignInManager
		{
			get
			{
				if (_signInManager == null)
				{
					var contextOwin = HttpContext.GetOwinContext();
					_signInManager = contextOwin.GetUserManager<SignInManager<UsuarioAplicacao, string>>();
				}
				return _signInManager;
			}
			set
			{
				_signInManager = value;
			}
		}

		public IAuthenticationManager AuthenticationManager
		{
			get
			{
				var contextoOwin = Request.GetOwinContext();
				return contextoOwin.Authentication;
			}
		}

        [Authorize(Roles = RolesNomes.ADMINISTRADOR)]
        // GET: Conta
        public ActionResult Registrar()
        {
            return View();
        }


        [Authorize(Roles = RolesNomes.ADMINISTRADOR)]
        [HttpPost]
		public async Task<ActionResult> Registrar(ContaRegistrarViewModels modelo)
		{
			if (ModelState.IsValid)
			{
				var dbContext = new IdentityDbContext<UsuarioAplicacao>("DefaultConnection");
				var userStore = new UserStore<UsuarioAplicacao>(dbContext);
				var userManager = new UserManager<UsuarioAplicacao>(userStore);

				var novoUsuario = new UsuarioAplicacao();

				novoUsuario.Email = modelo.Email;
				novoUsuario.UserName = modelo.UserName;
				novoUsuario.NomeCompleto = modelo.NomeCompleto;

				var usuario = await UserManager.FindByEmailAsync(modelo.Email);
				var usuarioJaExiste = usuario != null;

				if (usuarioJaExiste)
					return View("AguardandoConfirmacao");

				var resultado = await UserManager.CreateAsync(novoUsuario, modelo.Senha);

				if (resultado.Succeeded)
				{
					await EnviarEmailDeConfirmacaoAsync(novoUsuario);
					return View("AguardandoConfirmacao");
				}
				else
				{
					AdicionaErros(resultado);
				}
			}

			//Alguma coisa de errado aconteceu
			return View(modelo);
		}


        [Authorize(Roles = RolesNomes.ADMINISTRADOR)]
        [HttpPost]
		public ActionResult RegistrarPorAutenticacaoExterna(string provider)
		{
			SignInManager.AuthenticationManager.Challenge(new AuthenticationProperties
			{
				RedirectUri = Url.Action("RegistrarPorAutenticacaoExternaCallback")
			}, provider);

			return new HttpUnauthorizedResult();
		}


        [Authorize(Roles = RolesNomes.ADMINISTRADOR)]
        public async Task<ActionResult> RegistrarPorAutenticacaoExternaCallback()
		{
			var loginInfo =
				await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();

			var usuarioExistente = await UserManager.FindByEmailAsync(loginInfo.Email);
			if (usuarioExistente != null)
				return View("Error");

			var novoUsuario = new UsuarioAplicacao();

			novoUsuario.Email = loginInfo.Email;
			novoUsuario.UserName = loginInfo.Email;
			novoUsuario.NomeCompleto =
				loginInfo.ExternalIdentity.FindFirstValue(
						loginInfo.ExternalIdentity.NameClaimType
					);

			var resultado = await UserManager.CreateAsync(novoUsuario);
			if (resultado.Succeeded)
			{
				var resultadoAddLoginInfo =
					await UserManager.AddLoginAsync(novoUsuario.Id, loginInfo.Login);
				if (resultadoAddLoginInfo.Succeeded)
					return RedirectToAction("Index", "Home");
			}

			return View("Error");
		}

		private async Task EnviarEmailDeConfirmacaoAsync(UsuarioAplicacao usuario)
		{
			var token = await UserManager.GenerateEmailConfirmationTokenAsync(usuario.Id);

			var linkDeCallback =
				Url.Action(
					"ConfirmacaoEmail",
					"Conta",
					new { usuarioId = usuario.Id, token = token },
					Request.Url.Scheme);

			await UserManager.SendEmailAsync(
				usuario.Id,
                "Salon Enterprise Radice - Confirmação de Email",
				$"Bem vindo ao Salon Enterprise Radice, clique aqui {linkDeCallback} para confirmar seu email!");
		}

		public async Task<ActionResult> ConfirmacaoEmail(string usuarioId, string token)
		{
			if (usuarioId == null || token == null)
				return View("Error");

			var resultado = await UserManager.ConfirmEmailAsync(usuarioId, token);

			if (resultado.Succeeded)
				return View("ConfirmacaoContaValidada");
			else
				return View("Error");
		}

		public async Task<ActionResult> Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<ActionResult> Login(ContaLoginViewModel modelo)
		{
			if (ModelState.IsValid)
			{
				var usuario = await UserManager.FindByEmailAsync(modelo.Email);
                Session["usuarioLogado"] = usuario;

                if (usuario == null)
					return SenhaOuUsuarioInvalidos();

				var signInResultado =
					await SignInManager.PasswordSignInAsync(
						usuario.UserName,
						modelo.Senha,
						isPersistent: modelo.ContinuarLogado,
						shouldLockout: true);

				switch (signInResultado)
				{
					case SignInStatus.Success:

						if (!usuario.EmailConfirmed)
						{
							AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
							return View("AguardandoConfirmacao");
						}

						return RedirectToAction("Index2", "Home");
					case SignInStatus.LockedOut:
						var senhaCorreta =
							await UserManager.CheckPasswordAsync(
								usuario,
								modelo.Senha);

						if (senhaCorreta)
							ModelState.AddModelError("", "A conta está bloqueada!");
						else
							return SenhaOuUsuarioInvalidos();
						break;
					default:
						return SenhaOuUsuarioInvalidos();
				}
			}

			// Algo de errado aconteceu
			return View(modelo);
		}

		[HttpPost]
		public ActionResult LoginPorAutenticacaoExterna(string provider)
		{
			SignInManager.AuthenticationManager.Challenge(new AuthenticationProperties
			{
				RedirectUri = Url.Action("LoginPorAutenticacaoExternaCallback")
			}, provider);

			return new HttpUnauthorizedResult();
		}

		public async Task<ActionResult> LoginPorAutenticacaoExternaCallback()
		{
			var loginInfo = await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();

			var signInResultado = await SignInManager.ExternalSignInAsync(loginInfo, true);

			if (signInResultado == SignInStatus.Success)
				return RedirectToAction("Index", "Home");

			return View("Error");
		}

		public ActionResult EsqueciSenha()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> EsqueciSenha(ContaEsqueciSenhaViewModel modelo)
		{
			if (ModelState.IsValid)
			{
				// Gerar o token de reset da senha
				// Gerar a url para o usuário
				// Vamos enviar esse email

				var usuario = await UserManager.FindByEmailAsync(modelo.Email);

				if (usuario != null)
				{
					var token =
						await UserManager.GeneratePasswordResetTokenAsync(usuario.Id);

					var linkDeCallback =
						Url.Action(
							"ConfirmacaoAlteracaoSenha",
							"Conta",
							new { usuarioId = usuario.Id, token = token },
							Request.Url.Scheme);

					await UserManager.SendEmailAsync(
						usuario.Id,
						"Salon Enterprise Radice - Alteração de senha",
						$"Clique aqui {linkDeCallback} alterar a sua senha!");
				}

				return View("EmailAlteracaoSenhaEnviado");
			}

			return View();
		}

		public ActionResult ConfirmacaoAlteracaoSenha(string usuarioId, string token)
		{
			var modelo = new ContaConfirmacaoAlteracaoSenhaViewModel
			{
				UsuarioId = usuarioId,
				Token = token
			};

			return View(modelo);
		}

		[HttpPost]
		public async Task<ActionResult> ConfirmacaoAlteracaoSenha(ContaConfirmacaoAlteracaoSenhaViewModel modelo)
		{
			if (ModelState.IsValid)
			{
				// Verifica o Token recebido
				// Verifica o ID do usuário
				// Mudar a senha
				var resultadoAlteracao =
					await UserManager.ResetPasswordAsync(
						modelo.UsuarioId,
						modelo.Token,
						modelo.NovaSenha);

				if (resultadoAlteracao.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				AdicionaErros(resultadoAlteracao);
			}

			return View();
		}

		[HttpPost]
		public ActionResult Logoff()
		{
            object usuario = null;
            Session["usuarioLogado"] = usuario;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Index", "Home");
		}

		private ActionResult SenhaOuUsuarioInvalidos()
		{
			ModelState.AddModelError("", "Credenciais inválidas!");
			return View("Login");
		}

		private void AdicionaErros(IdentityResult resultado)
		{
			foreach(var erro in resultado.Errors)
			{
				ModelState.AddModelError("", erro);
			}
		}
	}
}