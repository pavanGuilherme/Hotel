using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Mod.Models;

namespace Hotel_Mod.Class
{
    public class DaoFormaPagamento<T> : Dao<T>
    {
        public DaoFormaPagamento() : base() { }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> formasPagamento = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM formaPagamento" : "SELECT * FROM formaPagamento WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.FormaPagamento_ID = Convert.ToInt32(reader["FormaPagamento_ID"]);
                        obj.formaPagamento = reader["formaPagamento"].ToString();
                        obj.Ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.DataCadastro = DateTime.Parse(reader["dataCadastro"].ToString());
                        obj.DataUltAlt = DateTime.Parse(reader["dataUltAlt"].ToString());

                        formasPagamento.Add(obj);
                    }
                }
            }

            return formasPagamento;
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(formaPagamento_ID) FROM formaPagamento";
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

        public string getFormaPag(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT formaPagamento FROM formaPagamento WHERE formaPagamento_ID = @id AND Ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["formaPagamento"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public override void Salvar(T obj)
        {
            dynamic formaPagamento = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO formaPagamento(formaPagamento, ativo, dataCadastro, dataUltAlt) " +
                               "VALUES (@formaPagamento, @ativo, @dataCadastro, @dataUltAlt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@formaPagamento", formaPagamento.formaPagamento);
                command.Parameters.AddWithValue("@ativo", formaPagamento.Ativo);
                command.Parameters.AddWithValue("@dataCadastro", formaPagamento.DataCadastro);
                command.Parameters.AddWithValue("@dataUltAlt", formaPagamento.DataUltAlt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM formaPagamento WHERE FormaPagamento_ID = @id";
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
                        MessageBox.Show("Não é possível excluir a forma de pagamento, pois ela está associada a um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
 

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM FormaPagamento WHERE FormaPagamento_ID = @FormaPagamento_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FormaPagamento_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.FormaPagamento_ID = Convert.ToInt32(reader["FormaPagamento_ID"]);
                        obj.formaPagamento = reader["formaPagamento"].ToString();
                        obj.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        obj.DataCadastro = DateTime.Parse(reader["DataCadastro"].ToString());
                        obj.DataUltAlt = DateTime.Parse(reader["DataUltAlt"].ToString());
                        return obj;
                    }
                    else
                    {
                        return default(T); // retorna default se a forma de pagamento não for encontrada
                    }
                }
            }
        }

        public override void alterar(T obj)
        {
            dynamic formaPagamento = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE formaPagamento SET formaPagamento = @formaPagamento, ativo = @ativo, dataUltAlt = @dataUltAlt " +
                               "WHERE FormaPagamento_ID = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", formaPagamento.FormaPagamento_ID);
                command.Parameters.AddWithValue("@formaPagamento", formaPagamento.formaPagamento);
                command.Parameters.AddWithValue("@ativo", formaPagamento.Ativo);
                command.Parameters.AddWithValue("@dataUltAlt", formaPagamento.DataUltAlt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string ObterDescricaoFormaPagamento(int formaPagamentoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Corrige o nome do campo para "formaPagamento"
                string query = "SELECT formaPagamento FROM formaPagamento WHERE formaPagamento_ID = @FormaPagamento_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FormaPagamento_ID", formaPagamentoId);
                    connection.Open();

                    // Retorna a descrição da forma de pagamento ou "N/A" caso não encontre
                    return command.ExecuteScalar()?.ToString() ?? "N/A";
                }
            }
        }


    }
}
