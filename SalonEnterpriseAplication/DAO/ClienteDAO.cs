using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class ClienteDAO
    {
        public IList<Cliente> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_clientes.ToList();
            }
        }

        public void Adiciona(Cliente cliente)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public Cliente BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_clientes.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverCliente(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var cliente = context.tb_clientes.Where(p => p.Id == id).FirstOrDefault();
                context.tb_clientes.Remove(cliente);
                context.SaveChanges();

            }
        }

        public void Atualiza(Cliente cliente)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_clientes.Update(cliente);
                contexto.SaveChanges();
            }
        }
    }
}