using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Controller
{
    
    public class controllerProduto<T> : controllerPai<T>
    {
        private DaoProduto<T> daoProduto;

        public controllerProduto() : base()
        {
            daoProduto = new DaoProduto<T>();
        }

        public int GetUltimoCodigo()
        {
            return daoProduto.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoProduto.alterar(obj);
        }

        public override void excluir(int idobj)
        {
            daoProduto.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoProduto.Salvar(obj);
        }

        public override T GetById(int idObj)
        {
            return daoProduto.GetById(idObj);
        }

         public List<string> GetFornecedorById(int fornecedor_ID)
        {
            return daoProduto.GetFornecedorById(fornecedor_ID);
        }

        public (string Produto, string Unidade, decimal PrecoVenda)? getProduto(int id)
        {
            return daoProduto.getProduto(id);
        }


        public override List<T> GetAll(bool inativos)
        {
            return daoProduto.GetAll(inativos);
        }
        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoProduto.GetAll(false);

            if (typeof(T) == typeof(Produto))
            {
                var Model = obj.Cast<Produto>().ToList();

                foreach (var produto in Model)
                {
                    // Verifica se o nome do produto já existe e não é o produto atual que está sendo alterado
                    if (produto.nome_produto.Equals(nome, StringComparison.OrdinalIgnoreCase) && produto.produto_ID != idAtual)
                    {
                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Aviso: O tipo genérico T não é compatível com Produto.");
            }

            return false;
        }
    }



}
