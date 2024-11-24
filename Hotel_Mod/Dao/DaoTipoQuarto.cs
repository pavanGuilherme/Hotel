using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Mod.Class
{
    public class DaoTipoQuarto<T> : Dao<T>
    {
        public DaoTipoQuarto() : base() { }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(tipo_quarto_ID) FROM tipo_quarto";
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

        public override List<T> GetAll(bool incluiInativos = true)
        {
            List<T> tiposQuarto = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tipo_quarto";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.tipo_quarto_ID = Convert.ToInt32(reader["tipo_quarto_ID"]);
                        obj.tipo = reader["tipo"].ToString();
                        obj.descricao = reader["descricao"].ToString();
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);
                        obj.capacidade_maxima = Convert.ToInt32(reader["capacidade_maxima"]);
                        obj.lotacaoMaxima = Convert.ToInt32(reader["lotacaoMaxima"]);
                        tiposQuarto.Add(obj);
                    }
                }
            }
            return tiposQuarto;
        }

        public override void Salvar(T obj)
        {
            dynamic tipoQuarto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tipo_quarto (tipo, descricao, valor_diaria, capacidade_maxima, lotacaoMaxima) VALUES (@tipo, @descricao, @valor_diaria, @capacidade_maxima, @lotacaoMaxima)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo", tipoQuarto.tipo);
                command.Parameters.AddWithValue("@descricao", tipoQuarto.descricao);
                command.Parameters.AddWithValue("@valor_diaria", tipoQuarto.valor_diaria);
                command.Parameters.AddWithValue("@capacidade_maxima", tipoQuarto.capacidade_maxima);
                command.Parameters.AddWithValue("@lotacaoMaxima", tipoQuarto.lotacaoMaxima);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM tipo_quarto WHERE tipo_quarto_ID = @tipo_quarto_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo_quarto_ID", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Erro de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o Tipo de Quarto, pois ele está sendo utilizado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dynamic tipoQuarto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE tipo_quarto SET tipo = @tipo, descricao = @descricao, capacidade_maxima = @capacidade_maxima WHERE tipo_quarto_ID = @tipo_quarto_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo_quarto_ID", tipoQuarto.tipo_quarto_ID);
                command.Parameters.AddWithValue("@tipo", tipoQuarto.tipo);
                command.Parameters.AddWithValue("@descricao", tipoQuarto.descricao);
                command.Parameters.AddWithValue("@valor_diaria", tipoQuarto.valor_diaria);
                command.Parameters.AddWithValue("@capacidade_maxima", tipoQuarto.capacidade_maxima);
                command.Parameters.AddWithValue("@lotacaoMaxima", tipoQuarto.lotacaoMaxima);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tipo_quarto WHERE tipo_quarto_ID = @tipo_quarto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo_quarto_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.tipo_quarto_ID = Convert.ToInt32(reader["tipo_quarto_ID"]);
                        obj.tipo = reader["tipo"].ToString();
                        obj.descricao = reader["descricao"].ToString();
                        obj.valor_diaria = Convert.ToDecimal(reader["valor_diaria"]);
                        obj.capacidade_maxima = Convert.ToInt32(reader["capacidade_maxima"]);
                        obj.lotacaoMaxima = Convert.ToInt32(reader["lotacaoMaxima"]);
                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }
    }
}
