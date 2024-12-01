using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using Hotel_Mod.Class;
using Hotel_Mod.Models;

namespace Hotel_Mod.DAO
{
    public class DaoReserva<T> : Dao<T>
    {
        public DaoReserva() : base() { }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ?
                    @"
            SELECT 
                r.*, 
                h.hospede_ID, h.nome, h.cpf, h.telefone,
                cp.CondPagamento_ID, cp.condicaoPagamento,
                p.parcela_ID, p.numeroParcela, p.dias, p.porcentagem, p.CondPagamento_ID, p.FormaPagamento_ID,
                tq.tipo_quarto_ID, tq.tipo, tq.descricao, tq.valor_diaria AS valor_quarto, tq.capacidade_maxima, tq.lotacaoMaxima
            FROM reserva r
            LEFT JOIN reserva_hospede rh ON r.reserva_ID = rh.reserva_ID
            LEFT JOIN hospede h ON rh.hospede_ID = h.hospede_ID
            LEFT JOIN condicaoPagamento cp ON r.condPagamento_ID = cp.CondPagamento_ID
            LEFT JOIN parcelas p ON cp.CondPagamento_ID = p.CondPagamento_ID
            LEFT JOIN tipo_quarto tq ON r.tipo_quarto_ID = tq.tipo_quarto_ID" :
                    @"
            SELECT 
                r.*, 
                h.hospede_ID, h.nome, h.cpf, h.telefone,
                cp.CondPagamento_ID, cp.condicaoPagamento,
                p.parcela_ID, p.numeroParcela, p.dias, p.porcentagem, p.CondPagamento_ID, p.FormaPagamento_ID,
                tq.tipo_quarto_ID, tq.tipo, tq.descricao, tq.valor_diaria AS valor_quarto, tq.capacidade_maxima, tq.lotacaoMaxima
            FROM reserva r
            LEFT JOIN reserva_hospede rh ON r.reserva_ID = rh.reserva_ID
            LEFT JOIN hospede h ON rh.hospede_ID = h.hospede_ID
            LEFT JOIN condicaoPagamento cp ON r.condPagamento_ID = cp.CondPagamento_ID
            LEFT JOIN parcelas p ON cp.CondPagamento_ID = p.CondPagamento_ID
            LEFT JOIN tipo_quarto tq ON r.tipo_quarto_ID = tq.tipo_quarto_ID
            WHERE r.ativo = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Busca reserva existente para evitar duplicação
                        var reserva = reservas.FirstOrDefault(r => r.reserva_ID == Convert.ToInt32(reader["reserva_ID"]));

