using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mod.Class
{
    public class DaoEstado<T> : Dao<T>
    {

        public DaoEstado() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(estado_ID) FROM estados";
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
            List<T> estados = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM estados" : "SELECT * FROM estados WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.estado_ID = Convert.ToInt32(reader["estado_ID"]);
                        obj.estado = reader["estado"].ToString();
                        obj.uf = reader["uf"].ToString();
                        obj.pais_ID = Convert.ToInt32(reader["pais_ID"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        estados.Add(obj);
                    }

                }
            }
            return estados;
        }

        public override void Salvar(T obj)
        {
            dynamic estado = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO estados (estado, uf, ativo, pais_ID, data_cadastro, data_ult_alt) values (@estado, @uf, @ativo, @pais_ID, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@estado", estado.estado);
                command.Parameters.AddWithValue("@uf", estado.uf);
                command.Parameters.AddWithValue("@ativo", estado.ativo);
                command.Parameters.AddWithValue("@pais_ID", estado.pais_ID);
                command.Parameters.AddWithValue("@data_cadastro", estado.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", estado.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }


        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM estados WHERE estado_ID = @estado_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@estado_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.estado_ID = Convert.ToInt32(reader["estado_ID"]);
                        obj.estado = reader["estado"].ToString();
                        obj.uf = reader["uf"].ToString();
                        obj.pais_ID = Convert.ToInt32(reader["pais_ID"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        return obj;
                    }
                    else
                    {
                        return default(T); // retorna default se o estado não for encontrado
                    }
                }
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM estados WHERE estado_ID = @estado_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("estado_ID", id);

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
                        MessageBox.Show("Não é possível excluir o estado, pois ele está sendo utilizado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dynamic Estado = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE estados SET estado = @estado, uf = @uf, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt, pais_id = @pais_ID WHERE estado_ID = @estado_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@estado_ID", Estado.estado_ID);
                command.Parameters.AddWithValue("@estado", Estado.estado);
                command.Parameters.AddWithValue("@uf", Estado.uf);
                command.Parameters.AddWithValue("@ativo", Estado.ativo);
                command.Parameters.AddWithValue("@pais_ID", Estado.pais_ID);
                command.Parameters.AddWithValue("@data_cadastro", Estado.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", Estado.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string GetNomePaisByEstadoId(int estado_ID)
        {
            string nomePais = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT pais.paises FROM estados INNER JOIN paises ON estados.pais_ID = paises.pais_ID WHERE estados.estado_ID = @estado_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@estado_ID", estado_ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        nomePais = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter o nome do país: " + ex.Message);
                }
            }
            return nomePais;
        }

    }
}
