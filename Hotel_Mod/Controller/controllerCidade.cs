using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{

        public class controllerCidade<T> : controllerPai<T>
        {
            private DaoCidade<T> daoCidade;

            public controllerCidade() : base()
            {
                daoCidade = new DaoCidade<T>();
            }

            public override void alterar(T obj)
            {
                daoCidade.alterar(obj);
            }
            public override void excluir(int idobj)
            {
                daoCidade.excluir(idobj);
            }

            public override void salvar(T obj)
            {
                daoCidade.Salvar(obj);
            }

            public override List<T> GetAll(bool inativos)
            {
                return daoCidade.GetAll(inativos);
            }

            public override T pesquisar(int id)
            {
                return daoCidade.pesquisar(id);
            }
        public string GetNomeEstadoByCidadeId(int cidade_ID)
        {
            return daoCidade.GetNomeEstadoByCidadeId(cidade_ID);
        }


        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoCidade.GetAll(false);

            if (typeof(T) == typeof(Cidade))
            {
                var Model = obj.Cast<Cidade>().ToList();

                foreach (var cidade in Model)
                {
                    // Verifica se o nome já existe e não é o país atual que está sendo alterado
                    if (cidade.cidade.Equals(nome, StringComparison.OrdinalIgnoreCase) && cidade.cidade_ID != idAtual)
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
