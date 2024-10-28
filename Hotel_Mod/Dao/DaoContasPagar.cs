using Hotel_Mod.Class;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Mod.Dao
{
    public class DaoContasPagar : Dao<ContasPagar>
    {
        public override void alterar(ContasPagar obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE contasPagar SET 
                    dataPagamento = @dataPagamento, 
                    dataEmissao = @dataEmissao, 
                    FormaPagamento_ID = @FormaPagamento_ID, 
                    data_vencimento = @data_vencimento, 
                    valorParcela = @valorParcela, 
                    juros = @juros, 
                    multa = @multa, 
                    desconto = @desconto, 
                    valorPago = @valorPago, 
                    data_cancelamento = @data_cancelamento, 
                    observacao = @observacao, 
                    data_ult_alt = @data_ult_alt, 
                    usuario = @usuario
                WHERE numeroNota = @numeroNota AND serie = @serie AND idFornecedor = @idFornecedor AND parcela = @parcela";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@numeroNota", obj.numeroNota);
                command.Parameters.AddWithValue("@serie", obj.serie);
                command.Parameters.AddWithValue("@idFornecedor", obj.idFornecedor);
                command.Parameters.AddWithValue("@dataEmissao", obj.dataEmissao);
                command.Parameters.AddWithValue("@FormaPagamento_ID", obj.FormaPagamento_ID);
                command.Parameters.AddWithValue("@parcela", obj.parcela);
                command.Parameters.AddWithValue("@data_vencimento", obj.data_vencimento);
                command.Parameters.AddWithValue("@valorParcela", obj.valorParcela);
                command.Parameters.AddWithValue("@dataPagamento", (object)obj.data_pagamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@juros", (object)obj.juros ?? DBNull.Value);
                command.Parameters.AddWithValue("@multa", (object)obj.multa ?? DBNull.Value);
                command.Parameters.AddWithValue("@desconto", (object)obj.desconto ?? DBNull.Value);
                command.Parameters.AddWithValue("@valorPago", (object)obj.valor_pago ?? DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", (object)obj.data_cancelamento ?? DBNull.Value);
                command.Parameters.AddWithValue("@observacao", obj.observacao ?? string.Empty);
                command.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);
                command.Parameters.AddWithValue("@usuario", obj.usuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

     

        public override void excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ContasPagar> GetAll(bool incluiInativos = false)
        {
            List<ContasPagar> contasPagar = new List<ContasPagar>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM contasPagar";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContasPagar contaPagar = new ContasPagar
                        {
                            numeroNota = Convert.ToInt32(reader["numeroNota"]),
                            serie = Convert.ToInt32(reader["serie"]),
                            idFornecedor = Convert.ToInt32(reader["idFornecedor"]),
                            data_vencimento = Convert.ToDateTime(reader["data_vencimento"]),
                            parcela = Convert.ToInt32(reader["parcela"]),
                            valorParcela = Convert.ToDecimal(reader["valorParcela"]),
                            data_pagamento = reader["dataPagamento"] != DBNull.Value ? Convert.ToDateTime(reader["dataPagamento"]) : (DateTime?)null,
                            data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null
                        };

                        contasPagar.Add(contaPagar);
                    }
                }
            }
            return contasPagar;
        }


        public ContasPagar GetContaById(int numero, int serie, int idFornecedor, int parcela)
        {
            ContasPagar contaPagar = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM contasPagar WHERE numeroNota = @numeroNota AND modelo = @modelo AND serie = @serie AND idFornecedor = @idFornecedor AND parcela = @parcela";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@numeroNota", numero);
                cmd.Parameters.AddWithValue("@serie", serie);
                cmd.Parameters.AddWithValue("@idFornecedor", idFornecedor);
                cmd.Parameters.AddWithValue("@parcela", parcela);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        contaPagar = new ContasPagar
                        {
                            numeroNota = Convert.ToInt32(reader["numeroNota"]),
                            serie = Convert.ToInt32(reader["serie"]),
                            dataEmissao = Convert.ToDateTime(reader["dataEmissao"]),
                            idFornecedor = Convert.ToInt32(reader["idFornecedor"]),
                            FormaPagamento_ID = Convert.ToInt32(reader["idFormaPagamento"]),
                            parcela = Convert.ToInt32(reader["parcela"]),
                            valorParcela = Convert.ToDecimal(reader["valorParcela"]),
                            data_vencimento = Convert.ToDateTime(reader["dataVencimento"]),

                            data_pagamento = reader["dataPagamento"] != DBNull.Value ? Convert.ToDateTime(reader["dataPagamento"]) : (DateTime?)null,
                            juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : (decimal?)null,
                            multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : (decimal?)null,
                            desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : (decimal?)null,
                            valor_pago = reader["valorPago"] != DBNull.Value ? Convert.ToDecimal(reader["valorPago"]) : (decimal?)null,

                            observacao = reader["observacao"].ToString(),
                            usuario = reader["usuario"].ToString(),
                            data_cancelamento = reader["dataCancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["dataCancelamento"]) : (DateTime?)null,
                            data_cadastro = Convert.ToDateTime(reader["dataCadastro"]),
                            data_ult_alt = Convert.ToDateTime(reader["dataUltAlt"]),
                        };
                    }
                }
            }
            return contaPagar;
        }

        public override ContasPagar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Salvar(ContasPagar obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO contasPagar 
                (numeroNota, serie, idFornecedor, dataEmissao, FormaPagamento_ID, parcela, valorParcela, data_vencimento, dataPagamento, juros, multa, desconto, valorPago, data_cancelamento, observacao, data_cadastro, data_ult_alt, usuario) 
                VALUES 
                (@numeroNota, @serie, @idFornecedor, @dataEmissao, @FormaPagamento_ID, @parcela, @valorParcela, @data_vencimento, @dataPagamento, @juros, @multa, @desconto, @valorPago, @data_cancelamento, @observacao, @data_cadastro, @data_ult_alt, @usuario)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@numeroNota", obj.numeroNota);
                command.Parameters.AddWithValue("@serie", obj.serie);
                command.Parameters.AddWithValue("@idFornecedor", obj.idFornecedor);
                command.Parameters.AddWithValue("@dataEmissao", obj.dataEmissao);
                command.Parameters.AddWithValue("@FormaPagamento_ID", obj.FormaPagamento_ID);
                command.Parameters.AddWithValue("@parcela", obj.parcela);
                command.Parameters.AddWithValue("@valorParcela", obj.valorParcela);
                command.Parameters.AddWithValue("@data_vencimento", obj.data_vencimento);
                command.Parameters.AddWithValue("@dataPagamento", obj.data_pagamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@juros", obj.juros ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@multa", obj.multa ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@desconto", obj.desconto ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@valorPago", obj.valor_pago ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", obj.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", obj.observacao ?? string.Empty);
                command.Parameters.AddWithValue("@data_cadastro", obj.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);
                command.Parameters.AddWithValue("@usuario", obj.usuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool CancelarConta(ContasPagar obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string cancelarQuery = @"
                    UPDATE contasPagar
                    SET data_cancelamento = @data_cancelamento
                    WHERE numeroNota = @numeroNota AND serie = @serie AND idFornecedor = @idFornecedor AND parcela = @parcela";

                    SqlCommand cancelarCommand = new SqlCommand(cancelarQuery, connection, transaction);
                    cancelarCommand.Parameters.AddWithValue("@numeroNota", obj.numeroNota);
                    cancelarCommand.Parameters.AddWithValue("@serie", obj.serie);
                    cancelarCommand.Parameters.AddWithValue("@idFornecedor", obj.idFornecedor);
                    cancelarCommand.Parameters.AddWithValue("@parcela", obj.parcela);
                    cancelarCommand.Parameters.AddWithValue("@data_cancelamento", obj.data_cancelamento ?? (object)DBNull.Value);

                    cancelarCommand.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Erro ao cancelar conta a pagar: " + ex.Message);
                    throw;
                }
            }
        }

        public bool VerificarParcelasNaoPagas(int numeroNota, int serie, int idFornecedor, int parcelaAtual)
        {
            string query = @"
            SELECT COUNT(*)
            FROM contasPagar
            WHERE numeroNota = @numeroNota
              AND serie = @serie
              AND idFornecedor = @idFornecedor
              AND parcela < @parcelaAtual
              AND dataPagamento IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@numeroNota", numeroNota);
                command.Parameters.AddWithValue("@serie", serie);
                command.Parameters.AddWithValue("@idFornecedor", idFornecedor);
                command.Parameters.AddWithValue("@parcelaAtual", parcelaAtual);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
