using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class CondicaoPagamento
    {
        public int CondPagamento_ID { get; set; }
        public string condicaoPagamento { get; set; }
        public decimal desconto { get; set; }
        public decimal juros { get; set; }
        public decimal multa { get; set; }
        public bool Ativo { get; set; }
        public List<parcela> parcelas { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
    }
}
