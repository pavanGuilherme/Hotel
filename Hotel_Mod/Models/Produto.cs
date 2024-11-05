using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Produto
    {
        public int produto_ID { get; set; }
        public int fornecedor_ID { get; set; }
        public string nome_fornecedor { get; set; }
        public string nome_produto { get; set; }
        public string unidade { get; set; }
        public string marca { get; set; }
        public decimal saldo { get; set; }
        public decimal? custo_medio { get; set; } // Nullable
        public decimal? preco_medio { get; set; } // Nullable
        public decimal? preco_ultima_compra { get; set; } // Nullable
        public DateTime? data_ultima_compra { get; set; } // Nullable
        public string observacao { get; set; }
        public bool ativo { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
    }
}
