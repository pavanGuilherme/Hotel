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
    public partial class CadastroPai : Form
    {
        public bool ativo = true;
        public int altera = -1;
        public CadastroPai()
        {
            InitializeComponent();
        }

        public virtual void salvar() { }
        public virtual void bloquear() { }
        public virtual void desbloquear() { }
        public virtual void carrega() { }
        public virtual void LimparCampos() { }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            
            salvar();

        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadastroPai_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                txt_dat_cad.Text = DateTime.Now.ToString();
                txt_dat_ult_alt.Text = DateTime.Now.ToString();
            }
        }
    }
}
