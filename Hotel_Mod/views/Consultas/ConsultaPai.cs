using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public partial class ConsultaPai : Form
    {
        public ConsultaPai()
        {
            InitializeComponent();
        }

        public virtual void Incluir() { }
        public virtual void Alterar() { }
        public virtual void Excluir() { }
        public virtual void Pesquisar() { }

       

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Pesquisar();
        }

        private void btn_incluir_Click(object sender, EventArgs e)
        {
            Incluir();

        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

