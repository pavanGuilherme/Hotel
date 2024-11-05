using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class newConsultaQuartos : Hotel_Mod.views.ConsultaPai
    {
      
        private controllerQuarto<Quarto> controllerQuarto;
        private CadastroQuarto cadastroQuarto;

        public newConsultaQuartos()
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
            AtualizarConsultaQuartos(btn_buscainativos.Checked); // Atualiza após incluir
        }

        public override void Alterar()
        {
            var panel = flowLayoutPanelQuartos.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.LightBlue); // Exemplo de seleção pelo destaque

            if (panel != null && panel.Tag is int quarto_ID)
            {
                using (CadastroQuarto cadastroQuarto = new CadastroQuarto(quarto_ID))
                {
                    cadastroQuarto.Owner = this;
                    cadastroQuarto.ShowDialog();
                    AtualizarConsultaQuartos(btn_buscainativos.Checked); // Atualiza após alterar
                }
            }
            else
            {
                MessageBox.Show("Selecione um quarto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public override void Excluir()
        {
            var selectedPanel = flowLayoutPanelQuartos.Controls.OfType<Panel>().FirstOrDefault(p => p.BackColor == Color.LightBlue); // ou outra forma de seleção
            if (selectedPanel != null)
            {
                int quarto_ID = (int)selectedPanel.Tag;
                if (MessageBox.Show("Tem certeza de que deseja excluir este quarto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    controllerQuarto.excluir(quarto_ID);
                    AtualizarConsultaQuartos(btn_buscainativos.Checked); // Atualiza após excluir
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
            var resultadosPesquisa = controllerQuarto.GetAll(btn_buscainativos.Checked)
                .Where(q => q.numero.ToString().Contains(pesquisa) ||
                            q.tipo.ToLower().Contains(pesquisa.ToLower()) ||
                            q.descricao.ToLower().Contains(pesquisa.ToLower()))
                .ToList();

            AtualizarFlowLayout(resultadosPesquisa); // Atualiza com os resultados da pesquisa
        }

        public void AtualizarConsultaQuartos(bool incluirInativos)
        {
            var quartos = controllerQuarto.GetAll(incluirInativos);
            AtualizarFlowLayout(quartos);
        }

        private void AtualizarFlowLayout(List<Quarto> quartos)
        {
            flowLayoutPanelQuartos.Controls.Clear(); // Limpa os panels antigos

            foreach (var quarto in quartos)
            {
                // Cria um Panel para cada quarto
                Panel panelQuarto = new Panel
                {
                    Size = new Size(150, 120), // Ajuste o tamanho conforme necessário
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = quarto.disponivel ? Color.White : Color.LightGray,
                    Tag = quarto.quarto_ID // Armazena o ID do quarto no Tag
                };

                // Adiciona o PictureBox para o ícone da cama
                PictureBox pictureBoxIcone = new PictureBox
                {
                    Image = Properties.Resources.cama_icone, // Use o recurso de imagem do ícone
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10),
                    Size = new Size(30, 30)
                };
                panelQuarto.Controls.Add(pictureBoxIcone);

                // Adiciona a descrição completa do quarto
                Label labelDescricao = new Label
                {
                    Text = $"QUARTO {quarto.numero} {quarto.descricao}",
                    Location = new Point(50, 10),
                    Size = new Size(90, 50), // Ajuste conforme necessário
                    Font = new Font("Arial", 8, FontStyle.Regular),
                    ForeColor = Color.Blue
                };
                panelQuarto.Controls.Add(labelDescricao);

                // Adiciona o número do quarto (em destaque)
                Label labelNumero = new Label
                {
                    Text = quarto.numero.ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(10, 70),
                    ForeColor = Color.DarkBlue
                };
                panelQuarto.Controls.Add(labelNumero);

                // Adiciona o status do quarto (Livre/Reservado/Ocupado) em destaque
                Label labelStatus = new Label
                {
                    Text = quarto.disponivel ? "LIVRE" : "OCUPADO",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(10, 90),
                    ForeColor = quarto.disponivel ? Color.Green : Color.Red
                };
                panelQuarto.Controls.Add(labelStatus);

                // Adiciona o Panel ao FlowLayoutPanel
                flowLayoutPanelQuartos.Controls.Add(panelQuarto);

                // Event handler para selecionar um panel ao clicar
                panelQuarto.Click += (s, e) =>
                {
                    foreach (Panel p in flowLayoutPanelQuartos.Controls)
                        p.BackColor = p.Tag is int id && id == quarto.quarto_ID ? Color.LightBlue : (quarto.disponivel ? Color.White : Color.LightGray);
                };
            }
        }


        private void ResetCadastro()
        {
            cadastroQuarto.LimparCampos();
        }

  

        private void newConsultaQuartos_Load_1(object sender, System.EventArgs e)
        {
            AtualizarConsultaQuartos(btn_buscainativos.Checked);
        }

        private void ExibirQuartos(List<Quarto> quartosFiltrados)
        {
            // Limpe a exibição atual do FlowLayoutPanel
            flowLayoutPanelQuartos.Controls.Clear();

            foreach (var quarto in quartosFiltrados)
            {
                // Crie um Panel para cada quarto
                var panelQuarto = new Panel
                {
                    Width = 100, // Defina a largura desejada
                    Height = 100, // Defina a altura desejada
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Crie um Label para exibir o número do quarto
                var labelNumero = new Label
                {
                    Text = $"Quarto {quarto.numero}",
                    AutoSize = true,
                    Location = new Point(10, 10) // Posição dentro do Panel
                };
                panelQuarto.Controls.Add(labelNumero);

                // Crie um Label para exibir o status do quarto
                var labelStatus = new Label
                {
                    Text = $"Status: {quarto.status}",
                    AutoSize = true,
                    Location = new Point(10, 30) // Posição dentro do Panel
                };
                panelQuarto.Controls.Add(labelStatus);

                // Adicione o Panel do quarto ao FlowLayoutPanel
                flowLayoutPanelQuartos.Controls.Add(panelQuarto);
            }
        }



        private void FiltrarQuartos()
        {
            // Obtenha a lista de status selecionados
            var statusSelecionados = new List<string>();

            if (check_livre.Checked) statusSelecionados.Add("Livre");
            if (check_ocupado.Checked) statusSelecionados.Add("Ocupado");
            if (check_reservado.Checked) statusSelecionados.Add("Reservado");

            // Filtre os quartos com base no status selecionado
            var quartosFiltrados = Quarto.Where(q => statusSelecionados.Contains(q.Status)).ToList();

            // Exiba os quartos filtrados (crie um método para atualizar a interface)
            ExibirQuartos(quartosFiltrados);
        }

        private void check_livre_CheckedChanged(object sender, System.EventArgs e)
        {

        }
    }
}

