using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroQuarto : Hotel_Mod.views.CadastroPai
    {
        private controllerQuarto<Quarto> controllerQuarto;
        private ConsultaTipoQuarto consultaTipoQuarto;


        public CadastroQuarto()
        {

            consultaTipoQuarto = new ConsultaTipoQuarto();
            controllerQuarto = new controllerQuarto<Quarto>();
            InitializeComponent();
        }

        // Construtor para alterar um quarto existente
        public CadastroQuarto(int quarto_ID) : this()
        {
            altera = quarto_ID;
            carrega();
        }

        public override void carrega()
        {
            // Verifica se há um quarto a ser alterado
            if (altera != -1)
            {
                Quarto quarto = controllerQuarto.GetById(altera);
                if (quarto != null)
                {
                    // Carrega os dados do quarto nos controles do formulário
                    txt_capacidade.Text = quarto.capacidade_maxima.ToString();
                    txt_codigo.Text = quarto.quarto_ID.ToString();
                    txt_numero.Text = quarto.numero.ToString();
                    txt_andar.Text = quarto.andar.ToString();
                    txt_tipo_id.Text = quarto.tipo_id.ToString();
                    txt_tipo.Text = quarto.tipo.ToString();
                    cmb_situacao.Text = quarto.situacao.ToString();
                    txt_descricao.Text = quarto.descricao.ToString();
                    txt_valor.Text = quarto.valor_diaria.ToString("F2"); // Mostra o valor com duas casas decimais
                    txt_dat_cad.Text = quarto.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = quarto.data_ult_alt.ToString();
                    check_ativo.Checked = quarto.ativo;
                    check_inativo.Checked = !quarto.ativo;

                }
                else
                {
                    MessageBox.Show("Quarto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
            // Validações dos campos obrigatórios
            if (!validadores.CampoObrigatorio(txt_numero.Text))
            {
                MessageBox.Show("Campo Número é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_numero.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_andar.Text))
            {
                MessageBox.Show("Campo Andar é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_andar.Focus();
            }
            else if (string.IsNullOrEmpty(txt_tipo_id.Text) || !int.TryParse(txt_tipo_id.Text, out int tipoId))
            {
                MessageBox.Show("Campo Tipo é obrigatório e deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tipo_id.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_valor.Text) || !decimal.TryParse(txt_valor.Text.Replace("R$", "").Trim(), out decimal valor))
            {
                MessageBox.Show("Campo Valor é obrigatório e deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_valor.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_capacidade.Text) || !int.TryParse(txt_capacidade.Text, out int capacidadeMaxima))
            {
                MessageBox.Show("Campo Capacidade Máxima é obrigatório e deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_capacidade.Focus();
            }
            else if (cmb_situacao.Text == null || !validadores.CampoObrigatorio(cmb_situacao.Text.ToString()))
            {
                MessageBox.Show("Campo Situação é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_situacao.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (int.TryParse(txt_numero.Text, out int numero))
                {
                    if (controllerQuarto.JaCadastrado(numero, idAtual))
                    {
                        MessageBox.Show("Quarto já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_numero.Focus();
                    }
                    else
                    {
                        try
                        {
                            int andar = int.Parse(txt_andar.Text);
                            string situacao = cmb_situacao.Text;
                            string descricao = txt_descricao.Text;
                            string observacao = txt_obs.Text;


                            DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                            DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                            Quarto novoQuarto = new Quarto
                            {
                                numero = numero,
                                andar = andar,
                                tipo_id = tipoId,
                                tipo = txt_tipo.Text,
                                valor_diaria = valor,
                                capacidade_maxima = capacidadeMaxima,
                                situacao = situacao,
                                descricao = descricao,
                                observacao = observacao,
                                data_cadastro = data_cadastro,
                                data_ult_alt = data_ult_alt,
                                ativo = ativo
                            };

                            if (altera == -1)
                            {
                                controllerQuarto.salvar(novoQuarto);
                            }
                            else
                            {
                                novoQuarto.quarto_ID = altera;
                                controllerQuarto.alterar(novoQuarto);
                            }

                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Número do quarto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_numero.Focus();
                }
            }
        }


        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_numero.Clear();
            txt_andar.Clear();
            txt_tipo_id.Clear();
            txt_valor.Clear();
            txt_descricao.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;

        }

        public void SetID(int id)
        {
            altera = id;
        }

        private void CadastroQuarto_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Atualiza a consulta de quartos ao fechar o formulário de cadastro
            ((ConsultaQuarto)this.Owner).AtualizarConsultaQuartos(false);
        }


        private void txt_numero_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_numero.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_numero.Focus();
            }
        }

        private void txt_andar_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_andar.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_andar.Focus();
            }
        }

        private void CadastroQuarto_Load_1(object sender, EventArgs e)
        {


            if (altera == -1)
            {
                int novoCodigo = controllerQuarto.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }

            cmb_situacao.Text = "livre";
            // Configuração do ComboBox de Situação no Load do formulário
            cmb_situacao.Items.Add("ocupado");
            cmb_situacao.Items.Add("reservado");
            cmb_situacao.Items.Add("livre");
            cmb_situacao.Items.Add("em preparação");
            

        }



        private void btn_busca_tipo_Click(object sender, EventArgs e)
        {
            consultaTipoQuarto.btn_sair.Text = "Selecionar";

            if (consultaTipoQuarto.ShowDialog() == DialogResult.OK)
            {
                // Receber os detalhes do país selecionado
                var tipoDetalhes = consultaTipoQuarto.Tag as Tuple<int, string, string, decimal, int>;
                if (tipoDetalhes != null)
                {
                    int tipo_ID = tipoDetalhes.Item1;
                    string tipo = tipoDetalhes.Item2;
                    string descricao = tipoDetalhes.Item3;
                    decimal valor_diaria = tipoDetalhes.Item4;
                    int capacidade_maxima = tipoDetalhes.Item5;

                    // Atualizar o campo txtPais com o nome do país selecionado
                    txt_tipo_id.Text = tipo_ID.ToString();
                    txt_tipo.Text = tipo.ToString();
                    txt_descricao.Text = descricao;
                    txt_valor.Text = valor_diaria.ToString();
                    txt_capacidade.Text = capacidade_maxima.ToString(); 
                }
            }
        }


        private void txt_tipo_id_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_tipo_id.Text))
            {
                int tipoId;
                if (int.TryParse(txt_tipo_id.Text, out tipoId))
                {
                    // Busca o tipo de quarto com base no ID fornecido
                    tipo_quarto tipoInfo = controllerQuarto.ObterTipoQuartoPorId(tipoId);

                    if (tipoInfo != null)
                    {
                        txt_tipo.Text = tipoInfo.tipo;           // Tipo
                        txt_descricao.Text = tipoInfo.descricao; // Descrição
                        txt_valor.Text = tipoInfo.valor_diaria.ToString("F2"); // Formats to two decimal places

                    }
                    else
                    {
                        MessageBox.Show("Código de Tipo de Quarto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_tipo_id.Focus();
                        txt_tipo_id.Clear();
                        txt_tipo.Clear();
                        txt_descricao.Clear();
                        txt_valor.Clear();  
                    }
                }
                else
                {
                    MessageBox.Show("Código de Tipo de Quarto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_tipo_id.Focus();
                    txt_tipo_id.Clear();
                    txt_tipo.Clear();
                    txt_descricao.Clear();
                    txt_valor.Clear();  
                }
            }
        }

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }
    }
}

