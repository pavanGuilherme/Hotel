using Hotel_Mod.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Dao
{
    public class DaoProduto<T> : Dao<T>
    {
        public DaoProduto() : base()
        {
        }

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
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.produto_ID = Convert.ToInt32(reader["produto_ID"]);
                        obj.produto = reader["produto"].ToString();
                        obj.unidade = reader["unidade"].ToString();
                        obj.saldo = Convert.ToInt32(reader["saldo"]);
                        obj.custo_medio = Convert.ToDecimal(reader["custo_medio"]);
                        obj.preco_venda = Convert.ToDecimal(reader["preco_venda"]);
                        obj.preco_ult_compra = Convert.ToDecimal(reader["preco_ult_compra"]);
                        obj.data_ult_compra = Convert.ToDateTime(reader["data_ult_compra"]);
                        obj.observacao = reader["observacao"].ToString();
                        obj.idFornecedor = Convert.ToInt32(reader["idFornecedor"]);
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        produtos.Add(obj);
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
                string query = @"INSERT INTO produtos (produto, unidade, saldo, custo_medio, preco_venda, 
                                preco_ult_compra, data_ult_compra, observacao, idFornecedor, 
                                data_cadastro, data_ult_alt, ativo) 
                                VALUES (@produto, @unidade, @saldo, @custo_medio, @preco_venda, 
                                @preco_ult_compra, @data_ult_compra, @observacao, @idFornecedor, 
                                @data_cadastro, @data_ult_alt, @ativo)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@produto", produto.produto);
                command.Parameters.AddWithValue("@unidade", produto.unidade);
                command.Parameters.AddWithValue("@saldo", produto.saldo);
                command.Parameters.AddWithValue("@custo_medio", produto.custo_medio);
                command.Parameters.AddWithValue("@preco_venda", produto.preco_venda);
                command.Parameters.AddWithValue("@preco_ult_compra", produto.preco_ult_compra);
                command.Parameters.AddWithValue("@data_ult_compra", produto.data_ult_compra);
                command.Parameters.AddWithValue("@observacao", produto.observacao);
                command.Parameters.AddWithValue("@idFornecedor", produto.idFornecedor);
                command.Parameters.AddWithValue("@data_cadastro", produto.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", produto.data_ult_alt);
                command.Parameters.AddWithValue("@ativo", produto.ativo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Produto WHERE produto_ID = @produto_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@produto_ID", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.produto_ID = Convert.ToInt32(reader["produto_ID"]);
                        obj.produto = reader["produto"].ToString();
                        obj.unidade = reader["unidade"].ToString();
                        obj.quantidade = Convert.ToInt32(reader["quantidade"]);
                        obj.saldo = Convert.ToDecimal(reader["saldo"]);
                        obj.custo_medio = Convert.ToDecimal(reader["custo_medio"]);
                        obj.preco_venda = Convert.ToDecimal(reader["preco_venda"]);
                        obj.preco_ult_compra = Convert.ToDecimal(reader["preco_ult_compra"]);
                        obj.data_ult_compra = DateTime.Parse(reader["data_ult_compra"].ToString());
                        obj.observacao = reader["observacao"].ToString();
                        obj.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        obj.data_cadastro = DateTime.Parse(reader["data_cadastro"].ToString());
                        obj.data_ult_alt = DateTime.Parse(reader["data_ult_alt"].ToString());
                        obj.ativo = Convert.ToBoolean(reader["ativo"]);
                        return obj;
                    }
                    else
                    {
                        return default(T); // retorna default se o produto não for encontrado
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

        public override void alterar(T obj)
        {
            dynamic produto = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE produtos SET 
                                produto = @produto, 
                                unidade = @unidade, 
                                saldo = @saldo, 
                                custo_medio = @custo_medio, 
                                preco_venda = @preco_venda, 
                                preco_ult_compra = @preco_ult_compra, 
                                data_ult_compra = @data_ult_compra, 
                                observacao = @observacao, 
                                idFornecedor = @idFornecedor, 
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
                command.Parameters.AddWithValue("@data_ult_compra", produto.data_ult_compra);
                command.Parameters.AddWithValue("@observacao", produto.observacao);
                command.Parameters.AddWithValue("@idFornecedor", produto.idFornecedor);
                command.Parameters.AddWithValue("@data_ult_alt", produto.data_ult_alt);
                command.Parameters.AddWithValue("@ativo", produto.ativo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

     
    }
}
