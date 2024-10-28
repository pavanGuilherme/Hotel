using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Controller
{
    public class controllerContasPagar<T> : controllerPai<T> where T : ContasPagar
    {
        protected DaoContasPagar contasPagarDAO;

        public controllerContasPagar() : base()
        {
            contasPagarDAO = new DaoContasPagar();
        }

        public override void alterar(T obj)
        {
            contasPagarDAO.alterar(obj as ContasPagar);
        }

        public override void excluir(int idObj)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> lista = new List<T>();
            var ordens = contasPagarDAO.GetAll(incluiInativos);
            foreach (var item in ordens)
            {
                lista.Add(item as T);
            }
            return lista;
        }

        public override T GetById(int idObj)
        {
            throw new NotImplementedException();
        }

        public T GetContaById(int numeroNota, int serie, int idFornecedor, int parcela)
        {
            return contasPagarDAO.GetContaById(numeroNota, serie, idFornecedor, parcela) as T;
        }

        public override void salvar(T obj)
        {
            contasPagarDAO.Salvar(obj as ContasPagar);
        }

        public bool CancelarConta(T obj)
        {
            return contasPagarDAO.CancelarConta(obj as ContasPagar);
        }

        public bool VerificarParcelasNaoPagas(int numeroNota, int serie, int idFornecedor, int parcelaAtual)
        {
            return contasPagarDAO.VerificarParcelasNaoPagas(numeroNota, serie, idFornecedor, parcelaAtual);
        }

        public bool JaCadastrado(int numeroNota, int serie, int idFornecedor, int parcela, bool incluindo)
        {
            List<ContasPagar> contasPagar = contasPagarDAO.GetAll(false).Cast<ContasPagar>().ToList();

            foreach (ContasPagar conta in contasPagar)
            {
                if (conta.numeroNota == numeroNota &&
                    conta.serie == serie &&
                    conta.idFornecedor == idFornecedor &&
                    conta.parcela == parcela)
                {
                    if (incluindo)
                    {
                        // Se está incluindo e encontrou um registro com a mesma chave, retorna true
                        return true;
                    }
                    else
                    {
                        // Se está alterando, verificar se é a mesma conta que está sendo alterada
                        if (conta.numeroNota == numeroNota &&
                            conta.serie == serie &&
                            conta.idFornecedor == idFornecedor &&
                            conta.parcela == parcela)
                        {
                            // É a mesma conta que está sendo alterada, não é duplicada
                            return false;
                        }
                        else
                        {
                            // É uma conta diferente, retorna true
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
