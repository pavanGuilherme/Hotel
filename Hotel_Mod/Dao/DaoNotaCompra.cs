using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Mod.Class
{
    public class DaoNotaCompra<T> : Dao<T>
    {
        public DaoNotaCompra() : base()
        {
        }

        public override List<T> GetAll(bool incluiInativos)
        {
            List<T> notasCompra = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = incluiInativos ? "SELECT * FROM nota_compra" : "SELECT * FROM nota_compra WHERE data_cancelamento IS NULL";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.num_Nota = Convert.ToInt32(reader["num_Nota"]);
                        obj.modelo = Convert.ToInt32(reader["modelo"]);
                        obj.serie = Convert.ToInt32(reader["serie"]);
                        obj.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        obj.data_emissao = Convert.ToDateTime(reader["data_emissao"]);
                        obj.data_chegada = Convert.ToDateTime(reader["data_chegada"]);
                        obj.tipo_frete = Convert.ToBoolean(reader["tipo_frete"]);
                        obj.valor_frete = Convert.ToDecimal(reader["valor_frete"]);
                        obj.valor_seguro = Convert.ToDecimal(reader["valor_seguro"]);
                        obj.outras_despesas = Convert.ToDecimal(reader["outras_despesas"]);
                        obj.total_produtos = Convert.ToDecimal(reader["total_produtos"]);
                        obj.total_pagar = Convert.ToDecimal(reader["total_pagar"]);
                        obj.Cond_Pagamento_ID = Convert.ToInt32(reader["Cond_Pagamento_ID"]);
                        obj.observacao = reader["observacao"]?.ToString();
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null;
                        obj.data_cadastro = Convert.ToDateTime(reader["data_cadastro"]);
                        obj.data_ult_alt = Convert.ToDateTime(reader["data_ult_alt"]);

                        notasCompra.Add(obj);
                    }
                }
            }
            return notasCompra;
        }

        public override void Salvar(T obj)
        {
            dynamic nota = obj;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO nota_compra (modelo, serie, fornecedor_ID, data_emissao, data_chegada, tipo_frete, valor_frete, 
                                                        valor_seguro, outras_despesas, total_produtos, total_pagar, Cond_Pagamento_ID, observacao, 
                                                        data_cancelamento, data_cadastro, data_ult_alt) 
                                 VALUES (@modelo, @serie, @fornecedor_ID, @data_emissao, @data_chegada, @tipo_frete, @valor_frete, 
                                         @valor_seguro, @outras_despesas, @total_produtos, @total_pagar, @Cond_Pagamento_ID, @observacao, 
                                         @data_cancelamento, @data_cadastro, @data_ult_alt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@modelo", nota.modelo);
                command.Parameters.AddWithValue("@serie", nota.serie);
                command.Parameters.AddWithValue("@fornecedor_ID", nota.fornecedor_ID);
                command.Parameters.AddWithValue("@data_emissao", nota.data_emissao);
                command.Parameters.AddWithValue("@data_chegada", nota.data_chegada);
                command.Parameters.AddWithValue("@tipo_frete", nota.tipo_frete);
                command.Parameters.AddWithValue("@valor_frete", nota.valor_frete);
                command.Parameters.AddWithValue("@valor_seguro", nota.valor_seguro);
                command.Parameters.AddWithValue("@outras_despesas", nota.outras_despesas);
                command.Parameters.AddWithValue("@total_produtos", nota.total_produtos);
                command.Parameters.AddWithValue("@total_pagar", nota.total_pagar);
                command.Parameters.AddWithValue("@Cond_Pagamento_ID", nota.Cond_Pagamento_ID);
                command.Parameters.AddWithValue("@observacao", nota.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", nota.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cadastro", nota.data_cadastro);
                command.Parameters.AddWithValue("@data_ult_alt", nota.data_ult_alt);

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

        public override void alterar(T obj)
        {
            dynamic nota = obj;

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

                command.Parameters.AddWithValue("@num_Nota", nota.num_Nota);
                command.Parameters.AddWithValue("@modelo", nota.modelo);
                command.Parameters.AddWithValue("@serie", nota.serie);
                command.Parameters.AddWithValue("@fornecedor_ID", nota.fornecedor_ID);
                command.Parameters.AddWithValue("@data_emissao", nota.data_emissao);
                command.Parameters.AddWithValue("@data_chegada", nota.data_chegada);
                command.Parameters.AddWithValue("@tipo_frete", nota.tipo_frete);
                command.Parameters.AddWithValue("@valor_frete", nota.valor_frete);
                command.Parameters.AddWithValue("@valor_seguro", nota.valor_seguro);
                command.Parameters.AddWithValue("@outras_despesas", nota.outras_despesas);
                command.Parameters.AddWithValue("@total_produtos", nota.total_produtos);
                command.Parameters.AddWithValue("@total_pagar", nota.total_pagar);
                command.Parameters.AddWithValue("@Cond_Pagamento_ID", nota.Cond_Pagamento_ID);
                command.Parameters.AddWithValue("@observacao", nota.observacao ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_cancelamento", nota.data_cancelamento ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@data_ult_alt", nota.data_ult_alt);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public override T GetById(int id)
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
                        dynamic obj = Activator.CreateInstance(typeof(T));
                        obj.num_Nota = Convert.ToInt32(reader["num_Nota"]);
                        obj.modelo = Convert.ToInt32(reader["modelo"]);
                        obj.serie = Convert.ToInt32(reader["serie"]);
                        obj.fornecedor_ID = Convert.ToInt32(reader["fornecedor_ID"]);
                        obj.data_emissao = Convert.ToDateTime(reader["data_emissao"]);
                        obj.data_chegada = Convert.ToDateTime(reader["data_chegada"]);
                        obj.tipo_frete = Convert.ToBoolean(reader["tipo_frete"]);
                        obj.valor_frete = Convert.ToDecimal(reader["valor_frete"]);
                        obj.valor_seguro = Convert.ToDecimal(reader["valor_seguro"]);
                        obj.outras_despesas = Convert.ToDecimal(reader["outras_despesas"]);
                        obj.total_produtos = Convert.ToDecimal(reader["total_produtos"]);
                        obj.total_pagar = Convert.ToDecimal(reader["total_pagar"]);
                        obj.Cond_Pagamento_ID = Convert.ToInt32(reader["Cond_Pagamento_ID"]);
                        obj.observacao = reader["observacao"]?.ToString();
                        obj.data_cancelamento = reader["data_cancelamento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["data_cancelamento"]) : null;
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
    }
}
