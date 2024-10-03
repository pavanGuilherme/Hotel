using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Class
{
    public class controllerNotaCompra<T> : controllerPai<T>
    {
        private DaoNotaCompra<T> daoNotaCompra;

        public controllerNotaCompra() : base()
        {
            daoNotaCompra = new DaoNotaCompra<T>();
        }

        public override void alterar(T obj)
        {
            daoNotaCompra.alterar(obj);
        }

        public override void excluir(int idObj)
        {
            daoNotaCompra.excluir(idObj);
        }

        public override void salvar(T obj)
        {
            daoNotaCompra.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoNotaCompra.GetAll(inativos);
        }

        public override T GetById(int idObj)
        {
            return daoNotaCompra.GetById(idObj);
        }

        public bool JaCadastrado(int numNota, int modelo, int serie, int idAtual)
        {
            List<T> obj = daoNotaCompra.GetAll(false);

            if (typeof(T) == typeof(nota_Compra))
            {
                var Model = obj.Cast<nota_Compra>().ToList();

                foreach (var nota in Model)
                {
                    // Verifica se a nota de compra já existe e não é a nota atual que está sendo alterada
                    if (nota.num_Nota == numNota && nota.modelo == modelo && nota.serie == serie && nota.num_Nota != idAtual)
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
