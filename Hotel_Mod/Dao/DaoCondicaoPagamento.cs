using Hotel_Mod.Class;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Mod.Dao
{
    public class DaoCondicaoPagamento : Dao<CondicaoPagamento>
    {
        public DaoCondicaoPagamento() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int ultimoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IDENT_CURRENT('condicaoPagamento')";
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

        public override void alterar(CondicaoPagamento obj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // inicia a transação

                try
                {
                    // Comando para atualizar a condição de pagamento
                    string queryCondicaoPagamento = @"UPDATE condicaoPagamento 
                                                      SET condicaoPagamento = @condicaoPagamento, desconto = @desconto, juros = @juros, multa = @multa, Ativo = @Ativo, data_ult_alt = @data_ult_alt 
                                                      WHERE CondPagamento_ID = @CondPagamento_ID";
                    SqlCommand cmdCondicaoPagamento = new SqlCommand(queryCondicaoPagamento, conn, transaction);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@condicaoPagamento", obj.condicaoPagamento);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@desconto", obj.desconto);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@juros", obj.juros);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@multa", obj.multa);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@Ativo", obj.Ativo);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@CondPagamento_ID", obj.CondPagamento_ID);

                    cmdCondicaoPagamento.ExecuteNonQuery(); // Atualiza condição de pagamento

                    // Mantendo a lógica para parcelas
                    string querySelectParcelas = "SELECT * FROM parcela WHERE CondPagamento_ID = @CondPagamento_ID";
                    SqlCommand cmdSelectParcelas = new SqlCommand(querySelectParcelas, conn, transaction);
                    cmdSelectParcelas.Parameters.AddWithValue("@CondPagamento_ID", obj.CondPagamento_ID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmdSelectParcelas);
                    DataTable parcelasExistentes = new DataTable();
                    adapter.Fill(parcelasExistentes);

                    foreach (var parcela in obj.parcelas)
                    {
                        bool existe = false;

                        foreach (DataRow row in parcelasExistentes.Rows)
                        {
                            if ((int)row["numeroParcela"] == parcela.numeroParcela)
                            {
                                string queryUpdateParcela = @"UPDATE parcela 
                                                              SET dias = @dias, porcentagem = @porcentagem, FormaPagamento_ID = @FormaPagamento_ID 
                                                              WHERE CondPagamento_ID = @CondPagamento_ID AND numeroParcela = @numeroParcela";
                                SqlCommand cmdUpdateParcela = new SqlCommand(queryUpdateParcela, conn, transaction);
                                cmdUpdateParcela.Parameters.AddWithValue("@dias", parcela.dias);
                                cmdUpdateParcela.Parameters.AddWithValue("@porcentagem", parcela.porcentagem);
                                cmdUpdateParcela.Parameters.AddWithValue("@FormaPagamento_ID", parcela.FormaPagamento_ID);
                                cmdUpdateParcela.Parameters.AddWithValue("@CondPagamento_ID", obj.CondPagamento_ID);
                                cmdUpdateParcela.Parameters.AddWithValue("@numeroParcela", parcela.numeroParcela);

                                cmdUpdateParcela.ExecuteNonQuery();
                                existe = true;
                                break;
                            }
                        }

                        if (!existe)
                        {
                            string queryInsertParcela = @"INSERT INTO parcela 
                                                          (numeroParcela, dias, porcentagem, CondPagamento_ID, FormaPagamento_ID) 
                                                          VALUES (@numeroParcela, @dias, @porcentagem, @CondPagamento_ID, @FormaPagamento_ID)";
                            SqlCommand cmdInsertParcela = new SqlCommand(queryInsertParcela, conn, transaction);
                            cmdInsertParcela.Parameters.AddWithValue("@numeroParcela", parcela.numeroParcela);
                            cmdInsertParcela.Parameters.AddWithValue("@dias", parcela.dias);
                            cmdInsertParcela.Parameters.AddWithValue("@porcentagem", parcela.porcentagem);
                            cmdInsertParcela.Parameters.AddWithValue("@CondPagamento_ID", obj.CondPagamento_ID);
                            cmdInsertParcela.Parameters.AddWithValue("@FormaPagamento_ID", parcela.FormaPagamento_ID);

                            cmdInsertParcela.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow row in parcelasExistentes.Rows)
                    {
                        bool existe = false;
                        foreach (var parcela in obj.parcelas)
                        {
                            if ((int)row["numeroParcela"] == parcela.numeroParcela)
                            {
                                existe = true;
                                break;
                            }
                        }
                        if (!existe)
                        {
                            string queryDeleteParcela = "DELETE FROM parcela WHERE CondPagamento_ID = @CondPagamento_ID AND numeroParcela = @numeroParcela";
                            SqlCommand cmdDeleteParcela = new SqlCommand(queryDeleteParcela, conn, transaction);
                            cmdDeleteParcela.Parameters.AddWithValue("@CondPagamento_ID", obj.CondPagamento_ID);
                            cmdDeleteParcela.Parameters.AddWithValue("@numeroParcela", (int)row["numeroParcela"]);

                            cmdDeleteParcela.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao alterar condição de pagamento: " + ex.Message);
                }
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string deleteParcelas = "DELETE FROM parcela WHERE CondPagamento_ID = @CondPagamento_ID";
                    SqlCommand cmdDeleteParcelas = new SqlCommand(deleteParcelas, conn, transaction);
                    cmdDeleteParcelas.Parameters.AddWithValue("@CondPagamento_ID", id);
                    cmdDeleteParcelas.ExecuteNonQuery();

                    string deleteCondicaoPagamento = "DELETE FROM condicaoPagamento WHERE CondPagamento_ID = @CondPagamento_ID";
                    SqlCommand cmdDeleteCondicaoPagamento = new SqlCommand(deleteCondicaoPagamento, conn, transaction);
                    cmdDeleteCondicaoPagamento.Parameters.AddWithValue("@CondPagamento_ID", id);
                    cmdDeleteCondicaoPagamento.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();

                    if (ex.Number == 547)
                    {
                        MessageBox.Show("Não é possível excluir a Condição de Pagamento, pois ela está sendo utilizada em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erro ao deletar a condição de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override List<CondicaoPagamento> GetAll(bool incluiInativos = false)
        {
            List<CondicaoPagamento> condicoesPagamento = new List<CondicaoPagamento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM condicaoPagamento" : "SELECT * FROM condicaoPagamento WHERE Ativo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CondicaoPagamento condicaoPagamento = new CondicaoPagamento();
                        condicaoPagamento.CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]);
                        condicaoPagamento.condicaoPagamento = reader["condicaoPagamento"].ToString();
                        condicaoPagamento.desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : 0;
                        condicaoPagamento.juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : 0;
                        condicaoPagamento.multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : 0;
                        condicaoPagamento.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        condicaoPagamento.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        condicaoPagamento.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);

                        condicoesPagamento.Add(condicaoPagamento);
                    }
                }
            }

            return condicoesPagamento;
        }

        public override CondicaoPagamento GetById(int id)
        {
            CondicaoPagamento condicaoPagamento = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM condicaoPagamento WHERE CondPagamento_ID = @CondPagamento_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CondPagamento_ID", id);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        condicaoPagamento = new CondicaoPagamento();
                        condicaoPagamento.CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]);
                        condicaoPagamento.condicaoPagamento = reader["condicaoPagamento"].ToString();
                        condicaoPagamento.desconto = reader["desconto"] != DBNull.Value ? Convert.ToDecimal(reader["desconto"]) : 0;
                        condicaoPagamento.juros = reader["juros"] != DBNull.Value ? Convert.ToDecimal(reader["juros"]) : 0;
                        condicaoPagamento.multa = reader["multa"] != DBNull.Value ? Convert.ToDecimal(reader["multa"]) : 0;
                        condicaoPagamento.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        condicaoPagamento.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        condicaoPagamento.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);

                        condicaoPagamento.parcelas = GetParcelasByCondicaoPagamentoId(condicaoPagamento.CondPagamento_ID);
                    }
                }
            }

            return condicaoPagamento;
        }

        private List<parcela> GetParcelasByCondicaoPagamentoId(int idCondPagamento)
        {
            List<parcela> parcelas = new List<parcela>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM parcela WHERE CondPagamento_ID = @CondPagamento_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CondPagamento_ID", idCondPagamento);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        parcela parcelaItem = new parcela();
                        parcelaItem.numeroParcela = Convert.ToInt32(reader["numeroParcela"]);
                        parcelaItem.dias = Convert.ToInt32(reader["dias"]);
                        parcelaItem.porcentagem = Convert.ToDecimal(reader["porcentagem"]);
                        parcelaItem.CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]);
                        parcelaItem.FormaPagamento_ID = Convert.ToInt32(reader["FormaPagamento_ID"]);

                        parcelas.Add(parcelaItem);
                    }
                }
            }

            return parcelas;
        }

        public override void Salvar(CondicaoPagamento obj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryCondicaoPagamento = @"INSERT INTO condicaoPagamento 
                                                      (condicaoPagamento, desconto, juros, multa, Ativo, data_cadastro, data_ult_alt) 
                                                      VALUES (@condicaoPagamento, @desconto, @juros, @multa, @Ativo, @data_cadastro, @data_ult_alt);
                                                      SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdCondicaoPagamento = new SqlCommand(queryCondicaoPagamento, conn, transaction);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@condicaoPagamento", obj.condicaoPagamento);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@desconto", obj.desconto);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@juros", obj.juros);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@multa", obj.multa);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@Ativo", obj.Ativo);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@data_cadastro", obj.data_cadastro);
                    cmdCondicaoPagamento.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);

                    int idCondPagamento = Convert.ToInt32(cmdCondicaoPagamento.ExecuteScalar());

                    foreach (var parcela in obj.parcelas)
                    {
                        string queryParcela = @"INSERT INTO parcela 
                                                (numeroParcela, dias, porcentagem, CondPagamento_ID, FormaPagamento_ID) 
                                                VALUES (@numeroParcela, @dias, @porcentagem, @CondPagamento_ID, @FormaPagamento_ID)";
                        SqlCommand cmdParcela = new SqlCommand(queryParcela, conn, transaction);
                        cmdParcela.Parameters.AddWithValue("@numeroParcela", parcela.numeroParcela);
                        cmdParcela.Parameters.AddWithValue("@dias", parcela.dias);
                        cmdParcela.Parameters.AddWithValue("@porcentagem", parcela.porcentagem);
                        cmdParcela.Parameters.AddWithValue("@CondPagamento_ID", idCondPagamento);
                        cmdParcela.Parameters.AddWithValue("@FormaPagamento_ID", parcela.FormaPagamento_ID);

                        cmdParcela.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao salvar condição de pagamento: " + ex.Message);
                }
            }
        }

        public string GetFormaPagByParcelaId(int idParcela)
        {
            string formaPag = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FormaPagamento.formaPagamento FROM parcela INNER JOIN FormaPagamento ON parcela.FormaPagamento_ID = FormaPagamento.FormaPagamento_ID WHERE parcela.idParcela = @idParcela";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idParcela", idParcela);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        formaPag = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter a forma de pagamento: " + ex.Message);
                }
            }
            return formaPag;
        }
    }
}
