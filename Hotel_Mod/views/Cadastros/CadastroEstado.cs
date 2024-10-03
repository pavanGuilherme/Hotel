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
    public partial class CadastroEstado : Hotel_Mod.views.CadastroPai
    {


        private controllerEstado<Estado> controllerEstado;
        private ConsultaPais ConsultaPais;
        private controllerPais<Pais> controllerPais;
        public CadastroEstado()
        {
            InitializeComponent();
            controllerEstado = new controllerEstado<Estado>();
            ConsultaPais = new ConsultaPais();
            controllerPais = new controllerPais<Pais>();
        }

        public CadastroEstado(int estado_ID) : this()
        {
            altera = estado_ID;
            carrega();
        }

        //public override void Bloqueia()
        //{
        //    txtEstado.Enabled = false;
        //    txtUF.Enabled = false;
        //    txtPais.Enabled = false;
        //    txtCodPais.Enabled = false;
        //    btnConsultaPais.Enabled = false;
        //}

        public override void carrega()
        {
            if (altera != -1)
            {
                Estado estado = controllerEstado.GetById(altera);
                if (estado != null)
                {
                    txt_codigo.Text = estado.estado_ID.ToString();
                    txt_estado.Text = estado.estado;
                    txt_uf.Text = estado.uf;
                    txt_cod_pais.Text = estado.pais_ID.ToString();
                    txt_dat_cad.Text = estado.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = estado.data_ult_alt.ToString();
                    check_ativo.Checked = estado.ativo;
                    check_inativo.Checked = !estado.ativo;

                    string nomePais = controllerEstado.GetNomePaisByEstadoId(estado.estado_ID);

                    if (!string.IsNullOrEmpty(nomePais))
                    {
                        txt_pais.Text = nomePais;
                    }
                }
                else
                {
                    MessageBox.Show("Estado não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_estado.Clear();
            txt_uf.Clear();
            txt_cod_pais.Clear();
            txt_pais.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        public void SetID(int id)
        {
            altera = id;
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_estado.Text))
            {
                MessageBox.Show("Campo Estado é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_estado.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_uf.Text))
            {
                MessageBox.Show("Campo UF é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_uf.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_cod_pais.Text))
            {
                MessageBox.Show("Campo Código País é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_pais.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerEstado.JaCadastrado(txt_estado.Text, idAtual))
                {
                    MessageBox.Show("Estado já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_estado.Focus();
                }
                else
                {
                    try
                    {
                        string estado = txt_estado.Text;
                        string uf = txt_uf.Text;
                        int pais_ID = int.Parse(txt_cod_pais.Text);

                        DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                        DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                        Estado novoEstado = new Estado
                        {
                            estado = estado,
                            uf = uf,
                            pais_ID = pais_ID,
                            data_cadastro = data_cadastro,
                            data_ult_alt = data_ult_alt,
                            ativo = ativo
                        };

                        if (altera == -1)
                        {
                            controllerEstado.salvar(novoEstado);
                        }
                        else
                        {
                            novoEstado.estado_ID = altera;
                            controllerEstado.alterar(novoEstado);
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

        private void CadastroEstados_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaEstado)this.Owner).AtualizarConsultaEstados(false);
        }

        private void txt_cod_pais_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_cod_pais.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_pais.Focus();
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_cod_pais.Text))
                {
                    Pais pais = controllerPais.GetById(int.Parse(txt_cod_pais.Text));
                    if (pais != null)
                    {
                        txt_pais.Text = pais.pais;
                    }
                    else
                    {
                        MessageBox.Show("País não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_cod_pais.Focus();
                    }
                }
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


        //busca o pais pelo codigo
        private void btn_cod_pais_Click(object sender, EventArgs e)
        {
            ConsultaPais.btn_sair.Text = "Selecionar";

            if (ConsultaPais.ShowDialog() == DialogResult.OK)
            {
                // Receber os detalhes do país selecionado
                var paisDetalhes = ConsultaPais.Tag as Tuple<int, string>;
                if (paisDetalhes != null)
                {
                    int pais_ID = paisDetalhes.Item1;
                    string pais = paisDetalhes.Item2;

                    // Atualizar o campo txtPais com o nome do país selecionado
                    txt_cod_pais.Text = pais_ID.ToString();
                    txt_pais.Text = pais;
                }
            }
        }

        private void CadastroEstado_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaEstado)this.Owner).AtualizarConsultaEstados(false);
        }
    }
}









