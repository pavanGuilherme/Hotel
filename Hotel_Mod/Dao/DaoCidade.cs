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

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> cidades = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM cidades" : "SELECT * FROM CIDADES WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cidade_ID = Convert.ToInt32(reader["cidade_ID"]);
                        obj.cidade = reader["cidade"].ToString();
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
                string query = "INSERT INTO cidades(cidade, ddd, ativo, data_cadastro, data_ult_alt) values (@cidade, @ddd, @ativo, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@cidade_nome", cidade.cidade_nome);
                command.Parameters.AddWithValue("@ddd", cidade.ddd);
                command.Parameters.AddWithValue("@ativo", cidade.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cidade.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cidade.dat_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE  * FROM cidades where cidade_id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void alterar(T obj)

        {
            dynamic cidade = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE pais SET cidade = @cidade, @ddd = ddd, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt WHERE cidade_id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cidade_id", cidade.cidade_ID);
                command.Parameters.AddWithValue("@cidade", cidade.cidade);
                command.Parameters.AddWithValue("@ativo", cidade.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cidade.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cidade.dat_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public override T pesquisar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from cidades where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);
                        obj.cidade = reader["cidade"].ToString();
                        obj.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        obj.dataCadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.dat_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }


                }


            }
        }

        public string GetNomeEstadoByCidadeId(int cidade_ID)
        {
            string nomeEstado = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT estado.estados FROM cidades INNER JOIN estado ON cidade.estado_ID = estado.estado_ID WHERE cidade.cidade_ID = @cidade_ID";
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


