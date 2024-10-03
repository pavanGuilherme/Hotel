using Hotel_Mod.views;
using Hotel_Mod.views.Cadastros;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mod
{
    public partial class Hotel : Form
    {
        private Form activeForm;

        public Hotel()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            button1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None; // Não usar DockStyle.Fill para permitir centralização
            this.panel2.Controls.Add(childForm);
            this.panel2.Tag = childForm;
            lbl_title.Text = childForm.Text;

            // Centralizar o formulário filho dentro do painel
            childForm.Left = (panel2.Width - childForm.Width) / 2;
            childForm.Top = (panel2.Height - childForm.Height) / 2;

            // Ajustar a cor e o tamanho da fonte dos controles
            foreach (Control control in childForm.Controls)
            {
                control.ForeColor = Color.Black; // Trocar a cor da fonte
                control.Font = new Font(control.Font.FontFamily, control.Font.Size + 2); // Aumentar o tamanho da fonte
            }

            childForm.FormClosed += ChildForm_FormClosed; // Adiciona o evento de fechamento do formulário filho
            childForm.BringToFront();
            childForm.Show();
        }

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lbl_title.Text = "HOME"; // Quando o formulário filho é fechado, a label volta a ser "HOME"
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = DateTime.Now.ToString("HH:mm:ss");
            button2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaCliente());
        }

        private void quartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaQuarto());
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* OpenChildForm(new ConsultaUsuario());*/ // Substitua por formulário de usuários, se existir
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaFormaPagamento());
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaFuncionario());
        }

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaPais());
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaEstado());
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaCidades());
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*OpenChildForm(new ConsultaServicos());*/ // Substitua por formulário de serviços, se existir
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaFornecedor());
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaProduto());
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            // Inicialização do formulário, se necessário
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaCliente());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultaCondPagamento()); 
        }
    }
}
