using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.Controller
{
    public class controllerContasReceber<T> : controllerPai<T>
    {
        private DaoContasReceber<T> daoContasReceber;

        public controllerContasReceber() : base()
        {
            daoContasReceber = new DaoContasReceber<T>();
        }

        public override void alterar(T obj)
        {
            daoContasReceber.alterar(obj);
        }

        public override void excluir(int idObj)
        {
            throw new NotImplementedException("A exclusão direta não é permitida para contas a receber. Considere marcar como cancelada.");
        }

        public override void salvar(T obj)
        {
            daoContasReceber.Salvar(obj);
        }

        public void Salvar(List<ContasReceber> contasReceber)
        {
            daoContasReceber.salvar(contasReceber);
        }

        public override List<T> GetAll(bool inativos)
        {
            return daoContasReceber.GetAll(inativos);
        }

        public override T GetById(int idObj)
        {
            throw new NotImplementedException("A busca por ID único não é aplicável devido à chave composta. Use métodos específicos.");
        }

        public int GetUltimoCodigo()
        {
            return daoContasReceber.GetUltimoCodigo();
        }

        public List<T> GetByClienteId(int clienteId)
        {
            return daoContasReceber.GetByClienteId(clienteId);
        }

        public bool VerificarParcelasNaoPagas(int reservaId, int idCliente, int parcelaAtual)
        {
            try
            {
                // Chama o método no DAO para verificar parcelas não pagas
                return daoContasReceber.VerificarParcelasNaoPagasPorReserva(reservaId, idCliente, parcelaAtual);
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro em caso de exceção
                MessageBox.Show($"Erro ao verificar parcelas não pagas para a reserva com ID {reservaId} e cliente {idCliente}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Retorna falso em caso de erro
            }
        }

        public bool CancelarContaPorReserva(ContasReceber obj)
        {
            try
            {
                // Chama o método no DAO para cancelar a conta vinculada à reserva
                return daoContasReceber.CancelarContaPorReserva(obj);
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro em caso de falha
                MessageBox.Show($"Erro ao cancelar a conta da reserva {obj.reserva_ID}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Retorna falso caso ocorra uma exceção
            }
        }

        public ContasReceber GetContaByReserva(int reservaId, int clienteId, int parcela)
        {
            try
            {
                // Chama o método no DAO para buscar a conta com base na reserva, cliente e parcela
                return daoContasReceber.GetContaByReserva(reservaId, clienteId, parcela);
            }
            catch (Exception ex)
            {
                // Log ou mensagem de erro para o usuário
                MessageBox.Show($"Erro ao buscar conta por reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retorna null em caso de erro
            }
        }






    }
}
