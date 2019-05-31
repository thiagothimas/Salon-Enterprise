using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class ServicoDAO
    {
        public IList<Servico> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_servicos.ToList();
            }
        }

        public void Adiciona(Servico servico)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_servicos.Add(servico);
                context.SaveChanges();
            }
        }

        public Servico BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_servicos.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverServico(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var servico = context.tb_servicos.Where(p => p.Id == id).FirstOrDefault();
                context.tb_servicos.Remove(servico);
                context.SaveChanges();

            }
        }

        public void Atualiza(Servico servico)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_servicos.Update(servico);
                contexto.SaveChanges();
            }
        }
    }
}