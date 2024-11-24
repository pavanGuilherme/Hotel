using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.DAO;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaOcupacao : Hotel_Mod.views.ConsultaPai
    {
        private List<Quarto> listaDeQuartos; // Full list of all rooms
        private readonly controllerQuarto<Quarto> controllerQuarto;
        private readonly CadastroQuarto cadastroQuarto;

        public ConsultaOcupacao()
        {
            InitializeComponent();
            controllerQuarto = new controllerQuarto<Quarto>();
            cadastroQuarto = new CadastroQuarto { Owner = this };
            listaDeQuartos = new List<Quarto>(); // Initialize list to avoid null reference
            InitializeDefaultStatus(); // Set default status checkboxes
        }

        private void InitializeDefaultStatus()
        {
            // Set default status checkboxes as checked on form load
            check_livre.Checked = true;
            check_ocupado.Checked = true;
            check_reservado.Checked = true;
            check_preparacao.Checked = true;
        }

        private void newConsultaQuartos_Load(object sender, EventArgs e)
        {
            AtualizarConsultaQuartos(btn_buscainativos.Checked);
            FiltrarQuartos(); // Automatically display rooms on load
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroQuarto.ShowDialog();
            AtualizarConsultaQuartos(btn_buscainativos.Checked);
        }

        public override void Alterar()
        {
            var selectedPanel = GetSelectedPanel();
            if (selectedPanel?.Tag is int quarto_ID)
            {
                using (var editForm = new CadastroQuarto(quarto_ID))
                {
                    editForm.Owner = this;
                    editForm.ShowDialog();
                    AtualizarConsultaQuartos(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um quarto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            var selectedPanel = GetSelectedPanel();
            if (selectedPanel?.Tag is int quarto_ID)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este quarto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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
            string pesquisa = txt_pesquisar.Text.Trim().ToLower();
            var resultadosPesquisa = listaDeQuartos
                .Where(q => q.numero.ToString().Contains(pesquisa) ||
                            (q.tipo ?? "").ToLower().Contains(pesquisa) ||
                            (q.descricao ?? "").ToLower().Contains(pesquisa))
                .ToList();

            AtualizarFlowLayout(resultadosPesquisa);
        }

        private Panel GetSelectedPanel()
        {
            return flowLayoutPanelQuartos.Controls
                   .OfType<Panel>()
                   .FirstOrDefault(p => p.BackColor == Color.LightBlue);
        }

        public void AtualizarConsultaQuartos(bool incluirInativos)
        {
            listaDeQuartos = controllerQuarto.GetAll(incluirInativos);
            FiltrarQuartos();
        }

        private void AtualizarFlowLayout(List<Quarto> quartos)
        {
            flowLayoutPanelQuartos.Controls.Clear();

            foreach (var quarto in quartos)
            {
                var panelQuarto = CreateRoomPanel(quarto);
                flowLayoutPanelQuartos.Controls.Add(panelQuarto);
            }
        }

        private Panel CreateRoomPanel(Quarto quarto)
        {
            var panelQuarto = new Panel
            {
                Size = new Size(150, 160),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Tag = quarto.quarto_ID
            };

            // Adiciona o ícone do quarto
            panelQuarto.Controls.Add(CreateRoomIcon());
            // Adiciona a descrição do quarto
            panelQuarto.Controls.Add(CreateRoomDescription(quarto));
            // Adiciona o número do quarto
            panelQuarto.Controls.Add(CreateRoomNumber(quarto.numero));
            // Adiciona o status do quarto com as cores corretas
            panelQuarto.Controls.Add(CreateRoomStatusLabel(quarto.situacao));
            // Adiciona a data de checkout, se aplicável
            panelQuarto.Controls.Add(CreateRoomCheckoutDate(quarto));

            panelQuarto.Click += (s, e) => HighlightSelectedPanel(panelQuarto);

            return panelQuarto;
        }

        private Label CreateRoomCheckoutDate(Quarto quarto)
        {
            DateTime? checkoutDate = ObterDataCheckoutPrevista(quarto.quarto_ID); // Busca a data de checkout prevista

            return new Label
            {
                Text = checkoutDate.HasValue ? $"Saída: {checkoutDate.Value:dd/MM/yyyy}" : string.Empty,
                Font = new Font("Arial", 9, FontStyle.Regular),
                Location = new Point(5, 130),
                Size = new Size(140, 20),
                ForeColor = Color.DarkGray,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private DateTime? ObterDataCheckoutPrevista(int quartoId)
        {
            controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
            var reserva = reservasController.ObterReservaPorQuarto(quartoId);

            // Retorna a data de checkout, se encontrada
            return reserva?.data_checkout;
        }

        private PictureBox CreateRoomIcon()
        {
            return new PictureBox
            {
                Image = Properties.Resources.cama_icone,                
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(60, 5),
                Size = new Size(30, 30)
            };
        }

        private Label CreateRoomDescription(Quarto quarto)
        {
            return new Label
            {
                Text = $"QUARTO {quarto.numero}\n{quarto.descricao}",
                Location = new Point(5, 40),
                Size = new Size(140, 40),
                Font = new Font("Arial", 8, FontStyle.Regular),
                ForeColor = Color.Blue,
                TextAlign = ContentAlignment.TopCenter
            };
        }

        private Label CreateRoomNumber(int numero)
        {
            return new Label
            {
                Text = numero.ToString(),
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(60, 85),
                Size = new Size(30, 25),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Label CreateRoomStatusLabel(string situacao)
        {
            return new Label
            {
                Text = situacao?.ToUpper(), // Usa o texto de 'situacao' da tabela
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 110),
                Size = new Size(140, 20),
                ForeColor = GetSituacaoColor(situacao), // Define a cor com base no status
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Color GetSituacaoColor(string situacao)
        {
            if (string.IsNullOrEmpty(situacao))
                return Color.Black;

            switch (situacao.ToLower())
            {
                case "livre":
                    return Color.Green;
                case "reservado":
                    return Color.Orange;
                case "check-in":
                    return Color.Blue;
                case "ocupado":
                    return Color.Red;
                case "em preparação":
                    return Color.Purple;
                default:
                    return Color.Black;
            }
        }




        private string ObterStatusReservaPorQuarto(int quartoId)
        {
            controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
            var reserva = reservasController.ObterReservaPorQuarto(quartoId); // Método que retorna a reserva associada ao quarto

            return reserva?.status_reserva; // Retorna o status da reserva, ou null se não houver
        }

        private void HighlightSelectedPanel(Panel panelQuarto)
        {
            foreach (Panel p in flowLayoutPanelQuartos.Controls)
                p.BackColor = p == panelQuarto ? Color.LightBlue : Color.White;
        }

       

        private void FiltrarQuartos()
        {
            // Check if the full list of rooms is loaded
            if (listaDeQuartos == null || listaDeQuartos.Count == 0)
            {
                MessageBox.Show("No rooms found to filter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Collect the selected statuses from the checkboxes
            var statusSelecionados = new List<string>();
            if (check_livre.Checked) statusSelecionados.Add("livre");
            if (check_ocupado.Checked) statusSelecionados.Add("ocupado");
            if (check_reservado.Checked) statusSelecionados.Add("reservado");
            if (check_preparacao.Checked) statusSelecionados.Add("em preparação");

            // Filter the list based on selected statuses
            var quartosFiltrados = listaDeQuartos
                .Where(q => !string.IsNullOrEmpty(q.situacao) && statusSelecionados.Contains(q.situacao.ToLower()))
                .ToList();

            // Display the filtered rooms
            ExibirQuartos(quartosFiltrados);
        }

        private void ExibirQuartos(List<Quarto> quartos)
        {
            flowLayoutPanelQuartos.Controls.Clear();
            foreach (var quarto in quartos)
            {
                var panelQuarto = CreateRoomPanel(quarto);
                flowLayoutPanelQuartos.Controls.Add(panelQuarto);
            }
        }

        private void ResetCadastro()
        {
            cadastroQuarto.LimparCampos();
        }

        private void checkStatus_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarQuartos();
        }

        private void PopulateFloorComboBox()
        {
            comboBoxAndar.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                comboBoxAndar.Items.Add(i);
            }
            comboBoxAndar.SelectedIndex = 0; // Set default selection to the first floor
        }

        private void FiltrarQuartosPorAndar()
        {
            // Get the selected floor from ComboBox
            if (comboBoxAndar.SelectedItem == null) return;
            int selectedFloor = Convert.ToInt32(comboBoxAndar.SelectedItem);

            // Filter rooms by the selected floor
            var quartosFiltrados = listaDeQuartos
                .Where(q => q.andar == selectedFloor)
                .ToList();

            ExibirQuartos(quartosFiltrados); // Display filtered rooms
        }


        private void newConsultaQuartos_Load_1(object sender, EventArgs e)
        {
            // Initialize the default status checkboxes (if not already checked in the designer)
            check_livre.Checked = true;
            check_ocupado.Checked = true;
            check_reservado.Checked = true;
            check_preparacao.Checked = true;

            PopulateFloorComboBox();

            // Load all rooms, including active and inactive if specified
            AtualizarConsultaQuartos(btn_buscainativos.Checked);

            // Apply initial filter to display all rooms on load
            FiltrarQuartos();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            FiltrarQuartos();
        }

        private void comboBoxAndar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarQuartosPorAndar();
        }


        private void AtualizarQuartoParaLivre(int quartoId)
        {
            controllerQuarto<Quarto> quartoController = new controllerQuarto<Quarto>();
            quartoController.AtualizarStatusQuarto(quartoId, "Em preparação");
        }

        private void AtualizarReservaParaCheckout(int reservaId)
        {
            controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
            reservasController.AtualizarStatusReserva(reservaId, "Checkout");
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            var selectedPanel = GetSelectedPanel(); // Obtém o quarto selecionado
            if (selectedPanel?.Tag is int quartoId)
            {
                try
                {
                    controllerReservas<Reserva> reservasController = new controllerReservas<Reserva>();
                    var reserva = reservasController.ObterReservaPorQuarto(quartoId);

                    if (reserva == null || reserva.status_reserva != "Check-in")
                    {
                        MessageBox.Show("Nenhuma reserva ativa encontrada para este quarto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (var cadastroReserva = new CadastroReserva())
                    {
                        cadastroReserva.CarregarReserva(reserva.reserva_ID);

                        // Verifica se é um checkout antecipado
                        if (DateTime.Now.Date < reserva.data_checkout.Value.Date)
                        {
                            MessageBox.Show("Checkout antecipado detectado. Ajuste a data de checkout no formulário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cadastroReserva.AjustarDataCheckout(DateTime.Now.Date);
                        }

                        var result = cadastroReserva.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            AtualizarQuartoParaLivre(quartoId);
                            AtualizarReservaParaCheckout(reserva.reserva_ID);
                            AtualizarConsultaQuartos(btn_buscainativos.Checked);

                            MessageBox.Show("Checkout realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao realizar o checkout: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um quarto para realizar o checkout.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

