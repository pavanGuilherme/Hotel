using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using Hotel_Mod.Class;
using Hotel_Mod.Models;

namespace Hotel_Mod.Dao
{
    public class DaoContasReceber<T> : Dao<T>
    {
        public DaoContasReceber() : base()
        {
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> contasReceber = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Ajustar a lógica de inativos conforme necessário
                string query = incluiInativos ?
                    "SELECT * FROM ContasReceber" :
                    "SELECT * FROM ContasReceber WHERE data_cancelamento IS NULL";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.reserva_ID = Convert.ToInt32(reader["reserva_ID"]);
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_ID"]);
                        obj.valor_total = Convert.ToDecimal(reader["valor_total"]);
                        obj.valor_parcela = Convert.ToDecimal(reader["valor_parcela"]);
                        obj.data_emissao = Convert.ToDateTime(reader["data_emissao"]);
                        obj.data_vencimento = Convert.ToDateTime(reader["data_vencimento"]);
                        obj.data_recebimento = reader["data_recebimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_recebimento"]) : (DateTime?)null;
                        obj.formaPagamento_ID = Convert.ToInt32(reader["formaPagamento_ID"]);
                        obj.num_parcela = Convert.ToInt32(reader["num_parcela"]);
                        obj.juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : (decimal?)null;
                        obj.multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : (decimal?)null;
                        obj.desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : (decimal?)null;
                        obj.valorRecebido = reader["valorRecebido"] != DBNull.Value ? Convert.ToDecimal(reader["valorRecebido"]) : (decimal?)null;
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null;
                        obj.observacao = reader["observacao"] != DBNull.Value ? reader["observacao"].ToString() : null;
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        contasReceber.Add(obj);
                    }
                }
            }
            return contasReceber;
        }


        public int GetUltimoCodigo()
        {
            int ultimoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 num_parcela FROM ContasReceber ORDER BY data_cadastro DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    ultimoCodigo = Convert.ToInt32(result);
                }
            }
            return ultimoCodigo;
        }



        public override void Salvar(T obj)
        {
            dynamic conta = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO ContasReceber 
            (reserva_ID, cliente_ID, valor_total, data_emissao, data_vencimento, data_recebimento, formaPagamento_ID, 
             num_parcela, juros, multa, desconto, valorRecebido, data_cancelamento, observacao, 
             data_cadastro, data_ult_alt) 
            VALUES 
            (@reserva_ID, @cliente_ID, @valor_total, @data_emissao, @data_vencimento, @data_recebimento, @formaPagamento_ID, 
             @num_parcela, @juros, @multa, @desconto, @valorRecebido, @data_cancelamento, @observacao, 
             @data_cadastro, @data_ult_alt)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reserva_ID", conta.reserva_ID);
                    command.Parameters.AddWithValue("@cliente_ID", conta.cliente_ID);
                    command.Parameters.AddWithValue("@valor_total", conta.valor_total);
                    command.Parameters.AddWithValue("@data_emissao", conta.data_emissao);
                    command.Parameters.AddWithValue("@data_vencimento", conta.data_vencimento);
                    command.Parameters.AddWithValue("@data_recebimento", conta.data_recebimento ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@formaPagamento_ID", conta.formaPagamento_ID);
                    command.Parameters.AddWithValue("@num_parcela", conta.num_parcela);
                    command.Parameters.AddWithValue("@juros", conta.juros ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@multa", conta.multa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@desconto", conta.desconto ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@valorRecebido", conta.valorRecebido ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@data_cancelamento", conta.data_cancelamento ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@observacao", conta.observacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@data_cadastro", conta.data_cadastro);
                    command.Parameters.AddWithValue("@data_ult_alt", conta.data_ult_alt);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public override void excluir(int id)
        {
            throw new NotImplementedException("A exclusão direta de contas a receber não é recomendada. Considere marcar como cancelada.");
        }

        public override void alterar(T obj)
        {
            dynamic conta = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE ContasReceber 
            SET data_recebimento = @data_recebimento, juros = @juros, multa = @multa, desconto = @desconto, 
                valorRecebido = @valorRecebido, data_cancelamento = @data_cancelamento, observacao = @observacao, 
                data_ult_alt = @data_ult_alt
            WHERE reserva_ID = @reserva_ID AND cliente_ID = @cliente_ID AND num_parcela = @num_parcela";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@data_recebimento", conta.data_recebimento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@juros", conta.juros ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@multa", conta.multa ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@desconto", conta.desconto ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@valorRecebido", conta.valorRecebido ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", conta.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", conta.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_ult_alt", conta.data_ult_alt);
                command.Parameters.AddWithValue("@reserva_ID", conta.reserva_ID);
                command.Parameters.AddWithValue("@cliente_ID", conta.cliente_ID);
                command.Parameters.AddWithValue("@num_parcela", conta.num_parcela);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public override T GetById(int id)
        {
            throw new NotImplementedException("A busca por ID único não é aplicável a essa tabela, devido à chave composta.");
        }

        // Método para obter contas por cliente
        public List<T> GetByClienteId(int clienteId)
        {
            List<T> contasReceber = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ContasReceber WHERE cliente_ID = @cliente_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_ID", clienteId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.reserva_ID = Convert.ToInt32(reader["reserva_ID"]);
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_ID"]);
                        obj.valor_total = Convert.ToDecimal(reader["valor_total"]);
                        obj.data_emissao = Convert.ToDateTime(reader["data_emissao"]);
                        obj.data_vencimento = Convert.ToDateTime(reader["data_vencimento"]);
                        obj.data_recebimento = reader["data_recebimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_recebimento"]) : (DateTime?)null;
                        obj.formaPagamento_ID = Convert.ToInt32(reader["formaPagamento_ID"]);
                        obj.num_parcela = Convert.ToInt32(reader["num_parcela"]);
                        obj.juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : (decimal?)null;
                        obj.multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : (decimal?)null;
                        obj.desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : (decimal?)null;
                        obj.valorRecebido = reader["valorRecebido"] != DBNull.Value ? Convert.ToDecimal(reader["valorRecebido"]) : (decimal?)null;
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null;
                        obj.observacao = reader["observacao"] != DBNull.Value ? reader["observacao"].ToString() : null;
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        contasReceber.Add(obj);
                    }
                }
            }

            return contasReceber;
        }

        public bool CancelarContaPorReserva(ContasReceber obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Verifica se a conta a receber está associada a uma reserva
                    string verificaQuery = @"
                     SELECT COUNT(*) 
                      FROM reserva
                        WHERE reserva_ID = @reservaId";

                    SqlCommand verificaCommand = new SqlCommand(verificaQuery, connection, transaction);
                    verificaCommand.Parameters.AddWithValue("@reservaId", obj.reserva_ID);

                    int count = (int)verificaCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        // Se não existe uma reserva associada, retornar falso
                        return false;
                    }

                    // Atualiza a data de cancelamento da conta a receber
                    string cancelarQuery = @"
                     UPDATE contasReceber
                      SET data_cancelamento = @dataCancelamento
                      WHERE reserva_ID = @reservaId 
                       AND num_parcela = @parcela";

                    SqlCommand cancelarCommand = new SqlCommand(cancelarQuery, connection, transaction);
                    cancelarCommand.Parameters.AddWithValue("@reservaId", obj.reserva_ID);
                    cancelarCommand.Parameters.AddWithValue("@parcela", obj.num_parcela);
                    cancelarCommand.Parameters.AddWithValue("@dataCancelamento", obj.data_cancelamento ?? (object)DBNull.Value);

                    cancelarCommand.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Erro ao cancelar conta a receber: " + ex.Message);
                    throw;
                }
            }
        }


        public bool VerificarParcelasNaoPagasPorReserva(int reservaId, int idCliente, int parcelaAtual)
        {
            string query = @"
             SELECT COUNT(*)
             FROM contasReceber
             WHERE reserva_ID = @reservaId
             AND cliente_ID = @idCliente
             AND num_parcela < @parcelaAtual
             AND data_recebimento IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reservaId", reservaId);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                command.Parameters.AddWithValue("@parcelaAtual", parcelaAtual);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public ContasReceber GetContaByReserva(int reservaId, int clienteId, int parcela)
        {
            ContasReceber contaReceber = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT * 
            FROM ContasReceber 
            WHERE reserva_ID = @reservaId 
              AND cliente_ID = @clienteId 
              AND num_parcela = @parcela" ;

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservaId", reservaId);
                cmd.Parameters.AddWithValue("@clienteId", clienteId);
                cmd.Parameters.AddWithValue("@parcela", parcela);


                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contaReceber = new ContasReceber
                        {
                            reserva_ID = Convert.ToInt32(reader["reserva_ID"]),
                            cliente_ID = Convert.ToInt32(reader["cliente_ID"]),
                            formaPagamento_ID = Convert.ToInt32(reader["formaPagamento_ID"]),
                            num_parcela = Convert.ToInt32(reader["num_parcela"]),
                            valor_parcela = Convert.ToInt32(reader["valor_parcela"]), 
                            valor_total = Convert.ToDecimal(reader["valor_total"]),
                            data_emissao = reader["data_emissao"] != DBNull.Value ? Convert.ToDateTime(reader["data_emissao"]) : (DateTime?)null,
                            data_vencimento = reader["data_vencimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_vencimento"]) : (DateTime?)null,
                            data_recebimento = reader["data_recebimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_recebimento"]) : (DateTime?)null,
                            juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : (decimal?)null,
                            multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : (decimal?)null,
                            desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : (decimal?)null,
                            valorRecebido = reader["valorRecebido"] != DBNull.Value ? Convert.ToDecimal(reader["valorRecebido"]) : (decimal?)null,
                            data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null,
                            observacao = reader["observacao"] != DBNull.Value ? reader["observacao"].ToString() : null,
                            data_cadastro = reader["data_cadastro"] != DBNull.Value? (DateTime?)Convert.ToDateTime(reader["data_cadastro"]): null,
                            data_ult_alt = reader["data_ult_alt"] != DBNull.Value ? Convert.ToDateTime(reader["data_ult_alt"]) : (DateTime?)null,
                        };
                    }
                }
            }

            return contaReceber;
        }


        public void salvar(List<ContasReceber> contasReceber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //string query = @" INSERT INTO ContasReceber 
                //    (reserva_ID, cliente_ID, valor_total, data_emissao, data_vencimento, data_recebimento, formaPagamento_ID, 
                //    num_parcela, juros, multa, desconto, valorRecebido, data_cancelamento, observacao, 
                //    data_cadastro, data_ult_alt) 
                //    VALUES 
                //    (";
                connection.Open();
                foreach (ContasReceber contareceber in contasReceber)
                {
                    string query = @"
                            INSERT INTO ContasReceber 
                            (reserva_ID, cliente_ID, valor_total, valor_parcela, data_emissao, data_vencimento, data_recebimento, formaPagamento_ID, 
                             num_parcela, juros, multa, desconto, valorRecebido, data_cancelamento, observacao, 
                             data_cadastro, data_ult_alt) 
                            VALUES 
                            (@reserva_ID, @cliente_ID, @valor_total, @valor_parcela, @data_emissao, @data_vencimento, @data_recebimento, @formaPagamento_ID, 
                             @num_parcela, @juros, @multa, @desconto, @valorRecebido, @data_cancelamento, @observacao, 
                             @data_cadastro, @data_ult_alt)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@reserva_ID", contareceber.reserva_ID);
                        command.Parameters.AddWithValue("@cliente_ID", contareceber.cliente_ID);
                        command.Parameters.AddWithValue("@valor_total", contareceber.valor_total);
                        command.Parameters.AddWithValue("@valor_parcela", contareceber.valor_parcela);
                        command.Parameters.AddWithValue("@data_emissao", contareceber.data_emissao);
                        command.Parameters.AddWithValue("@data_vencimento", contareceber.data_vencimento);
                        command.Parameters.AddWithValue("@data_recebimento", contareceber.data_recebimento ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@formaPagamento_ID", contareceber.formaPagamento_ID);
                        command.Parameters.AddWithValue("@num_parcela", contareceber.num_parcela);
                        command.Parameters.AddWithValue("@juros", contareceber.juros ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@multa", contareceber.multa ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@desconto", contareceber.desconto ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@valorRecebido", contareceber.valorRecebido ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@data_cancelamento", contareceber.data_cancelamento ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@observacao", contareceber.observacao ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@data_cadastro", contareceber.data_cadastro);
                        command.Parameters.AddWithValue("@data_ult_alt", contareceber.data_ult_alt);
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

    }
}
