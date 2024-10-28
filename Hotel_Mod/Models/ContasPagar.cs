using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class ContasPagar
    {
        // Chaves Primárias
        public int numeroNota { get; set; }
        public int serie { get; set; }
        public int idFornecedor { get; set; }
        public int parcela { get; set; }

        // Atributos da Tabela
        public DateTime dataEmissao { get; set; }
        public int FormaPagamento_ID { get; set; }
        public DateTime data_vencimento { get; set; }
        public DateTime? data_pagamento { get; set; } // Nullable (pode ser nulo)
        public decimal valorParcela { get; set; }
        public decimal? juros { get; set; } // Nullable (pode ser nulo)
        public decimal? multa { get; set; } // Nullable (pode ser nulo)
        public decimal? desconto { get; set; } // Nullable (pode ser nulo)
        public decimal? valor_pago { get; set; } // Nullable (pode ser nulo)
        public DateTime? data_cancelamento { get; set; } // Nullable (pode ser nulo)
        public string observacao { get; set; }
        public DateTime data_cadastro { get; set; }
        public DateTime data_ult_alt { get; set; }
        public string usuario { get; set; }
    }
}
