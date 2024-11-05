using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.DAO;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroReserva : Hotel_Mod.views.CadastroPai
    {
        private ConsultaCliente consultaCliente;
        private controllerReservas<Reserva> controllerReservas;
        private controllerCliente<Cliente> controllerCliente;
        private DaoReserva<Reserva> daoReserva;
        private ConsultaCondPagamento consultaCondPagamento;
        private controllerCondPagamento<CondicaoPagamento> ControllerCondPagamento;
        private ConsultaQuarto consultaQuarto;
        private ControllerFormaPagamento<FormaPagamento> controllerFormaPagamento;
        private ConsultaFormaPagamento consultaFormaPagamento;
        private controllerQuarto<Quarto> controllerQuarto;

        private ConsultaHospede consultaHospede;
        private controllerHospede<Hospede> controllerHospede;

        decimal juros;
        decimal descontos;
        decimal multa;

        string dataPainel;

        Int32 mes;
        Int32 diasMes;

        private int quartoId;





        public CadastroReserva()
        {
            InitializeComponent();

            // Populando o ano e mês na inicialização
            Populartxt_mesAno();
            dtp_checkin.ValueChanged += dtp_checkin_ValueChanged_1;
            dtp_checkout.ValueChanged += dtp_checkout_ValueChanged;

            consultaFormaPagamento = new ConsultaFormaPagamento();
            controllerFormaPagamento = new ControllerFormaPagamento<FormaPagamento>();

            consultaCliente = new ConsultaCliente();
            controllerCliente = new controllerCliente<Cliente>();

            controllerReservas = new controllerReservas<Reserva>();

            consultaCondPagamento = new ConsultaCondPagamento();
            ControllerCondPagamento = new controllerCondPagamento<CondicaoPagamento>();

            consultaQuarto = new ConsultaQuarto();
            controllerQuarto = new controllerQuarto<Quarto>();

            consultaHospede = new ConsultaHospede();
            controllerHospede = new controllerHospede<Hospede>();

        }

        private void AtualizarNumeroDeDias()
        {

            DateTime checkinDate = dtp_checkin.Value.Date;
            DateTime checkoutDate = dtp_checkout.Value.Date;

            if (checkoutDate > checkinDate)
            {
                TimeSpan difference = checkoutDate - checkinDate;
                txt_num_dias.Text = difference.Days.ToString();
            }
            else
            {
                txt_num_dias.Text = "0";
            }
        }

        public override void LimparCampos()
        {
            base.LimparCampos();
            txt_numero.Clear();
            txt_num_dias.Clear();

            txt_numero.Clear();
            txt_nome_cliente.Clear();
            txt_cpf.Clear();
            txt_telefone.Clear();
            txt_cod_quarto.Clear();
            txt_numero.Clear();
            txt_andar.Clear();
            txt_valor_diaria.Clear();
            txt_num_dias.Clear();
            txt_valor_total.Clear();
            check_ativo.Checked = true;
            check_inativo.Checked = false;
            txt_cod_cond_pagamento.Clear();
            txt_cond_pagamento.Clear();
            dataGridView_parcelas.Rows.Clear();

        }

        private void btn_busca_cod_cliente_Click(object sender, EventArgs e)
        {

            consultaCliente.btn_sair.Text = "Selecionar";

            if (consultaCliente.ShowDialog() == DialogResult.OK)
            {
                var clienteDetalhes = consultaCliente.Tag as Tuple<int, string, string, string>;

                if (clienteDetalhes != null)
                {
                    int cliente_ID = clienteDetalhes.Item1;
                    string nome = clienteDetalhes.Item2;
                    string cpf = clienteDetalhes.Item3;
                    string celular = clienteDetalhes.Item4;

                    txt_cod_cliente.Text = cliente_ID.ToString();
                    txt_nome_cliente.Text = nome;
                    txt_cpf.Text = cpf;
                    txt_telefone.Text = celular;

                    Cliente ClienteDetalhes = controllerCliente.GetById(cliente_ID);
                    if (ClienteDetalhes != null)
                        txt_cod_cliente.Text = ClienteDetalhes.cliente_ID.ToString();
                }
            }
        }

        private void btn_busca_cod_quarto_Click(object sender, EventArgs e)
        {
            if (txt_num_dias.Text == null)
            {
                MessageBox.Show("Escolha uma data para verificar se o quarto está disponivel !");
            }
            consultaQuarto.btn_sair.Text = "Selecionar";

            if (consultaQuarto.ShowDialog() == DialogResult.OK)
            {
                var quartoDetalhes = consultaQuarto.Tag as Tuple<int, int, int, decimal, string>;

                if (quartoDetalhes != null)
                {
                    int quarto_ID = quartoDetalhes.Item1;
                    int numero = quartoDetalhes.Item2;
                    int andar = quartoDetalhes.Item3;
                    decimal valorDiaria = quartoDetalhes.Item4;
                    string tipo = quartoDetalhes.Item5;

                    txt_cod_quarto.Text = quarto_ID.ToString();
                    txt_numero.Text = numero.ToString();
                    txt_andar.Text = andar.ToString();
                    txt_valor_diaria.Text = valorDiaria.ToString();
                    txt_tipo_quarto.Text = tipo.ToString();

                    Quarto QuartoDetalhes = controllerQuarto.GetById(quarto_ID);
                    if (QuartoDetalhes != null)
                        txt_cod_quarto.Text = QuartoDetalhes.quarto_ID.ToString();
  
                }
            }
        }

        private void btn_cancelar_reserva_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar esta reserva?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Suponha que o ID da reserva seja obtido de algum campo
                int reservaId = int.Parse(txt_codigo.Text);

                // Chama o método CancelarReserva e verifica o resultado
                bool sucesso = controllerReservas.CancelarReserva(reservaId);

                if (sucesso)
                {
                    MessageBox.Show("Reserva cancelada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    lbl_cancelada.Visible = true;
                    lbl_data_cancelamento.Visible = true;
                    txt_data_cancelamento.Visible = true;
                }
                else
                {
                    MessageBox.Show("Falha ao cancelar a reserva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dtp_checkout_ValueChanged(object sender, EventArgs e)
        {
            AtualizarNumeroDeDias();
            //ValidarDatas();
            CalcularValorTotal();   

        }
        private void dtp_checkin_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime datacheckin = dtp_checkin.Value;
            AtualizarNumeroDeDias();
            //ValidarDatas();
            ValidarDataCheckIn(datacheckin);
        }

        private bool ValidarDataCheckIn(DateTime dataCheckIn)
        {
            DateTime dataAtual = DateTime.Now.Date;

            if (dataCheckIn < dataAtual)
            {
                MessageBox.Show("A data de check-in não pode ser anterior à data atual.", "Data Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //private void ValidarDatas()
        //{
        //    DateTime checkinDate = dtp_checkin.Value;
        //    DateTime checkoutDate = dtp_checkout.Value;

        //    if (checkinDate > checkoutDate)
        //    {
        //        MessageBox.Show("A data de check-in não pode ser maior que a data de check-out.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        dtp_checkin.Value = dtp_checkout.Value;
        //    }
        //}

        private void CadastroReserva_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerReservas.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }


            foreach (Control control in this.Controls)
            {
                if (control is Label label && label.Tag?.ToString() == "Dia")
                {
                    label.Click += lbl_1_Click;
                }
            }


            dtp_checkout.Value = DateTime.Now.AddDays(7);

            
        }

        private void btn_busca_cond_pagamento_Click(object sender, EventArgs e)
        {
            consultaCondPagamento.btn_sair.Text = "Selecionar";
            consultaCondPagamento.btn_buscainativos.Visible = false;

            if (consultaCondPagamento.ShowDialog() == DialogResult.OK)
            {
                var condPagamento = consultaCondPagamento.Tag as Tuple<int, string>;
                if (condPagamento != null)
                {
                    int idCondPag = condPagamento.Item1;
                    string condicaoPagamento = condPagamento.Item2;

                    txt_cod_cond_pagamento.Text = idCondPag.ToString();
                    txt_cond_pagamento.Text = condicaoPagamento;
                }
            }
        }
        private void exibirParcelasDGV(List<parcela> parcelas)
        {
            dataGridView_parcelas.Rows.Clear();

            DateTime dataCheckin;
            decimal valorTotal;
            if (DateTime.TryParse(dtp_checkin.Text, out dataCheckin) && decimal.TryParse(txt_valor_total.Text, out valorTotal))
            {
                decimal somaParcelas = 0m;
                for (int i = 0; i < parcelas.Count; i++)
                {
                    var parcela = parcelas[i]; //parcela atual
                    int codFormaPagamento = parcela.FormaPagamento_ID;
                    string formaPagamento = ControllerCondPagamento.GetFormaPagByParcelaId(parcela.parcela_ID);
                    DateTime dataParcela = dataCheckin.AddDays(parcela.dias);
                    decimal valorParcela;

                    if (i == parcelas.Count - 1) //se for a ultima parcela
                    {
                        //para a última parcela, subtrai o valor das parcelas anteriores    
                        //assim nao corre o risco do valor final nao ser igual ao valor total
                        valorParcela = valorTotal - somaParcelas;
                    }
                    else
                    { //se nao for a ultima, faz a conta normal de acordo com a porcentagem do contas a pagar
                        valorParcela = Math.Round((valorTotal * parcela.porcentagem) / 100, 2);
                        somaParcelas += valorParcela;
                    }

                    dataGridView_parcelas.Rows.Add(
                        parcela.numeroParcela,
                        codFormaPagamento,
                        formaPagamento,
                        dataParcela.ToString("dd/MM/yyyy"),
                        valorParcela.ToString("F2")
                    );
                }
            }
            else
            {
                MessageBox.Show("Data de emissão ou valor total inválido.");
            }
        }

        private void btn_add_cond_pag_Click(object sender, EventArgs e)
        {
            CondicaoPagamento condPagamento = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));
            juros = condPagamento.juros;
            multa = condPagamento.multa;
            descontos = condPagamento.desconto;


            exibirParcelasDGV(condPagamento.parcelas);
        }




        private void Populartxt_mesAno()
        {
            // Populando o ComboBox de Anos com ano mínimo de 2024
            comboBox_ano.Items.Clear();
            int anoAtual = DateTime.Now.Year;
            int anoMinimo = 2024;

            for (int i = anoMinimo; i <= anoAtual + 5; i++) // Ajuste o intervalo de anos conforme necessário
            {
                comboBox_ano.Items.Add(i);
            }

            // Seleciona o ano atual por padrão, garantindo que há um valor selecionado
            comboBox_ano.SelectedItem = anoAtual;

            // Atualizar o ComboBox de meses com base no ano selecionado
            AtualizarMeses();

            // Associar evento de mudança ao ComboBox de ano para atualizar os meses
            comboBox_ano.SelectedIndexChanged += (sender, e) => AtualizarMeses();
        }

        private void AtualizarMeses()
        {
            comboBox_mes.Items.Clear();

            // Verificar se comboBox_ano.SelectedItem não é nulo
            if (comboBox_ano.SelectedItem == null)
            {
                return; // Se for nulo, sai da função, pois não podemos definir os meses ainda
            }

            int anoSelecionado = (int)comboBox_ano.SelectedItem;

            // Popula todos os meses de 1 a 12 com números
            for (int i = 1; i <= 12; i++)
            {
                comboBox_mes.Items.Add(i); // Adiciona o número do mês
            }

            // Selecionar automaticamente o primeiro mês disponível, se houver
            if (comboBox_mes.Items.Count > 0)
            {
                comboBox_mes.SelectedIndex = 0;
            }
        }




        private void AtualizarDisponibilidade()
        {
            int mes = int.Parse(comboBox_mes.SelectedItem.ToString());
            int ano = int.Parse(comboBox_ano.SelectedItem.ToString());

            DateTime dataInicio = new DateTime(ano, mes, 1);
            DateTime dataFim = dataInicio.AddMonths(1).AddDays(-1); // Último dia do mês

            AtualizarDisponibilidadeLabels(quartoId, dataInicio, dataFim);
        }

        private void lbl_1_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int dia;
                if (int.TryParse(label.Text, out dia))
                {
                    // Verifica se o controle de ano tem um valor numérico válido
                    if (int.TryParse(comboBox_ano.Text, out int anoSelecionado) && comboBox_mes.SelectedItem != null)
                    {
                        // Garante que o mês é extraído corretamente
                        int mesSelecionado = comboBox_mes.SelectedIndex + 1; // Índice começa em 0, então somamos 1

                        try
                        {
                            // Cria a data com o ano, mês selecionado e o dia do label
                            DateTime dataSelecionada = new DateTime(anoSelecionado, mesSelecionado, dia);
                            string numQuarto = txt_numero.Text;

                            if (!string.IsNullOrEmpty(numQuarto))
                            {
                                // Verifica se a data já foi adicionada à DataGridView
                                bool dataJaAdicionada = false;
                                foreach (DataGridViewRow row in dataGridView_datas.Rows)
                                {
                                    if (row.Cells[1].Value?.ToString() == dataSelecionada.ToString("dd/MM/yyyy") &&
                                        row.Cells[0].Value?.ToString() == numQuarto)
                                    {
                                        dataJaAdicionada = true;
                                        break;
                                    }
                                }

                                if (!dataJaAdicionada)
                                {
                                    // Verifica se a data está disponível antes de adicioná-la à DataGridView
                                    if (label.BackColor == Color.Green)
                                    {
                                        dataGridView_datas.Rows.Add(numQuarto, dataSelecionada.ToString("dd/MM/yyyy"));
                                        label.BackColor = Color.Orange; // Marca como selecionada
                                    }
                                    else
                                    {
                                        MessageBox.Show("Esta data já está ocupada. Escolha uma data disponível.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Esta data já foi adicionada.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor, insira o número do quarto.");
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("O dia selecionado é inválido para o mês/ano fornecido.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecione um ano e um mês válidos.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao converter o dia.");
                }
            }

        }

        private void AtualizarDisponibilidadeLabels(int quartoId, DateTime dataInicio, DateTime dataFim)
        {
            List<DateTime> datasIndisponiveis = controllerReservas.ObterDatasIndisponiveis(quartoId, dataInicio, dataFim);

            foreach (Control control in GetAllControls(this))
            {
                if (control is Label label && label.Tag?.ToString() == "Dia")
                {
                    int dia;
                    if (int.TryParse(label.Text, out dia))
                    {
                        DateTime dataLabel = new DateTime(dataInicio.Year, dataInicio.Month, dia);

                        // Encontra o painel pai da label
                        Panel panel = label.Parent as Panel;

                        if (datasIndisponiveis.Contains(dataLabel))
                        {
                            label.BackColor = Color.Red; // Cor para datas ocupadas
                            label.ForeColor = Color.White;

                            if (panel != null)
                            {
                                panel.BackColor = Color.Red; // Cor para o painel ocupado
                            }
                        }
                        else
                        {
                            label.BackColor = Color.Green; // Cor para datas disponíveis
                            label.ForeColor = Color.Black;

                            if (panel != null)
                            {
                                panel.BackColor = Color.Green; // Cor para o painel disponível
                            }
                        }
                    }
                }
            }
        }


        // Método auxiliar para obter todos os controles recursivamente
        private IEnumerable<Control> GetAllControls(Control control)
        {
            foreach (Control child in control.Controls)
            {
                foreach (Control grandChild in GetAllControls(child))
                {
                    yield return grandChild;
                }
                yield return child;
            }
        }

        private void txt_cod_quarto_TextChanged(object sender, EventArgs e)
        {
            int quartoId;
            if (int.TryParse(txt_cod_quarto.Text, out quartoId))
            {
                DateTime dataInicio = new DateTime(int.Parse(comboBox_ano.Text), comboBox_mes.SelectedIndex + 1, 1);
                DateTime dataFim = dataInicio.AddMonths(1).AddDays(-1);

                AtualizarDisponibilidadeLabels(quartoId, dataInicio, dataFim);
            }
            else
            {
                MessageBox.Show("Insira um número de quarto válido.");
            }
        }

        private void AdicionarDataGridView(Label label)
        {
            int dia;
            if (int.TryParse(label.Text, out dia))
            {
                // Verifica se o controle de ano tem um valor numérico válido
                if (int.TryParse(comboBox_ano.Text, out int anoSelecionado) && comboBox_mes.SelectedItem != null)
                {
                    // Garante que o mês é extraído corretamente
                    int mesSelecionado = comboBox_mes.SelectedIndex + 1; // Índice começa em 0, então somamos 1

                    try
                    {
                        // Cria a data com o ano, mês selecionado e o dia do label
                        DateTime dataSelecionada = new DateTime(anoSelecionado, mesSelecionado, dia);
                        string numQuarto = txt_numero.Text;

                        if (!string.IsNullOrEmpty(numQuarto))
                        {
                            // Verifica se a data já foi adicionada à DataGridView
                            bool dataJaAdicionada = false;
                            foreach (DataGridViewRow row in dataGridView_datas.Rows)
                            {
                                if (row.Cells[1].Value?.ToString() == dataSelecionada.ToString("dd/MM/yyyy") &&
                                    row.Cells[0].Value?.ToString() == numQuarto)
                                {
                                    dataJaAdicionada = true;
                                    break;
                                }
                            }

                            if (!dataJaAdicionada)
                            {
                                // Verifica se a data está disponível antes de adicioná-la à DataGridView
                                if (label.BackColor == Color.Green)
                                {
                                    dataGridView_datas.Rows.Add(numQuarto, dataSelecionada.ToString("dd/MM/yyyy"));
                                    label.BackColor = Color.Orange; // Marca como selecionada

                                    // Muda a cor do panel que contém a label
                                    if (label.Parent is Panel panel)
                                    {
                                        panel.BackColor = Color.Orange;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Esta data já está ocupada. Escolha uma data disponível.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira o número do quarto.");
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("O dia selecionado é inválido para o mês/ano fornecido.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um ano e um mês válidos.");
                }
            }
            else
            {
                MessageBox.Show("Erro ao converter o dia.");
            }

        }

        private void RemoverDataGridView(Label label)
        {
            int dia;
            if (int.TryParse(label.Text, out dia))
            {
                if (int.TryParse(comboBox_ano.Text, out int anoSelecionado) && comboBox_mes.SelectedItem != null)
                {
                    int mesSelecionado = comboBox_mes.SelectedIndex + 1; // Índice começa em 0, então somamos 1
                    DateTime dataSelecionada = new DateTime(anoSelecionado, mesSelecionado, dia);
                    string dataFormatada = dataSelecionada.ToString("dd/MM/yyyy");
                    string numQuarto = txt_numero.Text;

                    // Procura a data na DataGridView e remove a linha correspondente
                    foreach (DataGridViewRow row in dataGridView_datas.Rows)
                    {
                        if (row.Cells[1].Value?.ToString() == dataFormatada &&
                            row.Cells[0].Value?.ToString() == numQuarto)
                        {
                            dataGridView_datas.Rows.Remove(row);
                            label.BackColor = Color.Green; // Marca a data como disponível novamente

                            // Verifica se a label tem um Panel como pai e muda a cor do Panel
                            if (label.Parent is Panel panel)
                            {
                                panel.BackColor = Color.Green; // Marca o Panel como disponível novamente
                            }

                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um ano e um mês válidos.");
                }
            }
            else
            {
                MessageBox.Show("Erro ao converter o dia.");
            }

        }

        private void SetCheckInCheckOutDates()
        {
            DateTime? minDate = null;
            DateTime? maxDate = null;

            foreach (DataGridViewRow row in dataGridView_datas.Rows)
            {
                if (row.Cells["Data"].Value != null && DateTime.TryParse(row.Cells["Data"].Value.ToString(), out DateTime date))
                {
                    if (!minDate.HasValue || date < minDate.Value)
                    {
                        minDate = date;
                    }
                    if (!maxDate.HasValue || date > maxDate.Value)
                    {
                        maxDate = date;
                    }
                }
            }

            if (minDate.HasValue && maxDate.HasValue)
            {
                dtp_checkin.Value = minDate.Value; 
                dtp_checkout.Value = maxDate.Value; 
            }
            else
            {
                MessageBox.Show("Nenhuma data válida encontrada na tabela.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            consultaHospede.btn_sair.Text = "Selecionar";
            consultaHospede.btn_buscainativos.Visible = false;

            if (consultaHospede.ShowDialog() == DialogResult.OK)
            {
                var hospede = consultaHospede.Tag as Tuple<int, string>;
                if (hospede != null)
                {
                    int hospede_id = hospede.Item1;
                    string nome = hospede.Item2;

                    txt_cod_hospede.Text = hospede_id.ToString();
                    txt_hospede.Text = nome;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int hospedeId = int.Parse(txt_cod_hospede.Text);
                Hospede hospede = controllerHospede.GetById(hospedeId);

                if (hospede != null)
                {
                    // Adiciona o hóspede diretamente à DataGridView sem limpar as linhas existentes
                    dataGridView_hospedes.Rows.Add(
                        hospede.hospede_id,
                        hospede.nome
                    );
                }
                else
                {
                    MessageBox.Show("Hóspede não encontrado.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Código do hóspede inválido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

            txt_cod_hospede.Clear();
            txt_hospede.Clear();

        }

        private void lbl_1_Click_1(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_2_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }

        }

        private void lbl_3_Click_1(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_4_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_5_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_6_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_7_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_8_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }

        }

        private void lbl_9_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_10_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_11_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_12_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_13_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_14_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_15_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_16_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_17_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_18_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_19_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_20_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_21_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_22_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_23_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_24_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_25_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_26_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_27_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_28_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_29_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_30_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_31_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AdicionarDataGridView(label);
            }
        }

        private void lbl_1_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_2_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }

        }

        private void lbl_3_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_4_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_5_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_6_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_7_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_8_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_9_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_10_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_11_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_12_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_13_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_14_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_15_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_16_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }

        }

        private void lbl_17_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_18_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_19_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_20_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_21_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_22_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_23_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_24_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_25_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_26_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_27_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_28_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_29_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_30_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void lbl_31_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                RemoverDataGridView(label);
            }
        }

        private void SortDatesInDataGridView()
        {
            // Verifica se a coluna de datas existe
            if (dataGridView_datas.Columns.Count > 0)
            {
                var orderedRows = dataGridView_datas.Rows.Cast<DataGridViewRow>()
                                   .Where(row => row.Cells[1].Value != null) // Supondo que a coluna "data" seja a segunda (índice 1)
                                   .OrderBy(row => DateTime.Parse(row.Cells[1].Value.ToString()))
                                   .ToList();

                // Limpa as linhas atuais da DataGridView
                dataGridView_datas.Rows.Clear();

                // Adiciona as linhas ordenadas de volta à DataGridView
                foreach (var row in orderedRows)
                {
                    // Use os índices em vez dos nomes das colunas
                    dataGridView_datas.Rows.Add(row.Cells[0].Value, row.Cells[1].Value); // Supondo que a coluna "quarto" seja a primeira (índice 0)
                }
            }
            else
            {
                MessageBox.Show("A DataGridView não contém colunas.");
            }
        }


        private void SetCheckInCheckOutDatesFromDataGridView()
        {
            // Verifica se há linhas na DataGridView
            if (dataGridView_datas.Rows.Count > 0)
            {
                // Inicializa as variáveis para armazenar a menor e a maior data
                DateTime? minDate = null;
                DateTime? maxDate = null;

                // Percorre as linhas da DataGridView
                foreach (DataGridViewRow row in dataGridView_datas.Rows)
                {
                    if (row.Cells[1].Value != null && DateTime.TryParse(row.Cells[1].Value.ToString(), out DateTime date)) // Supondo que a coluna de data seja o índice 1
                    {
                        if (!minDate.HasValue || date < minDate.Value)
                        {
                            minDate = date;
                        }
                        if (!maxDate.HasValue || date > maxDate.Value)
                        {
                            maxDate = date;
                        }
                    }
                }

                // Define os valores dos DateTimePickers, se as datas foram encontradas
                if (minDate.HasValue && maxDate.HasValue)
                {
                    dtp_checkin.Value = minDate.Value; // Substitua pelo nome correto do seu DateTimePicker de check-in
                    dtp_checkout.Value = maxDate.Value; // Substitua pelo nome correto do seu DateTimePicker de check-out
                }
                else
                {
                    MessageBox.Show("Nenhuma data válida encontrada na DataGridView.");
                }
            }
            else
            {
                MessageBox.Show("A DataGridView não contém linhas.");
            }
        }

        private void ValidateAvailableMonths(ComboBox monthComboBox, int year)
        {
            // Obtenha o mês atual
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            // Itera por todos os itens do ComboBox
            for (int i = 1; i <= 12; i++)
            {
                // Verifica se o ano é o atual e o mês já passou
                if (year == currentYear && i < currentMonth)
                {
                    // Desabilita meses que já passaram
                    monthComboBox.Items.Remove(i);
                }
                else if (!monthComboBox.Items.Contains(i))
                {
                    // Adiciona os meses que ainda estão disponíveis
                    monthComboBox.Items.Add(i);
                }
            }
        }

        private void CalcularValorTotal()
        {
            // Verifica se o valor da diária está preenchido e é válido
            if (decimal.TryParse(txt_valor_diaria.Text, out decimal valorDiaria))
            {
                // Calcula o número de dias
                DateTime checkinDate = dtp_checkin.Value.Date;
                DateTime checkoutDate = dtp_checkout.Value.Date;
                int numDias = (checkoutDate - checkinDate).Days;

                if (numDias > 0)
                {
                    txt_num_dias.Text = numDias.ToString();

                    // Calcula o valor total
                    decimal valorTotal = numDias * valorDiaria;
                    txt_valor_total.Text = valorTotal.ToString("F2"); // Formata para duas casas decimais
                }
                else
                {
                    txt_num_dias.Clear();
                    txt_valor_total.Clear();
                    MessageBox.Show("A data de check-out deve ser maior que a data de check-in.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortDatesInDataGridView();
            SetCheckInCheckOutDates();
        }

        private void btn_excluir_hospede_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_hospedes.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView_hospedes.SelectedRows)
                    {
                        dataGridView_hospedes.Rows.Remove(row);
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um hóspede para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir hóspede: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btn_excluir_cond_pagamento_Click(object sender, EventArgs e)
        {
            // Verifica se a DataGridView tem linhas para limpar
            if (dataGridView_parcelas.Rows.Count > 0)
            {
                // Limpa todas as linhas da DataGridView
                dataGridView_parcelas.Rows.Clear();
                MessageBox.Show("Todas as parcelas foram removidas.", "Remoção Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não há parcelas para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PreencherMesesDisponiveis(ComboBox comboBoxMes, int anoSelecionado)
        {
             
            // Limpa os itens existentes no ComboBox
            comboBoxMes.Items.Clear();

            // Obtem o mês atual e o ano atual
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;

            // Verifica se o ano selecionado é o ano atual ou um ano futuro
            if (anoSelecionado >= anoAtual)
            {
                // Itera sobre todos os meses do ano (de 1 a 12)
                for (int i = 1; i <= 12; i++)
                {
                    // Adiciona ao ComboBox apenas meses que não passaram no ano atual
                    if (anoSelecionado > anoAtual || (anoSelecionado == anoAtual && i >= mesAtual))
                    {
                        comboBoxMes.Items.Add(i);
                    }
                }

                // Seleciona o primeiro item disponível por padrão, se houver
                if (comboBoxMes.Items.Count > 0)
                {
                    comboBoxMes.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Não há meses disponíveis para o ano selecionado.");
                }
            }
            else
            {
                MessageBox.Show("O ano selecionado já passou. Por favor, selecione um ano válido.");
            }
        }

        private void comboBox_ano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBox_ano.SelectedItem.ToString(), out int anoSelecionado))
            {
                PreencherMesesDisponiveis(comboBox_mes, anoSelecionado);
            }

       

        }


        public override void salvar()
        {
            // Validações obrigatórias dos campos
            if (!validadores.CampoObrigatorio(txt_cod_cliente.Text))
            {
                MessageBox.Show("Campo Código do Cliente é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_cliente.Focus();
                return;
            }
            if (!validadores.CampoObrigatorio(txt_cod_quarto.Text))
            {
                MessageBox.Show("Campo Código do Quarto é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_quarto.Focus();
                return;
            }
            if (!DateTime.TryParse(dtp_checkin.Text, out DateTime dataCheckin))
            {
                MessageBox.Show("Data de Check-in inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_checkin.Focus();
                return;
            }
            if (!DateTime.TryParse(dtp_checkout.Text, out DateTime dataCheckout))
            {
                MessageBox.Show("Data de Check-out inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_checkout.Focus();
                return;
            }
            if (dataCheckout <= dataCheckin)
            {
                MessageBox.Show("A data de Check-out deve ser posterior à data de Check-in.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_checkout.Focus();
                return;
            }

            try
            {
                int clienteID = int.Parse(txt_cod_cliente.Text);
                int quartoID = int.Parse(txt_cod_quarto.Text);
                decimal valorDiaria = decimal.Parse(txt_valor_diaria.Text.Replace("R$", "").Trim());
                decimal valorTotal = decimal.Parse(txt_valor_total.Text.Replace("R$", "").Trim());
                int numDias = (dataCheckout - dataCheckin).Days;

                DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                DateTime dataUltAlt = DateTime.Now;

                // Criar a nova reserva
                Reserva novaReserva = new Reserva
                {
                    cliente_ID = clienteID,
                    nome_cliente = txt_nome_cliente.Text,
                    cpf_cliente = txt_cpf.Text,
                    celular_cliente = txt_telefone.Text,
                    quarto_ID = quartoID,
                    numero_quarto = txt_numero.Text,
                    andar = int.Parse(txt_andar.Text),
                    valor_diaria = valorDiaria,
                    valor_total = valorTotal,
                    data_checkin = dataCheckin,
                    data_checkout = dataCheckout,
                    num_dias = numDias,
                    condPagamento_ID = int.TryParse(txt_cod_cond_pagamento.Text, out int condPagamentoID) ? condPagamentoID : 0,
                    condicao_pagamento = txt_cond_pagamento.Text,
                    status_reserva = "Reservado",
                    data_cancelamento = null,
                    observacao = txt_obs.Text,
                    ativo = check_ativo.Checked,
                    data_cadastro = dataCadastro,
                    data_ult_alt = dataUltAlt,
                    usuario_ult_alt = "UsuárioAtual" // Pode ser substituído pelo usuário logado atual
                };

                // Associar a lista de hóspedes à reserva (certifique-se de que a lista seja preenchida corretamente)
                novaReserva.hospedes = ObterListaHospedes(); // Método para obter a lista de hóspedes selecionados no formulário

                // Criar a ocupação correspondente
                Ocupacao novaOcupacao = new Ocupacao
                {
                    quarto_ID = quartoID,
                    DataEntrada = dataCheckin,
                    DataSaida = dataCheckout,
                    cliente_ID = clienteID,
                    ocupacao = "Reservado"
                };

                // Inserir reserva, ocupação e hóspedes
                if (altera == -1)
                {
                    controllerReservas.salvar(novaReserva); // Método void para salvar a reserva
                    controllerReservas.InserirOcupacao(novaOcupacao); // Método void para inserir a ocupação

                    // Salvar lista de hóspedes
                    if (novaReserva.hospedes != null && novaReserva.hospedes.Count > 0)
                    {
                        foreach (var hospede in novaReserva.hospedes)
                        {
                            controllerReservas.InserirHospedeNaReserva(novaReserva.reserva_ID, hospede.hospede_id);
                        }
                    }

                    MessageBox.Show("Reserva, ocupação e hóspedes inseridos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    novaReserva.reserva_ID = altera; // ID da reserva a ser alterada
                    controllerReservas.alterar(novaReserva);
                    MessageBox.Show("Reserva alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar a reserva: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Hospede> ObterListaHospedes()
        {
            List<Hospede> listaHospedes = new List<Hospede>();

            // Percorre a DataGridView ou outro controle onde os hóspedes são listados
            foreach (DataGridViewRow row in dataGridView_hospedes.Rows)
            {
                if (row.Cells["CodHospede"].Value != null && row.Cells["NomeHospede"].Value != null)
                {
                    Hospede hospede = new Hospede
                    {
                        hospede_id = Convert.ToInt32(row.Cells["CodHospede"].Value),
                        nome = row.Cells["NomeHospede"].Value.ToString()
                    };
                    listaHospedes.Add(hospede);
                }
            }

            return listaHospedes;
        }

        private void comboBox_mes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


        private void InativarMesesPassados(int anoSelecionado)
        {
            int anoAtual = DateTime.Now.Year;
            int mesAtual = DateTime.Now.Month;

            // Itera sobre os itens do ComboBox de meses
            for (int i = 0; i < comboBox_mes.Items.Count; i++)
            {
                // Verifica se o ano selecionado é o ano atual
                if (anoSelecionado == anoAtual && (i + 1) < mesAtual)
                {
                    // Desabilita o mês se já tiver passado
                    comboBox_mes.Items[i] = new ComboBoxItem(comboBox_mes.Items[i].ToString(), false);
                }
                else
                {
                    // Ativa o mês se não tiver passado
                    comboBox_mes.Items[i] = new ComboBoxItem(comboBox_mes.Items[i].ToString(), true);
                }
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; }
            public bool Enabled { get; }

            public ComboBoxItem(string text, bool enabled)
            {
                Text = text;
                Enabled = enabled;
            }

            public override string ToString()
            {
                return Text;
            }
        }

    }
}    