using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{
    public class Cidade
    {
        public  int cidade_ID { get; set; }
        public  string cidade{ get; set; }
        public string ddd { get; set; } 
        public int estado_ID { get; set; }
        public  DateTime data_cadastro {  get; set; }
        public  DateTime data_ult_alt { get; set; }
        public  bool ativo { get; set; }
    }
}
