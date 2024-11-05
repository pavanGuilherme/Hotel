using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Hotel_Mod.Controller;
using Hotel_Mod.views.Cadastros;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaCondPagamento : Hotel_Mod.views.ConsultaPai
    {

        private controllerCondPagamento<CondicaoPagamento> controllerCondicaoPagamento;
        private CadastroCondPagamento cadastroCondicaoPagamento;
        public ConsultaCondPagamento()
        {
            InitializeComponent();

            controllerCondicaoPagamento = new controllerCondPagamento<CondicaoPagamento>();
            cadastroCondicaoPagamento = new CadastroCondPagamento();
            cadastroCondicaoPagamento.Owner = this;

            this.Load += ConsultaCondPagamento_Load;

        }


        public override void Incluir()
        {
            ResetCadastro();
            cadastroCondicaoPagamento.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridViewCondPagamento.SelectedRows.Count > 0)
            {
                int condPagamentoId = (int)dataGridViewCondPagamento.SelectedRows[0].Cells["codigo"].Value;
                ResetCadastro(condPagamentoId);
                cadastroCondicaoPagamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma condição de pagamento para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewCondPagamento.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir esta condição de pagamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int condPagamentoId = (int)dataGridViewCondPagamento.SelectedRows[0].Cells["codigo"].Value;
                    controllerCondicaoPagamento.excluir(condPagamentoId);
                    dataGridViewCondPagamento.DataSource = controllerCondicaoPagamento.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma condição de pagamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<CondicaoPagamento> resultadosPesquisa = new List<CondicaoPagamento>();
                    bool buscaInativos = btn_buscainativos.Checked;

                    if (btn_nome.Checked)
                    {
                        resultadosPesquisa = controllerCondicaoPagamento.GetAll(buscaInativos)
                                                           .Where(p => p.condicaoPagamento.Contains(pesquisa))
                                                           .ToList();
                    }
                    else if (btn_Codigo.Checked)
                    {
                        if (int.TryParse(pesquisa, out int codigoPesquisa))
                        {
                            resultadosPesquisa = controllerCondicaoPagamento.GetAll(buscaInativos)
                                                               .Where(p => p.CondPagamento_ID == codigoPesquisa)
                                                               .ToList();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira um código válido.", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    dataGridViewCondPagamento.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaCondPag(btn_buscainativos.Checked);
            }
        }

        private void ResetCadastro()
        {
            cadastroCondicaoPagamento.LimparCampos();
        }

        private void ResetCadastro(int id)
        {
            cadastroCondicaoPagamento.SetID(id);
            cadastroCondicaoPagamento.limpaCamposparcela();
            cadastroCondicaoPagamento.carrega();
        }

        public void AtualizarConsultaCondPag(bool incluirInativos)
        {
            try
            {
                dataGridViewCondPagamento.DataSource = controllerCondicaoPagamento.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de condições de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_buscainativos_CheckedChanged(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaCondPag(incluirInativos);
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewCondPagamento.SelectedRows.Count > 0)
                {
                    int condPagamentoId = Convert.ToInt32(dataGridViewCondPagamento.SelectedRows[0].Cells["codigo"].Value);
                    string condPag = dataGridViewCondPagamento.SelectedRows[0].Cells["condicao"].Value.ToString();

                    this.Tag = new Tuple<int, string>(condPagamentoId, condPag);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma condição de pagamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }

        private void dataGridViewCondPagamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int condPagamentoId = (int)dataGridViewCondPagamento.Rows[e.RowIndex].Cells["codigo"].Value;
                ResetCadastro(condPagamentoId);
                cadastroCondicaoPagamento.ShowDialog();
            }
        }

        private void ConsultaCondPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                cadastroCondicaoPagamento.FormClosed += (s, args) => AtualizarConsultaCondPag(btn_buscainativos.Checked); // Quando aciona o Form Closed chama o AtualizarConsulta

                dataGridViewCondPagamento.AutoGenerateColumns = false;
                dataGridViewCondPagamento.Columns["codigo"].DataPropertyName = "CondPagamento_ID";
                dataGridViewCondPagamento.Columns["condicao"].DataPropertyName = "condicaoPagamento";

                AtualizarConsultaCondPag(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as condições de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewCondPagamento.SelectedRows.Count > 0)
                {
 
                    int condPag_ID = Convert.ToInt32(dataGridViewCondPagamento.SelectedRows[0].Cells["codigo"].Value);
                    string condPag = dataGridViewCondPagamento.SelectedRows[0].Cells["condicao"].Value.ToString();


                    this.Tag = new Tuple<int, string>(condPag_ID, condPag);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma condição.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }
    }
    
}