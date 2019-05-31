using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class FuncionarioDAO
    {

        public List<Funcionario> Lista()
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                return contexto.tb_funcionarios.ToList();
            }
        }

        public void Adiciona(Funcionario funcionario)
        {
            using (var context = new SalonEnterpriseContext())
            {
                context.tb_funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public Funcionario BuscaPorId(int Id)
        {
            using (var context = new SalonEnterpriseContext())
            {
                return context.tb_funcionarios.Where(p => p.Id == Id).FirstOrDefault();
            }
        }

        public void RemoverFuncionario(int id)
        {
            using (var context = new SalonEnterpriseContext())
            {

                var func = context.tb_funcionarios.Where(p => p.Id == id).FirstOrDefault();
                context.tb_funcionarios.Remove(func);
                context.SaveChanges();

            }
        }

        public void Atualiza(Funcionario funcionario)
        {
            using (var contexto = new SalonEnterpriseContext())
            {
                contexto.tb_funcionarios.Update(funcionario);
                contexto.SaveChanges();
            }
        }

    
    }
}