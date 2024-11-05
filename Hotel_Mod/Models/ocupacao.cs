using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{

    public class Ocupacao
    {
        public int ocupacao_ID { get; set; }
        public int quarto_ID { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int cliente_ID { get; set; }
        public string ocupacao { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public bool ativo { get; set; }
    }
}

