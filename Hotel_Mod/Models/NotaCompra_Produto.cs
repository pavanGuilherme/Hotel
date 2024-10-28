using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class NotaCompra_Produto
    {
        public int numNota { get; set; }
        public int modelo { get; set; }
        public int serie { get; set; }
        public int fornecedor_ID { get; set; }
        public int produto_ID { get; set; }
        public decimal precoProduto { get; set; }
        public int quantidade_Produto { get; set; }
        public decimal custoMedio { get; set; }
        public decimal? rateio { get; set; }
    }
}
