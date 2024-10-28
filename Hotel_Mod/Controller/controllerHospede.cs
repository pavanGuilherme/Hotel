using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Controller
{
    public class controllerHospede<T> : controllerPai<T>
    {
        private DaoHospede<T> daoHospede;

        public controllerHospede() : base()
        {
            daoHospede = new DaoHospede<T>();
        }

        public override void alterar(T obj)
        {
            daoHospede.alterar(obj);
        }

        public override void excluir(int idObj)
        {
            daoHospede.excluir(idObj);
        }

        public override void salvar(T obj)
        {
            daoHospede.Salvar(obj);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoHospede.GetAll(inativos);
        }

        public override T GetById(int idObj)
        {
            return daoHospede.GetById(idObj);
        }

        public List<string> GetCidadeEstadoEPaisByCidadeId(int cidade_ID)
        {
            return daoHospede.GetCidadeEstadoEPaisByCidadeId(cidade_ID);
        }

        public bool JaCadastrado(string nome, int idAtual)
        {
            List<T> obj = daoHospede.GetAll(false);

            if (typeof(T) == typeof(Hospede))
            {
                var Model = obj.Cast<Hospede>().ToList();

                foreach (var hospede in Model)
                {
                    // Verifica se o nome já existe e não é o hóspede atual que está sendo alterado
                    if (hospede.nome.Equals(nome, StringComparison.OrdinalIgnoreCase) && hospede.hospede_id != idAtual)
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
