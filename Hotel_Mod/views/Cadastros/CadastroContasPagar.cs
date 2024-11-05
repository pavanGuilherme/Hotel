using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroContasPagar : Hotel_Mod.views.CadastroPai
    {

        controllerContasPagar<ContasPagar> controllerContasPagar;
        public CadastroContasPagar()
        {

            controllerContasPagar = new controllerContasPagar<ContasPagar>();
            InitializeComponent();
        }

        private void CadastroContasPagar_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerContasPagar.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }
    }
}
