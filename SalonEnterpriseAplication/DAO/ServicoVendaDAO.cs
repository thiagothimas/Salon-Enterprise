using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    //public class ServicoVendaDAO
    //{
    //    public IList<ServicoVenda> Lista()
    //    {
    //        using (var contexto = new SalonEnterpriseContext())
    //        {
    //            return contexto.tb_servico_venda.ToList();
    //        }
    //    }

    //    public void Adiciona(ServicoVenda servicoVenda)
    //    {
    //        using (var context = new SalonEnterpriseContext())
    //        {
    //            context.tb_servico_venda.Add(servicoVenda);
    //            context.SaveChanges();
    //        }
    //    }

    //    public ServicoVenda BuscaPorId(int Id)
    //    {
    //        using (var context = new SalonEnterpriseContext())
    //        {
    //            return context.tb_servico_venda.Where(p => p.Id == Id).FirstOrDefault();
    //        }
    //    }

    //    public void RemoverVenda(int id)
    //    {
    //        using (var context = new SalonEnterpriseContext())
    //        {

    //            var venda = context.tb_servico_venda.Where(p => p.Id == id).FirstOrDefault();
    //            context.tb_servico_venda.Remove(venda);
    //            context.SaveChanges();

    //        }
    //    }

    //    public void Atualiza(ServicoVenda venda)
    //    {
    //        using (var contexto = new SalonEnterpriseContext())
    //        {
    //            contexto.tb_servico_venda.Update(venda);
    //            contexto.SaveChanges();
    //        }
    //    }
    //}
}