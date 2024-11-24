using Hotel_Mod.Class;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaTipoQuarto : Hotel_Mod.views.ConsultaPai
    {
        private controllerTipoQuarto<tipo_quarto> controllerTipoQuarto;
        private CadastroTipoQuarto cadastroTipoQuarto;

        public ConsultaTipoQuarto()
        {
            InitializeComponent();
            controllerTipoQuarto = new controllerTipoQuarto<tipo_quarto>();
            cadastroTipoQuarto = new CadastroTipoQuarto();
        }

        public override void Incluir()
        {
            using (var cadastroTipoQuarto = new CadastroTipoQuarto())
            {
                ResetCadastro();
                cadastroTipoQuarto.Owner = this;
                cadastroTipoQuarto.ShowDialog();
            }
        }

        public override void Alterar()
        {
            if (dataGridView_tipo_quarto.SelectedRows.Count > 0)
            {
                int tipo_quarto_ID = (int)dataGridView_tipo_quarto.SelectedRows[0].Cells["tipo_quarto_id"].Value;

                using (var cadastroTipoQuarto = new CadastroTipoQuarto(tipo_quarto_ID))
                {
                    cadastroTipoQuarto.Owner = this;
                    cadastroTipoQuarto.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Selecione um tipo de quarto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridView_tipo_quarto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este tipo de quarto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int tipo_quarto_ID = (int)dataGridView_tipo_quarto.CurrentRow.Cells["tipo_quarto_id"].Value;
                    controllerTipoQuarto.excluir(tipo_quarto_ID);
                    AtualizarConsultaTipoQuarto(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um tipo de quarto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<tipo_quarto> resultadosPesquisa = new List<tipo_quarto>();
                    bool buscaInativos = btn_buscainativos.Checked;

                    if (btn_nome.Checked)
                    {
                        // Pesquisa por Tipo
                        resultadosPesquisa = controllerTipoQuarto.GetAll(buscaInativos)
                                                                  .Where(t => t.tipo.IndexOf(pesquisa, StringComparison.OrdinalIgnoreCase) >= 0)
                                                                  .ToList();
                    }
                    else if (btn_Codigo.Checked)
                    {
                        // Pesquisa por Código
                        if (int.TryParse(pesquisa, out int codigoPesquisa))
                        {
                            resultadosPesquisa = controllerTipoQuarto.GetAll(buscaInativos)
                                                                     .Where(t => t.tipo_quarto_ID == codigoPesquisa)
                                                                     .ToList();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira um código válido.", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    dataGridView_tipo_quarto.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar tipos de quarto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaTipoQuarto(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaTipoQuarto(bool incluirInativos)
        {
            try
            {
                dataGridView_tipo_quarto.DataSource = controllerTipoQuarto.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de tipos de quarto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCadastro()
        {
            if (cadastroTipoQuarto != null)
            {
                cadastroTipoQuarto.LimparCampos();
            }
        }

        private void ConsultaTipoQuarto_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView_tipo_quarto.AutoGenerateColumns = false;
                dataGridView_tipo_quarto.Columns["tipo_quarto_id"].DataPropertyName = "tipo_quarto_ID";
                dataGridView_tipo_quarto.Columns["tipo"].DataPropertyName = "tipo";
                dataGridView_tipo_quarto.Columns["descricao"].DataPropertyName = "descricao";
                dataGridView_tipo_quarto.Columns["valor_diaria"].DataPropertyName = "valor_diaria";
                dataGridView_tipo_quarto.Columns["capacidade_maxima"].DataPropertyName = "capacidade_maxima";

                AtualizarConsultaTipoQuarto(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os tipos de quarto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscainativos_CheckedChanged(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaTipoQuarto(incluirInativos);
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridView_tipo_quarto.SelectedRows.Count > 0)
                {
                    int tipo_quarto_ID = Convert.ToInt32(dataGridView_tipo_quarto.SelectedRows[0].Cells["tipo_quarto_id"].Value);
                    string tipo = dataGridView_tipo_quarto.SelectedRows[0].Cells["tipo"].Value.ToString();
                    string descricao = dataGridView_tipo_quarto.SelectedRows[0].Cells["descricao"].Value.ToString();
                    decimal valor_diaria = Convert.ToDecimal(dataGridView_tipo_quarto.SelectedRows[0].Cells["valor_diaria"].Value);
                    int capacidade_maxima = Convert.ToInt32(dataGridView_tipo_quarto.SelectedRows[0].Cells["capacidade_maxima"].Value);


                    this.Tag = new Tuple<int, string, string, decimal, int>(tipo_quarto_ID, tipo, descricao, valor_diaria, capacidade_maxima);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um tipo de quarto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {  
                Close();
            }
        }
    }
}
