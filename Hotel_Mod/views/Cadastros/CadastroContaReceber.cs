using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroContaReceber : Hotel_Mod.views.CadastroPai
    {
        private ConsultaCliente consultaCliente;   
        private ConsultaReserva consultaReserva;
        private ConsultaFormaPagamento consultaFormaPagamento;
        private controllerCliente<Cliente> controllerCliente;
        private ControllerFormaPagamento<FormaPagamento> controllerFormaPagamento;
        controllerContasReceber<ContasReceber> ControllerContasReceber;

        int cliente_ID;
        int reserva_ID;
        int num_parcela;


        decimal? porcentagemJuros;
        decimal? porcentagemMulta;
        decimal? porcentagemDesconto;

        public CadastroContaReceber()
        {
            consultaCliente = new ConsultaCliente();        
            consultaReserva = new ConsultaReserva();
            controllerFormaPagamento = new ControllerFormaPagamento<FormaPagamento>();
            consultaFormaPagamento = new ConsultaFormaPagamento();
            ControllerContasReceber = new controllerContasReceber<ContasReceber>();
            controllerCliente = new controllerCliente<Cliente>();
            InitializeComponent();
        }

        public void Bloqueia()
        {

            txt_cod_cliente.Enabled = false;    
            txt_cod_reserva.Enabled = false;
            txt_data_emissao.Enabled = false;
            txt_cod_forma.Enabled = false;
            txt_num_parcela.Enabled = false;
            txt_vlr_parcela.Enabled = false;

            btn_busca_cliente.Enabled = false;
            btn_busca_reserva.Enabled = false;
            btn_busca_forma.Enabled = false;
        }

        public void BloqueiaTudo()
        {
            //usado quando a conta já está paga ou está cancelada
            txt_juros.Enabled = false;
            txt_multa.Enabled = false;
            txt_desconto.Enabled = false;
            txt_valor_recebido.Enabled = false;
            txt_data_vencimento.Enabled = false;
        }
        public void DesbloqueiaTudo()
        {
            txt_juros.Enabled = true;
            txt_multa.Enabled = true;
            txt_desconto.Enabled = true;
            txt_valor_recebido.Enabled = true;
            txt_data_vencimento.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultaCliente.btn_sair.Text = "Selecionar";
            consultaCliente.btn_buscainativos.Visible = false;

            if (consultaCliente.ShowDialog() == DialogResult.OK)
            {
                var infosCliente = consultaCliente.Tag as Tuple<int, string, string>;
                if (infosCliente != null)
                {
                    int idCliente = infosCliente.Item1;
                    string cliente = infosCliente.Item2;

                    txt_cod_cliente.Text = idCliente.ToString();
                    txt_cliente.Text = cliente;
                }
            }
        }

        public bool DataValida(string data, string formato = "dd/MM/yyyy")
        {
            //tenta converter a string para DateTime usando o formato especificado
            DateTime dataConvertida;
            bool dataValida = DateTime.TryParseExact(data, formato, null, System.Globalization.DateTimeStyles.None, out dataConvertida);

            return dataValida;
        }

        private void txt_busca_reserva_Click(object sender, EventArgs e)
        {
            consultaReserva.btn_sair.Text = "Selecionar";
            consultaReserva.btn_buscainativos.Visible=false;
            if (consultaReserva.ShowDialog() == DialogResult.OK)
            {
                var infosReserva = consultaCliente.Tag as Tuple<int>;
                if (infosReserva != null)
                {
                    int idReserva = infosReserva.Item1;

                    txt_cod_reserva.Text = idReserva.ToString();
       
                }
            }


        }

        private void txt_busca_forma_Click(object sender, EventArgs e)
        {
            consultaFormaPagamento.btn_sair.Text = "Selecionar";
            consultaFormaPagamento.btn_buscainativos.Visible = false;
            if (consultaFormaPagamento.ShowDialog() == DialogResult.OK)
            {
                var infosForma = consultaCliente.Tag as Tuple<int, string>;
                if (infosForma != null)
                {
                    int idForma = infosForma.Item1;
                    string forma = infosForma.Item2;

                    txt_cod_reserva.Text = idForma.ToString();
                    txt_forma_pagamento.Text = forma;   

                }
            }
        }

        public void SetID(int idReserva, int idCliente, int parcela)
        {
            reserva_ID = idReserva;
            cliente_ID = idCliente;
            num_parcela = parcela;
        }

        private void CadastroContaReceber_Load(object sender, EventArgs e)
        {
            if (reserva_ID != -1 && cliente_ID != -1 && num_parcela != -1)
            {
                btn_receber.Visible = true;
                btn_salvar.Visible = true;
            }
        }

        public override void carrega()
        {
            base.carrega();
            var contasReceber = ControllerContasReceber.GetContaByReserva(reserva_ID, cliente_ID, num_parcela);
            if (contasReceber != null)
            {
                txt_cod_reserva.Text = contasReceber.reserva_ID.ToString();
                txt_cod_cliente.Text = contasReceber.cliente_ID.ToString();
                txt_data_emissao.Text = contasReceber.data_emissao?.ToString("dd/MM/yyyy");
                txt_cod_forma.Text = contasReceber.formaPagamento_ID.ToString();
                txt_num_parcela.Text = contasReceber.num_parcela.ToString();
                txt_vlr_parcela.Text = contasReceber.valor_parcela.ToString("N2");
                txt_data_vencimento.Text = contasReceber.data_vencimento?.ToString("dd/MM/yyyy");
                txt_juros.Text = contasReceber.juros.ToString();
                txt_multa.Text = contasReceber.multa.ToString() ;
                txt_desconto.Text = contasReceber.desconto.ToString();
                txt_valor_recebido.Text = contasReceber.valorRecebido.ToString();
                txt_data_recebimento.Text = contasReceber.data_recebimento?.ToString("dd/MM/yyyy");
                txt_observacao.Text = contasReceber.observacao.ToString();
                txt_data_cancelamento.Text = contasReceber.data_cancelamento?.ToString("dd/MM/yyyy");
                txt_dat_cad.Text = contasReceber.data_cadastro?.ToString("dd/MM/yyyy");
                txt_dat_ult_alt.Text = contasReceber.data_ult_alt?.ToString("dd/MM/yyyy");

                Cliente cliente = controllerCliente.GetById(int.Parse(txt_cod_cliente.Text));
                FormaPagamento formaPagamento = controllerFormaPagamento.GetById(int.Parse(txt_cod_forma.Text));

                if (cliente != null)
                    txt_cliente.Text = cliente.nome;

                if (formaPagamento != null)
                    txt_forma_pagamento.Text = formaPagamento.formaPagamento;

                // Verificar se está cancelado
                if (contasReceber.data_cancelamento != null)
                {
                    lbl_data_cancelamento.Visible = true;
                    txt_data_cancelamento.Visible = true;
                    btn_cancelar.Visible = false;
                    BloqueiaTudo();
                }
                else
                {
                    lbl_data_cancelamento.Visible = false;
                    txt_data_cancelamento.Visible = false;
                    btn_cancelar.Visible = true;
                    DesbloqueiaTudo();
                }

                // Se não recebido, calcular valores
                if (contasReceber.data_recebimento == null)
                {
                    calcularJuros();
                    calcularMulta();
                    calcularDesconto();
                }
                else
                {
                    BloqueiaTudo();
                }

                calculaTotalReceber();
            }
        }
        private void calculaTotalReceber()
        {
            decimal valorDesconto = string.IsNullOrWhiteSpace(txt_desconto.Text) ? 0 : Convert.ToDecimal(txt_desconto.Text);
            decimal valorJuros = string.IsNullOrWhiteSpace(txt_juros.Text) ? 0 : Convert.ToDecimal(txt_juros.Text);
            decimal valorMulta = string.IsNullOrWhiteSpace(txt_multa.Text) ? 0 : Convert.ToDecimal(txt_multa.Text);
            decimal valorParcela = string.IsNullOrWhiteSpace(txt_vlr_parcela.Text) ? 0 : Convert.ToDecimal(txt_vlr_parcela.Text);

            decimal totalPagar = valorParcela + valorJuros + valorMulta - valorDesconto;
            txt_total_receber.Text = totalPagar.ToString("N2");
        }



        private void calcularJuros()
        {
            if (DataValida(txt_data_vencimento.Text))
            {
                DateTime dataVencimento = DateTime.Parse(txt_data_vencimento.Text);
                DateTime dataAtual = DateTime.Now;

                int diasAtraso = (dataAtual - dataVencimento).Days;
                decimal valorJuros = 0;

                if (diasAtraso > 0 && porcentagemJuros.HasValue)
                {
                    valorJuros = (diasAtraso * porcentagemJuros.Value / 100) * Convert.ToDecimal(txt_vlr_parcela.Text);
                }
                txt_juros.Text = valorJuros.ToString("N2");
            }
        }
        private void calcularMulta()
        {
            if (DataValida(txt_data_vencimento.Text))
            {
                DateTime dataVencimento = DateTime.Parse(txt_data_vencimento.Text);
                DateTime dataAtual = DateTime.Now;

                //verifica se a data de vencimento menor que data atual
                if (dataVencimento < dataAtual && porcentagemMulta.HasValue)
                {
                    //aplica a porcentagem da multa ao valor da parcela
                    decimal valorParcela = Convert.ToDecimal(txt_vlr_parcela.Text);
                    decimal valorMulta = (porcentagemMulta.Value / 100) * valorParcela;

                    txt_multa.Text = valorMulta.ToString("N2");
                }
                else
                {
                    //se não houver atraso, a multa é zero
                    txt_multa.Text = "0.00";
                }
            }
        }
        private void calcularDesconto()
        {
            if (DataValida(txt_data_vencimento.Text))
            {
                if (porcentagemDesconto.HasValue && !string.IsNullOrWhiteSpace(txt_vlr_parcela.Text))
                {
                    decimal valorParcela = Convert.ToDecimal(txt_vlr_parcela.Text);
                    decimal valorDesconto = (porcentagemDesconto.Value / 100) * valorParcela;

                    txt_desconto.Text = valorDesconto.ToString("N2");
                }
                else
                {
                    txt_desconto.Text = "0.00";
                }
            }
        }

        protected bool VerificaCamposObrigatorios()
        {
           
            string dVencimento = new string(txt_data_vencimento.Text.Where(char.IsDigit).ToArray());


            if (!validadores.CampoObrigatorio(txt_cod_reserva.Text))
            {
                MessageBox.Show("Campo Código Reserva é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_reserva.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_cod_cliente.Text))
            {
                MessageBox.Show("Campo codigo cliente é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_cliente.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_cod_forma.Text))
            {
                MessageBox.Show("Campo Código Forma Pagamento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_forma.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_num_parcela.Text))
            {
                MessageBox.Show("Campo Nº Parcela é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_num_parcela.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_vlr_parcela.Text))
            {
                MessageBox.Show("Campo Valor Parcela é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_vlr_parcela.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_data_vencimento.Text))
            {
                MessageBox.Show("Campo Data Vencimento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_data_vencimento.Focus();
                return false;
            }
            return true;
        }

        private void btn_receber_Click(object sender, EventArgs e)
        {
            string dRecebimento = new string(txt_data_recebimento.Text.Where(char.IsDigit).ToArray());
            string dCancelamento = new string(txt_data_cancelamento.Text.Where(char.IsDigit).ToArray());

            if (!string.IsNullOrEmpty(dCancelamento))
            {
                MessageBox.Show("Nota Cancelada! Não é possível efetuar o pagamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(dRecebimento))
            {
                MessageBox.Show("Pagamento já foi realizado dia " + txt_data_recebimento.Text, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //parcela atual
            int parcelaAtual = Convert.ToInt32(txt_num_parcela.Text);
    
            int idCliente = Convert.ToInt32(txt_cod_cliente.Text);
            int reservaId = Convert.ToInt32(txt_cod_reserva.Text);

            //verificar se existe uma parcela menor não paga
            bool parcelaNaoPaga = ControllerContasReceber.VerificarParcelasNaoPagas( reservaId, idCliente, parcelaAtual);

            if (parcelaNaoPaga)
            {
                MessageBox.Show("Existem parcelas anteriores que não foram pagas. Pague as parcelas anteriores antes de pagar esta.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //se não existe parcelas menor não pagas, permitir o pagamento
            if (MessageBox.Show("Deseja realizar o pagamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                salvar();
                txt_data_recebimento.Text = DateTime.Now.ToString();
                txt_valor_recebido.Text = txt_total_receber.Text;
                salvar();
            }
        }

        public override void salvar()
        {
            if (!VerificaCamposObrigatorios())
            {
                return;
            }

            try
            {
                // Obter valores obrigatórios
                int reservaId = int.Parse(txt_cod_reserva.Text.Trim());
                int clienteId = int.Parse(txt_cod_cliente.Text.Trim());
                int idFormaPag = int.Parse(txt_cod_forma.Text.Trim());
                int parcela = int.Parse(txt_num_parcela.Text.Trim());
                decimal valorParcela = decimal.Parse(txt_vlr_parcela.Text.Trim());

                // Limpeza do campo Data de Vencimento
                string dataVencimentoTexto = txt_data_vencimento.Text.Trim().Replace("_", "").Replace(" ", "");
                if (!DateTime.TryParseExact(dataVencimentoTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataVencimento))
                {
                    MessageBox.Show("A Data de Vencimento não está no formato correto (dd/MM/yyyy).",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Limpeza e validação de Data de Recebimento (opcional)
                DateTime? dataRecebimento = null;
                string dataRecebimentoTexto = txt_data_recebimento.Text.Trim().Replace("_", "").Replace(" ", "");
                if (!string.IsNullOrEmpty(dataRecebimentoTexto) &&
                    DateTime.TryParseExact(dataRecebimentoTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedRecebimento))
                {
                    dataRecebimento = parsedRecebimento;
                }

                // Limpeza e validação de Data de Cancelamento (opcional)
                DateTime? dataCancelamento = null;
                string dataCancelamentoTexto = txt_data_cancelamento.Text.Trim().Replace("_", "").Replace(" ", "");
                if (!string.IsNullOrEmpty(dataCancelamentoTexto) &&
                    DateTime.TryParseExact(dataCancelamentoTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedCancelamento))
                {
                    dataCancelamento = parsedCancelamento;
                }

                // Validação de valores financeiros
                decimal valorRecebido = 0;
                if (!string.IsNullOrWhiteSpace(txt_valor_recebido.Text) &&
                    !decimal.TryParse(txt_valor_recebido.Text.Trim(), out valorRecebido))
                {
                    MessageBox.Show("O Valor Recebido está inválido.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal totalReceber = 0;
                if (!decimal.TryParse(txt_total_receber.Text.Trim(), out totalReceber))
                {
                    MessageBox.Show("O Total a Receber está inválido.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string observacao = txt_observacao.Text.Trim();

                // Criar o objeto para salvar
                ContasReceber contaReceber = new ContasReceber
                {
                    reserva_ID = reservaId,
                    cliente_ID = clienteId,
                    formaPagamento_ID = idFormaPag,
                    num_parcela = parcela,
                    data_vencimento = dataVencimento,
                    data_recebimento = dataRecebimento,
                    valorRecebido = valorRecebido,
                    data_cancelamento = dataCancelamento,
                    observacao = observacao
                };

                // Salvar ou atualizar no banco de dados
                if (reservaId != -1 && parcela != -1)
                {
                    // Atualiza a conta existente
                    ControllerContasReceber.alterar(contaReceber);
                }
                else
                {
                    // Insere uma nova conta
                    ControllerContasReceber.salvar(contaReceber);
                }

                MessageBox.Show("Conta salva com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            string dRecebimento = new string(txt_data_recebimento.Text.Where(char.IsDigit).ToArray());
            DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar esta conta a receber?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(dRecebimento))
                {
                    try
                    {
                        ContasReceber contaReceber = new ContasReceber
                        {
                           reserva_ID = reserva_ID,
                           cliente_ID = cliente_ID, 
                           num_parcela = num_parcela,
                           data_cancelamento = DateTime.Now
                        };
                        bool cancelamentoRealizado = ControllerContasReceber.CancelarContaPorReserva(contaReceber);

                        if (cancelamentoRealizado)
                        {
                            txt_data_cancelamento.Text = contaReceber.data_cancelamento?.ToString("dd/MM/yyyy");
                            lbl_data_cancelamento.Visible = true;
                            txt_data_cancelamento.Visible = true;
                            BloqueiaTudo();

                            MessageBox.Show("Conta a receber cancelada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível cancelar a conta, pois ela está associada a uma nota de venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao cancelar a conta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível cancelar uma conta que o pagamento já foi realizado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_data_emissao_Leave(object sender, EventArgs e)
        {
                DateTime dataEmissao;
                DateTime dataHoje = DateTime.Now;
                bool dataValida = DateTime.TryParse(txt_data_emissao.Text, out dataEmissao);

                string dataE = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());

                if (!string.IsNullOrEmpty(dataE))
                {
                    if (DataValida(txt_data_emissao.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(dataE) && dataValida)
                        {
                            if (dataEmissao > dataHoje)
                            {
                                MessageBox.Show("Data de emissão inválida! A data deve ser menor ou igual a hoje.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_data_emissao.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data de emissão inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_data_emissao.Focus();
                        return;
                    }
                }
            
        }

        private void txt_cod_forma_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_forma.Text))
            {
                string formaPag = controllerFormaPagamento.getFormaPag(int.Parse(txt_cod_forma.Text));
                if (formaPag != null)
                {
                    txt_forma_pagamento.Text = formaPag;
                }
                else
                {
                    MessageBox.Show("Forma de Pagamento não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_forma.Focus();
                    txt_cod_forma.Clear();
                    txt_forma_pagamento.Clear();
                }
            }
        }

        private void txt_data_vencimento_Leave(object sender, EventArgs e)
        {
            string dVencimento = new string(txt_data_vencimento.Text.Where(char.IsDigit).ToArray());
            string dEmissao = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());
            if (!string.IsNullOrEmpty(dVencimento) && !string.IsNullOrEmpty(dEmissao))
            {
                if (DataValida(txt_data_emissao.Text) && DataValida(txt_data_vencimento.Text))
                {
                    DateTime dataEmissao;
                    DateTime dataVencimento;

                    bool dataEmissaoValida = DateTime.TryParseExact(txt_data_emissao.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataEmissao);
                    bool dataVencimentoValida = DateTime.TryParseExact(txt_data_vencimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataVencimento);

                    if (dataEmissaoValida && dataVencimentoValida)
                    {
                        if (dataVencimento < dataEmissao)
                        {
                            MessageBox.Show("Data de vencimento inválida! A data de vencimento deve ser maior ou igual à data de emissão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_data_vencimento.Focus();
                            return;
                        }
                    }
                    calcularJuros();
                    calcularMulta();
                    calcularDesconto();
                }
                else
                {
                    MessageBox.Show("Data de emissão ou data de vencimento inválida! Verifique os valores inseridos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_data_vencimento.Focus();
                }
            }
        }



        private void txt_cod_cliente_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_cliente.Text))
            {
                string cliente = controllerCliente.getCliente(int.Parse(txt_cod_cliente.Text));
                if (cliente != null)
                {
                    txt_cliente.Text = cliente;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_cliente.Focus();
                    txt_cod_cliente.Clear();
                    txt_cliente.Clear();
                }
            }
        }
    }
}
