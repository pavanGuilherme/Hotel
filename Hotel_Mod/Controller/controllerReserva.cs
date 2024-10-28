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

      
        public override void salvar(T obj)
        {
            reservasDAO.Salvar((T)(obj as Reserva));
        }

        public bool CancelarReserva(int reserva_ID)
        {
            return reservasDAO.CancelarReserva(reserva_ID);
        }

        //public bool VerificarDisponibilidade(int idQuarto, DateTime dataEntrada, DateTime dataSaida)
        //{
        //    return reservasDAO.VerificarDisponibilidade(idQuarto, dataEntrada, dataSaida);
        //}

        public bool JaReservado(int idCliente, DateTime dataEntrada, DateTime dataSaida, bool incluindo)
        {
            List<Reserva> reservas = reservasDAO.GetAll(false).Cast<Reserva>().ToList();

            foreach (Reserva reserva in reservas)
            {
                if (reserva.cliente_ID == idCliente &&
                    reserva.data_checkin == dataEntrada &&
                    reserva.data_checkout == dataSaida)
                {
                    if (incluindo)
                    {
                        // Se está incluindo e encontrou um registro com a mesma chave, retorna true
                        return true;
                    }
                    else
                    {
                        // Se está alterando, verificar se é a mesma reserva que está sendo alterada
                        if (reserva.cliente_ID == idCliente &&
                            reserva.data_checkin == dataEntrada &&
                            reserva.data_checkout == dataSaida)
                        {
                            // É a mesma reserva que está sendo alterada, não é duplicada
                            return false;
                        }
                        else
                        {
                            // É uma reserva diferente, retorna true
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
