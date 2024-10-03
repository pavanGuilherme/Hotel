using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class nota_Compra
    {
        public int num_Nota { get; set; }
        public int modelo { get; set; }
        public int serie { get; set; }
        public int fornecedor_ID { get; set; }
        public DateTime data_emissao { get; set; }
        public DateTime data_chegada { get; set; }
        public bool tipo_frete { get; set; }
        public decimal valor_frete { get; set; }
        public decimal valor_seguro { get; set; }
        public decimal outras_despesas { get; set; }
        public decimal total_produtos { get; set; }
        public decimal total_pagar { get; set; }
        public int Cond_Pagamento_ID { get; set; }
        public string observacao { get; set; }
        public DateTime? data_cancelamento { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
    }
}
