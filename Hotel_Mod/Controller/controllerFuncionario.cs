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
    public class controllerFuncionario<T> : controllerPai<T>
    {
        private DaoFuncionario<T> daoFuncionario;

        public controllerFuncionario() : base()
        {
            daoFuncionario = new DaoFuncionario<T>();
        }

        public override void alterar(T obj)
        {
            daoFuncionario.alterar(obj);
        }
        public override void excluir(int idobj)
        {
            daoFuncionario.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoFuncionario.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoFuncionario.GetAll(inativos);
        }

        public override T pesquisar(int id)
        {
            return daoFuncionario.pesquisar(id);
        }

        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoFuncionario.GetAll(false);

            if (typeof(T) == typeof(Funcionario))
            {
                var Model = obj.Cast<Funcionario>().ToList();

                foreach (var funcionario in Model)
                {
                    // Verifica se o nome já existe e não é o país atual que está sendo alterado
                    if (funcionario.nome.Equals(nome, StringComparison.OrdinalIgnoreCase) && funcionario.funcionario_ID != idAtual)
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

