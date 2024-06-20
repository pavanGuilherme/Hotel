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
    public class controllerCliente<T>: controllerPai<T>
    {
        private DaoCliente<T> daoCliente;

        public controllerCliente() : base()
        {
            daoCliente = new DaoCliente<T>();
        }

        public override void alterar(T obj)
        {
            daoCliente.alterar(obj);
        }
        public override void excluir(int idobj)
        {
            daoCliente.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoCliente.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoCliente.GetAll(inativos);
        }
        public override T pesquisar(int id)
        {
            return daoCliente.pesquisar(id);
        }


        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoCliente.GetAll(false);

            if (typeof(T) == typeof(Clientes))
            {
                var Model = obj.Cast<Clientes>().ToList();

                foreach (var cliente in Model)
                {
                    // Verifica se o nome já existe e não é o país atual que está sendo alterado
                    if (cliente.nome.Equals(nome, StringComparison.OrdinalIgnoreCase) && cliente.cliente_ID != idAtual)
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

