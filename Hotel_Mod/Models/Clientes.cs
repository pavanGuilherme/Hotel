using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Clientes
    {

        public int cliente_ID { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string rg { get; set; }
        public bool tipo_pcd { get; set; }
        public bool estrangeriro { get; set; }
        public string profissao { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public int cidade_ID { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public bool ativo { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
    }
}


