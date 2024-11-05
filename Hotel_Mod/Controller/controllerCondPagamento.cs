using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Controller
{
    public class controllerCondPagamento<T> : controllerPai<T> where T: CondicaoPagamento
    {
        private DaoCondicaoPagamento daoCondicaoPagamento;

        public controllerCondPagamento() : base()
        {
            daoCondicaoPagamento = new DaoCondicaoPagamento();
        }

        public int GetUltimoCodigo()
        {
            return daoCondicaoPagamento.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoCondicaoPagamento.alterar(obj);
        }

        public override void excluir(int condPagamento_ID)
        {
            daoCondicaoPagamento.excluir(condPagamento_ID);
        }

        public override void salvar(T obj)
        {
            daoCondicaoPagamento.Salvar(obj);
        }

        public override List<T> GetAll (bool incluirInativos)
        {
            List<T> lista = new List<T>();
            var condicoes = daoCondicaoPagamento.GetAll(incluirInativos);
            foreach (var item in condicoes)
            {
                lista.Add(item as T);
            }
            return lista;
        }


        public override T GetById(int idobj)
        {
            return daoCondicaoPagamento.GetById(idobj) as T;
        }

       


        public string GetFormaPagByParcelaId(int idParcela)
        {
            return daoCondicaoPagamento.GetFormaPagByParcelaId(idParcela);
        }

        public bool JaCadastrado(string descricao, int idAtual)
        {
            List<CondicaoPagamento> obj = daoCondicaoPagamento.GetAll(false);

            foreach (var condicao in obj)
            {
                // Verifica se a descrição já existe e não é a condição atual que está sendo alterada
                if (condicao.condicaoPagamento.Equals(descricao, StringComparison.OrdinalIgnoreCase) && condicao.CondPagamento_ID != idAtual)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
