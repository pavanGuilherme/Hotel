using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Hotel_Mod.views.Cadastros;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public partial class ConsultaFornecedor : ConsultaPai
    {
        private ControllerFornecedor<Fornecedor> controllerFornecedor;
        private CadastroFornecedor cadastroFornecedor;

        public ConsultaFornecedor()
        {
            InitializeComponent();
            controllerFornecedor = new ControllerFornecedor<Fornecedor>();
            cadastroFornecedor = new CadastroFornecedor();
            cadastroFornecedor.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroFornecedor.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
                int fornecedor_ID = (int)dataGridViewFornecedor.SelectedRows[0].Cells["codigo"].Value;
                CadastroFornecedor cadastroFornecedor = new CadastroFornecedor(fornecedor_ID);
                cadastroFornecedor.Owner = this;
                cadastroFornecedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este fornecedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int fornecedor_ID = (int)dataGridViewFornecedor.CurrentRow.Cells["codigo"].Value;
                    controllerFornecedor.excluir(fornecedor_ID);
                    dataGridViewFornecedor.DataSource = controllerFornecedor.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<Fornecedor> resultadosPesquisa = controllerFornecedor.GetAll(btn_buscainativos.Checked)
                        .Where(f => f.fornecedor_razao_social.ToLower().Contains(pesquisa.ToLower())).ToList();

                    dataGridViewFornecedor.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar fornecedores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaFornecedores(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaFornecedores(bool incluirInativos)
        {
            try
            {
                dataGridViewFornecedor.DataSource = controllerFornecedor.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de fornecedores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCadastro()
        {
            cadastroFornecedor.LimparCampos();
        }



        private void btn_buscainativos_CheckedChanged_1(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaFornecedores(incluirInativos);
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                btn_sair.Focus();
                if (dataGridViewFornecedor.SelectedRows.Count > 0)
                {
                    int fornecedor_ID = Convert.ToInt32(dataGridViewFornecedor.SelectedRows[0].Cells["codigo"].Value);
               

                    this.Tag = new Tuple<int>(fornecedor_ID);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um fornecedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }

        private void ConsultaFornecedor_Load_1(object sender, EventArgs e)
        {
            try
            {
                CadastroFornecedor cadastroFornecedor = new CadastroFornecedor();
                cadastroFornecedor.FormClosed += (s, args) => AtualizarConsultaFornecedores(btn_buscainativos.Checked);

                dataGridViewFornecedor.AutoGenerateColumns = false;
                dataGridViewFornecedor.Columns["codigo"].DataPropertyName = "fornecedor_ID";
                dataGridViewFornecedor.Columns["fornecedor_razao_social"].DataPropertyName = "fornecedor_razao_social";
                dataGridViewFornecedor.Columns["cpf_cnpj"].DataPropertyName = "cpf_cnpj";
                dataGridViewFornecedor.Columns["ativo"].DataPropertyName = "ativo";


                AtualizarConsultaFornecedores(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os fornecedores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
