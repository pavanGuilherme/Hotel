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
        public string produto { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; } 
        public decimal saldo { get; set; }
        public decimal custo_medio { get; set; }
        public decimal preco_venda { get; set; }
        public decimal preco_ult_compra { get; set; }
        public DateTime data_ult_compra { get; set; }
        public string observacao { get; set; }
        public int fornecedor_ID { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public bool ativo { get; set; }
    }
}
