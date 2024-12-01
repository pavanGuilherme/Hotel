using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
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
                string query = incluiInativos ? "SELECT * FROM cliente" : "SELECT * FROM cliente WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.cliente_ID = Convert.ToInt32(reader["cliente_id"]);
                        obj.nome = Convert.ToString(reader["nome"]);
                        obj.apelido = Convert.ToString(reader["apelido"]);  // Campo atualizado
                        obj.data_nascimento = Convert.ToDateTime(reader["data_nascimento"]);
                        obj.telefone = Convert.ToString(reader["telefone"]);
                        obj.cpf = Convert.ToString(reader["cpf"]);
                        obj.email = Convert.ToString(reader["email"]);
                        obj.rg = Convert.ToString(reader["rg"]);
                        obj.cep = Convert.ToString(reader["cep"]);
                        obj.logradouro = Convert.ToString(reader["logradouro"]);
                        obj.complemento = Convert.ToString(reader["complemento"]);
                        obj.numero = Convert.ToString(reader["numero"]);
                        obj.bairro = Convert.ToString(reader["bairro"]);
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

        public string getCliente(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nome FROM cliente WHERE cliente_ID = @id AND Ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["nome"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(cliente_ID) FROM cliente";
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

        public override void Salvar(T obj)
        {
            dynamic cliente = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO cliente 
                        (nome, data_nascimento, telefone, contato, cpf, email, sexo, rg, 
                         cep, logradouro, numero, bairro, ativo, data_cadastro, data_ult_alt, apelido, estado, 
                         pais, condicao_pagamento, tipo_pessoa, complemento, CondPagamento_ID, cidade_id) 
                         VALUES 
                        (@nome, @data_nascimento, @telefone, @contato, @cpf, @email, @sexo, @rg, 
                         @cep, @logradouro, @numero, @bairro, @ativo, @data_cadastro, @data_ult_alt, @apelido, @estado, 
                         @pais, @condicao_pagamento, @tipo_pessoa, @complemento, @CondPagamento_ID, @cidade_id)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adiciona os parâmetros da consulta
                    command.Parameters.AddWithValue("@nome", cliente.nome ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento != DateTime.MinValue
                        ? cliente.data_nascimento
                        : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@telefone", cliente.telefone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@contato", cliente.contato ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@cpf", cliente.cpf ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@email", cliente.email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@sexo", cliente.sexo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@rg", cliente.rg ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@cep", cliente.cep ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@logradouro", cliente.logradouro ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@numero", cliente.numero ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@bairro", cliente.bairro ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ativo", cliente.ativo);
                    command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro != DateTime.MinValue
                        ? cliente.data_cadastro
                        : DateTime.Now);
                    command.Parameters.AddWithValue("@data_ult_alt", cliente.data_ult_alt != DateTime.MinValue
                        ? cliente.data_ult_alt
                        : DateTime.Now);
                    command.Parameters.AddWithValue("@apelido", cliente.apelido ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@estado", cliente.estado ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pais", cliente.pais ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@condicao_pagamento", cliente.condicao_pagamento ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@tipo_pessoa", cliente.tipo_pessoa ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@complemento", cliente.complemento ?? (object)DBNull.Value);

                    // Verifica a chave CondPagamento_ID para evitar conflitos de FK
                    if (cliente.CondPagamento_ID != 0) // Verifica se o valor é diferente de 0
                    {
                        // Valida se o CondPagamento_ID existe na tabela condicaoPagamento
                        string validarCondPagamentoQuery = "SELECT COUNT(1) FROM condicaoPagamento WHERE CondPagamento_ID = @CondPagamento_ID";
                        using (SqlCommand validarCommand = new SqlCommand(validarCondPagamentoQuery, connection))
                        {
                            validarCommand.Parameters.AddWithValue("@CondPagamento_ID", cliente.CondPagamento_ID);
                            connection.Open();
                            int exists = (int)validarCommand.ExecuteScalar();
                            connection.Close();

                            if (exists == 0)
                            {
                                throw new Exception($"O CondPagamento_ID '{cliente.CondPagamento_ID}' não existe na tabela condicaoPagamento.");
                            }
                        }
                        command.Parameters.AddWithValue("@CondPagamento_ID", cliente.CondPagamento_ID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CondPagamento_ID", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@cidade_id", cliente.cidade_id ?? (object)DBNull.Value);

                    // Executa o comando
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM cliente WHERE cliente_ID = @cliente_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("cliente_ID", id);

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
                        MessageBox.Show("Não é possível excluir o cliente, pois ele está associado em um cadastro.", "Erro ao deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dynamic cliente = obj;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE cliente SET nome = @nome, apelido = @apelido, data_nascimento = @data_nascimento, telefone = @telefone, " +
                    "cpf = @cpf, email = @email, rg = @rg, cep = @cep, logradouro = @logradouro, sexo = @sexo " +
                    "numero = @numero, bairro = @bairro, complemento = @complemento, cidade_id = @cidade_id, ativo = @ativo, " +
                    "data_cadastro = @data_cadastro, data_ult_alt = @data_ult_alt WHERE cliente_id = @cliente_id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nome", cliente.nome);
                command.Parameters.AddWithValue("@apelido", cliente.apelido);  // Campo atualizado
                command.Parameters.AddWithValue("@data_nascimento", cliente.data_nascimento);
                command.Parameters.AddWithValue("@telefone", cliente.telefone);
                command.Parameters.AddWithValue("@cpf", cliente.cpf);
                command.Parameters.AddWithValue("@email", cliente.email);
                command.Parameters.AddWithValue("@rg", cliente.rg);
                command.Parameters.AddWithValue("@sexo", cliente.sexo);
                command.Parameters.AddWithValue("@cep", cliente.cep);
                command.Parameters.AddWithValue("@logradouro", cliente.logradouro);
                command.Parameters.AddWithValue("@numero", cliente.numero);
                command.Parameters.AddWithValue("@bairro", cliente.bairro);
                command.Parameters.AddWithValue("@complemento", cliente.complemento);
                command.Parameters.AddWithValue("@cidade_id", cliente.cidade_id);
                command.Parameters.AddWithValue("@ativo", cliente.ativo);
                command.Parameters.AddWithValue("@data_cadastro", cliente.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", cliente.data_ult_alt);
                command.Parameters.AddWithValue("@cliente_id", cliente.cliente_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int cliente_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM cliente WHERE cliente_id = @cliente_id";
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
                        obj.apelido = reader["apelido"].ToString();  // Campo atualizado
                        obj.data_nascimento = DateTime.Parse(reader["data_nascimento"].ToString());
                        obj.telefone = reader["telefone"].ToString();
                        obj.contato = reader["contato"].ToString();
                        obj.cpf = reader["cpf"].ToString();
                        obj.email = reader["email"].ToString();
                        obj.rg = reader["rg"].ToString();
                        obj.cep = reader["cep"].ToString();
                        obj.cep = reader["sexo"].ToString();
                        obj.logradouro = reader["logradouro"].ToString();
                        obj.numero = reader["numero"].ToString();
                        obj.bairro = reader["bairro"].ToString();
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



        public List<string> GetCondPagById(int CondPagamento_ID)
        {
            List<string> condPagInfos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT condicaoPagamento
                     FROM condicaoPagamento
                      WHERE CondPagamento_ID = @CondPagamento_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CondPagamento_ID", CondPagamento_ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string condPagInfo = string.Format("Condição: {0}",
                            reader["condicaoPagamento"]);

                        condPagInfos.Add(condPagInfo);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter informações da Condição de Pagamento: " + ex.Message);
                }
            }
            return condPagInfos;
        }

    }
}
