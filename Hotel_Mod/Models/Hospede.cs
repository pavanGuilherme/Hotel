using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Hospede
    {

        public int hospede_id { get; set; }      // Identificador único do hóspede (ID)
        public string nome { get; set; }         // Nome do hóspede
        public string sobrenome { get; set; }    // Sobrenome do hóspede
        public char sexo { get; set; }           // Sexo do hóspede (M/F)
        public bool ativo { get; set; }          // Status ativo/inativo
        public string cep { get; set; }          // CEP
        public string logradouro { get; set; }   // Logradouro (endereço)
        public string numero { get; set; }       // Número do endereço
        public string complemento { get; set; }  // Complemento do endereço
        public string bairro { get; set; }       // Bairro
        public int cidade_id { get; set; }       // ID da cidade
        public string cidade { get; set; }       // Nome da cidade
        public string estado { get; set; }       // Estado
        public string pais { get; set; }         // País
        public bool estrangeiro { get; set; }    // Indica se é estrangeiro
        public string cpf { get; set; }          // CPF
        public string rg { get; set; }           // RG
        public string passaporte { get; set; }   // Passaporte (para estrangeiros)
        public string telefone { get; set; }     // Telefone
        public string email { get; set; }        // Email
        public DateTime? data_nascimento { get; set; } // Data de nascimento (nullable)
        public bool pcd { get; set; }            // Indica se é PCD (Pessoa com Deficiência)
        public string observacao { get; set; }   // Observações
        public DateTime data_cadastro { get; set; }   // Data de cadastro
        public DateTime data_ult_alt { get; set; }    // Data da última alteração

    }
}
