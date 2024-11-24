using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Mod.Models
{
    public class tipo_quarto
    {
        public int tipo_quarto_ID { get; set; }  
        public string tipo { get; set; }      
        public string descricao { get; set; }   
        public decimal valor_diaria { get; set; }   
        public int capacidade_maxima { get; set; } 
        public int lotacaoMaxima { get; set; }  
    }
}
