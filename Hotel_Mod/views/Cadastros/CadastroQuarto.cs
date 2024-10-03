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

        public CadastroQuarto()
        {
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
                    txt_codigo.Text = quarto.quarto_ID.ToString();
                    txt_numero.Text = quarto.numero.ToString();
                    txt_andar.Text = quarto.andar.ToString();
                    cmb_tipo.SelectedItem = quarto.tipo;
                    txt_descricao.Text = quarto.descricao;
                    txt_valor.Text = quarto.valor.ToString("F2"); // Mostra o valor com duas casas decimais
                    txt_dat_cad.Text = quarto.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = quarto.data_ult_alt.ToString();
                    check_ativo.Checked = quarto.ativo;
                    check_inativo.Checked = !quarto.ativo;
                    check_disponivel.Checked = quarto.disponivel;
                    check_indisponivel.Checked = !quarto.disponivel;
                }
                else
                {
                    MessageBox.Show("Quarto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
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
            else if (!validadores.CampoObrigatorio(cmb_tipo.SelectedItem.ToString()))
            {
                MessageBox.Show("Campo Tipo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_tipo.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_valor.Text) || !decimal.TryParse(txt_valor.Text.Replace("R$", "").Trim(), out decimal valor))
            {
                MessageBox.Show("Campo Valor é obrigatório e deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_valor.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (int.TryParse(txt_numero.Text, out int numero))  // Convertendo o valor de txt_numero para int
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
                            int andar = int.Parse(txt_andar.Text); // Convertendo o valor de txt_andar para int
                            string tipo = cmb_tipo.SelectedItem.ToString(); 
                            string descricao = txt_descricao.Text;

                            DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                            DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                            Quarto novoQuarto = new Quarto
                            {
                                numero = numero,   // Usando o número já convertido para int
                                andar = andar,
                                tipo = tipo,
                                valor = valor,
                                descricao = descricao,
                                data_cadastro = data_cadastro,
                                data_ult_alt = data_ult_alt,
                                ativo = check_ativo.Checked,
                                disponivel = check_disponivel.Checked
                            };

                            if (altera == -1)
                            {
                                controllerQuarto.salvar(novoQuarto);
                            }
                            else
                            {
                                novoQuarto.quarto_ID = altera; // ID do quarto alterado
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
            cmb_tipo.SelectedIndex = -1;
            txt_valor.Clear();
            txt_descricao.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
            check_disponivel.Checked = true;
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

        private void CadastroQuarto_Load(object sender, EventArgs e)
        {

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
    }
}
