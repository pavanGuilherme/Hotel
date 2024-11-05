using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Quarto
    {
        public int quarto_ID { get; set; }
        public int numero { get; set; }
        public int andar { get; set; }
        public string tipo { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public string status { get; set; }
        public int ocupacaoMax { get; set; }    
        public bool ativo { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
    }
}
