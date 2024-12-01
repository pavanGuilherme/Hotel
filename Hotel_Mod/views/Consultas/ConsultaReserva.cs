using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.DAO;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaReserva : Hotel_Mod.views.ConsultaPai
    {
        private controllerReservas<Reserva> controllerReserva;
        private CadastroReserva cadastroReserva;
        private DaoQuarto<Quarto> daoQuarto;
        private DaoReserva<Reserva> daoReserva;


        public ConsultaReserva()
        {
            InitializeComponent();
            controllerReserva = new controllerReservas<Reserva>();
            cadastroReserva = new CadastroReserva();
            daoQuarto = new DaoQuarto<Quarto>();
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
                int reserva_id = (int)dataGridViewReserva.SelectedRows[0].Cells["codigo"].Value;

                using (var cadastroReserva = new CadastroReserva(reserva_id))
                {
                    //cadastroReserva.Owner = this;
                    cadastroReserva.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Selecione um tipo de quarto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de quartos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Configuração do DataGridView
                dataGridViewReserva.AutoGenerateColumns = false;
                dataGridViewReserva.Columns["codigo"].DataPropertyName = "reserva_ID";
                dataGridViewReserva.Columns["nome"].DataPropertyName = "nome_cliente";
                dataGridViewReserva.Columns["TipoQuarto_id"].DataPropertyName = "tipo_quarto_id";
                dataGridViewReserva.Columns["quarto"].DataPropertyName = "numero_quarto";
                dataGridViewReserva.Columns["andar"].DataPropertyName = "andar";
                dataGridViewReserva.Columns["status_reserva"].DataPropertyName = "status_reserva";
                dataGridViewReserva.Columns["checkin"].DataPropertyName = "data_checkin";
                dataGridViewReserva.Columns["checkout"].DataPropertyName = "data_checkout";
                dataGridViewReserva.Columns["telefone"].DataPropertyName = "celular_cliente";

                AtualizarConsultaReservas(btn_buscainativos.Checked);

                // Chama o método para pintar as reservas
                //PintarReservasComCheckin();

                //dataGridViewReserva.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as reservas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PintarReservasComCheckin(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewReserva.Rows)
            {
                var statusValue = row.Cells["status_reserva"].Value;

                // Verifica se a célula 'status_reserva' contém o valor 'Check-in'
                if (statusValue != null && statusValue.ToString() == "Check-in")
                {
                    // Pinta a célula 'checkin' de verde
                    row.Cells["checkin"].Style.ForeColor = Color.Green;

                    // Pinta a célula 'status_reserva' de verde
                    row.Cells["status_reserva"].Style.ForeColor = Color.Green;
                }
                // Verifica se a célula 'status_reserva' contém o valor 'Check-out'
                else if (statusValue != null && statusValue.ToString() == "Checkout")
                {
                    // Pinta a célula 'checkout' de vermelho
                    row.Cells["checkout"].Style.ForeColor = Color.Red;

                    // Pinta a célula 'status_reserva' de vermelho
                    row.Cells["status_reserva"].Style.ForeColor = Color.Red;
                }
                else if (statusValue != null && statusValue.ToString() == "Reservado")
                {
               
                    // Pinta a célula 'status_reserva' de vermelho
                    row.Cells["status_reserva"].Style.ForeColor = Color.Blue;
                }

            }
        }




        private void btn_checkin_Click(object sender, EventArgs e)
        {
            // Verifica se uma reserva está selecionada no DataGridView
            if (dataGridViewReserva.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma reserva antes de realizar o check-in!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o ID, tipo de quarto e data de check-in da reserva selecionada
            int reservaId = Convert.ToInt32(dataGridViewReserva.SelectedRows[0].Cells["codigo"].Value);
            int tipoQuarto_id = Convert.ToInt32(dataGridViewReserva.SelectedRows[0].Cells["TipoQuarto_id"].Value);
            DateTime dataCheckinPrevista = Convert.ToDateTime(dataGridViewReserva.SelectedRows[0].Cells["checkin"].Value);

            // Validação: Não permitir check-in antes ou depois da data prevista
            if (DateTime.Now.Date < dataCheckinPrevista.Date)
            {
                MessageBox.Show($"O check-in só pode ser realizado a partir de {dataCheckinPrevista:dd/MM/yyyy}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DateTime.Now.Date > dataCheckinPrevista.Date)
            {
                MessageBox.Show($"O check-in está atrasado. A data prevista era {dataCheckinPrevista:dd/MM/yyyy}.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Abre o formulário de consulta de quartos
                using (ConsultaQuarto consultaQuarto = new ConsultaQuarto
                {
                    tipoQuarto_id = tipoQuarto_id, // Define o tipo de quarto
                    btn_alterar = { Visible = false },
                    btn_excluir = { Visible = false },
                    btn_incluir = { Visible = false },
                    btn_buscainativos = { Visible = false },
                    btn_sair = { Text = "Selecionar Quarto" }
                })
                {
                    // Exibe o formulário e aguarda o resultado
                    var resultado = consultaQuarto.ShowDialog();
                    consultaQuarto.btn_sair.Text = "Sair"; // Redefine o texto do botão

                    // Verifica se um quarto foi selecionado no formulário
                    if (resultado == DialogResult.OK)
                    {
                        // Obtém os valores do quarto selecionado
                        int quartoId = consultaQuarto.QuartoSelecionado;
                        int numero = consultaQuarto.NumeroQuartoSelecionado;
                        int andar = consultaQuarto.AndarQuartoSelecionado;

                        // Atualiza o status do quarto para "ocupado"
                        controllerQuarto<Quarto> quartosController = new controllerQuarto<Quarto>();
                        quartosController.AtualizarStatusQuarto(quartoId, "ocupado");

                        // Vincula o quarto à reserva no banco de dados
                        controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
                        reservasController.AtualizarReservaComQuarto(reservaId, quartoId, numero, andar);

                        // Atualiza o status da reserva para "Check-in"
                        reservasController.AtualizarStatusReserva(reservaId, "Check-in");

                        // Exibe mensagem de sucesso
                        MessageBox.Show("Check-in realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza a lista de reservas
                        AtualizarConsultaReservas(btn_buscainativos.Checked);

                        // Alterar a cor da célula de check-in para verde
                        foreach (DataGridViewRow row in dataGridViewReserva.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["codigo"].Value) == reservaId)
                            {
                                row.Cells["checkin"].Style.BackColor = Color.LightGreen;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum quarto foi selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro em caso de falha
                MessageBox.Show($"Erro ao realizar o check-in: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridViewReserva_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewReserva.SelectedRows.Count != 0)
            {
                string status = dataGridViewReserva.SelectedRows[0].Cells["status_reserva"].Value.ToString();
                if (status == "Check-in")
                    this.btn_excluir.Enabled = false;
                else
                    this.btn_excluir.Enabled = true;
            }
        }

        private void btn_cancelar_reserva_Click(object sender, EventArgs e)
        {
            if (dataGridViewReserva.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma reserva antes de cancelar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservaId = Convert.ToInt32(dataGridViewReserva.SelectedRows[0].Cells["codigo"].Value);
            string statusReserva = dataGridViewReserva.SelectedRows[0].Cells["status_reserva"].Value.ToString();


            // Validação do status da reserva
            if (statusReserva != "Reservado")
            {
                MessageBox.Show("NÃO É POSSÍVEL CANCELAR ESSA RESERVA", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Tem certeza de que deseja cancelar esta reserva?",
                "Confirmação de Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Atualiza o status da reserva no banco
                    controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
                    reservasController.CancelarReserva(reservaId);

                 

                    // Atualiza o DataGridView
                    AtualizarConsultaReservas(btn_buscainativos.Checked);

                    // Mensagem de sucesso
                    MessageBox.Show("Reserva cancelada com sucesso e situação do quarto atualizada para 'Livre'!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cancelar a reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
