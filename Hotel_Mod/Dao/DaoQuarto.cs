using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Mod.Class
{
    public class DaoQuarto<T> : Dao<T>
    {
        public DaoQuarto() : base()
        {
        }

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
                string query = incluiInativos ? "SELECT * FROM quartos" : "SELECT * FROM quartos WHERE ativo = 1";
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
                        obj.tipo = reader["tipo"].ToString();
                        obj.descricao = reader["descricao"].ToString();
                        obj.valor = Convert.ToDecimal(reader["valor"]);
                        obj.disponivel = Convert.ToBoolean(reader["disponivel"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
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
                string query = "INSERT INTO quartos(numero, andar, tipo, descricao, valor, disponivel, ativo, data_cadastro, data_ult_alt) " +
                               "VALUES (@numero, @andar, @tipo, @descricao, @valor, @disponivel, @ativo, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@numero", quarto.numero);
                command.Parameters.AddWithValue("@andar", quarto.andar);
                command.Parameters.AddWithValue("@tipo", quarto.tipo);
                command.Parameters.AddWithValue("@descricao", quarto.descricao);
                command.Parameters.AddWithValue("@valor", quarto.valor);
                command.Parameters.AddWithValue("@disponivel", quarto.disponivel);
                command.Parameters.AddWithValue("@ativo", quarto.ativo);
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

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void alterar(T obj)
        {
            dynamic quarto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE quartos SET numero = @numero, andar = @andar, tipo = @tipo, descricao = @descricao, " +
                               "valor = @valor, disponivel = @disponivel, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt " +
                               "WHERE quarto_ID = @quarto_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quarto_ID", quarto.quarto_ID);
                command.Parameters.AddWithValue("@numero", quarto.numero);
                command.Parameters.AddWithValue("@andar", quarto.andar);
                command.Parameters.AddWithValue("@tipo", quarto.tipo);
                command.Parameters.AddWithValue("@descricao", quarto.descricao);
                command.Parameters.AddWithValue("@valor", quarto.valor);
                command.Parameters.AddWithValue("@disponivel", quarto.disponivel);
                command.Parameters.AddWithValue("@ativo", quarto.ativo);
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
                        obj.tipo = reader["tipo"].ToString();
                        obj.descricao = reader["descricao"].ToString();
                        obj.valor = Convert.ToDecimal(reader["valor"]);
                        obj.disponivel = Convert.ToBoolean(reader["disponivel"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
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

        public string GetTipoQuartoById(int quarto_ID)
        {
            string tipoQuarto = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT tipo FROM quartos WHERE quarto_ID = @quarto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quarto_ID", quarto_ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        tipoQuarto = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter o tipo do quarto: " + ex.Message);
                }
            }
            return tipoQuarto;
        }
    }
}
