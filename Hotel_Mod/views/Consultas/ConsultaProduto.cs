using Hotel_Mod.Controller;
using Hotel_Mod.Models;
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
    public partial class ConsultaProduto : Hotel_Mod.views.ConsultaPai
    {
        private controllerProduto<Produto> controllerProduto;
        private CadastroProduto CadastroProduto;
        public ConsultaProduto()
        {
            InitializeComponent();
            controllerProduto = new controllerProduto<Produto>();
            CadastroProduto = new CadastroProduto();
            CadastroProduto.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            CadastroProduto.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridViewProduto.SelectedRows.Count > 0)
            {
                int produto_ID = (int)dataGridViewProduto.SelectedRows[0].Cells["Código"].Value;
                CadastroProduto cadastroProduto = new CadastroProduto();
                cadastroProduto.Owner = this;
                cadastroProduto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um produto para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewProduto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este produto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int produto_ID = (int)dataGridViewProduto.CurrentRow.Cells[0].Value;
                    controllerProduto.excluir(produto_ID);
                    dataGridViewProduto.DataSource = controllerProduto.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim(); //obtem a pesquisa do txt

            //verifica se há um termo de pesquisa
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    //filtra os dados dos produtos
                    List<Produto> resultadosPesquisa = controllerProduto.GetAll(btn_buscainativos.Checked).Where(p => p.produto.ToLower().Contains(pesquisa.ToLower())).ToList();
                    dataGridViewProduto.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
                    txt_pesquisar.Text = string.Empty; //limpa o txt pesquisa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaProdutos(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaProdutos(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos produtos na consulta de produtos
                dataGridViewProduto.DataSource = controllerProduto.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCadastro()
        {
            CadastroProduto.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewProduto.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do produto selecionado
                    int produto_ID = Convert.ToInt32(dataGridViewProduto.SelectedRows[0].Cells["Código"].Value);
                    string nome = dataGridViewProduto.SelectedRows[0].Cells["Produto"].Value.ToString();

                    // Passar os detalhes do produto selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(produto_ID, nome);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }


        private void ConsultaProduto_Load(object sender, EventArgs e)
        {
            try
            {
                CadastroProduto cadastroProduto = new CadastroProduto();
                cadastroProduto.FormClosed += (s, args) => AtualizarConsultaProdutos(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta

                dataGridViewProduto.AutoGenerateColumns = false;
                dataGridViewProduto.Columns["Código"].DataPropertyName = "produto_ID";
                dataGridViewProduto.Columns["Produto"].DataPropertyName = "produto";
                dataGridViewProduto.Columns["Unidade"].DataPropertyName = "unidade";
                dataGridViewProduto.Columns["Custo Médio"].DataPropertyName = "custo_medio";
                dataGridViewProduto.Columns["Preço Venda"].DataPropertyName = "preco_venda";
                dataGridViewProduto.Columns["Ativo"].DataPropertyName = "ativo";

                AtualizarConsultaProdutos(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscainativos_CheckedChanged_1(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaProdutos(incluirInativos);
        }
    }
}
