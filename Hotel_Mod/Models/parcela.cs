
namespace Hotel_Mod.Models
{
    public class parcela
    {
        public int parcela_ID { get; set; }
        public int numeroParcela { get; set; }
        public int dias { get; set; }
        public decimal porcentagem { get; set; }
        public int CondPagamento_ID { get; set; }
        public int FormaPagamento_ID { get; set; }
    }
}
