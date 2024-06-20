using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{
    public class Pais
    {
        public  int pais_ID { get; set; } 
        public  string pais { get; set; }
        public  string sigla { get; set; }
        public  string ddi { get; set; }
        public  bool ativo { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }

    }
}
