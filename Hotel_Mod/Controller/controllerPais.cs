using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{
    public class controllerPais<T> : controllerPai<T>
    {
        private DaoPais<T> daoPais; 

        public controllerPais() : base() 
        {
            daoPais = new DaoPais<T>();           
        }

        public override void alterar(T obj)
        {
            daoPais.alterar(obj);
        }
        public override void excluir(int idobj)
        {
            daoPais.excluir(idobj); 
        }

        public override void salvar(T obj)
        {
           daoPais.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoPais.GetAll(inativos);
        }
        public override T pesquisar(int id)
        {
           return daoPais.pesquisar(id);
        }


        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoPais.GetAll(false);

            if (typeof(T) == typeof(Pais))
            {
                var Model = obj.Cast<Pais>().ToList();

                foreach (var pais in Model)
                {
                    // Verifica se o nome já existe e não é o país atual que está sendo alterado
                    if (pais.pais.Equals(nome, StringComparison.OrdinalIgnoreCase) && pais.pais_ID != idAtual)
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
