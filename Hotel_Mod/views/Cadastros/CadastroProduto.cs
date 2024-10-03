using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroProduto : Hotel_Mod.views.CadastroPai
    {
        public ConsultaFornecedor consultaFornecedor;
        private ControllerFornecedor<Fornecedor> controllerFornecedor;
        private controllerProduto<Produto> controllerProduto;
        public CadastroProduto()
        {
            InitializeComponent();
            controllerProduto = new controllerProduto<Produto>();
            controllerFornecedor = new ControllerFornecedor<Fornecedor>();
            consultaFornecedor = new ConsultaFornecedor();
        }

        // Construtor para alterar um produto
        public CadastroProduto(int produto_ID) : this()
        {
            altera = produto_ID;
            carrega();
        }

        public override void carrega()
        {
            // Verifica se há um produto a ser alterado
            if (altera != -1)
            {
                Produto produto = controllerProduto.GetById(altera);
                if (produto != null)
                {
                    // Carrega os dados do produto nos controles do formulário
                    txt_codigo.Text = produto.produto_ID.ToString();
                    txt_produto.Text = produto.produto;
                    txt_unidade.Text = produto.unidade;
                    txt_saldo.Text = produto.saldo.ToString();
                    txt_custo_medio.Text = produto.custo_medio.ToString();
                    txt_preco_venda.Text = produto.preco_venda.ToString();
                    txt_preco_ult_compra.Text = produto.preco_ult_compra.ToString();
                    txt_dat_ult_compra.Text = produto.data_ult_compra.ToString();
                    txt_obs.Text = produto.observacao;
                    txt_fornecedor_ID.Text = produto.fornecedor_ID.ToString();
                    txt_dat_cad.Text = produto.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = produto.data_ult_alt.ToString();
                    check_ativo.Checked = produto.ativo;
                    check_inativo.Checked = !produto.ativo;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_produto.Text))
            {
                MessageBox.Show("Campo Produto é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_produto.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_unidade.Text))
            {
                MessageBox.Show("Campo Unidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_unidade.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_preco_venda.Text))
            {
                MessageBox.Show("Campo Preço Venda é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_preco_venda.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerProduto.JaCadastrado(txt_produto.Text, idAtual))
                {
                    MessageBox.Show("Produto já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_produto.Focus();
                }
                else
                {
                    try
                    {
                        string produto = txt_produto.Text;
                        string unidade = txt_unidade.Text;
                        decimal saldo = decimal.Parse(txt_saldo.Text);
                        decimal custo_medio = decimal.Parse(txt_custo_medio.Text);
                        decimal preco_venda = decimal.Parse(txt_preco_venda.Text);
                        decimal preco_ult_compra = decimal.Parse(txt_preco_ult_compra.Text);
                        DateTime data_ult_compra = DateTime.Parse(txt_dat_ult_compra.Text);
                        string observacao = txt_obs.Text;
                        int fornecedor_ID = int.Parse(txt_fornecedor_ID.Text);

                        DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                        DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                        Produto novoProduto = new Produto
                        {
                            produto = produto,
                            unidade = unidade,
                            saldo = saldo,
                            custo_medio = custo_medio,
                            preco_venda = preco_venda,
                            preco_ult_compra = preco_ult_compra,
                            data_ult_compra = data_ult_compra,
                            observacao = observacao,
                            fornecedor_ID = fornecedor_ID,
                            data_cadastro = data_cadastro,
                            data_ult_alt = data_ult_alt,
                            ativo = ativo
                        };

                        if (altera == -1)
                        {
                            controllerProduto.salvar(novoProduto);
                        }
                        else
                        {
                            novoProduto.produto_ID = altera; // ID do produto alterado
                            controllerProduto.alterar(novoProduto);
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

        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_produto.Clear();
            txt_unidade.Clear();
            txt_saldo.Clear();
            txt_custo_medio.Clear();
            txt_preco_venda.Clear();
            txt_preco_ult_compra.Clear();
            txt_dat_ult_compra.Clear();
            txt_obs.Clear();
            txt_fornecedor_ID.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        public void SetID(int id)
        {
            altera = id;
        }

        private void CadastroProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Atualiza a consulta de produtos ao fechar o formulário de cadastro
            ((ConsultaProduto)this.Owner).AtualizarConsultaProdutos(false);
        }

        private void CadastroProduto_Load(object sender, EventArgs e)
        {

        }

        private void txt_produto_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetras(txt_produto.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_produto.Focus();
            }
        }

        private void txt_unidade_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaLetrasSemEspaco(txt_unidade.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_unidade.Focus();
            }
        }

        private void txt_preco_venda_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_preco_venda.Text))
            {
                MessageBox.Show("Campo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_preco_venda.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultaFornecedor.btn_sair.Text = "Selecionar";

            if (consultaFornecedor.ShowDialog() == DialogResult.OK)
            {
                var fornecedoresDetalhes = consultaFornecedor.Tag as Tuple<int>;

                if (fornecedoresDetalhes != null)
                {
                    int fornecedorID = fornecedoresDetalhes.Item1;
                   

                    txt_fornecedor_ID.Text = fornecedorID.ToString();
                 
                }
            }
        }
    }
}

