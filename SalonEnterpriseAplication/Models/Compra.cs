using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public IList<CompraProduto> Compras { get; set; }

        public Compra()
        {
            this.Compras = new List<CompraProduto>();
        }

        public void IncluirProduto(Produto produto)
        {
            this.Compras.Add(new CompraProduto() { Produto = produto });
        }
    }

    
}