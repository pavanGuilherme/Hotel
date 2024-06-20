using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Class
{
    public class Estado
    {
        public  int estado_ID { get; set; }
        public  string estado{ get; set; }
        public  string uf { get; set; }
        public  bool ativo { get; set; }
        public int pais_ID { get; set; }
        public  DateTime data_cadastro { get; set; }
        public  DateTime data_ult_alt { get; set; }


    }
}
