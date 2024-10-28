using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class Reserva
    {

        public int reserva_ID { get; set; }                    
        public int cliente_ID { get; set; }                     
        public string nome_cliente { get; set; }              
        public string cpf_cliente { get; set; }                 
        public string celular_cliente { get; set; }              
        public int quarto_ID { get; set; }                       
        public string numero_quarto { get; set; }              
        public int? andar { get; set; }                          
        public decimal valor_diaria { get; set; }              
        public decimal valor_total { get; set; }               
        public DateTime data_checkin { get; set; }       
        public DateTime data_checkout { get; set; }     
        public int num_dias { get; set; }                   
        public bool status_pagamento { get; set; }        
        public int? condicao_pagamento_ID { get; set; }       
        public string condicao_pagamento { get; set; }           
        public string status_reserva { get; set; }               
        public DateTime? data_cancelamento { get; set; }        
        public string observacao { get; set; }                  
        public bool ativo { get; set; }                      
        public DateTime data_cadastro { get; set; }            
        public DateTime data_ult_alt { get; set; }            
        public string usuario_ult_alt { get; set; }
    }
}
