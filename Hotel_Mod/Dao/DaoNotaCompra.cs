using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Mod.Class
{
    public class Daonota_compra<T> : Dao<nota_Compra>
    {
        public Daonota_compra() : base()
        {
        }

        public int GetUltimoCodigo()
        {
            int proximoCodigo = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(num_Nota) FROM nota_compra";
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

        public override List<nota_Compra> GetAll(bool incluiInativos)
        {
            List<nota_Compra> notasCompra = new List<nota_Compra>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM nota_compra" : "SELECT * FROM nota_compra WHERE data_cancelamento IS NULL";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nota_Compra nota_compra = new nota_Compra
                        {
                            num_Nota = Convert.ToInt32(reader["num_Nota"]),
                            modelo = Convert.ToInt32(reader["modelo"]),
                            serie = Convert.ToInt32(reader["serie"]),
                            fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]),
                            data_emissao = Convert.ToDateTime(reader["data_emissao"]),
                            data_chegada = Convert.ToDateTime(reader["data_chegada"]),
                            tipo_frete = Convert.ToBoolean(reader["tipo_frete"]),
                            valor_frete = Convert.ToDecimal(reader["valor_frete"]),
                            valor_seguro = Convert.ToDecimal(reader["valor_seguro"]),
                            outras_despesas = Convert.ToDecimal(reader["outras_despesas"]),
                            total_produtos = Convert.ToDecimal(reader["total_produtos"]),
                            total_pagar = Convert.ToDecimal(reader["total_pagar"]),
                            Cond_Pagamento_ID = Convert.ToInt32(reader["Cond_Pagamento_ID"]),
                            observacao = reader["observacao"]?.ToString(),
                            data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null,
                            data_cadastro = Convert.ToDateTime(reader["data_cadastro"]),
                            data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"])
                        };

                        notasCompra.Add(nota_compra);
                    }
                }
            }
            return notasCompra;
        }

        public override void Salvar(nota_Compra obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO nota_compra (modelo, serie, fornecedor_ID, data_emissao, data_chegada, tipo_frete, valor_frete, 
                                                        valor_seguro, outras_despesas, total_produtos, total_pagar, Cond_Pagamento_ID, observacao, 
                                                        data_cancelamento, data_cadastro, data_ult_alt) 
                                 VALUES (@modelo, @serie, @fornecedor_ID, @data_emissao, @data_chegada, @tipo_frete, @valor_frete, 
                                         @valor_seguro, @outras_despesas, @total_produtos, @total_pagar, @Cond_Pagamento_ID, @observacao, 
                                         @data_cancelamento, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@modelo", obj.modelo);
                command.Parameters.AddWithValue("@serie", obj.serie);
                command.Parameters.AddWithValue("@fornecedor_ID", obj.fornecedor_ID);
                command.Parameters.AddWithValue("@data_emissao", obj.data_emissao);
                command.Parameters.AddWithValue("@data_chegada", obj.data_chegada);
                command.Parameters.AddWithValue("@tipo_frete", obj.tipo_frete);
                command.Parameters.AddWithValue("@valor_frete", obj.valor_frete);
                command.Parameters.AddWithValue("@valor_seguro", obj.valor_seguro);
                command.Parameters.AddWithValue("@outras_despesas", obj.outras_despesas);
                command.Parameters.AddWithValue("@total_produtos", obj.total_produtos);
                command.Parameters.AddWithValue("@total_pagar", obj.total_pagar);
                command.Parameters.AddWithValue("@Cond_Pagamento_ID", obj.Cond_Pagamento_ID);
                command.Parameters.AddWithValue("@observacao", obj.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", obj.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cadastro", obj.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override void excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM nota_compra WHERE num_Nota = @num_Nota";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@num_Nota", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public nota_Compra GetNotaById(int numero,  int serie, int fornecedor_ID)
        {
            nota_Compra nota_compra = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM nota_compra WHERE num_Nota = @num_Nota  AND serie = @serie AND fornecedor_ID = @fornecedor_ID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@num_Nota", numero);
          
                cmd.Parameters.AddWithValue("@serie", serie);
                cmd.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nota_compra = new nota_Compra
                        {
                            num_Nota = Convert.ToInt32(reader["num_Nota"]),
                            modelo = Convert.ToInt32(reader["modelo"]),
                            serie = Convert.ToInt32(reader["serie"]),
                            fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]),
                            data_emissao = Convert.ToDateTime(reader["data_emissao"]),
                            data_chegada = Convert.ToDateTime(reader["data_chegada"]),
                            tipo_frete = Convert.ToBoolean(reader["tipo_frete"]),
                            valor_frete = Convert.ToDecimal(reader["valor_frete"]),
                            valor_seguro = Convert.ToDecimal(reader["valor_seguro"]),
                            outras_despesas = Convert.ToDecimal(reader["outras_despesas"]),
                            total_produtos = Convert.ToDecimal(reader["total_produtos"]),
                            total_pagar = Convert.ToDecimal(reader["total_pagar"]),
                            Cond_Pagamento_ID = Convert.ToInt32(reader["Cond_Pagamento_ID"]),
                            observacao = reader["observacao"]?.ToString(),
                            data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null,
                            data_cadastro = Convert.ToDateTime(reader["data_cadastro"]),
                            data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"])
                        };
                    }
                }
            }

            // Retorna null caso nenhuma nota seja encontrada
            return nota_compra;
        }


        public override void alterar(nota_Compra obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE nota_compra 
                                 SET modelo = @modelo, serie = @serie, fornecedor_ID = @fornecedor_ID, 
                                     data_emissao = @data_emissao, data_chegada = @data_chegada, tipo_frete = @tipo_frete, 
                                     valor_frete = @valor_frete, valor_seguro = @valor_seguro, outras_despesas = @outras_despesas, 
                                     total_produtos = @total_produtos, total_pagar = @total_pagar, Cond_Pagamento_ID = @Cond_Pagamento_ID, 
                                     observacao = @observacao, data_cancelamento = @data_cancelamento, data_ult_alt = @data_ult_alt 
                                 WHERE num_Nota = @num_Nota";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@num_Nota", obj.num_Nota);
                command.Parameters.AddWithValue("@modelo", obj.modelo);
                command.Parameters.AddWithValue("@serie", obj.serie);
                command.Parameters.AddWithValue("@fornecedor_ID", obj.fornecedor_ID);
                command.Parameters.AddWithValue("@data_emissao", obj.data_emissao);
                command.Parameters.AddWithValue("@data_chegada", obj.data_chegada);
                command.Parameters.AddWithValue("@tipo_frete", obj.tipo_frete);
                command.Parameters.AddWithValue("@valor_frete", obj.valor_frete);
                command.Parameters.AddWithValue("@valor_seguro", obj.valor_seguro);
                command.Parameters.AddWithValue("@outras_despesas", obj.outras_despesas);
                command.Parameters.AddWithValue("@total_produtos", obj.total_produtos);
                command.Parameters.AddWithValue("@total_pagar", obj.total_pagar);
                command.Parameters.AddWithValue("@Cond_Pagamento_ID", obj.Cond_Pagamento_ID);
                command.Parameters.AddWithValue("@observacao", obj.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", obj.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_ult_alt", obj.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AtualizarProdutosnota_compra(nota_Compra obj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    foreach (var produto in obj.Produtos)
                    {
                        string queryUpdateProduto = @"UPDATE produto SET 
                                    saldo = saldo + @quantidadeProduto,
                                    custoMedio = @custoMedio,
                                    dataUltCompra = @dataUltCompra,
                                    precoUltCompra = @precoUltCompra
                                    WHERE idProduto = @idProduto";
                        SqlCommand cmdUpdateProduto = new SqlCommand(queryUpdateProduto, conn, transaction);

                        cmdUpdateProduto.Parameters.AddWithValue("@quantidadeProduto", produto.quantidade_Produto);
                        cmdUpdateProduto.Parameters.AddWithValue("@custoMedio", produto.custoMedio);
                        cmdUpdateProduto.Parameters.AddWithValue("@dataUltCompra", obj.data_emissao);
                        cmdUpdateProduto.Parameters.AddWithValue("@precoUltCompra", produto.precoProduto);
                        cmdUpdateProduto.Parameters.AddWithValue("@idProduto", produto.produto_ID);

                        cmdUpdateProduto.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Produto GetProdutoById(int idProduto)
        {
            Produto produto = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT produto, unidade FROM produto WHERE idProduto = @idProduto";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@produto_ID", idProduto);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        produto = new Produto
                        {
                            produto_ID = idProduto,
                            nome_produto = reader["produto"].ToString(),
                            unidade = reader["unidade"].ToString()
                        };
                    }
                }
            }
            return produto;
        }

        public override nota_Compra GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM nota_compra WHERE num_Nota = @num_Nota";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@num_Nota", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new nota_Compra
                        {
                            num_Nota = Convert.ToInt32(reader["num_Nota"]),
                            modelo = Convert.ToInt32(reader["modelo"]),
                            serie = Convert.ToInt32(reader["serie"]),
                            fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]),
                            data_emissao = Convert.ToDateTime(reader["data_emissao"]),
                            data_chegada = Convert.ToDateTime(reader["data_chegada"]),
                            tipo_frete = Convert.ToBoolean(reader["tipo_frete"]),
                            valor_frete = Convert.ToDecimal(reader["valor_frete"]),
                            valor_seguro = Convert.ToDecimal(reader["valor_seguro"]),
                            outras_despesas = Convert.ToDecimal(reader["outras_despesas"]),
                            total_produtos = Convert.ToDecimal(reader["total_produtos"]),
                            total_pagar = Convert.ToDecimal(reader["total_pagar"]),
                            Cond_Pagamento_ID = Convert.ToInt32(reader["Cond_Pagamento_ID"]),
                            observacao = reader["observacao"]?.ToString(),
                            data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null,
                            data_cadastro = Convert.ToDateTime(reader["data_cadastro"]),
                            data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public bool ExisteNota(int num_Nota, string serie, int fornecedor_ID) //verificar se a nota existe no banco antes de liberar os campos
        {
            string query = "SELECT COUNT(*) FROM notaCompra WHERE num_Nota = @num_Nota  AND serie = @serie AND fornecedor_ID = @fornecedor_ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num_Nota", num_Nota);
                cmd.Parameters.AddWithValue("@serie", serie);
                cmd.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public bool Cancelarnota_compra(int num_Nota, int serie, int fornecedor_ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //add dataCancelamento na nota de compra
                        string queryCancelarNota = @"
                    UPDATE nota_compra
                    SET data_cancelamento = @data_cancelamento
                    WHERE num_Nota = @num_Nota AND modelo = @modelo AND serie = @serie AND fornecedor_ID = @fornecedor_ID";

                        using (SqlCommand cmd = new SqlCommand(queryCancelarNota, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@data_cancelamento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@num_Nota", num_Nota);
                       
                            cmd.Parameters.AddWithValue("@serie", serie);
                            cmd.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);
                            cmd.ExecuteNonQuery();
                        }

                        //puxa os produtos da nota para atualizar o estoque
                        string queryProdutosNota = @"
                    SELECT idProduto, quantidadeProduto
                    FROM nota_compra_Produto
                    WHERE num_Nota = @num_Nota AND modelo = @modelo AND serie = @serie AND fornecedor_ID = @fornecedor_ID";

                        List<(int idProduto, int quantidadeProduto)> produtos = new List<(int, int)>();

                        using (SqlCommand cmd = new SqlCommand(queryProdutosNota, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@num_Nota", num_Nota);
          
                            cmd.Parameters.AddWithValue("@serie", serie);
                            cmd.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int idProduto = reader.GetInt32(reader.GetOrdinal("idProduto"));
                                    int quantidadeProduto = reader.GetInt32(reader.GetOrdinal("quantidadeProduto"));
                                    produtos.Add((idProduto, quantidadeProduto));
                                }
                            }
                        }

                        //att o estoque
                        foreach (var produto in produtos)
                        {
                            //tenta encontrar uma nota de compra anterior válida (sem dataCancelamento) para atualizar os custos/preço/data
                            string queryNotaAnterior = @"
                        SELECT TOP 1 nc.dataChegada, ncp.precoProduto, ncp.custoMedio
                        FROM nota_compra nc
                        JOIN nota_compra_Produto ncp ON nc.num_Nota = ncp.num_Nota AND nc.modelo = ncp.modelo AND nc.serie = ncp.serie AND nc.fornecedor_ID = ncp.fornecedor_ID
                        WHERE ncp.idProduto = @idProduto AND nc.dataCancelamento IS NULL
                        ORDER BY nc.dataChegada DESC";

                            DateTime? dataUltCompra = null;
                            decimal precoUltCompra = 0;
                            decimal custoMedio = 0;
                            bool notaAnteriorEncontrada = false;

                            using (SqlCommand cmd = new SqlCommand(queryNotaAnterior, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idProduto", produto.idProduto);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        dataUltCompra = reader.GetDateTime(reader.GetOrdinal("dataChegada"));
                                        precoUltCompra = reader.GetDecimal(reader.GetOrdinal("precoProduto"));
                                        custoMedio = reader.GetDecimal(reader.GetOrdinal("custoMedio"));
                                        notaAnteriorEncontrada = true;
                                    }
                                }
                            }

                            //att o saldo do produto e, se houver uma nota válida anterior, atualiza os atributos do produto do produto
                            string queryAtualizarEstoque = @"
                        UPDATE produto
                        SET saldo = saldo - @quantidadeProduto, custoMedio = @custoMedio, dataUltCompra = @dataUltCompra, precoUltCompra = @precoUltCompra
                        WHERE idProduto = @idProduto";

                            using (SqlCommand cmd = new SqlCommand(queryAtualizarEstoque, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@quantidadeProduto", produto.quantidadeProduto);
                                cmd.Parameters.AddWithValue("@idProduto", produto.idProduto);
                                cmd.Parameters.AddWithValue("@custoMedio", notaAnteriorEncontrada ? custoMedio : 0);
                                cmd.Parameters.AddWithValue("@dataUltCompra", (object)dataUltCompra ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@precoUltCompra", notaAnteriorEncontrada ? precoUltCompra : 0);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //cancela as contas a pagar associadas a nota
                        string queryCancelarContasPagar = @"
                    UPDATE contasPagar
                    SET dataCancelamento = @dataCancelamento
                    WHERE num_Nota = @num_Nota AND modelo = @modelo AND serie = @serie AND fornecedor_ID = @fornecedor_ID";

                        using (SqlCommand cmd = new SqlCommand(queryCancelarContasPagar, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@dataCancelamento", DateTime.Now);
                            cmd.Parameters.AddWithValue("@num_Nota", num_Nota);
                            cmd.Parameters.AddWithValue("@serie", serie);
                            cmd.Parameters.AddWithValue("@fornecedor_ID", fornecedor_ID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao cancelar a nota de compra: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com o banco de dados: " + ex.Message);
            }
        }
    }
}
