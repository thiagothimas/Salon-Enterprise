using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class OrdemServicoDAO
    {
        public IList<OrdemServico> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_ordem_servico.ToList();
            }
        }

        public void Adiciona(OrdemServico ordem)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_ordem_servico.Add(ordem);
                context.SaveChanges();
            }
        }

        public OrdemServico BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_ordem_servico.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverOrdemServico(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var ordem = context.tb_ordem_servico.Where(p => p.Id == id).FirstOrDefault();
                context.tb_ordem_servico.Remove(ordem);
                context.SaveChanges();

            }
        }

        public void Atualiza(OrdemServico ordem)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_ordem_servico.Update(ordem);
                contexto.SaveChanges();
            }
        }
    }
}