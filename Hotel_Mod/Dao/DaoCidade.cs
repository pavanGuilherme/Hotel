using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{

    public class DaoCidade<T> : Dao<T>
    {

        public DaoCidade() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(cidade_ID) FROM cidades";
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
            List<T> cidades = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM cidades" : "SELECT * FROM cidades WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cidade_ID = Convert.ToInt32(reader["cidade_ID"]);
                        obj.cidade = reader["cidade"].ToString();
                        obj.ddd = reader["ddd"].ToString();
                        obj.estado_ID = Convert.ToInt32(reader["estado_ID"]);

                        cidades.Add(obj);
                    }

                }
            }
            return cidades;
        }

        public override void Salvar(T obj)
        {
            dynamic cidade = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO cidades(cidade, ddd, ativo, estado_ID, data_cadastro, data_ult_alt) values (@cidade, @ddd, @ativo, @estado_ID, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@cidade", cidade.cidade);
                command.Parameters.AddWithValue("@ddd", cidade.ddd);
                command.Parameters.AddWithValue("@ativo", cidade.ativo);
                command.Parameters.AddWithValue("@estado_ID", cidade.estado_ID);
                command.Parameters.AddWithValue("@data_cadastro", cidade.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cidade.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM paises WHERE pais_ID = @pais_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pais_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.pais_ID = Convert.ToInt32(reader["pais_ID"]);
                        obj.pais = reader["pais"].ToString();
                        obj.sigla = reader["sigla"].ToString();
                        obj.ddi = reader["ddi"].ToString();
                        obj.ativo = Convert.ToBoolean(reader["Ativo"]);
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        return obj;
                    }
                    else
                    {
                        return default(T); // retorna default se o país não for encontrado
                    }
                }
            }
        }

        public override void excluir(int cidade_ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM cidades where cidade_ID = @cidade_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cidade_ID", cidade_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void alterar(T obj)
        {
            dynamic cidade = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE cidades SET cidade = @cidade, ddd = @ddd, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt, estado_ID = @estado_ID WHERE cidade_ID = @cidade_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cidade_ID", cidade.cidade_ID);
                command.Parameters.AddWithValue("@cidade", cidade.cidade);
                command.Parameters.AddWithValue("@ddd", cidade.ddd);
                command.Parameters.AddWithValue("@ativo", cidade.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cidade.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cidade.data_ult_alt);
                command.Parameters.AddWithValue("@estado_ID", cidade.estado_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public string GetNomeEstadoByCidadeId(int cidade_ID)
        {
            string nomeEstado = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT estados.estado FROM cidades INNER JOIN estados ON cidades.estado_ID = estados.estado_ID WHERE cidades.cidade_ID = @cidade_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cidade_ID", cidade_ID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        nomeEstado = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter o nome do estado: " + ex.Message);
                }
            }
            return nomeEstado;
        }


    }
}


