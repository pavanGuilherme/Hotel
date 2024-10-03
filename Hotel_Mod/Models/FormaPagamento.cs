using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class FormaPagamento
    {
        public int FormaPagamento_ID { get; set; }
        public string formaPagamento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlt { get; set; }
    }
}
