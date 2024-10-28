using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Hotel_Mod;

namespace Hotel_Mod.Class
{
    public class ControllerNotaCompra<T> : controllerPai<T> where T : nota_Compra
    {
        private Daonota_compra<T> daoNotaCompra;

        public ControllerNotaCompra() : base()
        {
            daoNotaCompra = new Daonota_compra<T>();
        }

        public override void alterar(T obj)
        {
            daoNotaCompra.alterar(obj);
        }

        public override void excluir(int idObj)
        {
            daoNotaCompra.excluir(idObj);
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> lista = new List<T>();
            var ordens = daoNotaCompra.GetAll(incluiInativos);
            foreach (var item in ordens)
            {
                lista.Add(item as T);
            }
            return lista;
        }

        public override T GetById(int idObj)
        {
            throw new NotImplementedException();
        }

        public T GetNotaById(int numero, int serie, int idFornecedor)
        {
            return daoNotaCompra.GetNotaById(numero, serie, idFornecedor) as T;
        }

        public override void salvar(T obj)
        {
            daoNotaCompra.Salvar(obj as nota_Compra);
        }
        public Produto GetProdutoById(int produto_ID)
        {
            return daoNotaCompra.GetProdutoById(produto_ID);
        }

        public void AtualizarProdutosNotaCompra(nota_Compra obj)
        {
            daoNotaCompra.AtualizarProdutosnota_compra((nota_Compra)obj);
        }
        public bool CancelarNotaCompra(int numeroNota, int serie, int idFornecedor)
        {
            return daoNotaCompra.Cancelarnota_compra(numeroNota, serie, idFornecedor);
        }

        public bool ExisteNota(int numeroNota, string serie, int idFornecedor)
        {
            return daoNotaCompra.ExisteNota(numeroNota, serie, idFornecedor);
        }
    }
}
