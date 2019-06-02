﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.ViewModels
{
	public class ContaLoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Senha { get; set; }

		[Display(Name = "Continuar logado")]
		public bool ContinuarLogado { get; set; }
	}
}