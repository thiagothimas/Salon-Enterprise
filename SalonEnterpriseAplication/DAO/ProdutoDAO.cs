using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class ProdutoDAO
    {
        public IList<Produto> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_produtos.ToList();
            }
        }

        public void Adiciona(Produto produto)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public Produto BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_produtos.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverProduto(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var prod = context.tb_produtos.Where(p => p.Id == id).FirstOrDefault();
                context.tb_produtos.Remove(prod);
                context.SaveChanges();

            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_produtos.Update(produto);
                contexto.SaveChanges();
            }
        }
    }
}