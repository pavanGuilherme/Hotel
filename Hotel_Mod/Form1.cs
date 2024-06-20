using Hotel_Mod.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCliente consultacliente = new ConsultaCliente();
            consultacliente.ShowDialog();
            
        }

        private void quartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaPais consultaPais = new ConsultaPais();
            consultaPais.ShowDialog();

        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaEstado consultaEstado = new ConsultaEstado();
            consultaEstado.ShowDialog();

        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCidades consultaCidades = new ConsultaCidades();
            consultaCidades.ShowDialog();

        }
        private void btn_cliente_Click(object sender, EventArgs e)
        {
        

        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
