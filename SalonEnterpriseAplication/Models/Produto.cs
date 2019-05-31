using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public String Nome { get; set; }
        public String Tipo { get; set; }
        public String Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public IList<CompraProduto> Produtos { get; set; }
        public List<VendaProduto> Servicos { get; set; }

    }
}