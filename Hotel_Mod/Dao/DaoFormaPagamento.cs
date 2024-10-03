using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                connection.Open();
                command.ExecuteNonQuery();
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

        
        
    }
}
