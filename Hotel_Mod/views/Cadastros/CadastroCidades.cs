using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public partial class CadastroCidades : Hotel_Mod.views.CadastroPai
    {
        private ConsultaEstado consultaEstado;
        private controllerCidade<Cidade> controllerCidade;
        private controllerEstado<Estado> ControllerEstado;
        public CadastroCidades()
        {
            InitializeComponent();
            controllerCidade = new controllerCidade<Cidade>();
            consultaEstado = new ConsultaEstado();
            ControllerEstado = new controllerEstado<Estado>();  
        }

        public CadastroCidades(int cidade_ID) : this()
        {
            altera = cidade_ID;
            carrega();
        }
        public override void carrega()
        {
            //verifica se há um país a ser alterado
            if (altera != -1)
            {
                Cidade cidade = controllerCidade.GetById(altera);
                if (cidade != null)
                {
                    //carrega os dados do país nos controles do formulário
                    txt_codigo.Text = cidade.cidade_ID.ToString();
                    txt_cidade.Text = cidade.cidade;
                    txt_ddd.Text = cidade.ddd;
                    txt_cod_estado.Text = cidade.estado_ID.ToString();
                    txt_dat_cad.Text = cidade.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = cidade.data_ult_alt.ToString();
                    check_ativo.Checked = cidade.ativo;
                    check_inativo.Checked = !cidade.ativo;

                    string nomeEstado = controllerCidade.GetNomeEstadoByCidadeId(cidade.cidade_ID);
                    if (!string.IsNullOrEmpty(nomeEstado))
                    {
                        txt_estado.Text = nomeEstado;
                    }

                }
                else
                {
                    MessageBox.Show("Cidade não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_cidade.Text))
            {
                MessageBox.Show("Campo cidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cidade.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_ddd.Text))
            {
                MessageBox.Show("Campo ddd é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ddd.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerCidade.JaCadastrado(txt_cidade.Text, idAtual))
                {
                    MessageBox.Show("Cidade já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cidade.Focus();
                }
                else
                {
                    try
                    {
                        string cidade = txt_cidade.Text;
                        string ddd = txt_ddd.Text;
                        int estado_ID = int.Parse(txt_cod_estado.Text);


                        DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                        DateTime dataUltAlt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                        Cidade novaCidade = new Cidade
                        {
                            cidade = cidade,
                            ddd = ddd,
                            estado_ID = estado_ID,
                            data_cadastro = dataCadastro,
                            data_ult_alt = dataUltAlt,
                            ativo = ativo
                        };

                        if (altera == -1)
                        {
                            controllerCidade.salvar(novaCidade);
                        }
                        else
                        {
                            novaCidade.cidade_ID = altera; // ID do país alterado
                            controllerCidade.alterar(novaCidade);
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txt_pais_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetras(txt_cidade.Text))
            {
                MessageBox.Show("O campo cidade é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cidade.Focus();
            }

        }
        private void txt_sigla_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_ddd.Text))
            {
                MessageBox.Show("campo ddd inválido.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ddd.Focus();
            }

        }

        private void check_ativo_CheckedChanged(object sender, EventArgs e)
        {
            ativo = check_ativo.Checked;

        }

        private void check_inativo_CheckedChanged(object sender, EventArgs e)
        {
            ativo = !check_inativo.Checked;

        }

        private void CadastroPais_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaPais)this.Owner).AtualizarConsultaPaises(false);
        }

        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_cidade.Clear();
            txt_ddd.Clear();
            txt_cod_estado.Clear(); 
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            consultaEstado.btn_sair.Text = "Selecionar";

            if (consultaEstado.ShowDialog() == DialogResult.OK)
            {
                // Receber os detalhes do país selecionado
                var estadoDetalhes = consultaEstado.Tag as Tuple<int, string>;
                if (estadoDetalhes != null)
                {
                    int estado_ID = estadoDetalhes.Item1;
                    string estado = estadoDetalhes.Item2;

                    // Atualizar o campo txtPais com o nome do país selecionado
                    txt_cod_estado.Text = estado_ID.ToString();
                    txt_estado.Text = estado;
                }
            }
        }

        private void txt_cod_estado_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_cod_estado.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_estado.Focus();
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_cod_estado.Text))
                {
                    Estado estado = ControllerEstado.GetById(int.Parse(txt_cod_estado.Text));
                    if (estado != null)
                    {
                        txt_estado.Text = estado.estado;
                    }
                    else
                    {
                        MessageBox.Show("Estado não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_cod_estado.Focus();
                    }
                }
            }

        }
    }
}
