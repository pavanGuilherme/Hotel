using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hotel_Mod.Class;

namespace Hotel_Mod.Dao
{
    public class DaoHospede<T> : Dao<T>
    {
        public DaoHospede() : base()
        {
        }


        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(hospede_ID) FROM hospede";
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
            List<T> hospedes = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM hospede" : "SELECT * FROM hospede WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.hospede_id = Convert.ToInt32(reader["hospede_id"]);
                        obj.nome = Convert.ToString(reader["nome"]);
                        obj.sexo = Convert.ToChar(reader["sexo"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.cep = Convert.ToString(reader["cep"]);
                        obj.logradouro = Convert.ToString(reader["logradouro"]);
                        obj.numero = Convert.ToString(reader["numero"]);
                        obj.complemento = Convert.ToString(reader["complemento"]);
                        obj.bairro = Convert.ToString(reader["bairro"]);
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);
                        obj.estrangeiro = Convert.ToBoolean(reader["estrangeiro"]);
                        obj.cpf = Convert.ToString(reader["cpf"]);
                        obj.rg = Convert.ToString(reader["rg"]);
                        obj.passaporte = Convert.ToString(reader["passaporte"]);
                        obj.telefone = Convert.ToString(reader["telefone"]);
                        obj.email = Convert.ToString(reader["email"]);
                        obj.data_nascimento = reader["data_nascimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_nascimento"]) : (DateTime?)null;
                        obj.pcd = Convert.ToBoolean(reader["pcd"]);
                        obj.observacao = Convert.ToString(reader["observacao"]);
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        hospedes.Add(obj);
                    }
                }
            }
            return hospedes;
        }

        public override void Salvar(T obj)
        {
            dynamic hospede = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO hospede (nome, sexo, ativo, cep, logradouro, numero, complemento, bairro, cidade_id, " +
                    "estrangeiro, cpf, rg, passaporte, telefone, email, data_nascimento, pcd, observacao, data_cadastro, data_ult_alt) " +
                    "VALUES (@nome, @sexo, @ativo, @cep, @logradouro, @numero, @complemento, @bairro, @cidade_id, " +
                    "@estrangeiro, @cpf, @rg, @passaporte, @telefone, @email, @data_nascimento, @pcd, @observacao, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", hospede.nome);
                command.Parameters.AddWithValue("@sexo", hospede.sexo);
                command.Parameters.AddWithValue("@ativo", hospede.ativo);
                command.Parameters.AddWithValue("@cep", hospede.cep);
                command.Parameters.AddWithValue("@logradouro", hospede.logradouro);
                command.Parameters.AddWithValue("@numero", hospede.numero);
                command.Parameters.AddWithValue("@complemento", hospede.complemento);
                command.Parameters.AddWithValue("@bairro", hospede.bairro);
                command.Parameters.AddWithValue("@cidade_id", hospede.cidade_id);
                command.Parameters.AddWithValue("@estrangeiro", hospede.estrangeiro);
                command.Parameters.AddWithValue("@cpf", hospede.cpf);
                command.Parameters.AddWithValue("@rg", hospede.rg);

                // Tratamento para passaporte vazio ou nulo
                if (string.IsNullOrWhiteSpace(hospede.passaporte) || hospede.passaporte == "0000000000000000")
                {
                    command.Parameters.AddWithValue("@passaporte", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@passaporte", hospede.passaporte);
                }

                command.Parameters.AddWithValue("@telefone", hospede.telefone);
                command.Parameters.AddWithValue("@email", hospede.email);
                command.Parameters.AddWithValue("@data_nascimento", hospede.data_nascimento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@pcd", hospede.pcd);

                // Tratamento para observação vazio ou nulo
                if (string.IsNullOrWhiteSpace(hospede.observacao))
                {
                    command.Parameters.AddWithValue("@observacao", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@observacao", hospede.observacao);
                }

                command.Parameters.AddWithValue("@data_cadastro", hospede.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", hospede.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM hospede WHERE hospede_id = @hospede_id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@hospede_id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void alterar(T obj)
        {
            dynamic hospede = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE hospede SET nome = @nome, sexo = @sexo, ativo = @ativo, cep = @cep, logradouro = @logradouro, numero = @numero, " +
                    "complemento = @complemento, bairro = @bairro, cidade_id = @cidade_id, estrangeiro = @estrangeiro, " +
                    "cpf = @cpf, rg = @rg, passaporte = @passaporte, telefone = @telefone, email = @email, data_nascimento = @data_nascimento, pcd = @pcd, observacao = @observacao, " +
                    "data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt WHERE hospede_id = @hospede_id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nome", hospede.nome);
                command.Parameters.AddWithValue("@sexo", hospede.sexo);
                command.Parameters.AddWithValue("@ativo", hospede.ativo);
                command.Parameters.AddWithValue("@cep", hospede.cep);
                command.Parameters.AddWithValue("@logradouro", hospede.logradouro);
                command.Parameters.AddWithValue("@numero", hospede.numero);
                command.Parameters.AddWithValue("@complemento", hospede.complemento);
                command.Parameters.AddWithValue("@bairro", hospede.bairro);
                command.Parameters.AddWithValue("@cidade_id", hospede.cidade_id);
                command.Parameters.AddWithValue("@estrangeiro", hospede.estrangeiro);
                command.Parameters.AddWithValue("@cpf", hospede.cpf);
                command.Parameters.AddWithValue("@rg", hospede.rg);
                command.Parameters.AddWithValue("@passaporte", hospede.passaporte);
                command.Parameters.AddWithValue("@telefone", hospede.telefone);
                command.Parameters.AddWithValue("@email", hospede.email);
                command.Parameters.AddWithValue("@data_nascimento", hospede.data_nascimento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@pcd", hospede.pcd);
                command.Parameters.AddWithValue("@observacao", hospede.observacao);
                command.Parameters.AddWithValue("@data_cadastro", hospede.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", hospede.data_ult_alt);
                command.Parameters.AddWithValue("@hospede_id", hospede.hospede_id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int hospede_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM hospede WHERE hospede_id = @hospede_id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@hospede_id", hospede_id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.hospede_id = Convert.ToInt32(reader["hospede_id"]);
                        obj.nome = reader["nome"].ToString();
                        obj.sexo = reader["sexo"].ToString()[0];
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        obj.cep = reader["cep"].ToString();
                        obj.logradouro = reader["logradouro"].ToString();
                        obj.numero = reader["numero"].ToString();
                        obj.complemento = reader["complemento"].ToString();
                        obj.bairro = reader["bairro"].ToString();
                        obj.cidade_id = Convert.ToInt32(reader["cidade_id"]);
                        obj.estrangeiro = Convert.ToBoolean(reader["estrangeiro"]);
                        obj.cpf = reader["cpf"].ToString();
                        obj.rg = reader["rg"].ToString();
                        obj.passaporte = reader["passaporte"].ToString();
                        obj.telefone = reader["telefone"].ToString();
                        obj.email = reader["email"].ToString();
                        obj.data_nascimento = reader["data_nascimento"] != DBNull.Value ? Convert.ToDateTime(reader["data_nascimento"]) : (DateTime?)null;
                        obj.pcd = Convert.ToBoolean(reader["pcd"]);
                        obj.observacao = reader["observacao"].ToString();
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }

        // Método para obter cidade, estado e país a partir de cidade_id (chave estrangeira)
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
    }
}
