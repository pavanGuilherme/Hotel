using Hotel_Mod.Class;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Dao
{
    public class DaoFuncionario<T> : Dao<T>
    {

        public DaoFuncionario() : base()
        {
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> funcionarios = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM funcionarios" : "SELECT * FROM funcionarios WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.funcionario_ID = Convert.ToInt32(reader["funcionario_ID"]);
                        obj.nome = reader["nome"].ToString();
                        obj.celular = reader["celular"].ToString();
                        obj.cpf = reader["cpf"].ToString();
                        obj.cargo = reader["cargo"].ToString();
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                       

                        funcionarios.Add(obj);
                    }

                }
            }
            return funcionarios;
        }

        public override void Salvar(T obj)
        {
            dynamic funcionario = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO funcionario (nome, sobrenome, endereco, bairro, numero, cep, complemento, sexo, email, telefone, celular, data_nascimento, cpf, rg, cargo, salario, pis, data_admissao, data_demissao, ativo, data_cadastro, data_ult_alt, cidade_id) " +
                "VALUES (@nome, @sobrenome, @endereco, @bairro, @numero, @cep, @complemento, @sexo, @email, @telefone, @celular, @data_nascimento, @cpf, @rg, @cargo, @salario, @pis, @data_admissao, @data_demissao, @ativo, @data_cadastro, @data_ult_alt, @cidade_id)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", funcionario.nome);
                command.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                command.Parameters.AddWithValue("@endereco", funcionario.endereco);
                command.Parameters.AddWithValue("@bairro", funcionario.bairro);
                command.Parameters.AddWithValue("@numero", funcionario.numero);
                command.Parameters.AddWithValue("@cep", funcionario.cep);
                command.Parameters.AddWithValue("@complemento", funcionario.complemento);
                command.Parameters.AddWithValue("@sexo", funcionario.sexo);
                command.Parameters.AddWithValue("@email", funcionario.email);
                command.Parameters.AddWithValue("@telefone", funcionario.telefone);
                command.Parameters.AddWithValue("@celular", funcionario.celular);
                command.Parameters.AddWithValue("@data_nascimento", funcionario.data_nascimento);
                command.Parameters.AddWithValue("@cpf", funcionario.cpf);
                command.Parameters.AddWithValue("@rg", funcionario.rg);
                command.Parameters.AddWithValue("@cargo", funcionario.cargo);
                command.Parameters.AddWithValue("@salario", funcionario.salario);
                command.Parameters.AddWithValue("@pis", funcionario.pis);
                command.Parameters.AddWithValue("@data_admissao", funcionario.data_admissao);
                command.Parameters.AddWithValue("@data_demissao", funcionario.data_demissao.HasValue ? (object)funcionario.data_demissao.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ativo", funcionario.ativo);
                command.Parameters.AddWithValue("@data_cadastro", funcionario.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", funcionario.data_ult_alt);
                command.Parameters.AddWithValue("@cidade_id", funcionario.cidade_id);


                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE  * FROM funcionarios where funcionario_ID = @funcionario_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@funcionario_ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public override void alterar(T obj)

        {
            dynamic funcionario = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE funcionario SET nome = @nome, sobrenome = @sobrenome, endereco = @endereco, bairro = @bairro, numero = @numero, cep = @cep, complemento = @complemento, sexo = @sexo, email = @email, telefone = @telefone, celular = @celular, data_nascimento = @data_nascimento, cpf = @cpf, rg = @rg, cargo = @cargo, salario = @salario, pis = @pis, data_admissao = @data_admissao, data_demissao = @data_demissao, ativo = @ativo, data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt, cidade_id = @cidade_id WHERE funcionario_ID = @funcionario_ID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@funcionario_ID", funcionario.funcionario_ID);
                command.Parameters.AddWithValue("@nome", funcionario.nome);
                command.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                command.Parameters.AddWithValue("@endereco", funcionario.endereco);
                command.Parameters.AddWithValue("@bairro", funcionario.bairro);
                command.Parameters.AddWithValue("@numero", funcionario.numero);
                command.Parameters.AddWithValue("@cep", funcionario.cep);
                command.Parameters.AddWithValue("@complemento", funcionario.complemento);
                command.Parameters.AddWithValue("@sexo", funcionario.sexo);
                command.Parameters.AddWithValue("@email", funcionario.email);
                command.Parameters.AddWithValue("@telefone", funcionario.telefone);
                command.Parameters.AddWithValue("@celular", funcionario.celular);
                command.Parameters.AddWithValue("@data_nascimento", funcionario.data_nascimento);
                command.Parameters.AddWithValue("@cpf", funcionario.cpf);
                command.Parameters.AddWithValue("@rg", funcionario.rg);
                command.Parameters.AddWithValue("@cargo", funcionario.cargo);
                command.Parameters.AddWithValue("@salario", funcionario.salario);
                command.Parameters.AddWithValue("@pis", funcionario.pis);
                command.Parameters.AddWithValue("@data_admissao", funcionario.data_admissao);
                command.Parameters.AddWithValue("@data_demissao", funcionario.data_demissao.HasValue ? (object)funcionario.data_demissao.Value : DBNull.Value);
                command.Parameters.AddWithValue("@ativo", funcionario.ativo);
                command.Parameters.AddWithValue("@data_cadastro", funcionario.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", funcionario.data_ult_alt);
                command.Parameters.AddWithValue("@cidade_id", funcionario.cidade_id);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetCEPByCidadeId(int cidade_ID)
        {
            List<string> cidadeInfos = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    cidades.cidade AS cidade,
                    estados.UF AS UF,
                    paises.pais AS pais
                FROM 
                    cidades
                JOIN 
                    estados ON cidades.estado_ID = estados.estado_ID
                JOIN 
                    paises ON estados.paises_ID = paises.pais_ID
                WHERE 
                    cidades.cidade_ID = @cidade_ID";
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
                            reader["UF"],
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


        public override T pesquisar(int funcionario_ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from funcionarios where funcionario_ID = @funcionario_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@funcionario_ID", funcionario_ID);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.funcionario_ID = Convert.ToInt32(reader["funcionario_ID"]);
                        obj.nome = reader["nome"].ToString();
                        obj.sobrenome = reader["sobrenome"].ToString();
                        obj.endereco = reader["endereco"].ToString();
                        obj.bairro = reader["bairro"].ToString();
                        obj.numero = Convert.ToInt32(reader["numero"]);
                        obj.cep = reader["cep"].ToString();
                        obj.complemento = reader["complemento"].ToString();
                        obj.sexo = reader["sexo"].ToString();
                        obj.email = reader["email"].ToString();
                        obj.telefone = reader["telefone"].ToString();
                        obj.celular = reader["celular"].ToString();
                        obj.data_nascimento = DateTime.Parse(reader["data_nascimento"].ToString());
                        obj.cpf = reader["cpf"].ToString();
                        obj.rg = reader["rg"].ToString();
                        obj.cargo = reader["cargo"].ToString();
                        obj.salario = Convert.ToDecimal(reader["salario"]);
                        obj.pis = reader["pis"].ToString();
                        obj.data_admissao = DateTime.Parse(reader["data_admissao"].ToString());
                        obj.data_demissao = reader["data_demissao"] != DBNull.Value ? (DateTime?)DateTime.Parse(reader["data_demissao"].ToString()) : null;
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);

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
