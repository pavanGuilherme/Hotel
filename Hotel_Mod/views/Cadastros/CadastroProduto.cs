using Hotel_Mod.Class;
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
                    txt_produto.Text = produto.nome_produto;
                    txt_unidade.Text = produto.unidade;
                    txt_saldo.Text = produto.saldo.ToString();
                    txt_custo_medio.Text = produto.custo_medio.ToString();
                    txt_preco_medio.Text = produto.preco_medio.ToString();
                    txt_preco_ult_compra.Text = produto.preco_ultima_compra.ToString();
                    txt_data_ultcompra.Text = produto.data_ultima_compra.ToString();
                    txt_observacao.Text = produto.observacao;
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
            // Validações obrigatórias dos campos
            if (!validadores.CampoObrigatorio(txt_produto.Text))
            {
                MessageBox.Show("Campo Produto é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_produto.Focus();
                return;
            }
            if (!validadores.CampoObrigatorio(txt_unidade.Text))
            {
                MessageBox.Show("Campo Unidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_unidade.Focus();
                return;
            }
            if (!validadores.CampoObrigatorio(txt_preco_medio.Text))
            {
                MessageBox.Show("Campo Preço Médio é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_preco_medio.Focus();
                return;
            }
            if (!validadores.CampoObrigatorio(txt_marca.Text))
            {
                MessageBox.Show("Campo Marca é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_marca.Focus();
                return;
            }

            // Verifica se o produto já foi cadastrado
            int idAtual = altera != -1 ? altera : -1;
            if (controllerProduto.JaCadastrado(txt_produto.Text, idAtual))
            {
                MessageBox.Show("Produto já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_produto.Focus();
                return;
            }

            try
            {
                // Coleta e valida os dados do formulário
                string produto = txt_produto.Text;
                string unidade = txt_unidade.Text;
                string marca = txt_marca.Text;
                decimal saldo = decimal.TryParse(txt_saldo.Text, out decimal saldoValue) ? saldoValue : 0;
                decimal custo_medio = decimal.TryParse(txt_custo_medio.Text, out decimal custoMedioValue) ? custoMedioValue : 0;
                decimal preco_medio = decimal.TryParse(txt_preco_medio.Text, out decimal precoMedioValue) ? precoMedioValue : 0;
                decimal preco_ult_compra = decimal.TryParse(txt_preco_ult_compra.Text, out decimal precoUltCompraValue) ? precoUltCompraValue : 0;
                DateTime? data_ult_compra = DateTime.TryParse(txt_data_ultcompra.Text, out DateTime dataUltCompraValue) ? (DateTime?)dataUltCompraValue : null;
                string observacao = txt_observacao.Text;
                int fornecedor_ID = int.TryParse(txt_fornecedor_ID.Text, out int fornecedorIdValue) ? fornecedorIdValue : 0;
                DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                DateTime dataUltAlt = DateTime.Now;

                // Cria o objeto Produto
                Produto novoProduto = new Produto
                {
                    fornecedor_ID = fornecedor_ID,
                    nome_produto = produto,
                    unidade = unidade,
                    marca = marca,
                    saldo = saldo,
                    custo_medio = custo_medio,
                    preco_medio = preco_medio,
                    preco_ultima_compra = preco_ult_compra,
                    data_ultima_compra = data_ult_compra ?? DateTime.MinValue, // Converte para DateTime com valor padrão
                    observacao = observacao,
                    data_cadastro = dataCadastro,
                    data_ult_alt = dataUltAlt,
                    ativo = check_ativo.Checked
                };

                // Salva ou atualiza o produto
                if (altera == -1)
                {
                    controllerProduto.salvar(novoProduto);
                    MessageBox.Show("Produto cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    novoProduto.produto_ID = altera; // ID do produto a ser alterado
                    controllerProduto.alterar(novoProduto);
                    MessageBox.Show("Produto atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_produto.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            consultaFornecedor.btn_sair.Text = "Selecionar";

            if (consultaFornecedor.ShowDialog() == DialogResult.OK)
            {
                var fornecedoresDetalhes = consultaFornecedor.Tag as Tuple<int, string>;

                if (fornecedoresDetalhes != null)
                {
                    int fornecedorID = fornecedoresDetalhes.Item1;
                    string fornecedor = fornecedoresDetalhes.Item2;

                    txt_fornecedor_ID.Text = fornecedorID.ToString();
                    txt_fornecedor.Text = fornecedor.ToString();    
                 
                }
            }
        }

        private void CadastroProduto_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerProduto.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }
    }
}

