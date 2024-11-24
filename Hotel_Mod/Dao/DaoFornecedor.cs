using Hotel_Mod.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Dao
{
    public class DaoFornecedor<T> : Dao<T>
    {
        public DaoFornecedor() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(fornecedor_ID) FROM fornecedor";
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
            List<T> fornecedores = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM fornecedor" : "SELECT * FROM fornecedor WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        obj.fornecedor_razao_social = reader["fornecedor_razao_social"].ToString();
                        obj.cpf_cnpj = reader["cpf_cnpj"].ToString();
                        obj.Ativo = Convert.ToBoolean(reader["ativo"]);

                        fornecedores.Add(obj);
                    }
                }
            }

            return fornecedores;
        }
        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM fornecedor WHERE fornecedor_ID = @fornecedor_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fornecedor_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        obj.tipo_pessoa = Convert.ToBoolean(reader["tipo_pessoa"]);
                        obj.fornecedor_razao_social = reader["fornecedor_razao_social"].ToString();
                        obj.apelido_nome_fantasia = reader["apelido_nome_fantasia"].ToString();
                        obj.logradouro = reader["logradouro"].ToString();
                        obj.bairro = reader["bairro"].ToString();
                        obj.numero = Convert.ToInt32(reader["numero"]);
                        obj.cep = reader["cep"].ToString();
                        obj.complemento = reader["complemento"].ToString();
                        obj.sexo = reader["sexo"].ToString();
                        obj.email = reader["email"].ToString();
                        obj.telefone = reader["telefone"].ToString();
                        obj.celular = reader["celular"].ToString();
                        obj.nome_contato = reader["nome_contato"].ToString();
                        obj.data_nascimento = DateTime.Parse(reader["data_nascimento"].ToString());
                        obj.cpf_cnpj = reader["cpf_cnpj"].ToString();
                        obj.rg_ie = reader["rg_ie"].ToString();
                        obj.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        obj.cidade_ID = Convert.ToInt32(reader["cidade_ID"]);
                        obj.CondPagamento_ID = Convert.ToInt32(reader["CondPagamento_ID"]);
                        return obj;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }
        public List<string> GetCEPByIdCidade(int cidade_ID)
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
                    estado ON cidades.estado_ID = estads.estado_ID
                JOIN 
                    pais ON estados.pais_ID = paises.pais_ID
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

        public override void Salvar(T obj)
        {
            dynamic fornecedor = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Fornecedor (tipo_pessoa, fornecedor_razao_social, apelido_nome_fantasia, 
                                logradouro, bairro, numero, cep, complemento, email, telefone, celular, 
                                nome_contato, cpf_cnpj, rg_ie, data_cadastro, data_ult_alt, Ativo, cidade_id) 
                                VALUES (@tipo_pessoa, @fornecedor_razao_social, @apelido_nome_fantasia, 
                                @logradouro, @bairro, @numero, @cep, @complemento, @email, 
                                @telefone, @celular, @nome_contato, @cpf_cnpj, @rg_ie, 
                                @dataCadastro, @dataUltAlt, @Ativo, @cidade_id)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo_pessoa", fornecedor.tipo_pessoa);
                command.Parameters.AddWithValue("@fornecedor_razao_social", fornecedor.fornecedor_razao_social);
                command.Parameters.AddWithValue("@apelido_nome_fantasia", fornecedor.apelido_nome_fantasia);
                command.Parameters.AddWithValue("@logradouro", fornecedor.logradouro);
                command.Parameters.AddWithValue("@bairro", fornecedor.bairro);
                command.Parameters.AddWithValue("@numero", fornecedor.numero);
                command.Parameters.AddWithValue("@cep", fornecedor.cep);
                command.Parameters.AddWithValue("@complemento", fornecedor.complemento);
                command.Parameters.AddWithValue("@email", fornecedor.email);
                command.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                command.Parameters.AddWithValue("@celular", fornecedor.celular);
                command.Parameters.AddWithValue("@nome_contato", fornecedor.nome_contato);
                command.Parameters.AddWithValue("@cpf_cnpj", fornecedor.cpf_cnpj);
                command.Parameters.AddWithValue("@rg_ie", fornecedor.rg_ie);
                command.Parameters.AddWithValue("@dataCadastro", fornecedor.dataCadastro);
                command.Parameters.AddWithValue("@dataUltAlt", fornecedor.dataUltAlt);
                command.Parameters.AddWithValue("@Ativo", fornecedor.Ativo);
                command.Parameters.AddWithValue("@cidade_ID", fornecedor.cidade_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Fornecedor WHERE fornecedor_ID = @fornecedor_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fornecedor_ID", id);

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

        public override void alterar(T obj)
        {
            dynamic fornecedor = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Fornecedor SET 
                                tipo_pessoa = @tipo_pessoa, 
                                fornecedor_razao_social = @fornecedor_razao_social, 
                                apelido_nome_fantasia = @apelido_nome_fantasia, 
                                logradouro = @logradouro, 
                                bairro = @bairro, 
                                numero = @numero, 
                                cep = @cep, 
                                complemento = @complemento, 
                                email = @email, 
                                telefone = @telefone, 
                                celular = @celular, 
                                nome_contato = @nome_contato, 
                                cpf_cnpj = @cpf_cnpj, 
                                rg_ie = @rg_ie, 
                                dataCadastro = @dataCadastro, 
                                dataUltAlt = @dataUltAlt, 
                                Ativo = @Ativo, 
                                idCidade = @idCidade 
                                WHERE fornecedor_ID = @fornecedor_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tipo_pessoa", fornecedor.tipo_pessoa);
                command.Parameters.AddWithValue("@fornecedor_razao_social", fornecedor.fornecedor_razao_social);
                command.Parameters.AddWithValue("@apelido_nome_fantasia", fornecedor.apelido_nome_fantasia);
                command.Parameters.AddWithValue("@logradouro", fornecedor.logradouro);
                command.Parameters.AddWithValue("@bairro", fornecedor.bairro);
                command.Parameters.AddWithValue("@numero", fornecedor.numero);
                command.Parameters.AddWithValue("@cep", fornecedor.cep);
                command.Parameters.AddWithValue("@complemento", fornecedor.complemento);
                command.Parameters.AddWithValue("@email", fornecedor.email);
                command.Parameters.AddWithValue("@telefone", fornecedor.telefone);
                command.Parameters.AddWithValue("@celular", fornecedor.celular);
                command.Parameters.AddWithValue("@nome_contato", fornecedor.nome_contato);
                command.Parameters.AddWithValue("@cpf_cnpj", fornecedor.cpf_cnpj);
                command.Parameters.AddWithValue("@rg_ie", fornecedor.rg_ie);
                command.Parameters.AddWithValue("@dataCadastro", fornecedor.dataCadastro);
                command.Parameters.AddWithValue("@dataUltAlt", fornecedor.dataUltAlt);
                command.Parameters.AddWithValue("@Ativo", fornecedor.Ativo);
                command.Parameters.AddWithValue("@idCidade", fornecedor.idCidade);
                command.Parameters.AddWithValue("@fornecedor_ID", fornecedor.fornecedor_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
       
        
    }
}

