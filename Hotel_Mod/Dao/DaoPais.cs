using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Hotel_Mod.Class
{
    public class DaoPais<T> : Dao<T>
    {

        public DaoPais() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(pais_ID) FROM paises";
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
            List<T> paises = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM paises" : "SELECT * FROM paises WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.pais_ID = Convert.ToInt32(reader["pais_ID"]);
                        obj.pais = reader["pais"].ToString();
                        obj.ddi = reader["ddi"].ToString();
                        obj.sigla = reader["sigla"].ToString();
                        paises.Add(obj);
                    }

                }
            }
            return paises;
        }

        public override void Salvar(T obj)
        {
            dynamic pais = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO paises (pais, sigla, ddi, ativo, data_cadastro, data_ult_alt) values (@pais, @sigla, @ddi, @ativo, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@pais", pais.pais);
                command.Parameters.AddWithValue("@sigla", pais.sigla);
                command.Parameters.AddWithValue("@ddi", pais.ddi);
                command.Parameters.AddWithValue("@ativo", pais.ativo);
                command.Parameters.AddWithValue("@data_cadastro", pais.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", pais.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM paises WHERE pais_ID = @pais_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pais_ID", id);

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
                        MessageBox.Show("Não é possível excluir o País, pois ele está sendo utilizado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dynamic pais = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE paises SET pais = @pais, sigla = @sigla, ddi = @ddi, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt WHERE pais_ID = @pais_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@pais_ID", pais.pais_ID);
                command.Parameters.AddWithValue("@pais", pais.pais);
                command.Parameters.AddWithValue("@sigla", pais.sigla);
                command.Parameters.AddWithValue("@ddi", pais.ddi);
                command.Parameters.AddWithValue("@ativo", pais.ativo);
                command.Parameters.AddWithValue("@data_cadastro", pais.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", pais.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM paises WHERE pais_ID = @pais_id";
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
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
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


    
        
    }
}
