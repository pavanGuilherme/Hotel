using Hotel_Mod.Class;
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
        private DaoQuarto<Quarto> daoQuarto;
        private controllerReservas<Reserva> controllerReserva;
        public int tipoQuarto_id { get; set; }
        public int ReservaSelecionadaID { get; set; }
        public int QuartoSelecionado { get; set; }
        public int NumeroQuartoSelecionado { get; set; }
        public int AndarQuartoSelecionado { get; set; }



        public ConsultaQuarto()
        {

            InitializeComponent();
            controllerQuarto = new controllerQuarto<Quarto>();
            cadastroQuarto = new CadastroQuarto();
            daoQuarto = new DaoQuarto<Quarto>();
            controllerReserva = new controllerReservas<Reserva>();
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

            if (tipoQuarto_id == 0 || tipoQuarto_id == null) 
            {
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
            else
            {
                CarregarQuartosDisponiveis(tipoQuarto_id);
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
                    dataGridViewQuarto.Columns["valor"].DataPropertyName = "valor_diaria";
                if (dataGridViewQuarto.Columns.Contains("numero"))
                    dataGridViewQuarto.Columns["numero"].DataPropertyName = "numero";
                if (dataGridViewQuarto.Columns.Contains("andar"))
                    dataGridViewQuarto.Columns["andar"].DataPropertyName = "andar";
                if (dataGridViewQuarto.Columns.Contains("tipo"))
                    dataGridViewQuarto.Columns["tipo"].DataPropertyName = "tipo";
                if (dataGridViewQuarto.Columns.Contains("ativo"))
                    dataGridViewQuarto.Columns["ativo"].DataPropertyName = "ativo";
                if (dataGridViewQuarto.Columns.Contains("tipo_id"))
                    dataGridViewQuarto.Columns["tipo_id"].DataPropertyName = "tipo_id";


                AtualizarConsultaQuartos(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os quartos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tipoQuarto_id != 0)
            {
                // Carregar os quartos disponíveis com base no tipo
                CarregarQuartosDisponiveis(tipoQuarto_id);
            }
        }

        private void CarregarQuartosDisponiveis(int tipoQuarto_id)
        {
            // Lógica para buscar os quartos disponíveis no banco de dados com base no tipo
            var quartosDisponiveis = daoQuarto.BuscarQuartosDisponiveis(tipoQuarto_id);

            // Preenche a tabela ou lista de quartos
            dataGridViewQuarto.DataSource = quartosDisponiveis;
        }

        private void btn_buscainativos_CheckedChanged_1(object sender, EventArgs e)
        {
            AtualizarConsultaQuartos(btn_buscainativos.Checked);
        }

     
        private void btn_sair_Click_1(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                // Verifica se há uma linha selecionada no DataGridView
                if (dataGridViewQuarto.SelectedRows.Count > 0)
                {
                    // Obtém os valores do quarto selecionado
                    int quarto_ID = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["quarto_ID"].Value);
                    int numero = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["numero"].Value);
                    int andar = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["andar"].Value);
                    decimal valor = Convert.ToDecimal(dataGridViewQuarto.SelectedRows[0].Cells["valor"].Value);
                    string tipo = dataGridViewQuarto.SelectedRows[0].Cells["tipo"].Value.ToString();

                    // Armazena os dados selecionados no `Tag` do formulário
                    this.Tag = new Tuple<int, int, int, decimal, string>(quarto_ID, numero, andar, valor, tipo);

                    // Define o DialogResult como OK para retornar ao formulário principal
                    this.DialogResult = DialogResult.OK;

                    // Fecha o formulário
                    this.Close();
                }
                else
                {
                    // Exibe uma mensagem caso nenhum quarto tenha sido selecionado
                    MessageBox.Show("Por favor, selecione um quarto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Caso o texto do botão não seja "Selecionar", apenas fecha o formulário
                this.Close();
            }

            if (btn_sair.Text == "Selecionar Quarto")
            {
                // Verifica se há uma linha selecionada no DataGridView
                if (dataGridViewQuarto.SelectedRows.Count > 0)
                {
                    // Obtém os valores do quarto selecionado
                    QuartoSelecionado = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["quarto_ID"].Value);
                    NumeroQuartoSelecionado = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["numero"].Value);
                    AndarQuartoSelecionado = Convert.ToInt32(dataGridViewQuarto.SelectedRows[0].Cells["andar"].Value);

                    // Mensagem de confirmação
                    MessageBox.Show("Quarto selecionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Define o resultado como OK e fecha o formulário
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
                // Apenas fecha o formulário
                this.Close();
            }


        }
    }
}
