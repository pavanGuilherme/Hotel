using Hotel_Mod.Class;
using Hotel_Mod.Dao;
using Hotel_Mod.DAO;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Mod.Controller
{
    public class controllerReservas<T> : controllerPai<T> where T : Reserva
    {
        private  DaoReserva<T> reservasDAO;

        public controllerReservas() : base()
        {
            reservasDAO = new DaoReserva<T>();
        }

        public override void alterar(T obj)
        {
            reservasDAO.alterar((T)(obj as Reserva));
        }

        public override void excluir(int idObj)
        {
            reservasDAO.excluir(idObj);
        }

        public int GetUltimoCodigo()
        {
            return reservasDAO.GetUltimoCodigo();
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> lista = new List<T>();
            var reservas = reservasDAO.GetAll(incluiInativos);
            foreach (var item in reservas)
            {
                lista.Add(item as T);
            }
            return lista;
        }
        public override T GetById(int idObj)
        {
            return reservasDAO.GetById(idObj) as T;
        }


        public bool InserirOcupacao(Ocupacao ocupacao)
        {
            return reservasDAO.InserirOcupacao(ocupacao);
        }

        public override void salvar(T obj)
        {
            reservasDAO.Salvar((T)(obj as Reserva));
        }


        public List<DateTime> BuscarDiasIndisponiveis(string tipoQuarto, int mes, int ano)
        {
            return reservasDAO.BuscarDiasIndisponiveis(tipoQuarto, mes, ano);
        }


        public void InserirHospedeNaReserva(int reservaID, int hospedeID)
        {
            reservasDAO.InserirHospedeNaReserva(reservaID, hospedeID);
        }

        public bool ExcluirReservasTemporariasPorReservaId(int reservaId)
        {
            return reservasDAO.ExcluirReservasTemporariasPorReservaId(reservaId);
        }

        public void CancelarReserva(int reservaId)
        {
            try
            {
                // Chama o método correspondente no DAO para atualizar o status
    
                reservasDAO.CancelarReserva(reservaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cancelar a reserva: " + ex.Message);
            }
        }

        public bool ExcluirReservaTemporaria(int tipoQuartoId, DateTime dataReserva)
        {
            return reservasDAO.ExcluirReservaTemporaria(tipoQuartoId, dataReserva);
        }

        public bool InserirReservaTemporaria(int tipoQuartoId, DateTime dataReserva)
        {
            return reservasDAO.InserirReservaTemporaria(tipoQuartoId, dataReserva);
        }

        public bool AtualizarReservaTemporaria(int reservaId, int tipoQuartoId)
        {
            return reservasDAO.AtualizarReservaTemporaria(reservaId, tipoQuartoId);
        }

        public bool ExcluirReservasTemporariasNaoSalvas()
        {
            return reservasDAO.ExcluirReservasTemporariasNaoSalvas();
        }
        public void AtualizarReservaComQuarto(int reservaID, int quartoID, int numero, int andar)
        {
            reservasDAO.AtualizarReservaComQuarto(reservaID, quartoID, numero, andar);
        }

        public Reserva ObterReservaPorQuarto(int quartoId)
        {
            return reservasDAO.ObterReservaPorQuarto(quartoId);
        }
        public void AtualizarStatusReserva(int reservaId, string status)
        {
            reservasDAO.AtualizarStatusReserva(reservaId, status);
        }

        public Reserva ObterReservaDetalhadaPorQuarto(int quartoId)
        {
            return reservasDAO.ObterReservaDetalhadaPorQuarto(quartoId);
        }

        public List<Hospede> ObterHospedesPorReserva(int reservaId)
        {
          
            return reservasDAO.ObterHospedesPorReserva(reservaId);
        }
        

        public List<DateTime> GetDatasReservadasPorReserva(int reservaId)
        {
            return reservasDAO.ObterDatasReservadasPorReserva(reservaId);
        }

        public (DateTime checkIn, DateTime checkOut)? ObterIntervaloReserva(int reservaId)
        {
            return reservasDAO.ObterIntervaloReserva(reservaId);
        }
    }
}
