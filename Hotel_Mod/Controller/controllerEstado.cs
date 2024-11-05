using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Controller
{
    public class controllerEstado<T> : controllerPai<T>
    {
        private DaoEstado<T> daoEstado;

        public controllerEstado() : base()
        {
            daoEstado = new DaoEstado<T>();
        }

        public int GetUltimoCodigo()
        {
            return daoEstado.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoEstado.alterar(obj);
        }
        public override void excluir(int idobj)
        {
            daoEstado.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoEstado.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoEstado.GetAll(inativos);
        }

      

        public string GetNomePaisByEstadoId(int estado_ID)
        {
            return daoEstado.GetNomePaisByEstadoId(estado_ID);
        }



        public override T GetById(int idObj)
        {
            return daoEstado.GetById(idObj);
        }

        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoEstado.GetAll(false);

            if (typeof(T) == typeof(Estado))
            {
                var Model = obj.Cast<Estado>().ToList();

                foreach (var Estado in Model)
                {
                    // Verifica se o nome já existe e não é o país atual que está sendo alterado
                    if (Estado.estado.Equals(nome, StringComparison.OrdinalIgnoreCase) && Estado.estado_ID != idAtual)
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
