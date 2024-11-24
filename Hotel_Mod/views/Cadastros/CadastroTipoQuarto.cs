using Hotel_Mod.Class;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroTipoQuarto : Hotel_Mod.views.CadastroPai
    {
        private controllerTipoQuarto<tipo_quarto> controllerTipoQuarto;

        public CadastroTipoQuarto()
        {
            InitializeComponent();
            controllerTipoQuarto = new controllerTipoQuarto<tipo_quarto>();
        }

        // Construtor para alterar um tipo de quarto existente
        public CadastroTipoQuarto(int tipo_quarto_ID) : this()
        {
            altera = tipo_quarto_ID;
            carrega();
        }

        public override void carrega()
        {
            check_ativo.Enabled = false;
            check_inativo.Enabled = false;
            
            if (altera != -1)
            {
                tipo_quarto tipoQuarto = controllerTipoQuarto.GetById(altera);
                if (tipoQuarto != null)
                {
                    // Carrega os dados do tipo de quarto nos controles do formulário
                    txt_codigo.Text = tipoQuarto.tipo_quarto_ID.ToString();
                    txt_tipo.Text = tipoQuarto.tipo;
                    txt_descricao.Text = tipoQuarto.descricao;
                    txt_valor.Text = tipoQuarto.valor_diaria.ToString();
                    txt_capacidade_max.Text = tipoQuarto.capacidade_maxima.ToString();  
                    txt_lotacao_maxima.Text = tipoQuarto.lotacaoMaxima.ToString();  
                }
                else
                {
                    MessageBox.Show("Tipo de quarto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_tipo.Text))
            {
                MessageBox.Show("Campo Tipo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tipo.Focus();
                return;
            }

            if (!validadores.CampoObrigatorio(txt_capacidade_max.Text))
            {
                MessageBox.Show("Campo capacidade máxima é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_capacidade_max.Focus();
                return;
            }

            if (!validadores.CampoObrigatorio(txt_valor.Text))
            {
                MessageBox.Show("Campo valor é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_valor.Focus();
                return;
            }


            if (!validadores.CampoObrigatorio(txt_descricao.Text))
            {
                MessageBox.Show("Campo Descrição é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_descricao.Focus();
                return;
            }

            int idAtual = altera != -1 ? altera : -1;

            if (controllerTipoQuarto.JaCadastrado(txt_tipo.Text, idAtual))
            {
                MessageBox.Show("Tipo de quarto já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tipo.Focus();
                return;
            }

            try
            {
                tipo_quarto novoTipoQuarto = new tipo_quarto
                {
                    tipo = txt_tipo.Text,
                    descricao = txt_descricao.Text,
                    valor_diaria = decimal.Parse(txt_valor.Text),
                    capacidade_maxima = int.Parse(txt_capacidade_max.Text),
                    lotacaoMaxima = int.Parse(txt_lotacao_maxima.Text),
                };

                if (altera == -1)
                {
                    controllerTipoQuarto.salvar(novoTipoQuarto);
                }
                else
                {
                    novoTipoQuarto.tipo_quarto_ID = altera; // ID do tipo de quarto alterado
                    controllerTipoQuarto.alterar(novoTipoQuarto);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimparCampos()
        {
            base.LimparCampos();
            altera = -1;
            txt_codigo.Clear();
            txt_tipo.Clear();
            txt_descricao.Clear();
            txt_valor.Clear();
            txt_capacidade_max.Clear();
            txt_lotacao_maxima.Clear();
        
        }

        public void SetID(int id)
        {
            altera = id;
        }

        private void txt_tipo_Leave_1(object sender, EventArgs e)
        {
            if (!validadores.CampoObrigatorio(txt_tipo.Text))
            {
                MessageBox.Show("Campo obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tipo.Focus();
            }
        }

        private void txt_descricao_Leave(object sender, EventArgs e)
        {
            if (!validadores.CampoObrigatorio(txt_descricao.Text))
            {
                MessageBox.Show("Campo obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_descricao.Focus();
            }
        }



        private void CadastroTipoQuarto_Load_1(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerTipoQuarto.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }

        }

        private void txt_valor_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_valor.Text))
            {
                MessageBox.Show(" Valor ínvalido ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_valor.Focus();
             
            }
        }
    }
}
