using Hotel_Mod.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public partial class CadastroPais : Hotel_Mod.views.CadastroPai
    {
        private controllerPais<Pais> controllerPais;
        public CadastroPais()
        {
            InitializeComponent();
            controllerPais = new controllerPais<Pais>();
        }
        //construtor para alterar um país
        public CadastroPais(int pais_ID) : this()
        {
            altera = pais_ID;
            carrega();
        }

        public override void carrega()
        {
           
            if (altera != -1)
            {
                Pais pais = controllerPais.GetById(altera);
                if (pais != null)
                {
                    //carrega os dados do país nos controles do formulário
                    txt_codigo.Text = pais.pais_ID.ToString();
                    txt_pais.Text = pais.pais;
                    txt_sigla.Text = pais.sigla;
                    txt_ddi.Text = pais.ddi;
                    txt_dat_cad.Text = pais.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = pais.data_ult_alt.ToString();
                    check_ativo.Checked = pais.ativo;
                    check_inativo.Checked = !pais.ativo;
                }
                else
                {
                    MessageBox.Show("País não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_pais.Text))
            {
                MessageBox.Show("Campo País é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pais.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_sigla.Text))
            {
                MessageBox.Show("Campo Sigla é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sigla.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_ddi.Text))
            {
                MessageBox.Show("Campo DDI é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ddi.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerPais.JaCadastrado(txt_pais.Text, idAtual))
                {
                    MessageBox.Show("País já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_pais.Focus();
                }
                else
                {
                    try
                    {
                        string pais = txt_pais.Text;
                        string sigla = txt_sigla.Text;
                        string ddi = txt_ddi.Text;

                        DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                        DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                        Pais novoPais = new Pais
                        {
                            pais = pais,
                            sigla = sigla,
                            ddi = ddi,
                            data_cadastro = data_cadastro,
                            data_ult_alt = data_ult_alt,
                            ativo = ativo
                        };

                        if (altera == -1)
                        {
                            controllerPais.salvar(novoPais);
                        }
                        else
                        {
                            novoPais.pais_ID = altera; // ID do país alterado
                            controllerPais.alterar(novoPais);
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public override void LimparCampos()
        {
            base.LimparCampos();    

            altera = -1;
            txt_codigo.Clear();
            txt_pais.Clear();
            txt_sigla.Clear();
            txt_ddi.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        public void SetID(int id)
        {
            altera = id;
        }

        private void CadastroPaises_FormClosed(object sender, FormClosedEventArgs e)
        {
            //atualiza a consulta de países ao fechar o formulário de cadastro
            ((ConsultaPais)this.Owner).AtualizarConsultaPaises(false);
        }

     
        private void txt_pais_Leave_1(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetras(txt_pais.Text))
            {
                MessageBox.Show("campo inválido.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pais.Focus();
            }
        }

        private void txt_sigla_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetrasSemEspaco(txt_sigla.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sigla.Focus();
            }
        }

        private void txt_ddi_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_ddi.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ddi.Focus();
            }
        }

        private void CadastroPais_Load(object sender, EventArgs e)
        {

            if (altera == -1)
            {
                int novoCodigo = controllerPais.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }

        private void txt_ddi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_sigla_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas letras, espaço e teclas de controle (ex.: Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }
    }
}
