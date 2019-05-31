using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class EstoqueDAO
    {
        public IList<Estoque> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_estoque.ToList();
            }
        }

        public void Adiciona(Estoque estoque)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_estoque.Add(estoque);
                context.SaveChanges();
            }
        }

        public Estoque BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_estoque.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverEstoque(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var estoque = context.tb_estoque.Where(p => p.Id == id).FirstOrDefault();
                context.tb_estoque.Remove(estoque);
                context.SaveChanges();

            }
        }

        public void Atualiza(Estoque estoque)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_estoque.Update(estoque);
                contexto.SaveChanges();
            }
        }
    }
}