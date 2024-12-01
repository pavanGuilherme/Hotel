using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class ContasReceber
    {
        public int reserva_ID { get; set; } // Chave composta
        public int cliente_ID { get; set; } // Chave composta
        public int num_parcela { get; set; } // Chave composta
        public decimal valor_total { get; set; } // Valor total da conta
        public decimal valor_parcela { get; set; }  
        public DateTime? data_emissao { get; set; } = DateTime.Now; // Data padrão para emissão
        public DateTime? data_vencimento { get; set; } // Data de vencimento
        public DateTime? data_recebimento { get; set; } // Opcional
        public int formaPagamento_ID { get; set; } // Chave estrangeira
        public decimal? juros { get; set; } // Opcional
        public decimal? multa { get; set; } // Opcional
        public decimal? desconto { get; set; } // Opcional
        public decimal? valorRecebido { get; set; } // Opcional
        public DateTime? data_cancelamento { get; set; } // Opcional
        public string observacao { get; set; } // Opcional, até 200 caracteres
        public DateTime? data_cadastro { get; set; } = DateTime.Now; // Data padrão para cadastro
        public DateTime? data_ult_alt { get; set; } = DateTime.Now; // Data padrão para última alteração
    }

}
