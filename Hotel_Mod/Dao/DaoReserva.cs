using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hotel_Mod.Class;
using Hotel_Mod.Models;

namespace Hotel_Mod.DAO
{
    public class DaoReserva<T> : Dao<T>
    {
        public DaoReserva() : base() { }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> reservas = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM reserva" : "SELECT * FROM reserva WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.reserva_ID = Convert.ToInt32(reader["reserva_ID"]);
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_ID"]);
                        obj.nome_cliente = reader["nome_cliente"].ToString();
                        obj.cpf_cliente = reader["cpf_cliente"]?.ToString();
                        obj.celular_cliente = reader["celular_cliente"]?.ToString();
                        obj.quarto_ID = Convert.ToInt32(reader["quarto_ID"]);
                        obj.numero_quarto = reader["numero_quarto"].ToString();
                        obj.andar = reader["andar"] != DBNull.Value ? Convert.ToInt32(reader["andar"]) : 0;
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);
                        obj.valor_total = Convert.ToDecimal(reader["valor_total"]);
                        obj.data_checkin = Convert.ToDateTime(reader["data_checkin"]);
                        obj.data_checkout = Convert.ToDateTime(reader["data_checkout"]);
                        obj.num_dias = Convert.ToInt32(reader["num_dias"]);
                        obj.status_pagamento = Convert.ToBoolean(reader["status_pagamento"]);
                        obj.condicao_pagamento_ID = reader["condicao_pagamento_ID"] != DBNull.Value ? Convert.ToInt32(reader["condicao_pagamento_ID"]) : 0;
                        obj.condicao_pagamento = reader["condicao_pagamento"]?.ToString();
                        obj.status_reserva = reader["status_reserva"].ToString();
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null;
                        obj.observacao = reader["observacao"]?.ToString();
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        obj.usuario_ult_alt = reader["usuario_ult_alt"].ToString();

