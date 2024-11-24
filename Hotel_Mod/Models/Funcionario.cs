using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Funcionario
    {
        public int funcionario_ID { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }
        public string complemento { get; set; }
        public int cidade_id { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string cargo { get; set; }
        public decimal salario { get; set; }
        public string pis { get; set; }
        public DateTime? data_nascimento { get; set; } // Alterado para nullable
        public DateTime? data_admissao { get; set; }   // Alterado para nullable
        public DateTime? data_demissao { get; set; }   // Alterado para nullable
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public bool ativo { get; set; }
    }


}
