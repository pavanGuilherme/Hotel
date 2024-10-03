using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroCondPagamento : Hotel_Mod.views.CadastroPai
    {

        private controllerCondPagamento<CondicaoPagamento> controllerCondPagamento;
        private ConsultaFormaPagamento consultaFormasPagamento;
        private ControllerFormaPagamento<FormaPagamento> formaPagamentoController;


        public CadastroCondPagamento()
        {
            InitializeComponent();

            controllerCondPagamento = new controllerCondPagamento<CondicaoPagamento>();
            consultaFormasPagamento = new ConsultaFormaPagamento();
            formaPagamentoController = new ControllerFormaPagamento<FormaPagamento>();
        }

        public override void LimparCampos()
        {
            base.LimparCampos();
            txt_codigo.Clear();
            txt_cond_pagamento.Clear();
            txt_juros.Clear();
            txt_multa.Clear();
            txt_desconto.Clear();
            txt_parcela.Clear();
            txt_dias.Clear();
            txt_porcentagem.Clear();
            txt_porcentagem_total.Clear();
            txt_cod_forma.Clear();
            txt_forma_pagamento.Clear();
            txt_dat_ult_alt.Clear();
            txt_dat_cad.Clear();
            check_ativo.Checked = true;
            dataGridView_parcelas.Rows.Clear();
            limpaCamposparcela();
        }

        public void limpaCamposparcela()
        {
            txt_parcela.Clear();
            txt_dias.Clear();
            txt_porcentagem.Clear();
            txt_cod_forma.Clear();
            txt_forma_pagamento.Clear();
        }

        public void SetID(int id)
        {
            altera = id;
        }

        public override void salvar()
        {
            if (!string.IsNullOrEmpty(txt_porcentagem_total.Text))
            {
                decimal porcentagem = Convert.ToDecimal(txt_porcentagem_total.Text);
                if (porcentagem != 100)
                {
                    MessageBox.Show("A porcentagem total deve ser igual a 100%.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (validadores.CampoObrigatorio(txt_cond_pagamento.Text))
            {
                MessageBox.Show("Campo Condição de Pagamento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cond_pagamento.Focus();
            }
            else if (dataGridView_parcelas.Rows.Count == 0) // Verifica se há pelo menos uma parcela
            {
                MessageBox.Show("É necessário adicionar pelo menos uma parcela.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string condPagamento = txt_cond_pagamento.Text;
                    decimal desconto = Convert.ToDecimal(txt_desconto.Text);
                    decimal juros = Convert.ToDecimal(txt_juros.Text);
                    decimal multa = Convert.ToDecimal(txt_multa.Text);
                    DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                    DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                    CondicaoPagamento NovaCondPagamento = new CondicaoPagamento
                    {
                        condicaoPagamento = condPagamento,
                        desconto = desconto,
                        juros = juros,
                        multa = multa,
                        Ativo = ativo,
                        data_cadastro = dataCadastro,
                        data_ult_alt = data_ult_alt,
                        parcelas = obtemparcela()
                    };

                    if (altera == -1)
                    {
                        controllerCondPagamento.salvar(NovaCondPagamento);
                    }
                    else
                    {
                        NovaCondPagamento.CondPagamento_ID = altera;
                        controllerCondPagamento.alterar(NovaCondPagamento);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void carrega()
        {
            base.carrega();
            var condicaoPagamento = controllerCondPagamento.GetById(altera);
            if (condicaoPagamento != null)
            {
                txt_codigo.Text = condicaoPagamento.CondPagamento_ID.ToString();
                txt_cond_pagamento.Text = condicaoPagamento.condicaoPagamento;
                txt_juros.Text = condicaoPagamento.juros.ToString();
                txt_multa.Text = condicaoPagamento.multa.ToString();
                txt_desconto.Text = condicaoPagamento.desconto.ToString();
                txt_dat_cad.Text = condicaoPagamento.data_cadastro.ToString();
                txt_dat_ult_alt.Text = condicaoPagamento.data_ult_alt.ToString();
                check_ativo.Checked = condicaoPagamento.Ativo;

                exibirparcelaDGV(condicaoPagamento.parcelas);
                atualizaPorcentagemTotal();
            }
        }

        private List<parcela> obtemparcela()
        {
            List<parcela> parcela = new List<parcela>(); // Lista para armazenar as parcela

            foreach (DataGridViewRow row in dataGridView_parcelas.Rows) // Percorre o DataGridView
            {
                parcela parcelas = new parcela
                {
                    numeroParcela = Convert.ToInt32(row.Cells["numeroParcela"].Value),
                    dias = Convert.ToInt32(row.Cells["dias"].Value),
                    porcentagem = Convert.ToDecimal(row.Cells["porcentagem"].Value),
                    FormaPagamento_ID = Convert.ToInt32(row.Cells["CódFormaPag"].Value)
                };
                parcela.Add(parcelas);
            }

            return parcela;
        }

        private void exibirparcelaDGV(List<parcela> parcela)
        {
            dataGridView_parcelas.Rows.Clear(); // Limpa o DataGridView

            foreach (var parcelas in parcela) // Adiciona as parcela ao DataGridView
            {
                string formaPagamento = controllerCondPagamento.GetFormaPagByParcelaId(parcelas.parcela_ID);

                dataGridView_parcelas.Rows.Add(
                    parcelas.numeroParcela,
                    parcelas.dias,
                    parcelas.porcentagem,
                    parcelas.FormaPagamento_ID,
                    formaPagamento
                );
            }

            dataGridView_parcelas.Sort(dataGridView_parcelas.Columns["numeroParcela"], ListSortDirection.Ascending);
        }

        private bool verificaNumeroParcela(int numeroParcela)
        {
            foreach (DataGridViewRow row in dataGridView_parcelas.Rows)
            {
                if (Convert.ToInt32(row.Cells["numeroParcela"].Value) == numeroParcela)
                {
                    return true;
                }
            }
            return false;
        }

        private void atualizaPorcentagemTotal()
        {
            decimal porcentagemTotal = 0;

            foreach (DataGridViewRow row in dataGridView_parcelas.Rows) // Percorre as linhas do DataGridView
            {
                porcentagemTotal += Convert.ToDecimal(row.Cells["porcentagem"].Value); // Adiciona à variável
            }
            txt_porcentagem_total.Text = porcentagemTotal.ToString("F2"); // Atualiza o campo com duas casas decimais
        }

        private void CadastroCondicaoPagamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaCondPagamento)this.Owner).AtualizarConsultaCondPag(false);
        }

        private void CadastroCondicaoPagamento_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerCondPagamento.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
                txt_parcela.Text = "1";
                txt_juros.Text = "0";
                txt_multa.Text = "0";
                txt_desconto.Text = "0";
            }
        }

        private void btnConsultaFormaPag_Click(object sender, EventArgs e)
        {
            consultaFormasPagamento.btn_sair.Text = "Selecionar";

            if (consultaFormasPagamento.ShowDialog() == DialogResult.OK)
            {
                var infosFormaPag = consultaFormasPagamento.Tag as Tuple<int, string>;
                if (infosFormaPag != null)
                {
                    int idFormaPag = infosFormaPag.Item1;
                    string formaPag = infosFormaPag.Item2;

                    txt_cod_forma.Text = idFormaPag.ToString();
                    txt_forma_pagamento.Text = formaPag;
                }
            }
        }

        private void txt_cod_forma_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_forma.Text))
            {
                FormaPagamento formaPag = formaPagamentoController.GetById(int.Parse(txt_cod_forma.Text));
                if (formaPag != null)
                {
                    txt_forma_pagamento.Text = formaPag.formaPagamento;
                }
                else
                {
                    MessageBox.Show("Forma de Pagamento não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_forma.Focus();
                    txt_cod_forma.Clear();
                    txt_forma_pagamento.Clear();
                }
            }
        }

        private void txt_porcentagem_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_porcentagem.Text) && decimal.Parse(txt_porcentagem.Text) == 0)
            {
                MessageBox.Show("A porcentagem deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_porcentagem.Focus();
            }
        }

        private void txt_cod_forma_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddParcela_Click(object sender, EventArgs e)
        {
            if (validadores.CampoObrigatorio(txt_parcela.Text))
            {
                MessageBox.Show("Campo Nº Parcela é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_parcela.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_dias.Text))
            {
                MessageBox.Show("Campo Dias é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dias.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_porcentagem.Text))
            {
                MessageBox.Show("Campo % é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_porcentagem.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_cod_forma.Text))
            {
                MessageBox.Show("Campo Código Forma Pagamento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_forma.Focus();
            }
            else
            {
                try
                {
                    int numeroParcela = Convert.ToInt32(txt_parcela.Text);
                    if (verificaNumeroParcela(numeroParcela))
                    {
                        MessageBox.Show("Número de parcela já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_parcela.Focus();
                        return;
                    }

                    int dias = Convert.ToInt32(txt_dias.Text);
                    decimal porcentagem = Convert.ToDecimal(txt_porcentagem.Text);
                    int idFormaPag = Convert.ToInt32(txt_cod_forma.Text);
                    string formaPagamento = txt_forma_pagamento.Text;

                    dataGridView_parcelas.Rows.Add(numeroParcela, dias, porcentagem, idFormaPag, formaPagamento); // Adiciona nova linha com os valores

                    atualizaPorcentagemTotal();
                    dataGridView_parcelas.Sort(dataGridView_parcelas.Columns["numeroParcela"], ListSortDirection.Ascending);
                    limpaCamposparcela();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar parcela: " + ex.Message);
                }
            }
        }

        private void btnExcluirParcela_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_parcelas.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView_parcelas.SelectedRows)
                    {
                        dataGridView_parcelas.Rows.Remove(row);
                    }
                    atualizaPorcentagemTotal();
                }
                else
                {
                    MessageBox.Show("Selecione uma parcela para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir parcela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_multa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtParcela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_porcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}