                        reservas.Add(obj);
                    }
                }
            }

            return reservas;
        }

        public Quarto GetCodQuartoById(int reserva_ID)
        {
            Quarto quarto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    r.quarto_ID AS [Cód Quarto], 
                    q.numero_quarto AS [Numero Quarto], 
                    q.andar AS [Andar], 
                    q.valor_diaria AS [Valor Diária]
                FROM 
                    reserva r
                INNER JOIN 
                    quartos q ON r.quarto_ID = q.quarto_ID
                WHERE 
                    r.reserva_ID = @reserva_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva_ID", reserva_ID);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        quarto = new Quarto
                        {
                            quarto_ID = Convert.ToInt32(reader["quarto_ID"]),
                            numero = Convert.ToInt32(reader["numero"]),
                            andar  = Convert.ToInt32(reader["andar"]),
                            valor = Convert.ToDecimal(reader["valor"])
                        };
                    }
                }
            }

            return quarto;
        }
    

    public override void Salvar(T obj)
        {
            dynamic reserva = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO reserva (cliente_ID, nome_cliente, cpf_cliente, celular_cliente, quarto_ID, numero_quarto, andar, valor_diaria, valor_total, data_checkin, data_checkout, num_dias, status_pagamento, condicao_pagamento_ID, condicao_pagamento, status_reserva, data_cancelamento, observacao, ativo, data_cadastro, data_ult_alt, usuario_ult_alt) 
                    VALUES (@cliente_ID, @nome_cliente, @cpf_cliente, @celular_cliente, @quarto_ID, @numero_quarto, @andar, @valor_diaria, @valor_total, @data_checkin, @data_checkout, @num_dias, @status_pagamento, @condicao_pagamento_ID, @condicao_pagamento, @status_reserva, @data_cancelamento, @observacao, @ativo, @data_cadastro, @data_ult_alt, @usuario_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_ID", reserva.cliente_ID);
                command.Parameters.AddWithValue("@nome_cliente", reserva.nome_cliente);
                command.Parameters.AddWithValue("@cpf_cliente", reserva.cpf_cliente ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@celular_cliente", reserva.celular_cliente ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@quarto_ID", reserva.quarto_ID);
                command.Parameters.AddWithValue("@numero_quarto", reserva.numero_quarto);
                command.Parameters.AddWithValue("@andar", reserva.andar != 0 ? (object)reserva.andar : DBNull.Value);
                command.Parameters.AddWithValue("@valor_diaria", reserva.valor_diaria);
                command.Parameters.AddWithValue("@valor_total", reserva.valor_total);
                command.Parameters.AddWithValue("@data_checkin", reserva.data_checkin);
                command.Parameters.AddWithValue("@data_checkout", reserva.data_checkout);
                command.Parameters.AddWithValue("@num_dias", reserva.num_dias);
                command.Parameters.AddWithValue("@status_pagamento", reserva.status_pagamento);
                command.Parameters.AddWithValue("@condicao_pagamento_ID", reserva.condicao_pagamento_ID != 0 ? (object)reserva.condicao_pagamento_ID : DBNull.Value);
                command.Parameters.AddWithValue("@condicao_pagamento", reserva.condicao_pagamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@status_reserva", reserva.status_reserva);
                command.Parameters.AddWithValue("@data_cancelamento", reserva.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", reserva.observacao ?? string.Empty);
                command.Parameters.AddWithValue("@ativo", reserva.ativo);
                command.Parameters.AddWithValue("@data_cadastro", reserva.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", reserva.data_ult_alt);
                command.Parameters.AddWithValue("@usuario_ult_alt", reserva.usuario_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM reserva WHERE reserva_ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool CancelarReserva(int reserva_ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Atualiza a data de cancelamento e o status da reserva para "Cancelado"
                        string queryCancelarReserva = @"
                         UPDATE reserva
                         SET data_cancelamento = @data_cancelamento, status_reserva = 'Cancelado'
                         WHERE reserva_ID = @reserva_ID";

                        using (SqlCommand cmd = new SqlCommand(queryCancelarReserva, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@data_cancelamento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@reserva_ID", reserva_ID);
                            cmd.ExecuteNonQuery();
                        }

                        // Obtém o quarto associado a esta reserva
                        string queryQuartoReserva = @"
                        SELECT quarto_ID, data_checkin, data_checkout
                        FROM reserva
                        WHERE reserva_ID = @reserva_ID";

                        int quartoID = 0;
                        DateTime dataCheckin = DateTime.MinValue;
                        DateTime dataCheckout = DateTime.MinValue;

                        using (SqlCommand cmd = new SqlCommand(queryQuartoReserva, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@reserva_ID", reserva_ID);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    quartoID = reader.GetInt32(reader.GetOrdinal("quarto_ID"));
                                    dataCheckin = reader.GetDateTime(reader.GetOrdinal("data_checkin"));
                                    dataCheckout = reader.GetDateTime(reader.GetOrdinal("data_checkout"));
                                }
                            }
                        }

                        // Atualiza o status de disponibilidade do quarto, se aplicável
                        string queryAtualizarQuarto = @"
                UPDATE quarto
                SET disponivel = 1
                WHERE quarto_ID = @quarto_ID";

                        using (SqlCommand cmd = new SqlCommand(queryAtualizarQuarto, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@quarto_ID", quartoID);
                            cmd.ExecuteNonQuery();
                        }

                        // Cancela contas a pagar associadas à reserva, se existirem
                        string queryCancelarContasPagar = @"
                UPDATE contasPagar
                SET data_cancelamento = @data_cancelamento
                WHERE reserva_ID = @reserva_ID AND ativo = 1";

                        using (SqlCommand cmd = new SqlCommand(queryCancelarContasPagar, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@data_cancelamento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@reserva_ID", reserva_ID);
                            cmd.ExecuteNonQuery();
                        }

                        // Confirma a transação
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao cancelar a reserva: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com o banco de dados: " + ex.Message);
            }
        }


        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM reserva WHERE reserva_ID = @reserva_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.reserva_ID = Convert.ToInt32(reader["reserva_ID"]);
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_ID"]);
                        obj.nome_cliente = reader["nome_cliente"].ToString();
                        obj.cpf_cliente = reader["cpf_cliente"]?.ToString();
                        obj.celular_cliente = reader["celular_cliente"]?.ToString();
                        obj.quarto_ID = Convert.ToInt32(reader["quarto_ID"]);
                        obj.numero_quarto = reader["numero_quarto"].ToString();
                        obj.andar = reader["andar"] != DBNull.Value ? Convert.ToInt32(reader["andar"]) : 0;
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);
                        obj.valor_total = Convert.ToDecimal(reader["valor_total"]);
                        obj.data_checkin = Convert.ToDateTime(reader["data_checkin"]);
                        obj.data_checkout = Convert.ToDateTime(reader["data_checkout"]);
                        obj.num_dias = Convert.ToInt32(reader["num_dias"]);
                        obj.status_pagamento = Convert.ToBoolean(reader["status_pagamento"]);
                        obj.condicao_pagamento_ID = reader["condicao_pagamento_ID"] != DBNull.Value ? Convert.ToInt32(reader["condicao_pagamento_ID"]) : 0;
                        obj.condicao_pagamento = reader["condicao_pagamento"]?.ToString();
                        obj.status_reserva = reader["status_reserva"].ToString();
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null;
                        obj.observacao = reader["observacao"]?.ToString();
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        obj.usuario_ult_alt = reader["usuario_ult_alt"].ToString();

                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }

        public override void alterar(T obj)
        {
            dynamic reserva = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE reserva 
                    SET cliente_ID = @cliente_ID, nome_cliente = @nome_cliente, cpf_cliente = @cpf_cliente, celular_cliente = @celular_cliente, quarto_ID = @quarto_ID, numero_quarto = @numero_quarto, andar = @andar, valor_diaria = @valor_diaria, valor_total = @valor_total, data_checkin = @data_checkin, data_checkout = @data_checkout, num_dias = @num_dias, status_pagamento = @status_pagamento, condicao_pagamento_ID = @condicao_pagamento_ID, condicao_pagamento = @condicao_pagamento, status_reserva = @status_reserva, data_cancelamento = @data_cancelamento, observacao = @observacao, ativo = @ativo, data_ult_alt = @data_ult_alt, usuario_ult_alt = @usuario_ult_alt 
                    WHERE reserva_ID = @reserva_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva_ID", reserva.reserva_ID);
                command.Parameters.AddWithValue("@cliente_ID", reserva.cliente_ID);
                command.Parameters.AddWithValue("@nome_cliente", reserva.nome_cliente);
                command.Parameters.AddWithValue("@cpf_cliente", reserva.cpf_cliente ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@celular_cliente", reserva.celular_cliente ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@quarto_ID", reserva.quarto_ID);
                command.Parameters.AddWithValue("@numero_quarto", reserva.numero_quarto);
                command.Parameters.AddWithValue("@andar", reserva.andar != 0 ? (object)reserva.andar : DBNull.Value);
                command.Parameters.AddWithValue("@valor_diaria", reserva.valor_diaria);
                command.Parameters.AddWithValue("@valor_total", reserva.valor_total);
                command.Parameters.AddWithValue("@data_checkin", reserva.data_checkin);
                command.Parameters.AddWithValue("@data_checkout", reserva.data_checkout);
                command.Parameters.AddWithValue("@num_dias", reserva.num_dias);
                command.Parameters.AddWithValue("@status_pagamento", reserva.status_pagamento);
                command.Parameters.AddWithValue("@condicao_pagamento_ID", reserva.condicao_pagamento_ID != 0 ? (object)reserva.condicao_pagamento_ID : DBNull.Value);
                command.Parameters.AddWithValue("@condicao_pagamento", reserva.condicao_pagamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@status_reserva", reserva.status_reserva);
                command.Parameters.AddWithValue("@data_cancelamento", reserva.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", reserva.observacao ?? string.Empty);
                command.Parameters.AddWithValue("@ativo", reserva.ativo);
                command.Parameters.AddWithValue("@data_ult_alt", reserva.data_ult_alt);
                command.Parameters.AddWithValue("@usuario_ult_alt", reserva.usuario_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
