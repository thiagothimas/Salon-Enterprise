using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class CompraDAO
    {
        public IList<Compra> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_compras.ToList();
            }
        }

        public void Adiciona(Compra compra)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_compras.Add(compra);
                context.SaveChanges();
            }
        }

        public Compra BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_compras.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverCompra(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var compra = context.tb_compras.Where(p => p.Id == id).FirstOrDefault();
                context.tb_compras.Remove(compra);
                context.SaveChanges();

            }
        }

        public void Atualiza(Compra compra)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_compras.Update(compra);
                contexto.SaveChanges();
            }
        }
    }
}