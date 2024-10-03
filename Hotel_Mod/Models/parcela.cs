using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class parcela
    {
        public int parcela_ID { get; set; }
        public int numeroParcela { get; set; }
        public int dias { get; set; }
        public decimal porcentagem { get; set; }
        public int CondPagamento_ID { get; set; }
        public int FormaPagamento_ID { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public bool Ativo { get; set; }
    }
}
