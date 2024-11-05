using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroFormaPagamento : Hotel_Mod.views.CadastroPai
    {
        private ControllerFormaPagamento<FormaPagamento> controllerFormaPagamento;

        public CadastroFormaPagamento()
        {
            InitializeComponent();
            controllerFormaPagamento = new ControllerFormaPagamento<FormaPagamento>();
        }

        // Construtor para alterar uma forma de pagamento
        public CadastroFormaPagamento(int formaPagamento_ID) : this()
        {
            altera = formaPagamento_ID;
            carrega();
        }

        public override void carrega()
        {
            // Verifica se há uma forma de pagamento a ser alterada
            if (altera != -1)
            {
                FormaPagamento formaPagamento = controllerFormaPagamento.GetById(altera);
                if (formaPagamento != null)
                {
                    // Carrega os dados da forma de pagamento nos controles do formulário
                    txt_codigo.Text = formaPagamento.FormaPagamento_ID.ToString();
                    txt_forma_pagamento.Text = formaPagamento.formaPagamento;
                    txt_dat_cad.Text = formaPagamento.DataCadastro.ToString();
                    txt_dat_ult_alt.Text = formaPagamento.DataUltAlt.ToString();
                    check_ativo.Checked = formaPagamento.Ativo;
                }
                else
                {
                    MessageBox.Show("Forma de pagamento não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_forma_pagamento.Text))
            {
                MessageBox.Show("Campo Forma de Pagamento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_forma_pagamento.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerFormaPagamento.JaCadastrado(txt_forma_pagamento.Text, idAtual))
                {
                    MessageBox.Show("Forma de pagamento já cadastrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_forma_pagamento.Focus();
                }
                else
                {
                    try
                    {
                        string formaPagamento = txt_forma_pagamento.Text;
                        bool ativo = check_ativo.Checked;
                        DateTime dataCadastro = altera == -1 ? DateTime.Now : DateTime.Parse(txt_dat_cad.Text);
                        DateTime dataUltAlt = DateTime.Now;

                        FormaPagamento novaFormaPagamento = new FormaPagamento
                        {
                            formaPagamento = formaPagamento,
                            Ativo = ativo,
                            DataCadastro = dataCadastro,
                            DataUltAlt = dataUltAlt
                        };

                        if (altera == -1)
                        {
                            controllerFormaPagamento.salvar(novaFormaPagamento);
                        }
                        else
                        {
                            novaFormaPagamento.FormaPagamento_ID = altera; // ID da forma de pagamento alterada
                            controllerFormaPagamento.alterar(novaFormaPagamento);
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
            altera = -1;
            txt_codigo.Clear();
            txt_forma_pagamento.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        private void CadastroFormaPagamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Atualiza a consulta de formas de pagamento ao fechar o formulário de cadastro
            ((ConsultaFormaPagamento)this.Owner).AtualizarConsultaFormaPagamentos(false);
        }

        private void CadastroFormaPagamento_Load(object sender, EventArgs e)
        {
            // Código para inicializar o formulário, se necessário
        }

        private void txt_forma_pagamento_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetras(txt_forma_pagamento.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_forma_pagamento.Focus();
            }
        }

        private void CadastroFormaPagamento_Load_1(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerFormaPagamento.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }
    }
}
