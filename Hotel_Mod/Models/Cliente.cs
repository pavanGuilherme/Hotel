using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Cliente
    {
        public int cliente_ID { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string rg { get; set; }
        public string contato { get; set; }
        public string sexo { get; set; }    
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public int cidade_id { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public bool ativo { get; set; }
        public string tipo_pessoa { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public string condicao_pagamento { get; set; }
        public int CondPagamento_ID { get; set; } // Campo adicionado para representar o ID da Condição de Pagamento
    }
}



