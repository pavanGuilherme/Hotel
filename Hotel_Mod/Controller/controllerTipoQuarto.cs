using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Class
{
    public class controllerTipoQuarto<T> : controllerPai<T>
    {
        private DaoTipoQuarto<T> daoTipoQuarto;

        public controllerTipoQuarto() : base()
        {
            daoTipoQuarto = new DaoTipoQuarto<T>();
        }

        public int GetUltimoCodigo()
        {
            return daoTipoQuarto.GetUltimoCodigo();
        }

        public override void alterar(T obj)
        {
            daoTipoQuarto.alterar(obj);
        }

        public override void excluir(int idobj)
        {
            daoTipoQuarto.excluir(idobj);
        }

        public override void salvar(T obj)
        {
            daoTipoQuarto.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoTipoQuarto.GetAll(inativos);
        }

        public override T GetById(int idObj)
        {
            return daoTipoQuarto.GetById(idObj);
        }

        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoTipoQuarto.GetAll(true);

            if (typeof(T) == typeof(tipo_quarto))
            {
                var Model = obj.Cast<tipo_quarto>().ToList();

                foreach (var tipoQuarto in Model)
                {
                    // Verifica se o tipo já existe e não é o tipo de quarto atual que está sendo alterado
                    if (tipoQuarto.tipo.Equals(nome, StringComparison.OrdinalIgnoreCase) && tipoQuarto.tipo_quarto_ID != idAtual)
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