                        if (reserva == null)
                        {
                            // Cria uma nova reserva se ainda não existe na lista
                            reserva = new Reserva
                            {
                                reserva_ID = Convert.ToInt32(reader["reserva_ID"]),
                                cliente_ID = Convert.ToInt32(reader["cliente_ID"]),
                                nome_cliente = reader["nome_cliente"]?.ToString(),
                                cpf_cliente = reader["cpf_cliente"]?.ToString(),
                                celular_cliente = reader["celular_cliente"]?.ToString(),
                                tipo_quarto_ID = reader["tipo_quarto_ID"] != DBNull.Value ? Convert.ToInt32(reader["tipo_quarto_ID"]) : (int?)null,
                                tipo_quarto = reader["tipo"]?.ToString(),
                                valor_diaria = reader["valor_diaria"] != DBNull.Value ? Convert.ToDecimal(reader["valor_diaria"]) : (decimal?)null,
                                quarto_ID = reader["quarto_ID"] != DBNull.Value ? Convert.ToInt32(reader["quarto_ID"]) : (int?)null,
                                numero_quarto = reader["numero_quarto"]?.ToString(),
                                andar = reader["andar"] != DBNull.Value ? Convert.ToInt32(reader["andar"]) : (int?)null,
                                valor_total = reader["valor_total"] != DBNull.Value ? Convert.ToDecimal(reader["valor_total"]) : (decimal?)null,
                                data_checkin = reader["data_checkin"] != DBNull.Value ? Convert.ToDateTime(reader["data_checkin"]) : DateTime.MinValue,
                                data_checkout = reader["data_checkout"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_checkout"]) : null,
                                num_dias = reader["num_dias"] != DBNull.Value ? Convert.ToInt32(reader["num_dias"]) : 0,
                                condPagamento_ID = reader["CondPagamento_ID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["CondPagamento_ID"]) : null,
                                condicao_pagamento = reader["condicaoPagamento"]?.ToString(),
                                status_reserva = reader["status_reserva"]?.ToString(),
                                data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null,
                                observacao = reader["observacao"]?.ToString(),
                                motivo_checkout = reader["motivo_checkout"] != DBNull.Value ? reader["motivo_checkout"].ToString() : null, // Novo campo
                                ativo = reader["ativo"] != DBNull.Value && Convert.ToBoolean(reader["ativo"]),
                                data_cadastro = reader["data_cadastro"] != DBNull.Value ? Convert.ToDateTime(reader["data_cadastro"]) : DateTime.MinValue,
                                data_ult_alt = reader["data_ult_alt"] != DBNull.Value ? Convert.ToDateTime(reader["data_ult_alt"]) : DateTime.MinValue,
                                hospedes = new List<Hospede>(), // Inicializa lista de hóspedes
                                parcelas = new List<Parcela>()  // Inicializa lista de parcelas
                            };

                            reservas.Add(reserva);
                        }

                        // Adiciona hóspede relacionado, se houver
                        if (reader["hospede_ID"] != DBNull.Value)
                        {
                            reserva.hospedes.Add(new Hospede
                            {
                                hospede_id = Convert.ToInt32(reader["hospede_ID"]),
                                nome = reader["nome"]?.ToString(),
                                cpf = reader["cpf"]?.ToString(),
                                telefone = reader["telefone"]?.ToString()
                            });
                        }

                        // Adiciona parcela relacionada, se houver
                        if (reader["parcela_ID"] != DBNull.Value)
                        {
                            reserva.parcelas.Add(new Parcela
                            {
                                parcela_ID = Convert.ToInt32(reader["parcela_ID"]),
                                numeroParcela = reader["numeroParcela"] != DBNull.Value ? Convert.ToInt32(reader["numeroParcela"]) : 0,
                                dias = reader["dias"] != DBNull.Value ? Convert.ToInt32(reader["dias"]) : 0,
                                porcentagem = reader["porcentagem"] != DBNull.Value ? Convert.ToDecimal(reader["porcentagem"]) : 0,
                                CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]),
                                FormaPagamento_ID = Convert.ToInt32(reader["FormaPagamento_ID"])
                            });
                        }
                    }
                }
            }

            return reservas.Cast<T>().ToList();
        }


        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(reserva_ID) FROM reserva";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    proximoCodigo = Convert.ToInt32(result);
                }
            }
            return proximoCodigo;
        }
        public Quarto GetCodQuartoById(int reserva_ID)
        {
            Quarto quarto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            r.quarto_ID AS [Cód Quarto], 
            q.numero AS [Numero Quarto], 
            q.andar AS [Andar], 
            q.valor AS [Valor Diária],
            q.tipo AS [Tipo]
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
                            quarto_ID = Convert.ToInt32(reader["Cód Quarto"]),
                            numero = Convert.ToInt32(reader["Numero Quarto"]), // Considerando que número seja do tipo string
                            andar = Convert.ToInt32(reader["Andar"]),
                            valor_diaria = Convert.ToDecimal(reader["Valor Diária"]),
                            tipo = reader["Tipo"].ToString() // Atribuindo o valor do campo 'Tipo'
                        };
                    }
                }
            }

            return quarto;
        }

        public bool InserirOcupacao(Ocupacao ocupacao)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ocupacoes (quarto_ID, checkin, checkout, cliente_ID, statusOcupacao)
                       VALUES (@QuartoID, @Checkin, @Checkout, @ClienteID, @StatusOcupacao)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@QuartoID", ocupacao.quarto_ID);
                cmd.Parameters.AddWithValue("@Checkin", ocupacao.DataEntrada);
                cmd.Parameters.AddWithValue("@Checkout", ocupacao.DataSaida);
                cmd.Parameters.AddWithValue("@ClienteID", ocupacao.cliente_ID);
                cmd.Parameters.AddWithValue("@StatusOcupacao", ocupacao.ocupacao);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inserir ocupação no banco de dados: {ex.Message}");
                    return false;
                }
            }
        }

        public void InserirHospedeNaReserva(int reservaID, int hospedeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO reserva_hospede (reserva_ID, hospede_ID)
            VALUES (@reserva_ID, @hospede_ID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva_ID", reservaID);
                command.Parameters.AddWithValue("@hospede_ID", hospedeID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    DELETE FROM contasReceber WHERE reserva_id = @id;
                    DELETE FROM ReservasTemporarias WHERE reserva_id = @id;
                    DELETE FROM reserva_hospede WHERE reserva_ID = @id;
                    DELETE FROM reserva WHERE reserva_ID = @id;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    //verifica se a exceção está relacionada a uma restrição de chave estrangeira (uso em algum cadastro)
                    if (ex.Number == 547) //código de erro para conflito de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir a reserva, pois ele está sendo utilizado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void CancelarReserva(int reservaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE reserva SET status_reserva = @status, data_cancelamento = @dataCancelamento WHERE reserva_ID = @reservaId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", "Cancelada");
                command.Parameters.AddWithValue("@dataCancelamento", DateTime.Now);
                command.Parameters.AddWithValue("@reservaId", reservaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void Salvar(T obj)
        {
            dynamic reserva = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Inserir reserva
                    string queryReserva = @"
                INSERT INTO reserva (cliente_ID, nome_cliente, cpf_cliente, celular_cliente, tipo_quarto_ID, valor_diaria, valor_total, data_checkin, data_checkout, num_dias, condPagamento_ID, condicao_pagamento, status_reserva, data_cancelamento, observacao, ativo, data_cadastro, data_ult_alt, motivo_checkout)
                VALUES (@cliente_ID, @nome_cliente, @cpf_cliente, @celular_cliente, @tipo_quarto_ID, @valor_diaria, @valor_total, @data_checkin, @data_checkout, @num_dias, @condPagamento_ID, @condicao_pagamento, @status_reserva, @data_cancelamento, @observacao, @ativo, @data_cadastro, @data_ult_alt, @motivo_checkout);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdReserva = new SqlCommand(queryReserva, connection, transaction);
                    cmdReserva.Parameters.AddWithValue("@cliente_ID", reserva.cliente_ID);
                    cmdReserva.Parameters.AddWithValue("@nome_cliente", reserva.nome_cliente);
                    cmdReserva.Parameters.AddWithValue("@cpf_cliente", reserva.cpf_cliente ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@celular_cliente", reserva.celular_cliente ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@tipo_quarto_ID", reserva.tipo_quarto_ID); // Novo parâmetro para tipo_quarto_ID
                    cmdReserva.Parameters.AddWithValue("@valor_diaria", reserva.valor_diaria);
                    cmdReserva.Parameters.AddWithValue("@valor_total", reserva.valor_total);
                    cmdReserva.Parameters.AddWithValue("@data_checkin", reserva.data_checkin);
                    cmdReserva.Parameters.AddWithValue("@data_checkout", reserva.data_checkout);
                    cmdReserva.Parameters.AddWithValue("@num_dias", reserva.num_dias);
                    cmdReserva.Parameters.AddWithValue("@condPagamento_ID", reserva.condPagamento_ID != 0 ? (object)reserva.condPagamento_ID : DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@condicao_pagamento", reserva.condicao_pagamento ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@status_reserva", reserva.status_reserva);
                    cmdReserva.Parameters.AddWithValue("@data_cancelamento", reserva.data_cancelamento ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@observacao", reserva.observacao ?? string.Empty);
                    cmdReserva.Parameters.AddWithValue("@ativo", reserva.ativo);
                    cmdReserva.Parameters.AddWithValue("@data_cadastro", reserva.data_cadastro);
                    cmdReserva.Parameters.AddWithValue("@data_ult_alt", reserva.data_ult_alt);
                    cmdReserva.Parameters.AddWithValue("@motivo_checkout", !string.IsNullOrEmpty(reserva.motivo_checkout) ? (object)reserva.motivo_checkout : DBNull.Value);

                    int reservaID = Convert.ToInt32(cmdReserva.ExecuteScalar());

                    // Inserir cada hóspede associado à reserva
                    foreach (var hospede in reserva.hospedes)
                    {
                        string queryHospede = @"
                    INSERT INTO reserva_hospede (reserva_id, hospede_id)
                    VALUES (@reserva_id, @hospede_id);";

                        SqlCommand cmdHospede = new SqlCommand(queryHospede, connection, transaction);
                        cmdHospede.Parameters.AddWithValue("@reserva_id", reservaID);
                        cmdHospede.Parameters.AddWithValue("@hospede_id", hospede.hospede_id);

                        cmdHospede.ExecuteNonQuery();
                    }

                    // Commit da transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback em caso de erro
                    transaction.Rollback();
                    throw new Exception("Erro ao salvar reserva e hóspedes: " + ex.Message);
                }
            }
        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            r.reserva_ID, r.cliente_ID, r.nome_cliente, r.cpf_cliente, r.celular_cliente,
            r.tipo_quarto_ID, r.data_checkin, r.data_checkout, r.status_reserva, r.num_dias, 
            r.valor_total, r.condPagamento_ID, r.data_cancelamento, r.observacao, r.motivo_checkout,
            r.ativo, r.data_cadastro, r.data_ult_alt, 
            tq.tipo_quarto_ID, tq.tipo, tq.descricao, tq.valor_diaria AS valor_diaria, 
            tq.capacidade_maxima, tq.lotacaoMaxima,
            h.hospede_ID, h.nome AS nome_hospede, h.cpf, h.telefone,
            cp.condicaoPagamento,
            p.parcela_ID, p.numeroParcela, p.dias, p.porcentagem, p.CondPagamento_ID, p.FormaPagamento_ID,
	        (SELECT COUNT(*)
	         FROM reserva_hospede rh_sub
	         WHERE rh_sub.reserva_ID = r.reserva_ID) as 'NumHosp'
        FROM reserva r
        LEFT JOIN reserva_hospede rh ON r.reserva_ID = rh.reserva_ID
        LEFT JOIN hospede h ON rh.hospede_ID = h.hospede_ID
        LEFT JOIN condicaoPagamento cp ON r.condPagamento_ID = cp.CondPagamento_ID
        LEFT JOIN parcelas p ON cp.CondPagamento_ID = p.CondPagamento_ID
        LEFT JOIN tipo_quarto tq ON r.tipo_quarto_ID = tq.tipo_quarto_ID
        WHERE r.reserva_ID = @reserva_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reserva_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Reserva reserva = null;
                    var hospedes = new List<Hospede>();
                    var parcelas = new List<Parcela>();

                    while (reader.Read())
                    {
                        if (reserva == null)
                        {
                            // Instancia a reserva com os dados principais e tipo do quarto
                            reserva = new Reserva
                            {
                                reserva_ID = Convert.ToInt32(reader["reserva_ID"]),
                                cliente_ID = Convert.ToInt32(reader["cliente_ID"]),
                                nome_cliente = reader["nome_cliente"]?.ToString(),
                                cpf_cliente = reader["cpf_cliente"]?.ToString(),
                                celular_cliente = reader["celular_cliente"]?.ToString(),
                                tipo_quarto_ID = reader["tipo_quarto_ID"] != DBNull.Value ? Convert.ToInt32(reader["tipo_quarto_ID"]) : (int?)null,
                                tipo_quarto = reader["tipo"]?.ToString(),
                                valor_diaria = reader["valor_diaria"] != DBNull.Value ? Convert.ToDecimal(reader["valor_diaria"]) : (decimal?)null,
                                valor_total = reader["valor_total"] != DBNull.Value ? Convert.ToDecimal(reader["valor_total"]) : (decimal?)null,
                                data_checkin = reader["data_checkin"] != DBNull.Value ? Convert.ToDateTime(reader["data_checkin"]) : DateTime.MinValue,
                                data_checkout = reader["data_checkout"] != DBNull.Value ? Convert.ToDateTime(reader["data_checkout"]) : DateTime.MinValue,
                                num_dias = reader["num_dias"] != DBNull.Value ? Convert.ToInt32(reader["num_dias"]) : 0,
                                condPagamento_ID = reader["condPagamento_ID"] != DBNull.Value ? Convert.ToInt32(reader["condPagamento_ID"]) : (int?)null,
                                condicao_pagamento = reader["condicaoPagamento"]?.ToString(),
                                status_reserva = reader["status_reserva"]?.ToString(),
                                data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? Convert.ToDateTime(reader["data_cancelamento"]) : (DateTime?)null,
                                observacao = reader["observacao"]?.ToString(),
                                motivo_checkout = reader["motivo_checkout"]?.ToString(),
                                ativo = reader["ativo"] != DBNull.Value && Convert.ToBoolean(reader["ativo"]),
                                data_cadastro = reader["data_cadastro"] != DBNull.Value ? Convert.ToDateTime(reader["data_cadastro"]) : DateTime.MinValue,
                                data_ult_alt = reader["data_ult_alt"] != DBNull.Value ? Convert.ToDateTime(reader["data_ult_alt"]) : DateTime.MinValue,
                                numHosp = Convert.ToInt32(reader["NumHosp"])
                            };
                        }

                        // Adiciona os hóspedes
                        if (reader["hospede_ID"] != DBNull.Value)
                        {
                            hospedes.Add(new Hospede
                            {
                                hospede_id = Convert.ToInt32(reader["hospede_ID"]),
                                nome = reader["nome_hospede"]?.ToString(),
                                cpf = reader["cpf"]?.ToString(),
                                telefone = reader["telefone"]?.ToString()
                            });
                        }

                        // Adiciona as parcelas
                        if (reader["parcela_ID"] != DBNull.Value)
                        {
                            parcelas.Add(new Parcela
                            {
                                parcela_ID = Convert.ToInt32(reader["parcela_ID"]),
                                numeroParcela = reader["numeroParcela"] != DBNull.Value ? Convert.ToInt32(reader["numeroParcela"]) : 0,
                                dias = reader["dias"] != DBNull.Value ? Convert.ToInt32(reader["dias"]) : 0,
                                porcentagem = reader["porcentagem"] != DBNull.Value ? Convert.ToDecimal(reader["porcentagem"]) : 0,
                                CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]),
                                FormaPagamento_ID = Convert.ToInt32(reader["FormaPagamento_ID"])
                            });
                        }
                    }

                    if (reserva != null)
                    {
                        reserva.hospedes = hospedes;
                        reserva.parcelas = parcelas;
                        return (T)(object)reserva;
                    }

                    return default(T);
                }
            }
        }

        public override void alterar(T obj)
        {
            dynamic reserva = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Atualizar a reserva
                    string queryReserva = @"
                UPDATE reserva
                SET cliente_ID = @cliente_ID,
                    nome_cliente = @nome_cliente,
                    cpf_cliente = @cpf_cliente,
                    celular_cliente = @celular_cliente,
                    tipo_quarto_ID = @tipo_quarto_ID,
                    valor_diaria = @valor_diaria,
                    valor_total = @valor_total,
                    data_checkin = @data_checkin,
                    data_checkout = @data_checkout,
                    num_dias = @num_dias,
                    condPagamento_ID = @condPagamento_ID,
                    condicao_pagamento = @condicao_pagamento,
                    status_reserva = @status_reserva,
                    data_cancelamento = @data_cancelamento,
                    observacao = @observacao,
                    ativo = @ativo,
                    data_ult_alt = @data_ult_alt,
                    motivo_checkout = @motivo_checkout
                WHERE reserva_ID = @reserva_ID";

                    SqlCommand cmdReserva = new SqlCommand(queryReserva, connection, transaction);
                    cmdReserva.Parameters.AddWithValue("@reserva_ID", reserva.reserva_ID);
                    cmdReserva.Parameters.AddWithValue("@cliente_ID", reserva.cliente_ID);
                    cmdReserva.Parameters.AddWithValue("@nome_cliente", reserva.nome_cliente);
                    cmdReserva.Parameters.AddWithValue("@cpf_cliente", reserva.cpf_cliente ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@celular_cliente", reserva.celular_cliente ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@tipo_quarto_ID", reserva.tipo_quarto_ID);
                    cmdReserva.Parameters.AddWithValue("@valor_diaria", reserva.valor_diaria);
                    cmdReserva.Parameters.AddWithValue("@valor_total", reserva.valor_total);
                    cmdReserva.Parameters.AddWithValue("@data_checkin", reserva.data_checkin);
                    cmdReserva.Parameters.AddWithValue("@data_checkout", reserva.data_checkout ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@num_dias", reserva.num_dias);
                    cmdReserva.Parameters.AddWithValue("@condPagamento_ID", reserva.condPagamento_ID != 0 ? (object)reserva.condPagamento_ID : DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@condicao_pagamento", reserva.condicao_pagamento ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@status_reserva", reserva.status_reserva);
                    cmdReserva.Parameters.AddWithValue("@data_cancelamento", reserva.data_cancelamento ?? (object)DBNull.Value);
                    cmdReserva.Parameters.AddWithValue("@observacao", reserva.observacao ?? string.Empty);
                    cmdReserva.Parameters.AddWithValue("@ativo", reserva.ativo);
                    cmdReserva.Parameters.AddWithValue("@data_ult_alt", reserva.data_ult_alt);
                    cmdReserva.Parameters.AddWithValue("@motivo_checkout", !string.IsNullOrEmpty(reserva.motivo_checkout) ? (object)reserva.motivo_checkout : DBNull.Value);

                    cmdReserva.ExecuteNonQuery();

                    // Remover todos os hóspedes associados à reserva antes de inserir os novos
                    string queryDeletarHospedes = "DELETE FROM reserva_hospede WHERE reserva_id = @reserva_id";
                    SqlCommand cmdDeletarHospedes = new SqlCommand(queryDeletarHospedes, connection, transaction);
                    cmdDeletarHospedes.Parameters.AddWithValue("@reserva_id", reserva.reserva_ID);
                    cmdDeletarHospedes.ExecuteNonQuery();

                    // Inserir os hóspedes atualizados
                    foreach (var hospede in reserva.hospedes)
                    {
                        string queryHospede = @"
                    INSERT INTO reserva_hospede (reserva_id, hospede_id)
                    VALUES (@reserva_id, @hospede_id);";

                        SqlCommand cmdHospede = new SqlCommand(queryHospede, connection, transaction);
                        cmdHospede.Parameters.AddWithValue("@reserva_id", reserva.reserva_ID);
                        cmdHospede.Parameters.AddWithValue("@hospede_id", hospede.hospede_id);

                        cmdHospede.ExecuteNonQuery();
                    }

                    // Commit da transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback em caso de erro
                    transaction.Rollback();
                    throw new Exception("Erro ao alterar reserva e hóspedes: " + ex.Message);
                }
            }
        }


        public tipo_quarto ObterTipoQuartoPorId(int tipoId)
        {
            tipo_quarto tipo = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT tipo_quarto_ID, tipo, valor_diaria, capacidade_maxima FROM tipo_quarto WHERE tipo_quarto_ID = @tipoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipoId", tipoId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tipo = new tipo_quarto
                        {
                            tipo_quarto_ID = (int)reader["tipo_quarto_ID"],
                            tipo = reader["tipo"].ToString(),
                            valor_diaria = (decimal)reader["valor_diaria"],
                            capacidade_maxima = (int)reader["capacidade_maxima"]
                        };
                    }
                }
            }

            return tipo;
        }

        public List<DateTime> BuscarDiasIndisponiveis(string tipoQuarto, int mes, int ano)
        {
            List<DateTime> diasIndisponiveis = new List<DateTime>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT data_reserva
            FROM V_ReservasResumo
            WHERE tipo_quarto = @tipoQuarto
              AND MONTH(data_reserva) = @mes
              AND YEAR(data_reserva) = @ano
              AND quantidade_reservas >= lotacao_maxima";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipoQuarto", tipoQuarto);
                command.Parameters.AddWithValue("@mes", mes);
                command.Parameters.AddWithValue("@ano", ano);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    diasIndisponiveis.Add(reader.GetDateTime(0));
                }
            }

            return diasIndisponiveis;
        }



        public bool InserirReservaTemporaria(int tipoQuartoId, DateTime dataReserva)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ReservasTemporarias (reserva_id, tipo_quarto_ID, data_reserva) VALUES (NULL, @tipoQuartoId, @dataReserva)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@tipoQuartoId", tipoQuartoId);
                    command.Parameters.AddWithValue("@dataReserva", dataReserva);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Número de erro gerado pelo RAISERROR na trigger
                {
                    Console.WriteLine($"Erro ao inserir reserva: {ex.Message}");
                }
                return false;
            }
        }

        public bool AtualizarReservaTemporaria(int reservaId, int tipoQuartoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ReservasTemporarias SET reserva_id = @reservaId WHERE reserva_id IS NULL AND tipo_quarto_ID = @tipoQuartoId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reservaId", reservaId);
                command.Parameters.AddWithValue("@tipoQuartoId", tipoQuartoId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ExcluirReservasTemporariasNaoSalvas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ReservasTemporarias WHERE reserva_id IS NULL";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ExcluirReservaTemporaria(int tipoQuartoId, DateTime dataReserva)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ReservasTemporarias WHERE tipo_quarto_ID = @tipoQuartoID AND data_reserva = @dataReserva";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@tipoQuartoID", tipoQuartoId);
                command.Parameters.AddWithValue("@dataReserva", dataReserva);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }


        public bool ExcluirReservasTemporariasPorReservaId(int reservaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ReservasTemporarias WHERE reserva_id = @reservaId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reservaId", reservaId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public int ObterProximoReservaId()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(reserva_id), 0) + 1 FROM reserva";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int proximoReservaId = (int)command.ExecuteScalar();
                return proximoReservaId;
            }
        }

        public void AtualizarReservaComQuarto(int reservaId, int quartoId, int numero, int andar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE reserva 
            SET quarto_ID = @quartoId, 
                numero_quarto = @numero, 
                andar = @andar
            WHERE reserva_ID = @reservaId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@reservaId", reservaId);
                command.Parameters.AddWithValue("@quartoId", quartoId);
                command.Parameters.AddWithValue("@numero", numero);
                command.Parameters.AddWithValue("@andar", andar);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public Reserva ObterReservaPorQuarto(int quartoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT r.reserva_ID, r.cliente_ID, r.data_checkout, r.data_checkin, r.status_reserva, r.valor_diaria, COUNT(rh.hospede_ID) as 'NumHosp'
                    FROM reserva r
                    INNER JOIN reserva_hospede rh ON rh.reserva_ID = r.reserva_ID
                    WHERE r.quarto_ID = @quartoId AND r.status_reserva = 'Check-in'
                    GROUP BY r.reserva_ID, r.cliente_ID, r.data_checkout, r.data_checkin, r.status_reserva, r.valor_diaria;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@quartoId", quartoId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reserva
                            {
                                reserva_ID = Convert.ToInt32(reader["reserva_ID"]),
                                cliente_ID = Convert.ToInt32(reader["cliente_ID"]),
                                data_checkin = Convert.ToDateTime(reader["data_checkin"]),
                                data_checkout = reader["data_checkout"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["data_checkout"])
                                    : (DateTime?)null,
                                status_reserva = reader["status_reserva"].ToString(),
                                valor_diaria = Convert.ToDecimal(reader["valor_diaria"]),
                                numHosp = Convert.ToInt32(reader["NumHosp"])
                            };
                        }
                    }
                }
            }
            return null;
        }

     

        public List<Parcela> ObterParcelasDaReserva(int reservaId)
        {
            var parcelas = new List<Parcela>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT p.parcela_ID, p.numeroParcela, p.valorParcela, p.dias
        FROM parcela p
        WHERE p.reserva_ID = @reservaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reservaId", reservaId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            parcelas.Add(new Parcela
                            {
                                parcela_ID = Convert.ToInt32(reader["parcela_ID"]),
                                numeroParcela = Convert.ToInt32(reader["numeroParcela"]),
                                dias = Convert.ToInt32(reader["dias"])
                            });
                        }
                    }
                }
            }
            return parcelas;
        }


        public void AtualizarStatusReserva(int reservaId, string status)
        {
            string query = "UPDATE reserva SET status_reserva = @status, data_ult_alt = GETDATE() WHERE reserva_ID = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@id", reservaId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public Reserva ObterReservaDetalhadaPorQuarto(int quartoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                r.reserva_ID,
                r.cliente_ID,
                r.nome_cliente,
                r.cpf_cliente,
                r.celular_cliente,
                r.tipo_quarto_ID,
                r.valor_diaria,
                r.valor_total,
                r.data_checkin,
                r.data_checkout,
                r.num_dias,
                r.condPagamento_ID,
                r.condicao_pagamento,
                r.status_reserva,
                r.data_cancelamento,
                r.observacao,
                r.quarto_ID,
                r.numero_quarto,
                r.andar,
                r.motivo_checkout,
                fp.formaPagamento AS forma_pagamento
            FROM 
                reserva r
            LEFT JOIN 
                forma_pagamento fp ON fp.formaPagamento_ID = r.condPagamento_ID
            WHERE 
                r.status_reserva = 'Check-in' AND r.quarto_ID = @QuartoId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QuartoId", quartoId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reserva
                            {
                                reserva_ID = Convert.ToInt32(reader["reserva_ID"]),
                                cliente_ID = Convert.ToInt32(reader["cliente_ID"]),
                                nome_cliente = reader["nome_cliente"].ToString(),
                                cpf_cliente = reader["cpf_cliente"].ToString(),
                                celular_cliente = reader["celular_cliente"].ToString(),
                                tipo_quarto_ID = Convert.ToInt32(reader["tipo_quarto_ID"]),
                                valor_diaria = Convert.ToDecimal(reader["valor_diaria"]),
                                valor_total = Convert.ToDecimal(reader["valor_total"]),
                                data_checkin = Convert.ToDateTime(reader["data_checkin"]),
                                data_checkout = reader["data_checkout"] as DateTime?,
                                num_dias = Convert.ToInt32(reader["num_dias"]),
                                condPagamento_ID = Convert.ToInt32(reader["condPagamento_ID"]),
                                condicao_pagamento = reader["condicao_pagamento"].ToString(),
                                status_reserva = reader["status_reserva"].ToString(),
                                data_cancelamento = reader["data_cancelamento"] as DateTime?,
                                observacao = reader["observacao"].ToString(),
                                quarto_ID = Convert.ToInt32(reader["quarto_ID"]),
                                numero_quarto = reader["numero_quarto"] != DBNull.Value ? Convert.ToString(reader["numero_quarto"]): null, 
                                andar = reader["andar"] != DBNull.Value ? Convert.ToInt32(reader["andar"]) : 0,

                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Hospede> ObterHospedesPorReserva(int reservaId)
        {
            var hospedes = new List<Hospede>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT h.hospede_id, h.nome, h.data_nascimento
            FROM hospede h
            INNER JOIN reserva_hospede rh ON h.hospede_id = rh.hospede_ID
            WHERE rh.reserva_ID = @reservaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reservaId", reservaId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hospedes.Add(new Hospede
                            {
                                hospede_id = Convert.ToInt32(reader["hospede_id"]),
                                nome = reader["nome"].ToString(),
                                data_nascimento = reader.GetDateTime(reader.GetOrdinal("data_nascimento"))
                            });
                        }
                    }
                }
            }

            return hospedes;
        }

        public List<DateTime> ObterDatasReservadasPorReserva(int reservaId)
        {
            var datas = new List<DateTime>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                 SELECT data_reserva 
                 FROM ReservasTemporarias 
                 WHERE reserva_id = @reservaId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reservaId", reservaId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datas.Add(Convert.ToDateTime(reader["data_reserva"]));
                        }
                    }
                }
            }

            return datas;
        }

        public (DateTime checkIn, DateTime checkOut)? ObterIntervaloReserva(int reservaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT data_checkin, data_checkout
            FROM reserva
            WHERE reserva_ID = @reservaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@reservaId", reservaId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime checkIn = Convert.ToDateTime(reader["data_checkin"]);
                            DateTime checkOut = Convert.ToDateTime(reader["data_checkout"]);

                            // Adicione um log aqui para validar os valores
                            Debug.WriteLine($"Check-in: {checkIn}, Check-out: {checkOut}");

                            return (checkIn, checkOut);
                        }
                    }
                }
            }
            return null;
        }


       


    }
}

