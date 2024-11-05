using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Controller
{
    public class ControllerFormaPagamento<T> : controllerPai<T>
    {
        private DaoFormaPagamento<T> daoFormaPagamento;

        public ControllerFormaPagamento() : base()
        {
            daoFormaPagamento = new DaoFormaPagamento<T>();
        }


        public int GetUltimoCodigo()
        {
            return daoFormaPagamento.GetUltimoCodigo();
        }
        public override void alterar(T obj)
        {
            daoFormaPagamento.alterar(obj);
        }

        public override void excluir(int id)
        {
            daoFormaPagamento.excluir(id);
        }

        public override void salvar(T obj)
        {
            daoFormaPagamento.Salvar(obj);
        }

        public override T GetById(int idObj)
        {
            return daoFormaPagamento.GetById(idObj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoFormaPagamento.GetAll(inativos);
        }

      

        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoFormaPagamento.GetAll(false);

            if (typeof(T) == typeof(FormaPagamento))
            {
                var Model = obj.Cast<FormaPagamento>().ToList();

                foreach (var formaPagamento in Model)
                {
                    if (formaPagamento.formaPagamento.Equals(nome, StringComparison.OrdinalIgnoreCase) && formaPagamento.FormaPagamento_ID != idAtual)
                    {
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Aviso: O tipo genérico T não é compatível.");
            }

            return false;
        }
    }
}
