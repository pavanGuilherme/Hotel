using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaReserva : Hotel_Mod.views.ConsultaPai
    {
        private controllerReservas<Reserva> controllerReserva;
        private CadastroReserva cadastroReserva;

        public ConsultaReserva()
        {
            InitializeComponent();
            controllerReserva = new controllerReservas<Reserva>();
            cadastroReserva = new CadastroReserva();
            cadastroReserva.Owner = this;
        }

        // Método para incluir uma nova reserva
        public override void Incluir()
        {
            ResetCadastro();
            cadastroReserva.ShowDialog();
        }

        // Método para alterar a reserva selecionada
        public override void Alterar()
        {
            if (dataGridViewReserva.SelectedRows.Count > 0)
            {
                int reserva_ID = (int)dataGridViewReserva.SelectedRows[0].Cells["codigo"].Value;
                CadastroReserva cadastroReserva = new CadastroReserva();
                cadastroReserva.Owner = this;
                cadastroReserva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma reserva para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para excluir a reserva selecionada
        public override void Excluir()
        {
            if (dataGridViewReserva.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir esta reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int reserva_ID = (int)dataGridViewReserva.CurrentRow.Cells["codigo"].Value;
                    controllerReserva.excluir(reserva_ID);
                    AtualizarConsultaReservas(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma reserva para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para pesquisar reservas
        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<Reserva> resultadosPesquisa = controllerReserva.GetAll(btn_buscainativos.Checked)
                        .Where(r => r.nome_cliente.ToLower().Contains(pesquisa.ToLower()) ||
                                    r.celular_cliente.ToLower().Contains(pesquisa.ToLower()) ||
                                    r.numero_quarto.ToLower().Contains(pesquisa.ToLower()))
                        .ToList();

                    dataGridViewReserva.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar reservas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaReservas(btn_buscainativos.Checked);
            }
        }

        // Método para atualizar a lista de reservas no DataGridView
        public void AtualizarConsultaReservas(bool incluirInativos)
        {
            try
            {
                dataGridViewReserva.DataSource = controllerReserva.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de reservas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para resetar o formulário de cadastro
        private void ResetCadastro()
        {
            cadastroReserva.LimparCampos();
        }

        // Evento para sair ou selecionar uma reserva
        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewReserva.SelectedRows.Count > 0)
                {
                    int reserva_ID = Convert.ToInt32(dataGridViewReserva.SelectedRows[0].Cells["codigo"].Value);
                    string nome_cliente = dataGridViewReserva.SelectedRows[0].Cells["nome"].Value.ToString();

                    this.Tag = new Tuple<int, string>(reserva_ID, nome_cliente);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma reserva.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }

   

        private void ConsultaReserva_Load(object sender, EventArgs e)
        {
            try
            {
                CadastroReserva cadastroReserva = new CadastroReserva();
                cadastroReserva.FormClosed += (s, args) => AtualizarConsultaReservas(btn_buscainativos.Checked);

                dataGridViewReserva.AutoGenerateColumns = false;
                dataGridViewReserva.Columns["codigo"].DataPropertyName = "reserva_ID";
                dataGridViewReserva.Columns["nome"].DataPropertyName = "nome_cliente";
                dataGridViewReserva.Columns["quarto"].DataPropertyName = "numero_quarto";
                dataGridViewReserva.Columns["andar"].DataPropertyName = "andar";
                dataGridViewReserva.Columns["checkin"].DataPropertyName = "data_checkin";
                dataGridViewReserva.Columns["checkout"].DataPropertyName = "data_checkout";
                dataGridViewReserva.Columns["telefone"].DataPropertyName = "celular_cliente";

                AtualizarConsultaReservas(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as reservas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
