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
    public class ControllerFornecedor<T> : controllerPai<T>
    {
        private DaoFornecedor<T> daoFornecedor;

        public ControllerFornecedor() : base()
        {
            daoFornecedor = new DaoFornecedor<T>();
        }

        public int GetUltimoCodigo()
        {
            return daoFornecedor.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoFornecedor.alterar(obj);
        }

        public override void excluir(int idobj)
        {
            daoFornecedor.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoFornecedor.Salvar(obj);
        }


        public override T GetById(int idObj)
        {
            return daoFornecedor.GetById(idObj);
        }


        public override List<T> GetAll(bool inativos)
        {
            return daoFornecedor.GetAll(inativos);
        }

       

        public List<string> GetCEPByIdCidade(int cidade_ID)
        {
            return daoFornecedor.GetCEPByIdCidade(cidade_ID);
        }

     

        public bool JaCadastrado(string razaoSocial, int idAtual)
        {
            List<T> obj = daoFornecedor.GetAll(false);

            if (typeof(T) == typeof(Fornecedor))
            {
                var fornecedores = obj.Cast<Fornecedor>().ToList();

                foreach (var fornecedor in fornecedores)
                {
                    // Verifica se a razão social já existe e não é o fornecedor atual que está sendo alterado
                    if (fornecedor.fornecedor_razao_social.Equals(razaoSocial, StringComparison.OrdinalIgnoreCase) && fornecedor.fornecedor_ID != idAtual)
                    {
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Aviso: O tipo genérico T não é compatível com Fornecedor.");
            }

            return false;
        }
    }
}
