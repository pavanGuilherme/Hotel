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

        public int GetUltimoCodigo()
        {
            return daoFuncionario.GetUltimoCodigo();
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

       
        public List<string> GetCEPByIdCidade(int cidade_ID)
        {
            return daoFuncionario.GetCEPByIdCidade(cidade_ID);
        }


        public override T GetById(int idObj)
        {
            return daoFuncionario.GetById(idObj);
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


        public bool BuscaNome(string nome, int idAtual)
        {
            List<Funcionario> funcinoarios = daoFuncionario.GetAll(false).Cast<Funcionario>().ToList();

            foreach (Funcionario funcionario in funcinoarios)
            {
                if (string.Equals(funcionario.nome, nome, StringComparison.OrdinalIgnoreCase) && funcionario.funcionario_ID != idAtual)
                {
                    return true;
                }
            }
            return false;
        }

    }


}

