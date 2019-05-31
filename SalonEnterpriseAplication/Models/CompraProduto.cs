using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class CompraProduto
    {
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

    }
}