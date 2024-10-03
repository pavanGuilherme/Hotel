using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaFormaPagamento : Hotel_Mod.views.ConsultaPai
    {

        private ControllerFormaPagamento<FormaPagamento> controllerFormaPagamento;
        private CadastroFormaPagamento CadastroFormaPagamento;
        public ConsultaFormaPagamento()
        {
            InitializeComponent();
            controllerFormaPagamento = new ControllerFormaPagamento<FormaPagamento>();
            CadastroFormaPagamento = new CadastroFormaPagamento();
            CadastroFormaPagamento.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            CadastroFormaPagamento.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridViewFormaPagamento.SelectedRows.Count > 0)
            {
                int formaPagamento_ID = (int)dataGridViewFormaPagamento.SelectedRows[0].Cells["codigo"].Value;
                CadastroFormaPagamento cadastroFormaPagamento = new CadastroFormaPagamento(formaPagamento_ID);
                cadastroFormaPagamento.Owner = this;
                cadastroFormaPagamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma forma de pagamento para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewFormaPagamento.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir esta forma de pagamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int formaPagamento_ID = (int)dataGridViewFormaPagamento.CurrentRow.Cells["codigo"].Value;
                    controllerFormaPagamento.excluir(formaPagamento_ID);
                    AtualizarConsultaFormaPagamentos(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma forma de pagamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<FormaPagamento> resultadosPesquisa = controllerFormaPagamento.GetAll(btn_buscainativos.Checked)
                        .Where(fp => fp.formaPagamento.ToLower().Contains(pesquisa.ToLower()))
                        .ToList();

                    dataGridViewFormaPagamento.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar formas de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaFormaPagamentos(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaFormaPagamentos(bool incluirInativos)
        {
            try
            {
                dataGridViewFormaPagamento.DataSource = controllerFormaPagamento.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de formas de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCadastro()
        {
            CadastroFormaPagamento.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewFormaPagamento.SelectedRows.Count > 0)
                {
                    int formaPagamento_ID = Convert.ToInt32(dataGridViewFormaPagamento.SelectedRows[0].Cells["codigo"].Value);
                    string formaPagamento = dataGridViewFormaPagamento.SelectedRows[0].Cells["forma"].Value.ToString();

                    this.Tag = new Tuple<int, string>(formaPagamento_ID, formaPagamento);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma forma de pagamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }

        private void btn_buscainativos_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarConsultaFormaPagamentos(btn_buscainativos.Checked);
        }

       
        private void ConsultaFormaPagamento_Load_1(object sender, EventArgs e)
        {
            try
            {
                CadastroFormaPagamento cadastroFormaPagamento = new CadastroFormaPagamento();
                cadastroFormaPagamento.FormClosed += (s, args) => AtualizarConsultaFormaPagamentos(btn_buscainativos.Checked);

                dataGridViewFormaPagamento.AutoGenerateColumns = false;
                dataGridViewFormaPagamento.Columns["codigo"].DataPropertyName = "FormaPagamento_ID";
                dataGridViewFormaPagamento.Columns["forma"].DataPropertyName = "formaPagamento";
                dataGridViewFormaPagamento.Columns["ativo"].DataPropertyName = "Ativo";

                AtualizarConsultaFormaPagamentos(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as formas de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
    
