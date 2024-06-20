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
                        obj.cliente_ID= Convert.ToInt32(reader["cliente_ID"]);
                        obj.nome = Convert.ToString(reader["nome"]);
                        obj.sobrenome = Convert.ToString(reader["sobrenome"]);
                        obj.telefone = Convert.ToString(reader["telefone"]);
                        obj.cpf = Convert.ToString(reader["cpf"]);
                        obj.rg = Convert.ToString(reader["rg"]);
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
                string query = "INSERT INTO clientes (nome,sobrenome, data_nascimento,telefone, cpf, rg, tipo_pcd, estrangeiro, " +
                    "profissao, cep, logradouro, numero, bairro, cidade, estado, pais, ativo, data_cadastro, dat_ult_alt) " +
                    "values (@nome,@sobrenome, @data_nascimento, @telefone, @cpf, @rg, @tipo_pcd, @estrangeiro, @profissao, @cep, @logradouro, @numero, " +
                    "@bairro, @cidade, @estado, @pais, @ativo, @data_cadastro, @dat_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", cliente.nome );
                command.Parameters.AddWithValue("@sobrenome", cliente.sobrenome);
                command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@rg", cliente.rg);
                command.Parameters.AddWithValue("@cpf", cliente.cpf);
                command.Parameters.AddWithValue("@tipo_pcd", cliente.tipo_pcd);
                command.Parameters.AddWithValue("@estrangeiro", cliente.estrangeiro);
                command.Parameters.AddWithValue("@profissao", cliente.profissao);
                command.Parameters.AddWithValue("@cep", cliente.cep);
                command.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                command.Parameters.AddWithValue("@numero", cliente.numero);
                command.Parameters.AddWithValue("@bairro", cliente.bairro);
                command.Parameters.AddWithValue("@cidade", cliente.cidade);
                command.Parameters.AddWithValue("@estado", cliente.estado);
                command.Parameters.AddWithValue("@pais", cliente.pais);
                command.Parameters.AddWithValue("@ativo", cliente.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro);
                command.Parameters.AddWithValue("@dat_ult_alt", cliente.dat_ult_alt);
      
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM clientes where cliente_ID = @cliente_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void alterar(T obj)
        {
            dynamic cliente = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE clientes SET nome = @nome, sobrenome = @sobrenome, data_nascimento = @data_nascimento, telefone = @telefone, rg = @rg, cpf = @cpf, tipo_pcd = @tipo_pcd, estrangeiro = @estrangeiro, profissao = @profissao, cep = @cep, logradouro = @logradouro, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado, pais = @pais, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt  WHERE cliente_ID = @cliente_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", cliente.nome);
                command.Parameters.AddWithValue("@sobrenome", cliente.sobrenome);
                command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@rg", cliente.rg);
                command.Parameters.AddWithValue("@cpf", cliente.cpf);
                command.Parameters.AddWithValue("@tipo_pcd", cliente.tipo_pcd);
                command.Parameters.AddWithValue("@estrangeiro", cliente.estrangeiro);
                command.Parameters.AddWithValue("@profissao", cliente.profissao);
                command.Parameters.AddWithValue("@cep", cliente.cep);
                command.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                command.Parameters.AddWithValue("@numero", cliente.numero);
                command.Parameters.AddWithValue("@bairro", cliente.bairro);
                command.Parameters.AddWithValue("@cidade", cliente.cidade);
                command.Parameters.AddWithValue("@estado", cliente.estado);
                command.Parameters.AddWithValue("@pais", cliente.pais);
                command.Parameters.AddWithValue("@ativo", cliente.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro);
                command.Parameters.AddWithValue("@dat_ult_alt", cliente.dat_ult_alt);




                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public override T pesquisar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from clientes where cliente_ID = @cliente_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente_ID", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_ID"]);
                        obj.nome = reader["nome"].ToString();
                        obj.sobrenome = reader["sobrenome"].ToString();
                        obj.data_nascimento = DateTime.Parse(reader["data_nascimento"].ToString());
                        obj.telefone = reader["telefone"].ToString();
                        obj.cpf = reader["cpf"].ToString();
                        obj.rg = reader["rg"].ToString();
                        obj.tipo_pcd = Convert.ToBoolean(reader["tipo_pcd"]);
                        obj.estrangeiro = Convert.ToBoolean(reader["estrangeiro"]);
                        obj.profissao = reader["profissao"].ToString();
                        obj.cep = reader["cep"].ToString();
                        obj.logradouro = reader["logradouro"].ToString();
                        obj.numero = reader["numero"].ToString();
                        obj.bairro = reader["bairro"].ToString();
                        obj.cidade = reader["cidade"].ToString();
                        obj.estado = reader["estado"].ToString();
                        obj.pais = reader["pais"].ToString();
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
