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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroReserva : Hotel_Mod.views.CadastroPai
    {
        private ConsultaCliente consultaCliente;
        private controllerReservas<Reserva> controllerReservas;
        private controllerCliente<Clientes> controllerCliente;
        private DaoReserva<Reserva> daoReserva;
        private ConsultaCondPagamento consultaCondPagamento;
        private controllerCondPagamento<CondicaoPagamento> ControllerCondPagamento;
        private ConsultaQuarto consultaQuarto;
        private controllerQuarto<Quarto> controllerQuarto;


        public CadastroReserva()
        {
            InitializeComponent();
            dtp_checkin.ValueChanged += dtp_checkin_ValueChanged_1;
            dtp_checkout.ValueChanged += dtp_checkout_ValueChanged;


            consultaCliente = new ConsultaCliente();
            controllerCliente = new controllerCliente<Clientes>();

            controllerReservas = new controllerReservas<Reserva>();

            controllerReservas = new controllerReservas<Reserva>();

            consultaCondPagamento = new ConsultaCondPagamento();
            ControllerCondPagamento = new controllerCondPagamento<CondicaoPagamento>();

            consultaQuarto = new ConsultaQuarto();
            controllerQuarto = new controllerQuarto<Quarto>();
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
            txt_observacao.Clear();
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

                    Clientes ClienteDetalhes = controllerCliente.GetById(cliente_ID);
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
                var quartoDetalhes = consultaQuarto.Tag as Tuple<int, int, int, decimal>;

                if (quartoDetalhes != null)
                {
                    int quarto_ID = quartoDetalhes.Item1;
                    int numero = quartoDetalhes.Item2;
                    int andar = quartoDetalhes.Item3;
                    decimal valorDiaria = quartoDetalhes.Item4;

                    txt_cod_quarto.Text = quarto_ID.ToString();
                    txt_numero.Text = numero.ToString();
                    txt_andar.Text = andar.ToString();
                    txt_valor_diaria.Text = valorDiaria.ToString();

                    Quarto QuartoDetalhes = controllerQuarto.GetById(quarto_ID);
                    if (QuartoDetalhes != null)
                        txt_cod_quarto.Text = QuartoDetalhes.quarto_ID.ToString();

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
                        MessageBox.Show("A data de check-out deve ser maior que a data de check-in.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            ValidarDatas();
        }



        private void dtp_checkin_ValueChanged_1(object sender, EventArgs e)
        {
            AtualizarNumeroDeDias();
            ValidarDatas();
        }

        private void ValidarDatas()
        {
            DateTime checkinDate = dtp_checkin.Value;
            DateTime checkoutDate = dtp_checkout.Value;

            if (checkinDate > checkoutDate)
            {
                MessageBox.Show("A data de check-in não pode ser maior que a data de check-out.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_checkin.Value = dtp_checkout.Value;
            }
        }
    }
}
