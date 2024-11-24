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
        private controllerTipoQuarto<tipo_quarto> controllerTipoQuarto;
        private ConsultaTipoQuarto consultaTipoQuarto;  

        private ConsultaHospede consultaHospede;
        private controllerHospede<Hospede> controllerHospede;

        decimal juros;
        decimal descontos;
        decimal multa;
        private bool reservaSalva = false;
        private int reservaIdAtual;
        string dataPainel;
        private int tipoQuartoSelecionado;

        Int32 mes;
        Int32 diasMes;

        public int? ReservaId { get; set; }

        private int quartoId;

        public CadastroReserva()
        {
            InitializeComponent();

            daoReserva = new DaoReserva<Reserva>();
            reservaIdAtual = daoReserva.ObterProximoReservaId();


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

            consultaTipoQuarto = new ConsultaTipoQuarto();
            controllerTipoQuarto = new controllerTipoQuarto<tipo_quarto>();



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
            txt_cod_tipo.Clear();
            txt_num_dias.Clear();
            txt_tipo_quarto.Clear();    
            txt_vlr_tarifa.Clear(); 
            txt_nome_cliente.Clear();
            txt_cpf.Clear();
            txt_telefone.Clear();
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

        public CadastroReserva(int reserva_id) : this()
        {
            altera = reserva_id;
            carrega();
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
        private void exibirParcelasDGV(List<Parcela> parcelas)
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



        private void RemoverDataGridView(DateTime dataReserva)
        {
            string dataFormatada = dataReserva.ToString("dd/MM/yyyy");

            foreach (DataGridViewRow row in dataGridView_datas.Rows)
            {
                if (row.Cells["Data"].Value.ToString() == dataFormatada)
                {
                    dataGridView_datas.Rows.Remove(row);
                    break;
                }
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

            // Verifica a capacidade máxima antes de adicionar o hóspede
            int capacidadeMaxima = int.TryParse(txt_capacidade_max.Text, out int capacidade) ? capacidade : 0;
            if (dataGridView_hospedes.Rows.Count >= capacidadeMaxima)
            {
                MessageBox.Show("Capacidade máxima de hóspedes atingida para este quarto.", "Capacidade Excedida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int hospedeId = int.Parse(txt_cod_hospede.Text);
                Hospede hospede = controllerHospede.GetById(hospedeId);

                if (hospede != null && hospede.data_nascimento.HasValue)
                {
                    // Calcula a idade do hóspede
                    int idade = DateTime.Now.Year - hospede.data_nascimento.Value.Year;
                    if (hospede.data_nascimento.Value > DateTime.Now.AddYears(-idade))
                    {
                        idade--;
                    }

                    // Define o status de "Pagante"
                    string pagante = idade > 5 ? "SIM" : "NÃO";

                    // Adiciona o hóspede diretamente à DataGridView sem limpar as linhas existentes
                    dataGridView_hospedes.Rows.Add(
                        hospede.hospede_id,
                        hospede.nome,
                        pagante // Adiciona o valor "Sim" ou "Não" para o campo Pagante
                    );
                }
                else if (hospede == null)
                {
                    MessageBox.Show("Hóspede não encontrado.");
                }
                else
                {
                    MessageBox.Show("Data de nascimento do hóspede inválida.");
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

            AtualizarNumeroHospedesEValor();
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


      

        private void CalcularValorTotal()
        {
            // Verifica se o valor da diária está preenchido e é válido
            if (decimal.TryParse(txt_vlr_tarifa.Text, out decimal valorDiaria))
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


            AtualizarNumeroHospedesEValor();
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
            comboBoxMes.Items.Clear();

            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;

            if (anoSelecionado >= anoAtual)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (anoSelecionado > anoAtual || (anoSelecionado == anoAtual && i >= mesAtual))
                    {
                        comboBoxMes.Items.Add(i);
                    }
                }

                // Remove a seleção automática do primeiro mês disponível
                comboBoxMes.SelectedIndex = -1;
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
            AtualizarDiasDisponiveis();
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
            if (!validadores.CampoObrigatorio(txt_tipo_quarto.Text))
            {
                MessageBox.Show("Campo Código do Quarto é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tipo_quarto.Focus();
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
                if (!int.TryParse(txt_cod_cliente.Text, out int clienteID))
                {
                    MessageBox.Show("Código do Cliente inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txt_cod_tipo.Text, out int tipo_quarto_ID))
                {
                    MessageBox.Show("Código do Tipo de Quarto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txt_vlr_tarifa.Text.Replace("R$", "").Trim(), out decimal valorDiaria))
                {
                    MessageBox.Show("Valor da Tarifa inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txt_valor_total.Text.Replace("R$", "").Trim(), out decimal valorTotal))
                {
                    MessageBox.Show("Valor Total inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                    tipo_quarto_ID = tipo_quarto_ID,
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
                };

                // Associar a lista de hóspedes à reserva
                novaReserva.hospedes = ObterListaHospedesDaDataGridView();

                // Inserir reserva, ocupação e hóspedes
                if (altera == -1)
                {
                    controllerReservas.salvar(novaReserva);

                    // Obter o último ID de reserva após salvar
                    int novoReservaId = controllerReservas.GetUltimoCodigo();

                    // Atualizar a tabela de ReservasTemporarias para associar com o novo reserva_id
                    controllerReservas.AtualizarReservaTemporaria(novoReservaId, tipo_quarto_ID);

                    // Salvar lista de hóspedes
                    if (novaReserva.hospedes != null && novaReserva.hospedes.Count > 0)
                    {
                        foreach (var hospede in novaReserva.hospedes)
                        {
                            controllerReservas.InserirHospedeNaReserva(novoReservaId, hospede.hospede_id);
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
            reservaSalva = true;
        }





        private List<Hospede> ObterListaHospedesDaDataGridView()
        {
            List<Hospede> hospedes = new List<Hospede>();
            foreach (DataGridViewRow row in dataGridView_hospedes.Rows)
            {
                if (row.Cells["codigo_hospede"].Value != null && row.Cells["hospede"].Value != null)
                {
                    Hospede hospede = new Hospede
                    {
                        hospede_id = Convert.ToInt32(row.Cells["codigo_hospede"].Value),
                        nome = row.Cells["hospede"].Value.ToString()
                    };
                    hospedes.Add(hospede);
                }
            }
            return hospedes;
        }

     

        private void comboBox_mes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.tipoQuartoSelecionado != 0 && comboBox_ano.SelectedItem != null && comboBox_mes.SelectedItem != null)
            {
                int mes = int.Parse(comboBox_mes.SelectedItem.ToString());
                int ano = int.Parse(comboBox_ano.SelectedItem.ToString());
                DateTime dataInicio = new DateTime(ano, mes, 1);
                DateTime dataFim = dataInicio.AddMonths(1).AddDays(-1);

                // Chama a função para atualizar os dias disponíveis
           
            }

            AtualizarDiasDisponiveis();
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

        private void btn_busca_cod_tipo_Click(object sender, EventArgs e)
        {
            consultaTipoQuarto.btn_sair.Text = "Selecionar";

            if (consultaTipoQuarto.ShowDialog() == DialogResult.OK)
            {
                // Receber os detalhes do país selecionado
                var tipoDetalhes = consultaTipoQuarto.Tag as Tuple<int, string, string,  decimal, int>;
                if (tipoDetalhes != null)
                {
                    int tipo_quarto_ID = tipoDetalhes.Item1;
                    string tipo = tipoDetalhes.Item2;
                    string descricao = tipoDetalhes.Item3;  
                    decimal valor_diaria = tipoDetalhes.Item4;
                    int capacidade_maxima = tipoDetalhes.Item5; 


       
                    txt_cod_tipo.Text = tipo_quarto_ID.ToString();
                    txt_tipo_quarto.Text = tipo.ToString();
                    txt_vlr_tarifa.Text = valor_diaria.ToString();
                    txt_capacidade_max.Text = capacidade_maxima.ToString();
                }
            }
            if (int.TryParse(txt_cod_tipo.Text, out int tipoQuartoId))
            {
                // Armazene o tipo de quarto selecionado para uso posterior
                this.tipoQuartoSelecionado = tipoQuartoId;

                MessageBox.Show("Tipo de quarto selecionado. Agora, selecione o mês e o ano.", "Tipo Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Código do tipo de quarto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void AtualizarNumeroHospedesEValor()
        {
            // Obtém a capacidade máxima do quarto
            int capacidadeMaxima = int.TryParse(txt_capacidade_max.Text, out int capacidade) ? capacidade : 0;

            // Atualiza o número de hóspedes no campo apropriado
            int numeroHospedes = dataGridView_hospedes.Rows.Count;
            txt_num_hospedes.Text = numeroHospedes.ToString();

            // Habilita ou desabilita o botão "ADD" com base na capacidade máxima
            button1.Enabled = numeroHospedes < capacidadeMaxima;

            // Conta o número de hóspedes pagantes
            int numeroPagantes = 0;
            foreach (DataGridViewRow row in dataGridView_hospedes.Rows)
            {
                if (row.Cells["Pagante"].Value != null && row.Cells["Pagante"].Value.ToString().ToUpper() == "SIM")
                {
                    numeroPagantes++;
                }
            }

            // Obtém o número de dias da reserva e o valor da tarifa
            if (int.TryParse(txt_num_dias.Text, out int numDias) && decimal.TryParse(txt_vlr_tarifa.Text, out decimal valorTarifa))
            {
                // Calcula o valor total com base no número de dias e apenas os hóspedes pagantes
                decimal valorTotal = numDias * valorTarifa * numeroPagantes;

                // Atualiza o campo "Valor Total"
                txt_valor_total.Text = valorTotal.ToString("F2"); // Formatação para duas casas decimais
            }
            else
            {
                MessageBox.Show("Erro ao calcular o valor total. Verifique os valores de diária e número de dias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastroReserva_Load(object sender, EventArgs e)
        {
            if (lbl_cancelada.Enabled = false)
            {
                BloquearTodosOsCampos();
            }
            if (altera == -1) // Verifica se é uma inclusão
            {
                int novoCodigo = controllerReservas.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();

                comboBox_mes.Items.Clear();
                comboBox_mes.SelectedIndex = -1;
                comboBox_mes.Text = "";
            }

            dtp_checkout.Value = DateTime.Now.AddDays(1);

            int anoAtual = DateTime.Now.Year;
            comboBox_ano.Items.Clear();
            for (int i = anoAtual; i <= anoAtual + 5; i++)
            {
                comboBox_ano.Items.Add(i);
            }
            comboBox_ano.SelectedItem = anoAtual;


            for (int i = 1; i <= 31; i++)
            {
                Label label = this.Controls.Find("lbl_" + i, true).FirstOrDefault() as Label;
                if (label != null)
                {
                    label.Click += Label_Click;
                }
            }

            foreach (Control control in panel_dias.Controls)
            {
                if (control is Label label)
                {
                    // Associa o evento de DoubleClick para cada label de dia
                    label.DoubleClick += Label_DoubleClick;
                }
            }
        }

        
        private void BloquearTodosOsCampos()
        {
            foreach (Control control in this.Controls)
            {
                // Verifica o tipo de controle e desativa adequadamente
                if (control is TextBox textBox)
                {
                    textBox.Enabled = false;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.Enabled = false;
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Enabled = false;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Enabled = false;
                }
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.Enabled = false;
                }
                else if (control is Button button && button.Name != "btn_sair") // Mantém o botão "Sair" ativo
                {
                    button.Enabled = false;
                }
            }
        }




        private void Label_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label && int.TryParse(label.Text, out int dia))
            {
                if (comboBox_ano.SelectedItem != null && comboBox_mes.SelectedItem != null &&
                    int.TryParse(comboBox_ano.SelectedItem.ToString(), out int anoSelecionado) &&
                    int.TryParse(comboBox_mes.SelectedItem.ToString(), out int mesSelecionado))
                {
                    int tipoQuartoId = int.Parse(txt_cod_tipo.Text);
                    DateTime dataReserva = new DateTime(anoSelecionado, mesSelecionado, dia);

                    // Excluir a reserva temporária
                    bool sucesso = controllerReservas.ExcluirReservaTemporaria(tipoQuartoId, dataReserva);

                    if (sucesso)
                    {
                        // Atualiza a cor da label e do panel para indicar que a data está disponível
                        label.BackColor = Color.Green;
                        label.ForeColor = Color.Black;
                        if (label.Parent is Panel panel)
                        {
                            panel.BackColor = Color.Green;
                        }
                        MessageBox.Show("Reserva temporária removida com sucesso!", "Reserva Temporária", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Falha ao remover a reserva temporária.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private DateTime? dataInicio = null;
        private DateTime? dataFim = null;

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label label && int.TryParse(label.Text, out int dia))
            {
                if (comboBox_ano.SelectedItem != null && comboBox_mes.SelectedItem != null &&
                    int.TryParse(comboBox_ano.SelectedItem.ToString(), out int anoSelecionado) &&
                    int.TryParse(comboBox_mes.SelectedItem.ToString(), out int mesSelecionado))
                {
                    DateTime dataSelecionada = new DateTime(anoSelecionado, mesSelecionado, dia);

                    if (dataInicio == null)
                    {
                        // Define a data inicial
                        dataInicio = dataSelecionada;
                        label.BackColor = Color.Blue; // Indica que esta é a data inicial
                        label.ForeColor = Color.White;
                    }
                    else if (dataFim == null)
                    {
                        // Define a data final
                        dataFim = dataSelecionada;
                        label.BackColor = Color.Blue; // Indica que esta é a data final
                        label.ForeColor = Color.White;

                        // Chama o método para preencher as datas entre a inicial e a final
                        PreencherDatasEntre(dataInicio.Value, dataFim.Value);
                    }
                    else
                    {
                        // Reinicia as seleções se ambas as datas já estão definidas
                        LimparSelecao();
                        dataInicio = dataSelecionada;
                        label.BackColor = Color.Blue;
                        label.ForeColor = Color.White;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um mês e ano válidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PreencherDatasEntre(DateTime inicio, DateTime fim)
        {
            if (inicio > fim)
            {
                // Troca as datas se a data inicial for maior que a final
                DateTime temp = inicio;
                inicio = fim;
                fim = temp;
            }

            DateTime dataAtual = inicio;
            while (dataAtual <= fim)
            {
                // Chama o método de inserção para cada data no intervalo, com reserva_id nulo
                bool sucesso = controllerReservas.InserirReservaTemporaria(int.Parse(txt_cod_tipo.Text), dataAtual);

                if (sucesso)
                {
                    // Adiciona a data na DataGridView para visualização
                    dataGridView_datas.Rows.Add(txt_cod_tipo.Text, dataAtual.ToString("dd/MM/yyyy"));

                    // Atualiza a cor no calendário para indicar que a data foi reservada temporariamente
                    foreach (Control panel in panel_dias.Controls)
                    {
                        if (panel is Panel dayPanel && dayPanel.Controls.Count > 0 && dayPanel.Controls[0] is Label dayLabel &&
                            int.TryParse(dayLabel.Text, out int dia) && dataAtual.Day == dia)
                        {
                            dayLabel.BackColor = Color.Orange;
                            dayLabel.ForeColor = Color.White;
                            dayPanel.BackColor = Color.Orange;
                            break;
                        }
                    }
                }
                else
                {
                    // Exibir um erro caso a inserção falhe para uma data específica
                    MessageBox.Show($"Erro ao reservar a data {dataAtual.ToString("dd/MM/yyyy")} no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataAtual = dataAtual.AddDays(1);
            }

            // Limpa as variáveis de data para permitir uma nova seleção
            dataInicio = null;
            dataFim = null;
        }



        private void LimparSelecao()
        {
            dataInicio = null;
            dataFim = null;

            // Restaura as cores originais das labels no calendário
            foreach (Control panel in panel_dias.Controls)
            {
                if (panel is Panel dayPanel && dayPanel.Controls.Count > 0 && dayPanel.Controls[0] is Label dayLabel)
                {
                    dayLabel.BackColor = Color.Green; // Dia disponível padrão
                    dayLabel.ForeColor = Color.Black;
                    dayPanel.BackColor = Color.Green;
                }
            }

            // Limpa a DataGridView
            dataGridView_datas.Rows.Clear();
        }


        private void AtualizarDiasDisponiveis()
        {
            // Verificar se todos os campos de seleção estão preenchidos
            if (string.IsNullOrWhiteSpace(txt_cod_tipo.Text) || comboBox_mes.SelectedItem == null || comboBox_ano.SelectedItem == null)
                return;

            // Obter o valor do tipo de quarto, mês e ano
            string tipoQuarto = txt_cod_tipo.Text;
            int mes = int.Parse(comboBox_mes.SelectedItem.ToString());
            int ano = int.Parse(comboBox_ano.SelectedItem.ToString());

            // Obter a data atual
            DateTime hoje = DateTime.Today;

            // Chamar o método da Controller para obter os dias indisponíveis
            List<DateTime> diasIndisponiveis = controllerReservas.BuscarDiasIndisponiveis(tipoQuarto, mes, ano);

            // Iterar sobre os Panels individuais dentro do panel maior
            foreach (Control panel in panel_dias.Controls)
            {
                if (panel is Panel dayPanel && dayPanel.Controls.Count > 0 && dayPanel.Controls[0] is Label dayLabel)
                {
                    // Tenta converter o texto do Label para obter o dia
                    if (int.TryParse(dayLabel.Text, out int dia))
                    {
                        // Verifica se a data é válida para o mês e ano selecionados
                        if (dia >= 1 && dia <= DateTime.DaysInMonth(ano, mes))
                        {
                            DateTime data = new DateTime(ano, mes, dia);

                            // Define a cor com base na disponibilidade e se o dia já passou
                            if (data < hoje && mes == hoje.Month && ano == hoje.Year)
                            {
                                // Dias que já passaram no mês atual ficam em cinza
                                dayLabel.BackColor = Color.Gray;
                                dayLabel.ForeColor = Color.White;
                                dayPanel.BackColor = Color.Gray;
                            }
                            else if (diasIndisponiveis.Contains(data))
                            {
                                // Dias reservados ficam em vermelho
                                dayLabel.BackColor = Color.Red;
                                dayLabel.ForeColor = Color.White;
                                dayPanel.BackColor = Color.Red;
                            }
                            else
                            {
                                // Dias disponíveis ficam em verde
                                dayLabel.BackColor = Color.Green;
                                dayLabel.ForeColor = Color.Black;
                                dayPanel.BackColor = Color.Green;
                            }
                        }
                        else
                        {
                            // Se o dia não é válido para o mês e ano, deixa o dia em branco ou em uma cor neutra
                            dayLabel.BackColor = Color.LightGray;
                            dayLabel.ForeColor = Color.DarkGray;
                            dayPanel.BackColor = Color.LightGray;
                        }
                    }
                }
            }
        }



        private void txt_cod_tipo_TextChanged(object sender, EventArgs e)
        {
            AtualizarDiasDisponiveis();
        }

        private void CadastroReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!reservaSalva)
            {
                //int reservaId;
                //if (int.TryParse(txt_codigo.Text, out reservaId))
                //{
                //    // Executa a lógica com o reservaId válido
                //    controllerReservas.ExcluirReservasTemporariasPorReservaId(reservaId);
                //}
                //else
                //{
                //    MessageBox.Show("O código da reserva não está em um formato válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                controllerReservas.ExcluirReservasTemporariasNaoSalvas();
            }

        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (!reservaSalva)
            {
                int reservaId;
                if (int.TryParse(txt_codigo.Text, out reservaId))
                {
                    // Executa a lógica com o reservaId válido
                    controllerReservas.ExcluirReservasTemporariasPorReservaId(reservaId);
                }
                else
                {
                    MessageBox.Show("O código da reserva não está em um formato válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

      

        public Reserva ObterReservaAtualizada()
        {
            try
            {
                // Cria um novo objeto de reserva com os valores atualizados no formulário
                Reserva reserva = new Reserva
                {
                    reserva_ID = int.TryParse(txt_codigo.Text, out int reservaId) ? reservaId : 0,
                    cliente_ID = int.TryParse(txt_cod_cliente.Text, out int clienteId) ? clienteId : 0,
                    nome_cliente = txt_nome_cliente.Text,
                    cpf_cliente = txt_cpf.Text,
                    celular_cliente = txt_telefone.Text,
                    tipo_quarto_ID = int.TryParse(txt_cod_tipo.Text, out int tipoQuartoId) ? tipoQuartoId : (int?)null,
                    tipo_quarto = txt_tipo_quarto.Text,
                    data_checkin = DateTime.TryParse(dtp_checkin.Text, out DateTime checkin) ? checkin : DateTime.MinValue,
                    data_checkout = DateTime.TryParse(dtp_checkout.Text, out DateTime checkout) ? checkout : (DateTime?)null,
                    valor_diaria = decimal.TryParse(txt_vlr_tarifa.Text, out decimal valorTarifa) ? valorTarifa : (decimal?)null,
                    valor_total = decimal.TryParse(txt_valor_total.Text, out decimal valorTotal) ? valorTotal : (decimal?)null,
                    observacao = txt_obs.Text,
                    condPagamento_ID = int.TryParse(txt_cod_cond_pagamento.Text, out int condPagId) ? condPagId : (int?)null,
                    condicao_pagamento = txt_cond_pagamento.Text,
                    hospedes = dataGridView_hospedes.DataSource as List<Hospede> ?? new List<Hospede>(), // Recupera os hóspedes
                    parcelas = dataGridView_parcelas.DataSource as List<Parcela> ?? new List<Parcela>(), // Recupera as parcelas
                    motivo_checkout = !string.IsNullOrEmpty(txt_motivo_checkout.Text) ? txt_motivo_checkout.Text : null, // Motivo do checkout antecipado
                    ativo = true,
                    data_ult_alt = DateTime.Now
                };

                return reserva;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter a reserva atualizada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

      

        private void CadastroReserva_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void RecalcularValores()
        {
            // Calcula a diferença em dias entre check-in e checkout
            int numDias = (dtp_checkout.Value - dtp_checkin.Value).Days;

            // Atualiza os campos de valores
            txt_num_dias.Text = numDias.ToString();
            txt_valor_total.Text = (numDias * Convert.ToDecimal(txt_vlr_tarifa.Text)).ToString("F2");
        }

        public void AjustarDataCheckout(DateTime novaDataCheckout)
        {
            dtp_checkout.Value = novaDataCheckout;
            RecalcularValores(); // Atualiza o valor total com base na nova data
        }


        private bool CalcularSeHospedeEPagante(DateTime? dataNascimento)
        {
            if (!dataNascimento.HasValue)
                return false; // Sem data de nascimento, não é possível calcular

            int idade = DateTime.Now.Year - dataNascimento.Value.Year;

            // Verifica se ainda não completou aniversário no ano atual
            if (dataNascimento.Value.Date > DateTime.Now.AddYears(-idade))
            {
                idade--;
            }

            // Considera pagante se a idade for maior ou igual a 5
            return idade >= 5;
        }



        public void CarregarReserva(int reservaId)
        {
            try
            {
                // Busca a reserva pelo ID
                var reserva = controllerReservas.GetById(reservaId);

                if (reserva != null)
                {
                    // Preenche os campos gerais da reserva
                    txt_codigo.Text = reserva.reserva_ID.ToString();
                    txt_cod_cliente.Text = reserva.cliente_ID.ToString();
                    txt_nome_cliente.Text = reserva.nome_cliente ?? string.Empty;
                    txt_cpf.Text = reserva.cpf_cliente ?? string.Empty;
                    txt_telefone.Text = reserva.celular_cliente ?? string.Empty;
                    txt_cod_tipo.Text = reserva.tipo_quarto_ID?.ToString() ?? string.Empty;
                    txt_tipo_quarto.Text = reserva.tipo_quarto ?? string.Empty;
                    txt_vlr_tarifa.Text = reserva.valor_diaria?.ToString("F2") ?? string.Empty;
                    txt_valor_total.Text = reserva.valor_total?.ToString("F2") ?? string.Empty;
                    txt_obs.Text = reserva.observacao ?? string.Empty;

                    // Preenche as datas de check-in e check-out
                    dtp_checkin.Value = reserva.data_checkin != DateTime.MinValue ? reserva.data_checkin : DateTime.Now;
                    dtp_checkout.Value = reserva.data_checkout.HasValue && reserva.data_checkout.Value != DateTime.MinValue
                        ? reserva.data_checkout.Value
                        : DateTime.Now;

                    // Preenche o status da reserva
                    check_ativo.Checked = reserva.ativo;
                    check_inativo.Checked = !reserva.ativo;

                    // Preenche o número de dias
                    txt_num_dias.Text = reserva.num_dias.ToString();

                    // Preenche a condição de pagamento
                    if (reserva.condPagamento_ID.HasValue)
                    {
                        txt_cod_cond_pagamento.Text = reserva.condPagamento_ID.Value.ToString();
                        txt_cond_pagamento.Text = reserva.condicao_pagamento ?? string.Empty;
                    }
                    else
                    {
                        txt_cod_cond_pagamento.Clear();
                        txt_cond_pagamento.Clear();
                    }

                    // Preenche as datas de cadastro e última alteração
                    txt_dat_cad.Text = reserva.data_cadastro != DateTime.MinValue
                        ? reserva.data_cadastro.ToString("dd/MM/yyyy HH:mm:ss")
                        : string.Empty;
                    txt_dat_ult_alt.Text = reserva.data_ult_alt != DateTime.MinValue
                        ? reserva.data_ult_alt.ToString("dd/MM/yyyy HH:mm:ss")
                        : string.Empty;

                    // Exibe os hóspedes associados à reserva
                    var hospedes = controllerReservas.ObterHospedesPorReserva(reservaId);
                    ExibirHospedesDGV(hospedes);

                    // Exibe as parcelas associadas à condição de pagamento
                    ExibirParcelasDGV(reserva.parcelas ?? new List<Parcela>());

                    // Carrega informações adicionais, como o calendário
        
                }
                else
                {
                    MessageBox.Show("Reserva não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     


        public override void carrega()
        {
            // Desabilita os controles de status ativo/inativo
            check_ativo.Enabled = false;
            check_inativo.Enabled = false;

            if (altera != -1) // Verifica se estamos em modo de edição
            {
                // Busca a reserva pelo ID
                var reserva = controllerReservas.GetById(altera);

                if (reserva != null)
                {
                    try
                    {
                        // Carrega os dados principais da reserva
                        txt_codigo.Text = reserva.reserva_ID.ToString();
                        txt_cod_cliente.Text = reserva.cliente_ID.ToString();
                        txt_nome_cliente.Text = reserva.nome_cliente ?? string.Empty;
                        txt_cpf.Text = reserva.cpf_cliente ?? string.Empty;
                        txt_telefone.Text = reserva.celular_cliente ?? string.Empty;
                        txt_cod_tipo.Text = reserva.tipo_quarto_ID?.ToString() ?? string.Empty;
                        txt_tipo_quarto.Text = reserva.tipo_quarto ?? string.Empty;
                        txt_vlr_tarifa.Text = reserva.valor_diaria?.ToString("F2") ?? string.Empty;
                        txt_valor_total.Text = reserva.valor_total?.ToString("F2") ?? string.Empty;
                        txt_obs.Text = reserva.observacao ?? string.Empty;

                        // Configura as datas de check-in e check-out
                        dtp_checkin.Value = ParseDate(reserva.data_checkin, DateTime.Now);
                        dtp_checkout.Value = ParseDate(reserva.data_checkout, DateTime.Now);

                        // Carrega os hóspedes associados à reserva
                        ExibirHospedesDGV(reserva.hospedes ?? new List<Hospede>());

                        // Carrega as parcelas associadas à reserva
                        ExibirParcelasDGV(reserva.parcelas ?? new List<Parcela>());

                        // Configura a condição de pagamento
                        if (reserva.condPagamento_ID.HasValue)
                        {
                            txt_cod_cond_pagamento.Text = reserva.condPagamento_ID.Value.ToString();
                            txt_cond_pagamento.Text = reserva.condicao_pagamento ?? string.Empty;
                        }
                        else
                        {
                            txt_cod_cond_pagamento.Clear();
                            txt_cond_pagamento.Clear();
                        }

                        // Configura os campos de data de cadastro e última alteração
                        txt_dat_cad.Text = reserva.data_cadastro != DateTime.MinValue
                            ? reserva.data_cadastro.ToString("dd/MM/yyyy HH:mm:ss")
                            : string.Empty;

                        txt_dat_ult_alt.Text = reserva.data_ult_alt != DateTime.MinValue
                            ? reserva.data_ult_alt.ToString("dd/MM/yyyy HH:mm:ss")
                            : string.Empty;

                        // Configura os campos de status ativo/inativo
                        check_ativo.Checked = reserva.ativo;
                        check_inativo.Checked = !reserva.ativo;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar os dados da reserva: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparCampos();
                    }
                }
                else
                {
                    // Exibe uma mensagem de erro caso a reserva não seja encontrada
                    MessageBox.Show("Reserva não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Limpa os campos para evitar informações residuais
                    LimparCampos();
                }
            }
            else
            {
                // Caso não esteja em modo de edição, limpa os campos
                LimparCampos();
            }
        }

        // Método auxiliar para converter as datas
        private DateTime ParseDate(object dateValue, DateTime defaultValue)
        {
            if (dateValue == null || dateValue == DBNull.Value)
                return defaultValue;

            if (DateTime.TryParse(dateValue.ToString(), out DateTime parsedDate))
                return parsedDate;

            // Tenta interpretar o formato yyyy-MM-dd explicitamente
            try
            {
                return DateTime.ParseExact(dateValue.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return defaultValue; // Retorna o valor padrão em caso de erro
            }
        }

      


        private void ExibirHospedesDGV(List<Hospede> hospedes)
        {
            dataGridView_hospedes.Rows.Clear(); // Limpa o DataGridView

            var hospedesUnicos = hospedes.GroupBy(h => h.hospede_id).Select(g => g.First()).ToList(); // Evita duplicados

            foreach (var hospede in hospedesUnicos)
            {
                // Verifica se a data de nascimento é válida
                bool isPagante = hospede.data_nascimento.HasValue && CalcularSeHospedeEPagante(hospede.data_nascimento.Value);

                dataGridView_hospedes.Rows.Add(
                    hospede.hospede_id,
                    hospede.nome ?? "Não informado", // Nome padrão para casos nulos
                    isPagante ? "Sim" : "Não"
                );
            }
        }

        private void ExibirParcelasDGV(List<Parcela> parcelas)
        {
            dataGridView_parcelas.Rows.Clear(); // Limpa o DataGridView

            var parcelasUnicas = parcelas.GroupBy(p => new { p.numeroParcela, p.FormaPagamento_ID })
                               .Select(g => g.First())
                               .ToList();

            foreach (var parcela in parcelasUnicas)
            {
                string formaPagamento = controllerFormaPagamento.ObterDescricaoFormaPagamento(parcela.FormaPagamento_ID);

                dataGridView_parcelas.Rows.Add(
                    parcela.numeroParcela,
                    parcela.dias,
                    parcela.porcentagem,
                    parcela.FormaPagamento_ID,
                    formaPagamento
                );
            }
        }



    }
}    