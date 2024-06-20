
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
    public partial class Principal : Form
    {
        private Button activeButton;

        private Form activeForm;
        public Principal()
        {
            InitializeComponent();
        }




        //private void OpenChildForm(Form childForm, object btnsender)
        //{
        //    if (activeForm != null)
        //    {
        //        activeForm.Close();
        //    }
        //    btn_close.Visible = true;
        //    activeForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    this.panel2.Controls.Add(childForm);
        //    this.panel2.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //    lbl_title.Text = childForm.Text;


        //}


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_pais_Click(object sender, EventArgs e)
        {
            ConsultaPais consultaPais = new ConsultaPais();
            consultaPais.ShowDialog();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }
        private void Reset()
        {
            lbl_title.Text = "HOME";
            btn_close.Visible = false;
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
        

        }

        private void btn_estado_Click(object sender, EventArgs e)
        {
            ConsultaEstado consultaEstado = new ConsultaEstado();
            consultaEstado.ShowDialog();

        }

        private void btn_cidade_Click(object sender, EventArgs e)
        {
            ConsultaCidades consultaCidades = new ConsultaCidades();
            consultaCidades.ShowDialog();
        }


        private void btn_cliente_Click(object sender, EventArgs e)
        {
            ConsultaCliente consultaCliente = new ConsultaCliente();
            consultaCliente.ShowDialog();
        }

        private void btn_fornecedor_Click(object sender, EventArgs e)
        {

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {


        }
        private void btn_checkin_Click(object sender, EventArgs e)
        {

        }
    }
}
