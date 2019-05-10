using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class FornecedorDAO
    {
        public IList<Fornecedor> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_fornecedores.ToList();
            }
        }

        public void Adiciona(Fornecedor fornecedor)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_fornecedores.Add(fornecedor);
                context.SaveChanges();
            }
        }

        public Fornecedor BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_fornecedores.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverFornecedor(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var forn = context.tb_fornecedores.Where(p => p.Id == id).FirstOrDefault();
                context.tb_fornecedores.Remove(forn);
                context.SaveChanges();

            }
        }

        public void Atualiza(Fornecedor fornecedor)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_fornecedores.Update(fornecedor);
                contexto.SaveChanges();
            }
        }
    }
}