using Hotel_Mod.Class;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Controller
{
    public class controllerQuarto<T> : controllerPai<T>
    {
        private DaoQuarto<T> daoQuarto;

        public controllerQuarto() : base()
        {
            daoQuarto = new DaoQuarto<T>();
        }
        public int GetUltimoCodigo()
        {
            return daoQuarto.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoQuarto.alterar(obj);
        }
        public override void excluir(int cidade_ID)
        {
            daoQuarto.excluir(cidade_ID);
        }

        public override void salvar(T obj)
        {
            daoQuarto.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoQuarto.GetAll(inativos);
        }

        public override T GetById(int id)
        {
            return daoQuarto.GetById(id);
        }

      


        public tipo_quarto ObterTipoQuartoPorId(int tipoId)
        {
            try
            {
                return daoQuarto.ObterTipoQuartoPorId(tipoId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter tipo de quarto por ID: " + ex.Message);
                return null;
            }
        }


        public bool JaCadastrado(int numero, int idAtual)
        {
            List<T> obj = daoQuarto.GetAll(false);

            if (typeof(T) == typeof(Quarto))
            {
                var Model = obj.Cast<Quarto>().ToList();

                foreach (var quarto in Model)
                {
                    // Verifica se o número já existe e não é o quarto atual que está sendo alterado
                    if (quarto.numero == numero && quarto.quarto_ID != idAtual)
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


        public List<Quarto> BuscarQuartosDisponiveis(int tipoQuarto_id)
        {
            try
            {
                return daoQuarto.BuscarQuartosDisponiveis(tipoQuarto_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na Controller ao buscar quartos disponíveis: " + ex.Message);
            }
        }

        public void AtualizarStatusQuarto(int quartoId, string status)
        {
            daoQuarto.AtualizarStatusQuarto(quartoId, status);
        }



    }
}
