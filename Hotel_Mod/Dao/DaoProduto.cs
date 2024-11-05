using Hotel_Mod.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Mod.Dao
{
    public class DaoProduto<T> : Dao<T>
    {
        public DaoProduto() : base() { }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> produtos = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM produtos" : "SELECT * FROM produtos WHERE ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic produto = Activator.CreateInstance(typeof(T));
                        produto.produto_ID = Convert.ToInt32(reader["produto_ID"]);
                        produto.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        produto.nome_fornecedor = reader["nome_fornecedor"]?.ToString();
                        produto.nome_produto = reader["nome_produto"].ToString();
                        produto.unidade = reader["unidade"].ToString();
                        produto.marca = reader["marca"].ToString();
                        produto.saldo = Convert.ToDecimal(reader["saldo"]);
                        produto.custo_medio = reader["custo_medio"] != DBNull.Value ? Convert.ToDecimal(reader["custo_medio"]) : 0;
                        produto.preco_medio = reader["preco_medio"] != DBNull.Value ? Convert.ToDecimal(reader["preco_medio"]) : 0;
                        produto.preco_ultima_compra = reader["preco_ultima_compra"] != DBNull.Value ? Convert.ToDecimal(reader["preco_ultima_compra"]) : 0;
                        produto.data_ultima_compra = reader["data_ultima_compra"] != DBNull.Value ? Convert.ToDateTime(reader["data_ultima_compra"]) : (DateTime?)null;
                        produto.observacao = reader["observacao"]?.ToString();
                        produto.ativo = Convert.ToBoolean(reader["ativo"]);
                        produto.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        produto.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        produtos.Add(produto);
                    }
                }
            }

            return produtos;
        }

        public override void Salvar(T obj)
        {
            dynamic produto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO produtos (fornecedor_ID, nome_fornecedor, nome_produto, unidade, marca, saldo, custo_medio, preco_medio, 
                                  preco_ultima_compra, data_ultima_compra, observacao, ativo, data_cadastro, data_ult_alt) 

            VALUES (@fornecedor_ID, @nome_fornecedor, @nome_produto, @unidade, @marca, @saldo, @custo_medio, @preco_medio, 
                    @preco_ultima_compra, @data_ultima_compra, @observacao, @ativo, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fornecedor_ID", produto.fornecedor_ID);
                command.Parameters.AddWithValue("@nome_fornecedor", produto.nome_fornecedor ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@nome_produto", produto.nome_produto);
                command.Parameters.AddWithValue("@unidade", produto.unidade);
                command.Parameters.AddWithValue("@marca", produto.marca);
                command.Parameters.AddWithValue("@saldo", produto.saldo);
                command.Parameters.AddWithValue("@custo_medio", produto.custo_medio);
                command.Parameters.AddWithValue("@preco_medio", produto.preco_medio);
                command.Parameters.AddWithValue("@preco_ultima_compra", produto.preco_ultima_compra);
                command.Parameters.AddWithValue("@data_ultima_compra", produto.data_ultima_compra ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", produto.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ativo", produto.ativo);
                command.Parameters.AddWithValue("@data_cadastro", produto.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", produto.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetFornecedorById(int fornecedor_ID)
        {
            List<string> fornecedorInfos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT fornecedor_ID, fornecedor_razao_social
            FROM fornecedores
            WHERE fornecedor_ID = @fornecedor_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string fornecedorInfo = string.Format("ID: {0}, Razão Social: {1}",
                            reader["fornecedor_ID"],
                            reader["fornecedor_razao_social"]);

                        fornecedorInfos.Add(fornecedorInfo);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao obter informações do fornecedor: " + ex.Message);
                }
            }
            return fornecedorInfos;
        }


        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM produtos WHERE produto_ID = @produto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@produto_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic produto = Activator.CreateInstance(typeof(T));
                        produto.produto_ID = Convert.ToInt32(reader["produto_ID"]);
                        produto.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        produto.nome_fornecedor = reader["nome_fornecedor"]?.ToString();
                        produto.nome_produto = reader["nome_produto"].ToString();
                        produto.unidade = reader["unidade"].ToString();
                        produto.marca = reader["marca"].ToString();
                        produto.saldo = Convert.ToDecimal(reader["saldo"]);
                        produto.custo_medio = reader["custo_medio"] != DBNull.Value ? Convert.ToDecimal(reader["custo_medio"]) : (decimal?)null;
                        produto.preco_medio = reader["preco_medio"] != DBNull.Value ? Convert.ToDecimal(reader["preco_medio"]) : (decimal?)null;
                        produto.preco_ultima_compra = reader["preco_ultima_compra"] != DBNull.Value ? Convert.ToDecimal(reader["preco_ultima_compra"]) : (decimal?)null;
                        produto.data_ultima_compra = reader["data_ultima_compra"] != DBNull.Value ? Convert.ToDateTime(reader["data_ultima_compra"]) : (DateTime?)null;
                        produto.observacao = reader["observacao"]?.ToString();
                        produto.ativo = Convert.ToBoolean(reader["ativo"]);
                        produto.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        produto.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        return produto;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }


        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM produtos WHERE produto_ID = @produto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@produto_ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(produto_ID) FROM produtos";
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


        public (string Produto, string Unidade, decimal PrecoVenda)? getProduto(int idProduto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nome_produto, unidade, preco_venda FROM produto WHERE produto_ID = @idProduto AND Ativo = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idProduto", idProduto);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string produto = reader["nome_produto"].ToString();
                        string unidade = reader["unidade"].ToString();
                        decimal precoVenda = Convert.ToDecimal(reader["preco_venda"]);

                        return (produto, unidade, precoVenda);
                    }
                }
            }

            return null;
        }

        public override void alterar(T obj)
        {
            dynamic produto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE produtos SET 
                        produto = @produto, 
                        unidade = @unidade, 
                        saldo = @saldo, 
                        custo_medio = @custo_medio, 
                        preco_venda = @preco_venda, 
                        preco_ult_compra = @preco_ult_compra, 
                        data_ult_compra = @data_ult_compra, 
                        observacao = @observacao, 
                        fornecedor_ID = @fornecedor_ID, 
                        data_ult_alt = @data_ult_alt, 
                        ativo = @ativo 
                    WHERE produto_ID = @produto_ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@produto_ID", produto.produto_ID);
                command.Parameters.AddWithValue("@produto", produto.produto);
                command.Parameters.AddWithValue("@unidade", produto.unidade);
                command.Parameters.AddWithValue("@saldo", produto.saldo);
                command.Parameters.AddWithValue("@custo_medio", produto.custo_medio);
                command.Parameters.AddWithValue("@preco_venda", produto.preco_venda);
                command.Parameters.AddWithValue("@preco_ult_compra", produto.preco_ult_compra);
                command.Parameters.AddWithValue("@data_ult_compra", produto.data_ult_compra ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@observacao", produto.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fornecedor_ID", produto.fornecedor_ID);
                command.Parameters.AddWithValue("@data_ult_alt", produto.data_ult_alt);
                command.Parameters.AddWithValue("@ativo", produto.ativo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
