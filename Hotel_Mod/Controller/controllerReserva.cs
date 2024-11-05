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

        public List<DateTime> ObterDatasIndisponiveis(int quartoId, DateTime dataInicio, DateTime dataFim)
        {
            return reservasDAO.ObterDatasIndisponiveis(quartoId, dataInicio, dataFim);
        }

        public bool InserirOcupacao(Ocupacao ocupacao)
        {
            return reservasDAO.InserirOcupacao(ocupacao);
        }

        public override void salvar(T obj)
        {
            reservasDAO.Salvar((T)(obj as Reserva));
        }

        public void InserirHospedeNaReserva(int reservaID, int hospedeID)
        {
            reservasDAO.InserirHospedeNaReserva(reservaID, hospedeID);
        }


        public bool CancelarReserva(int reserva_ID)
        {
            return reservasDAO.CancelarReserva(reserva_ID);
        }

      
    }
}
