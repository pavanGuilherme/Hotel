using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Mod.Class
{
    public class DaoQuarto<T> : Dao<T>
    {
        public DaoQuarto() : base() { }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(quarto_ID) FROM quartos";
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

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> quartos = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define a consulta SQL com base no parâmetro `incluiInativos`
                string query = incluiInativos
                    ? "SELECT * FROM quartos"
                    : "SELECT * FROM quartos WHERE ativo = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));

                        obj.quarto_ID = Convert.ToInt32(reader["quarto_ID"]);
                        obj.numero = Convert.ToInt32(reader["numero"]);
                        obj.andar = Convert.ToInt32(reader["andar"]);
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);

                        // Converte tipo_id para int? (nullable int)
                        obj.tipo_id = reader["tipo_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["tipo_id"]) : null;

                        obj.tipo = reader["tipo"].ToString();
                        obj.capacidade_maxima = Convert.ToInt32(reader["capacidade_maxima"]);

                        // Para campos opcionais de texto, usa string.Empty se o valor for DBNull
                        obj.descricao = reader["descricao"] != DBNull.Value ? reader["descricao"].ToString() : string.Empty;
                        obj.observacao = reader["observacao"] != DBNull.Value ? reader["observacao"].ToString() : string.Empty;


                        obj.ativo = Convert.ToBoolean(reader["ativo"]);

                        obj.situacao = reader["situacao"].ToString();
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());

                        quartos.Add(obj);
                    }
                }
            }
            return quartos;
        }

        public override void Salvar(T obj)
        {
            dynamic quarto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO quartos (numero, andar, valor_diaria, tipo_id, tipo, capacidade_maxima, descricao, observacao, ativo, situacao, data_cadastro, data_ult_alt) " +
                               "VALUES (@numero, @andar, @valor_diaria, @tipo_id, @tipo, @capacidade_maxima, @descricao, @observacao, @ativo, @situacao, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@numero", quarto.numero);
                command.Parameters.AddWithValue("@andar", quarto.andar);
                command.Parameters.AddWithValue("@valor_diaria", quarto.valor_diaria);
                command.Parameters.AddWithValue("@tipo_id", quarto.tipo_id != null ? (object)quarto.tipo_id : DBNull.Value);
                command.Parameters.AddWithValue("@tipo", quarto.tipo);
                command.Parameters.AddWithValue("@capacidade_maxima", quarto.capacidade_maxima);
                command.Parameters.AddWithValue("@descricao", quarto.descricao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", quarto.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ativo", quarto.ativo);
                command.Parameters.AddWithValue("@situacao", quarto.situacao);
                command.Parameters.AddWithValue("@data_cadastro", quarto.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", quarto.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int quarto_ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM quartos WHERE quarto_ID = @quarto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quarto_ID", quarto_ID);

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
                        MessageBox.Show("Não é possível excluir o quarto, pois ele está sendo utilizado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public override void alterar(T obj)
        {
            dynamic quarto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE quartos SET numero = @numero, andar = @andar, valor_diaria = @valor_diaria, tipo_id = @tipo_id, tipo = @tipo, " +
                               "capacidade_maxima = @capacidade_maxima, descricao = @descricao, observacao = @observacao, ativo = @ativo, situacao = @situacao, " +
                               "data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt WHERE quarto_ID = @quarto_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quarto_ID", quarto.quarto_ID);
                command.Parameters.AddWithValue("@numero", quarto.numero);
                command.Parameters.AddWithValue("@andar", quarto.andar);
                command.Parameters.AddWithValue("@valor_diaria", quarto.valor_diaria);
                command.Parameters.AddWithValue("@tipo_id", quarto.tipo_id != null ? (object)quarto.tipo_id : DBNull.Value);
                command.Parameters.AddWithValue("@tipo", quarto.tipo);
                command.Parameters.AddWithValue("@capacidade_maxima", quarto.capacidade_maxima);
                command.Parameters.AddWithValue("@descricao", quarto.descricao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", quarto.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ativo", quarto.ativo);
                command.Parameters.AddWithValue("@situacao", quarto.situacao);
                command.Parameters.AddWithValue("@data_cadastro", quarto.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", quarto.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM quartos WHERE quarto_ID = @quarto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quarto_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.quarto_ID = Convert.ToInt32(reader["quarto_ID"]);
                        obj.numero = Convert.ToInt32(reader["numero"]);
                        obj.andar = Convert.ToInt32(reader["andar"]);
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);
                        obj.tipo_id = reader["tipo_id"] != DBNull.Value ? Convert.ToInt32(reader["tipo_id"]) : (int?)null;
                        obj.tipo = reader["tipo"].ToString();
                        obj.capacidade_maxima = Convert.ToInt32(reader["capacidade_maxima"]);
                        obj.descricao = reader["descricao"] != DBNull.Value ? reader["descricao"].ToString() : string.Empty;
                        obj.observacao = reader["observacao"] != DBNull.Value ? reader["observacao"].ToString() : string.Empty;
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.situacao = reader["situacao"].ToString();
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());

                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }
        public tipo_quarto ObterTipoQuartoPorId(int tipoId)
        {
            tipo_quarto tipo = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT tipo_quarto_ID, tipo, descricao, valor_diaria, capacidade_maxima FROM tipo_quarto WHERE tipo_quarto_ID = @tipoId";
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
                            descricao = reader["descricao"].ToString(), 
                            valor_diaria = (decimal)reader["valor_diaria"],
                            capacidade_maxima = (int)reader["capacidade_maxima"]
                        };
                    }
                }
            }

            return tipo;
        }

     

        public List<Quarto> BuscarQuartosDisponiveis(int tipoQuarto_id)
        {
            List<Quarto> quartosDisponiveis = new List<Quarto>();

            string query = @"
        SELECT quarto_ID, numero, andar, descricao, tipo, valor_diaria, tipo_id
        FROM quartos
        WHERE tipo_id = @tipoQuarto_id
          AND situacao = 'livre'
          AND ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipoQuarto_id", tipoQuarto_id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Quarto quarto = new Quarto
                        {
                            quarto_ID = reader.GetInt32(0),
                            numero = reader.GetInt32(1),
                            andar = reader.GetInt32(2),
                            descricao = reader.IsDBNull(3) ? null : reader.GetString(3),
                            tipo = reader.GetString(4),
                            valor_diaria = reader.GetDecimal(5),
                            tipo_id = reader.GetInt32(6)
                        };

                        quartosDisponiveis.Add(quarto);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar quartos disponíveis: " + ex.Message);
                }
            }

            return quartosDisponiveis;
        }
        public void AtualizarStatusQuarto(int quartoId, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE quartos SET situacao = @status WHERE quarto_ID = @quartoId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@quartoId", quartoId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AtualizarSituacao(Quarto quarto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE quartos SET situacao = @situacao WHERE quarto_ID = @quarto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@situacao", quarto.situacao);
                command.Parameters.AddWithValue("@quarto_ID", quarto.quarto_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
        





