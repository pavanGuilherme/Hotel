using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaQuarto : Hotel_Mod.views.ConsultaPai
    {
        private controllerQuarto<Quarto> controllerQuarto;
        private CadastroQuarto cadastroQuarto;

        public ConsultaQuarto()
        {
            InitializeComponent();
            controllerQuarto = new controllerQuarto<Quarto>();
            cadastroQuarto = new CadastroQuarto();
            cadastroQuarto.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroQuarto.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridViewQuarto.SelectedRows.Count > 0)
            {
                int quarto_ID = (int)dataGridViewQuarto.SelectedRows[0].Cells["quarto_ID"].Value;
                using (CadastroQuarto cadastroQuarto = new CadastroQuarto(quarto_ID))
                {
                    cadastroQuarto.Owner = this;
                    cadastroQuarto.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Selecione um quarto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewQuarto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este quarto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int quarto_ID = (int)dataGridViewQuarto.CurrentRow.Cells["quarto_ID"].Value;
                    controllerQuarto.excluir(quarto_ID);
                    AtualizarConsultaQuartos(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um quarto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    var resultadosPesquisa = controllerQuarto.GetAll(btn_buscainativos.Checked)
                        .Where(q => q.numero.ToString().Contains(pesquisa) ||
                                    q.tipo.ToLower().Contains(pesquisa.ToLower()) ||
                                    q.descricao.ToLower().Contains(pesquisa.ToLower()))
                        .ToList();

                    dataGridViewQuarto.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar quartos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaQuartos(btn_buscainativos.Checked);
            }
        }   

        public void AtualizarConsultaQuartos(bool incluirInativos)
        {
            try
            {
                dataGridViewQuarto.DataSource = controllerQuarto.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de quartos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCadastro()
        {
            cadastroQuarto.LimparCampos();
        }

        private void ConsultaQuarto_Load_1(object sender, EventArgs e)
        {
            try
            {
                cadastroQuarto.FormClosed += (s, args) => AtualizarConsultaQuartos(btn_buscainativos.Checked);

                dataGridViewQuarto.AutoGenerateColumns = false;

                // Verifica se as colunas existem antes de configurar
                if (dataGridViewQuarto.Columns.Contains("quarto_ID"))
                    dataGridViewQuarto.Columns["quarto_ID"].DataPropertyName = "quarto_ID";
                if (dataGridViewQuarto.Columns.Contains("valor"))
                    dataGridViewQuarto.Columns["valor"].DataPropertyName = "valor";
                if (dataGridViewQuarto.Columns.Contains("numero"))
                    dataGridViewQuarto.Columns["numero"].DataPropertyName = "numero";
                if (dataGridViewQuarto.Columns.Contains("andar"))
                    dataGridViewQuarto.Columns["andar"].DataPropertyName = "andar";
                if (dataGridViewQuarto.Columns.Contains("tipo"))
                    dataGridViewQuarto.Columns["tipo"].DataPropertyName = "tipo";
                if (dataGridViewQuarto.Columns.Contains("disponivel"))
                    dataGridViewQuarto.Columns["disponivel"].DataPropertyName = "disponivel";
                if (dataGridViewQuarto.Columns.Contains("ativo"))
                    dataGridViewQuarto.Columns["ativo"].DataPropertyName = "ativo";

                AtualizarConsultaQuartos(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os quartos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscainativos_CheckedChanged_1(object sender, EventArgs e)
        {
            AtualizarConsultaQuartos(btn_buscainativos.Checked);
        }

        private void btn_sair_Click_1(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewQuarto.SelectedRows.Count > 0)
                {
                    int quarto_ID = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["quarto_ID"].Value);
                    int numero = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["numero"].Value);
           

                    this.Tag = new Tuple<int, int>(quarto_ID, numero);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um quarto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }
    }
}
