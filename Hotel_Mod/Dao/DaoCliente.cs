using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Hotel_Mod.Class;

namespace Hotel_Mod.Dao
{
    public class DaoCliente<T> : Dao<T>
    {
        public DaoCliente() : base()
        {
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> clientes = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM clientes" : "SELECT * FROM clientes WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_id"]);
                        obj.nome = Convert.ToString(reader["nome"]);
                        obj.sobrenome = Convert.ToString(reader["sobrenome"]);
                        obj.data_nascimento = Convert.ToDateTime(reader["data_nascimento"]);
                        obj.telefone = Convert.ToString(reader["telefone"]);
                        obj.cpf = Convert.ToString(reader["cpf"]);
                        obj.email = Convert.ToString(reader["email"]);
                        obj.rg = Convert.ToString(reader["rg"]);
                        obj.tipo_pcd = Convert.ToBoolean(reader["tipo_pcd"]);
                        obj.estrangeiro = Convert.ToBoolean(reader["estrangeiro"]);
                        obj.profissao = Convert.ToString(reader["profissao"]);
                        obj.cep = Convert.ToString(reader["cep"]);
                        obj.logradouro = Convert.ToString(reader["logradouro"]);
                        obj.numero = Convert.ToString(reader["numero"]);
                        obj.bairro = Convert.ToString(reader["bairro"]);
                        obj.complemento = Convert.ToString(reader["complemento"]);
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        clientes.Add(obj);
                    }
                }
            }
            return clientes;
        }

        public override void Salvar(T obj)
        {
            dynamic cliente = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO clientes (nome, sobrenome, data_nascimento, telefone, cpf, email, rg, tipo_pcd, estrangeiro, " +
                    "profissao, cep, logradouro, numero, bairro, complemento, cidade_id, ativo, data_cadastro, data_ult_alt) " +
                    "VALUES (@nome, @sobrenome, @data_nascimento, @telefone, @cpf, @email, @rg, @tipo_pcd, @estrangeiro, @profissao, @cep, @logradouro, " +
                    "@numero, @bairro, @complemento, @cidade_id, @ativo, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", cliente.nome);
                command.Parameters.AddWithValue("@sobrenome", cliente.sobrenome);
                command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@cpf", cliente.cpf);
                command.Parameters.AddWithValue("@email", cliente.email);
                command.Parameters.AddWithValue("@rg", cliente.rg);
                command.Parameters.AddWithValue("@tipo_pcd", cliente.tipo_pcd);
                command.Parameters.AddWithValue("@estrangeiro", cliente.estrangeiro);
                command.Parameters.AddWithValue("@profissao", cliente.profissao);
                command.Parameters.AddWithValue("@cep", cliente.cep);
                command.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                command.Parameters.AddWithValue("@numero", cliente.numero);
                command.Parameters.AddWithValue("@bairro", cliente.bairro);
                command.Parameters.AddWithValue("@complemento", cliente.complemento);
                command.Parameters.AddWithValue("@cidade_id", cliente.cidade_id);
                command.Parameters.AddWithValue("@ativo", cliente.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cliente.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

      

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM clientes WHERE cliente_id = @cliente_id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void alterar(T obj)
        {
            dynamic cliente = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE clientes SET nome = @nome, sobrenome = @sobrenome, data_nascimento = @data_nascimento, telefone = @telefone, " +
                    "cpf = @cpf, email = @email, rg = @rg, tipo_pcd = @tipo_pcd, estrangeiro = @estrangeiro, profissao = @profissao, cep = @cep, " +
                    "logradouro = @logradouro, numero = @numero, bairro = @bairro, complemento = @complemento, cidade_id = @cidade_id, " +
                    "ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt " +
                    "WHERE cliente_id = @cliente_id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", cliente.nome);
                command.Parameters.AddWithValue("@sobrenome", cliente.sobrenome);
                command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@cpf", cliente.cpf);
                command.Parameters.AddWithValue("@email", cliente.email);
                command.Parameters.AddWithValue("@rg", cliente.rg);
                command.Parameters.AddWithValue("@tipo_pcd", cliente.tipo_pcd);
                command.Parameters.AddWithValue("@estrangeiro", cliente.estrangeiro);
                command.Parameters.AddWithValue("@profissao", cliente.profissao);
                command.Parameters.AddWithValue("@cep", cliente.cep);
                command.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                command.Parameters.AddWithValue("@numero", cliente.numero);
                command.Parameters.AddWithValue("@bairro", cliente.bairro);
                command.Parameters.AddWithValue("@complemento", cliente.complemento);
                command.Parameters.AddWithValue("@cidade_id", cliente.cidade_id);
                command.Parameters.AddWithValue("@ativo", cliente.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cliente.data_ult_alt);
                command.Parameters.AddWithValue("@cliente_id", cliente.cliente_id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<string> GetCidadeEstadoEPaisByCidadeId(int cidade_ID)
        {
            List<string> cidadeInfos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT c.cidade AS cidade, e.estado AS estado, p.pais AS pais
            FROM cidades c
            INNER JOIN estados e ON c.estado_ID = e.estado_ID
            INNER JOIN paises p ON e.pais_ID = p.pais_ID
            WHERE c.cidade_ID = @cidade_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cidade_ID", cidade_ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string cidadeInfo = string.Format("{0}, {1}, {2}",
                            reader["cidade"],
                            reader["estado"],
                            reader["pais"]);
                        cidadeInfos.Add(cidadeInfo);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter informações da cidade: " + ex.Message);
                }
            }
            return cidadeInfos;
        }




        public override T GetById(int cliente_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM clientes WHERE cliente_id = @cliente_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_id", cliente_id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_id"]);
                        obj.nome = reader["nome"].ToString();
                        obj.sobrenome = reader["sobrenome"].ToString();
                        obj.data_nascimento = DateTime.Parse(reader["data_nascimento"].ToString());
                        obj.telefone = reader["telefone"].ToString();
                        obj.cpf = reader["cpf"].ToString();
                        obj.email = reader["email"].ToString();
                        obj.rg = reader["rg"].ToString();
                        obj.tipo_pcd = Convert.ToBoolean(reader["tipo_pcd"]);
                        obj.estrangeiro = Convert.ToBoolean(reader["estrangeiro"]);
                        obj.profissao = reader["profissao"].ToString();
                        obj.cep = reader["cep"].ToString();
                        obj.logradouro = reader["logradouro"].ToString();
                        obj.numero = reader["numero"].ToString();
                        obj.bairro = reader["bairro"].ToString();
                        obj.complemento = reader["complemento"].ToString();
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);
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
    }
}
