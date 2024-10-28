using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroNotaCompra : Hotel_Mod.views.CadastroPai
    {
        private ConsultaFornecedor consultaFornecedor;
        private ControllerFornecedor<Fornecedor> controllerfornecedor;
        private ConsultaCondPagamento consultaCondPagamento;
        private controllerCondPagamento<CondicaoPagamento> ControllerCondPagamento;
        private ConsultaProduto consultaProduto;
        private controllerProduto<Produto> ControllerProduto;
        private ControllerNotaCompra<nota_Compra> ControllerNotaCompra;
        private controllerContasPagar<ContasPagar> ControllerContasPagar;

        decimal precoUNProduto;
        bool isCIF = true;
        decimal frete;
        decimal seguro;
        decimal outros;
        decimal juros;
        decimal descontos;
        decimal multa;

        int numNota;
        int serie;
        int fornecedor_ID;


        public CadastroNotaCompra()
        {
            InitializeComponent();
            consultaFornecedor = new ConsultaFornecedor();
            controllerfornecedor = new ControllerFornecedor<Fornecedor>();
            consultaCondPagamento = new ConsultaCondPagamento();
            ControllerCondPagamento = new controllerCondPagamento<CondicaoPagamento>();
            consultaProduto = new ConsultaProduto();
            ControllerProduto = new controllerProduto<Produto>();
            ControllerNotaCompra = new ControllerNotaCompra<nota_Compra>();
            ControllerContasPagar = new controllerContasPagar<ContasPagar>();
            txt_cod_cond_pagamento.Focus();

        }


        public override void LimparCampos()
        {

            serie = -1;
            fornecedor_ID = -1;

            base.LimparCampos();
            //limpa todos os campos de texto
            txt_cod_cond_pagamento.Clear();
            txt_serie.Clear();
            txt_data_emissao.Clear();
            txt_data_chegada.Clear();
            txt_cod_fornecedor.Clear();
            txt_fornecedor.Clear();
            lbl_cancelada.Visible = false;
            txt_cod_produto.Clear();
            txt_produto.Clear();
            txt_unidade.Clear();
            txt_qtd.Clear();
            txt_preco.Clear();
            txt_valor_frete.Text = "0";
            txt_valor_seguro.Text = "0";
            txt_outros.Text = "0";
            txt_cod_cond_pagamento.Clear();
            txt_cond_pagamento.Clear();
            txt_total_produtos.Clear();
            txt_total_pagar.Clear();
            txt_obs.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            txt_data_cancelamento.Clear();

            //limpa os DataGridViews
            dataGridView_produtos.Rows.Clear();
            dataGridView_parcelas.Rows.Clear();

            check_cif.Checked = true;

            Desbloqueia();
        }

        public void Desbloqueia()
        {
            txt_cod_cond_pagamento.Enabled = true;
            txt_serie.Enabled = true;
            txt_cod_fornecedor.Enabled = true;
            txt_obs.Enabled = true;

            txt_data_emissao.Enabled = false;
            txt_data_chegada.Enabled = false;
            txt_cod_produto.Enabled = false;
            txt_produto.Enabled = false;
            txt_unidade.Enabled = false;
            txt_qtd.Enabled = false;
            txt_preco.Enabled = false;
            txt_valor_frete.Enabled = false;
            txt_valor_seguro.Enabled = false;
            txt_outros.Enabled = false;
            txt_cod_cond_pagamento.Enabled = false;
            txt_cond_pagamento.Enabled = false;
            txt_total_produtos.Enabled = false;
            txt_total_pagar.Enabled = false;
            txt_obs.Enabled = false;
            txt_dat_cad.Enabled = false;
            txt_dat_ult_alt.Enabled = false;

            btn_busca_fornecedor.Enabled = true;
            btn_salvar.Visible = true;
            btn_cancelar_nota.Visible = false;


            dataGridView_produtos.Enabled = true;
            dataGridView_parcelas.Enabled = true;

            //desativa os RadioButtons
            check_cif.Enabled = false;
            check_fob.Enabled = false;

            //desativa o GroupBox
            tipo_frete.Enabled = false;

            btn_excluir_produto.Visible = true;
        }

        public void BloqueiaTudo()
        {
            //desativa todos os campos de texto
            txt_cod_cond_pagamento.Enabled = false;
            txt_serie.Enabled = false;
            txt_data_emissao.Enabled = false;
            txt_data_chegada.Enabled = false;
            txt_cod_fornecedor.Enabled = false;
            txt_fornecedor.Enabled = false;
            txt_cod_produto.Enabled = false;
            txt_produto.Enabled = false;
            txt_unidade.Enabled = false;
            txt_qtd.Enabled = false;
            txt_preco.Enabled = false;
            txt_valor_frete.Enabled = false;
            txt_valor_seguro.Enabled = false;
            txt_outros.Enabled = false;
            txt_cod_cond_pagamento.Enabled = false;
            txt_cond_pagamento.Enabled = false;
            txt_total_produtos.Enabled = false;
            txt_total_pagar.Enabled = false;
            txt_obs.Enabled = false;
            txt_dat_cad.Enabled = false;
            txt_dat_ult_alt.Enabled = false;


            //desativa todos os botões
            btn_busca_fornecedor.Enabled = false;
            btn_buscaproduto.Enabled = false;


            //desativa o DataGridView
            dataGridView_produtos.Enabled = true;
            dataGridView_parcelas.Enabled = true;

            //desativa os RadioButtons
            check_cif.Enabled = false;
            check_fob.Enabled = false;

            //desativa o GroupBox
            tipo_frete.Enabled = false;

            btn_excluir_produto.Visible = false;
        }

        public override void carrega()
        {
            base.carrega();

            var notaCompra = ControllerNotaCompra.GetNotaById(numNota,  serie, fornecedor_ID);
            if (notaCompra != null)
            {
                txt_cod_cond_pagamento.Text = notaCompra.num_Nota.ToString();
                txt_serie.Text = notaCompra.serie.ToString();
                txt_data_emissao.Text = notaCompra.data_emissao.ToString();
                txt_data_chegada.Text = notaCompra.data_chegada.ToString();
                txt_cod_fornecedor.Text = notaCompra.fornecedor_ID.ToString();
                check_cif.Checked = notaCompra.tipo_frete;
                check_fob.Checked = !notaCompra.tipo_frete;
                txt_valor_frete.Text = notaCompra.valor_frete.ToString();
                txt_valor_seguro.Text = notaCompra.valor_seguro.ToString();
                txt_outros.Text = notaCompra.outras_despesas.ToString();
                txt_total_pagar.Text = notaCompra.total_pagar.ToString();
                txt_total_produtos.Text = notaCompra.total_produtos.ToString();
                txt_cod_cond_pagamento.Text = notaCompra.Cond_Pagamento_ID.ToString();
                txt_obs.Text = notaCompra.observacao.ToString();
                txt_dat_cad.Text = notaCompra.data_cadastro.ToString();
                txt_dat_ult_alt.Text = notaCompra.data_ult_alt.ToString();


                Fornecedor fornecedor = controllerfornecedor.GetById(int.Parse(txt_cod_fornecedor.Text));
                CondicaoPagamento condPagamento = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));

                if (fornecedor != null)
                    txt_fornecedor.Text = fornecedor.fornecedor_razao_social;
                if (condPagamento != null)
                    txt_cond_pagamento.Text = condPagamento.condicaoPagamento;

                if (notaCompra.data_cancelamento != null)
                {
                    lbl_cancelada.Visible = true;
                    lbl_data_cancelamento.Visible = true;
                    txt_data_cancelamento.Visible = true;
                }
                else
                {
                    lbl_cancelada.Visible = false;
                    lbl_data_cancelamento.Visible = false;
                    txt_data_cancelamento.Visible = false;
                }
                exibirProdutosDGV(notaCompra.Produtos);
                exibirParcelasDGV(condPagamento.parcelas);
            }
        }
        public override void salvar()
        {
            string dEmissao = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());
            string dChegada = new string(txt_data_chegada.Text.Where(char.IsDigit).ToArray());
            if (validadores.CampoObrigatorio(txt_cod_cond_pagamento.Text))
            {
                MessageBox.Show("Campo Número é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_cond_pagamento.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_serie.Text))
            {
                MessageBox.Show("Campo Série é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_serie.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_cod_fornecedor.Text))
            {
                MessageBox.Show("Campo Código Fornecedor é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_fornecedor.Focus();
            }
            else if (validadores.CampoObrigatorio(dEmissao))
            {
                MessageBox.Show("Campo Data Emissão é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_data_emissao.Focus();
            }
            else if (validadores.CampoObrigatorio(dChegada))
            {
                MessageBox.Show("Campo Data Chegada é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_data_chegada.Focus();
            }
            else if (dataGridView_produtos.Rows.Count <= 0)
            {
                MessageBox.Show("É necessário adicionar pelo menos um produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_produto.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_cod_cond_pagamento.Text))
            {
                MessageBox.Show("Campo Código Condição de Pagamento é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_cond_pagamento.Focus();
            }
            else if (dataGridView_parcelas.Rows.Count <= 0)
            {
                MessageBox.Show("É necessário adicionar pelo menos uma parcela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_produto.Focus();
            }
            else
            {
                try
                {
                    int numeroNota = Convert.ToInt32(txt_cod_cond_pagamento.Text);
                    int serie = Convert.ToInt32(txt_serie.Text);
                    int fornecedor_ID = Convert.ToInt32(txt_cod_fornecedor.Text);
                    decimal valorFrete = Convert.ToDecimal(txt_valor_frete.Text);
                    decimal valorSeguro = Convert.ToDecimal(txt_valor_seguro.Text);
                    decimal outrasDespesas = Convert.ToDecimal(txt_outros.Text);
                    decimal totalProdutos = Convert.ToDecimal(txt_total_produtos.Text);
                    decimal totalPagar = Convert.ToDecimal(txt_total_pagar.Text);
                    int idCondPagamento = Convert.ToInt32(txt_cod_cond_pagamento.Text);
                    string observacao = txt_obs.Text;
                    DateTime.TryParse(txt_data_emissao.Text, out DateTime dataEmissao);
                    DateTime.TryParse(txt_data_chegada.Text, out DateTime dataChegada);
                    dataChegada = dataChegada.Date.Add(DateTime.Now.TimeOfDay); //add a hora que está chegando

                    DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                    DateTime dataUltAlt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                    nota_Compra notaCompra = new nota_Compra
                    {
                        num_Nota = numeroNota,
                        serie = serie,
                        fornecedor_ID = fornecedor_ID,
                        tipo_frete = isCIF,
                        valor_frete = valorFrete,
                        valor_seguro = valorSeguro,
                        outras_despesas = outrasDespesas,
                        total_produtos = totalProdutos,
                        total_pagar = totalPagar,
                        Cond_Pagamento_ID = idCondPagamento,
                        data_emissao = dataEmissao,
                        data_chegada = dataChegada,
                        observacao = observacao,
                        data_cadastro = dataCadastro,
                        data_ult_alt = dataUltAlt,

                        Produtos = obtemProdutos(valorFrete, valorSeguro, outrasDespesas, totalProdutos),
                    };

                    ControllerNotaCompra.salvar(notaCompra);
                    ControllerNotaCompra.AtualizarProdutosNotaCompra(notaCompra);


                    try //salvar contas a pagar
                    {
                        foreach (DataGridViewRow row in dataGridView_parcelas.Rows)
                        {
                            if (row.IsNewRow) continue;

                            //validação do que está no datagrid
                            if (row.Cells["idFormaPagamento"].Value == null || !int.TryParse(row.Cells["idFormaPagamento"].Value.ToString(), out int idFormaPagamento))
                            {
                                MessageBox.Show("Forma de pagamento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (row.Cells["numeroParcela"].Value == null || !int.TryParse(row.Cells["numeroParcela"].Value.ToString(), out int parcela))
                            {
                                MessageBox.Show("Número de parcela inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (row.Cells["valorParcela"].Value == null || !decimal.TryParse(row.Cells["valorParcela"].Value.ToString(), out decimal valorParcela))
                            {
                                MessageBox.Show("Valor da parcela inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (row.Cells["dataVencimento"].Value == null || !DateTime.TryParse(row.Cells["dataVencimento"].Value.ToString(), out DateTime dataVencimento))
                            {
                                MessageBox.Show("Data de vencimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            ContasPagar contaPagar = new ContasPagar
                            {
                                numeroNota = numeroNota,
                                serie = serie,
                                idFornecedor = fornecedor_ID,
                                dataEmissao = dataEmissao,
                                FormaPagamento_ID = idFormaPagamento,
                                parcela = parcela,
                                valorParcela = valorParcela,
                                data_vencimento = dataVencimento,
                                data_pagamento = null,
                                juros = juros,
                                multa = multa,
                                desconto = descontos,
                                valor_pago = null,
                                data_cancelamento = null,
                                observacao = observacao,
                                data_cadastro = DateTime.Now,
                                data_ult_alt = DateTime.Now
                            };

                            ControllerContasPagar.salvar(contaPagar);
                        }
                    }
                    catch (FormatException fe)
                    {
                        MessageBox.Show("Erro ao converter valores: " + fe.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar as Contas a Pagar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao salvar a Nota de Compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<NotaCompra_Produto> obtemProdutos(decimal valorFrete, decimal valorSeguro, decimal outrasDespesas, decimal totalProdutos)
        {
            List<NotaCompra_Produto> produtos = new List<NotaCompra_Produto>();

            foreach (DataGridViewRow row in dataGridView_produtos.Rows)
            {
                decimal precoUN = Convert.ToDecimal(row.Cells["PrecoUN"].Value);
                decimal quantidadeProduto = Convert.ToDecimal(row.Cells["quantidadeProduto"].Value);
                decimal precoTotalProd = precoUN * quantidadeProduto;

                // Calcular o Rateio e arredondar para 4 casas decimais
                decimal rateio = Math.Round(precoTotalProd / totalProdutos, 4);

                // Calcular o Custo do Produto e arredondar para 4 casas decimais
                decimal custoProd = Math.Round((valorFrete + valorSeguro + outrasDespesas) * rateio, 4);

                // Calcular o Custo Médio do Produto e arredondar para 4 casas decimais
                decimal custoMedio = Math.Round((precoTotalProd + custoProd) / quantidadeProduto, 4);

                // Se custo médio for igual ao preço unitário, considerar apenas o preço unitário
                if (custoProd == 0)
                {
                    custoMedio = Math.Round(precoUN, 4);
                }

                NotaCompra_Produto produto = new NotaCompra_Produto
                {
                    quantidade_Produto = Convert.ToInt32(row.Cells["quantidadeProduto"].Value),
                    precoProduto = Math.Round(precoUN, 4),
                    produto_ID = Convert.ToInt32(row.Cells["produto_ID"].Value),
                    rateio = rateio,
                    custoMedio = custoMedio,
                };

                produtos.Add(produto);
            }

            return produtos;
        }

        private void exibirProdutosDGV(List<NotaCompra_Produto> produtos)
        {
            dataGridView_produtos.Rows.Clear();

            foreach (var produto in produtos)
            {
                Produto produtoDetalhes = ControllerNotaCompra.GetProdutoById(produto.produto_ID);

                if (produtoDetalhes != null)
                {
                    dataGridView_produtos.Rows.Add(
                        produto.produto_ID,
                        produtoDetalhes.produto,
                        produtoDetalhes.unidade,
                        produto.quantidade_Produto,
                        produto.precoProduto,
                        (produto.quantidade_Produto * produto.precoProduto)
                    );
                }
            }

            if (dataGridView_produtos.Columns.Contains("produto_ID"))
            {
                dataGridView_produtos.Sort(dataGridView_produtos.Columns["produto_ID"], ListSortDirection.Ascending);
            }
        }

        private void exibirParcelasDGV(List<parcela> parcelas)
        {
            dataGridView_parcelas.Rows.Clear();

            DateTime dataEmissao;
            decimal valorTotalNota;
            if (DateTime.TryParse(txt_data_emissao.Text, out dataEmissao) && decimal.TryParse(txt_total_pagar.Text, out valorTotalNota))
            {
                decimal somaParcelas = 0m;
                for (int i = 0; i < parcelas.Count; i++)
                {
                    var parcela = parcelas[i]; //parcela atual
                    int codFormaPagamento = parcela.FormaPagamento_ID;
                    string formaPagamento = ControllerCondPagamento.GetFormaPagByParcelaId(parcela.parcela_ID);
                    DateTime dataParcela = dataEmissao.AddDays(parcela.dias);
                    decimal valorParcela;

                    if (i == parcelas.Count - 1) //se for a ultima parcela
                    {
                        //para a última parcela, subtrai o valor das parcelas anteriores    
                        //assim nao corre o risco do valor final nao ser igual ao valor total
                        valorParcela = valorTotalNota - somaParcelas;
                    }
                    else
                    { //se nao for a ultima, faz a conta normal de acordo com a porcentagem do contas a pagar
                        valorParcela = Math.Round((valorTotalNota * parcela.porcentagem) / 100, 2);
                        somaParcelas += valorParcela;
                    }

                    dataGridView_parcelas.Rows.Add(
                        parcela.numeroParcela,
                        codFormaPagamento,
                        formaPagamento,
                        dataParcela.ToString("dd/MM/yyyy"),
                        valorParcela.ToString("F2")
                    );
                }
            }
            else
            {
                MessageBox.Show("Data de emissão ou valor total inválido.");
            }
        }

        public void SetID(int numero, int Modelo, int Serie, int Fornecedor_ID)
        {
            numNota = numero;
         
            Serie = serie;
            Fornecedor_ID = fornecedor_ID;
        }
        private void VerificaCamposPreenchidosNF()
        {
            string dataEmissao = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());
            string dataChegada = new string(txt_data_chegada.Text.Where(char.IsDigit).ToArray());
            bool camposPreenchidos = !string.IsNullOrEmpty(txt_cod_cond_pagamento.Text) &&
                                     !string.IsNullOrEmpty(txt_serie.Text) &&
                                     !string.IsNullOrEmpty(dataEmissao) &&
                                     !string.IsNullOrEmpty(dataChegada) &&
                                     !string.IsNullOrEmpty(txt_cod_fornecedor.Text);

            txt_cod_produto.Enabled = camposPreenchidos;
            txt_qtd.Enabled = camposPreenchidos;
            txt_preco.Enabled = camposPreenchidos;
            btn_buscaproduto.Enabled = camposPreenchidos;
            //  btnExcluirProduto.Enabled= camposPreenchidos;
            dataGridView_produtos.Enabled = camposPreenchidos;
        }
        private void VerificaProdutos()
        {
            if (numNota == -1 &&  serie == -1 && fornecedor_ID == -1)
            {
                bool habilitar = dataGridView_produtos.Rows.Count > 0;

                //desabilita os campos com infos da nota
                txt_cod_cond_pagamento.Enabled = !habilitar; 
                txt_serie.Enabled = !habilitar;
                txt_data_emissao.Enabled = !habilitar;
                txt_data_chegada.Enabled = !habilitar;
                txt_cod_fornecedor.Enabled = !habilitar;
                btn_busca_fornecedor.Enabled = !habilitar;

                tipo_frete.Enabled = habilitar;
                check_cif.Enabled = habilitar;
                check_fob.Enabled = habilitar;
                txt_valor_seguro.Enabled = habilitar;
                txt_outros.Enabled = habilitar;

                txt_cod_cond_pagamento.Enabled = habilitar;
                btn_busca_cond_pagamento.Enabled = habilitar;
                dataGridView_parcelas.Enabled = habilitar;
            }
        }
        private void VerificaCamposPreenchidosFrete()
        {
            bool camposPreenchidos = ((decimal.TryParse(txt_valor_frete.Text, out var valorFrete) && valorFrete != 0) ||
                                     (decimal.TryParse(txt_valor_seguro.Text, out var valorSeguro) && valorSeguro != 0) ||
                                     (decimal.TryParse(txt_outros.Text, out var outrasDespesas) && outrasDespesas != 0));

            txt_cod_produto.Enabled = !camposPreenchidos;
            txt_qtd.Enabled = !camposPreenchidos;
            txt_preco.Enabled = !camposPreenchidos;
            dataGridView_produtos.Enabled = !camposPreenchidos;
            btn_buscaproduto.Enabled = !camposPreenchidos;
        }
        private void VerificaCamposPreenchidosCondPagamento()
        {
            bool camposPreenchidos = !string.IsNullOrEmpty(txt_cod_cond_pagamento.Text);

            tipo_frete.Enabled = !camposPreenchidos;
            check_cif.Enabled = !camposPreenchidos;
            check_fob.Enabled = !camposPreenchidos;
            txt_valor_frete.Enabled = !camposPreenchidos;
            txt_valor_seguro.Enabled = !camposPreenchidos;
            txt_outros.Enabled = !camposPreenchidos;

        }

        private void txt_cod_Leave(object sender, EventArgs e)
        {
            VerificaNotaExistente();
            VerificaCamposPreenchidosNF();
        }

        private void txt_modelo_Leave(object sender, EventArgs e)
        {
            VerificaNotaExistente();
            VerificaCamposPreenchidosNF();
        }

        private void txt_serie_Leave(object sender, EventArgs e)
        {
            VerificaNotaExistente();
            VerificaCamposPreenchidosNF();
        }

     
        private void limpaCamposProdutos()
        {
            txt_cod_produto.Clear();
            txt_produto.Clear();
            txt_unidade.Clear();
            txt_qtd.Clear();
            txt_preco.Clear();
        }
        private void VerificaNotaExistente()
        {
            if (int.TryParse(txt_cod_cond_pagamento.Text, out int numeroNota) &&
                !string.IsNullOrWhiteSpace(txt_serie.Text) &&
                int.TryParse(txt_cod_fornecedor.Text, out int fornecedor_ID))
            {
                bool notaExiste = ControllerNotaCompra.ExisteNota(numeroNota,  txt_serie.Text, fornecedor_ID);

                txt_data_emissao.Enabled = !notaExiste;
                txt_data_chegada.Enabled = !notaExiste;
            }
            else
            {
                txt_data_emissao.Enabled = false;
                txt_data_chegada.Enabled = false;
            }
        }


        private void atualizaTotalProdutos()
        {
            decimal subtotalProd = 0;

            foreach (DataGridViewRow row in dataGridView_produtos.Rows) //percorre as linhas do dgv
            {
                subtotalProd += Convert.ToDecimal(row.Cells["precoTotal"].Value); //add os valores da coluna precoProduto a variavel
            }
            txt_total_produtos.Text = subtotalProd.ToString("F2"); //att o campo com 2 casas decimais
        }

        private void atualizaTotalPagar()
        {
            decimal totalProdutos = string.IsNullOrWhiteSpace(txt_total_produtos.Text) ? 0 : Convert.ToDecimal(txt_total_produtos.Text);
            frete = string.IsNullOrWhiteSpace(txt_valor_frete.Text) ? 0 : Convert.ToDecimal(txt_valor_frete.Text);
            seguro = string.IsNullOrWhiteSpace(txt_valor_seguro.Text) ? 0 : Convert.ToDecimal(txt_valor_seguro.Text);
            outros = string.IsNullOrWhiteSpace(txt_outros.Text) ? 0 : Convert.ToDecimal(txt_outros.Text);

            decimal total = totalProdutos + frete + seguro + outros;

            txt_total_pagar.Text = total.ToString("F2");
        }


  ///////////////////////////////////////////////////////////////////////////////////////////////////////////     

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (validadores.CampoObrigatorio(txt_cod_produto.Text))
            {
                MessageBox.Show("Campo Código Produto é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_produto.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_qtd.Text))
            {
                MessageBox.Show("Campo Quantidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_qtd.Focus();
            }
            else if (validadores.CampoObrigatorio(txt_preco.Text))
            {
                MessageBox.Show("Campo Preço é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_preco.Focus();
            }
            else
            {
                try
                {
                    int produto_ID = Convert.ToInt32(txt_cod_produto.Text);
                    string produto = txt_produto.Text;
                    int qtdeProduto = Convert.ToInt32(txt_qtd.Text);
                    string unidade = txt_unidade.Text;
                    decimal precoUN = Convert.ToDecimal(txt_preco.Text);
                    decimal precoTotal = Convert.ToDecimal(txt_preco.Text) * Convert.ToInt32(txt_qtd.Text);

                    dataGridView_produtos.Rows.Add(produto_ID, produto, unidade, qtdeProduto, precoUN, precoTotal); //add nova linha com os valores 
                    atualizaTotalProdutos();
                    atualizaTotalPagar();
                    dataGridView_produtos.Sort(dataGridView_produtos.Columns["produto_ID"], ListSortDirection.Ascending);
                    limpaCamposProdutos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                }
            }

        }

        private void btn_excluir_produto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_produtos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView_produtos.SelectedRows)
                    {
                        dataGridView_produtos.Rows.Remove(row);
                    }
                    atualizaTotalProdutos();
                    atualizaTotalPagar();
                }
                else
                {
                    MessageBox.Show("Selecione um produto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_nota_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar esta nota?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            string dataCancelamento = new string(txt_data_cancelamento.Text.Where(char.IsDigit).ToArray());
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(dataCancelamento))
                {
                    bool sucesso = ControllerNotaCompra.CancelarNotaCompra(numNota, serie, fornecedor_ID);

                    if (sucesso)
                    {
                        MessageBox.Show("Nota cancelada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cancelar a nota.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esta nota já foi cancelada anteriormente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_buscaproduto_Click(object sender, EventArgs e)
        {
            consultaProduto.btn_sair.Text = "Selecionar";

            if (consultaProduto.ShowDialog() == DialogResult.OK)
            {
                var infosProd = consultaProduto.Tag as Tuple<int, string, decimal, string>;
                if (infosProd != null)
                {
                    int idProd = infosProd.Item1;
                    string produto = infosProd.Item2;
                    precoUNProduto = infosProd.Item3;
                    string unidade = infosProd.Item4;

                    txt_cod_produto.Text = idProd.ToString();
                    txt_produto.Text = produto;
                    txt_unidade.Text = unidade;
                }
            }

        }

        private void btn_busca_fornecedor_Click(object sender, EventArgs e)
        {
            consultaFornecedor.btn_sair.Text = "Selecionar";

            if (consultaFornecedor.ShowDialog() == DialogResult.OK)
            {
                var fornecedoresDetalhes = consultaFornecedor.Tag as Tuple<int, string>;

                if (fornecedoresDetalhes != null)
                {
                    int fornecedorID = fornecedoresDetalhes.Item1;
                    string fornecedorNome = fornecedoresDetalhes.Item2;

                    txt_cod_fornecedor.Text = fornecedorID.ToString();
                    txt_fornecedor.Text = fornecedorNome;

                    Fornecedor fornecedorDetalhes = controllerfornecedor.GetById(fornecedorID);
                    if (fornecedorDetalhes != null)
                        txt_cod_cond_pagamento.Text = fornecedorDetalhes.CondPagamento_ID.ToString();
                    CondicaoPagamento condPag = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));
                    if (condPag != null)
                        txt_cond_pagamento.Text = condPag.condicaoPagamento.ToString();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CondicaoPagamento condPagamento = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));
            juros = condPagamento.juros;
            multa = condPagamento.multa;
            descontos = condPagamento.desconto;
            exibirParcelasDGV(condPagamento.parcelas);
        }

        private void btn_busca_cond_pagamento_Click(object sender, EventArgs e)
        {
            consultaCondPagamento.btn_sair.Text = "Selecionar";
            if (consultaCondPagamento.ShowDialog() == DialogResult.OK)
            {
                var condPagamento = consultaCondPagamento.Tag as Tuple<int, string>;
                if (condPagamento != null)
                {
                    int idCondPag = condPagamento.Item1;
                    string condicaoPagamento = condPagamento.Item2;

                    txt_cod_cond_pagamento.Text = idCondPag.ToString();
                    txt_cond_pagamento.Text = condicaoPagamento;
                }
            }
        }

        private void txt_data_chegada_Leave(object sender, EventArgs e)
        {
            string dChegada = new string(txt_data_chegada.Text.Where(char.IsDigit).ToArray());
            string dEmissao = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());
            if (!string.IsNullOrEmpty(dChegada) && !string.IsNullOrEmpty(dEmissao))
            {
                DateTime dataEmissao;
                DateTime dataChegada;
                DateTime dataHoje = DateTime.Now;

                bool dataEmissaoValida = DateTime.TryParse(txt_data_emissao.Text, out dataEmissao);
                bool dataChegadaValida = DateTime.TryParse(txt_data_chegada.Text, out dataChegada);

                if (dataEmissaoValida && dataChegadaValida)
                {
                    if (dataChegada < dataEmissao || dataChegada > dataHoje)
                    {
                        MessageBox.Show("Data de chegada inválida! A data de chegada deve ser maior ou igual à data de emissão e menor ou igual à data de hoje.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_data_chegada.Focus();
                    }
                    else
                    {
                        VerificaCamposPreenchidosNF();
                    }
                }
                else
                {
                    MessageBox.Show("Data de emissão ou data de chegada inválida! Verifique os valores inseridos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_data_chegada.Focus();
                }
            }
        }

        private void txt_cod_fornecedor_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_fornecedor.Text))
            {
                Fornecedor fornecedor = controllerfornecedor.GetById(int.Parse(txt_cod_fornecedor.Text));
                if (fornecedor != null)
                {
                    txt_fornecedor.Text = fornecedor.fornecedor_razao_social;

                    Fornecedor fornecedorDetalhes = controllerfornecedor.GetById(int.Parse(txt_cod_fornecedor.Text));
                    if (fornecedorDetalhes != null)
                        txt_cod_cond_pagamento.Text = fornecedorDetalhes.CondPagamento_ID.ToString();
                    CondicaoPagamento condPag = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));
                    if (condPag != null)
                        txt_cond_pagamento.Text = condPag.condicaoPagamento.ToString();
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_fornecedor.Focus();
                    txt_cod_fornecedor.Clear();
                    txt_fornecedor.Clear();
                }
            }
            VerificaNotaExistente();
            VerificaCamposPreenchidosNF();
        }

        private void CadastroNotaCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaNotaCompra)this.Owner).AtualizarConsultaNotaCompra(false);
        }

        private void dataGridView_produtos_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            VerificaProdutos();
        }

        private void dataGridView_produtos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            VerificaProdutos();
        }

        private void check_cif_CheckedChanged_1(object sender, EventArgs e)
        {
            isCIF = check_cif.Checked;
            txt_valor_frete.Enabled = false;
            txt_valor_frete.Text = "0";
        }

        private void check_fob_CheckedChanged_1(object sender, EventArgs e)
        {
            isCIF = !check_fob.Checked;
            if (numNota != -1 &&  serie != -1 && fornecedor_ID != -1)
                txt_valor_frete.Enabled = false;
            else
                txt_valor_frete.Enabled = true;
            txt_valor_frete.Text = "0";
        }

        private void txt_valor_frete_Leave(object sender, EventArgs e)
        {
            txt_valor_frete.Text = validadores.FormataPreco(txt_valor_frete.Text);
            VerificaCamposPreenchidosFrete();
            atualizaTotalPagar();
        }

        private void txt_outros_Leave(object sender, EventArgs e)
        {
            txt_outros.Text = validadores.FormataPreco(txt_outros.Text);
            VerificaCamposPreenchidosFrete();
            atualizaTotalPagar();
        }

        private void txt_valor_seguro_Leave(object sender, EventArgs e)
        {
            txt_valor_seguro.Text = validadores.FormataPreco(txt_valor_seguro.Text);
            VerificaCamposPreenchidosFrete();
            atualizaTotalPagar();
        }

        private void txt_data_emissao_Leave(object sender, EventArgs e)
        {
            DateTime dataEmissao;
            DateTime dataHoje = DateTime.Now;
            bool dataValida = DateTime.TryParse(txt_data_emissao.Text, out dataEmissao);

            string dataE = new string(txt_data_emissao.Text.Where(char.IsDigit).ToArray());

            if (!string.IsNullOrWhiteSpace(dataE) && dataValida)
            {
                if (dataEmissao > dataHoje)
                {
                    MessageBox.Show("Data de emissão inválida! A data deve ser menor ou igual a hoje.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_data_emissao.Focus();
                    return;
                }
                VerificaCamposPreenchidosNF();
            }
            else if (string.IsNullOrWhiteSpace(dataE) || !dataValida)
            {
                //se estiver vazio ou com a máscara inicial, sai do método sem validação
                return;
            }
        }

        private void txt_cod_cond_pagamento_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_cond_pagamento.Text))
            {
                CondicaoPagamento condPagamento = ControllerCondPagamento.GetById(int.Parse(txt_cod_cond_pagamento.Text));
                if (condPagamento != null)
                {
                    txt_cond_pagamento.Text = condPagamento.condicaoPagamento;
                }
                else
                {
                    MessageBox.Show("Condição de Pagamento não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_cond_pagamento.Focus();
                    txt_cod_cond_pagamento.Clear();
                    txt_cond_pagamento.Clear();
                }
            }
            VerificaCamposPreenchidosCondPagamento();
        }

        private void txt_cod_produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_produto.Text))
            {
                Produto produto = ControllerProduto.GetById(int.Parse(txt_cod_produto.Text));
                if (produto != null)
                {
                    txt_produto.Text = produto.produto;
                    precoUNProduto = produto.preco_venda;
                    txt_unidade.Text = produto.unidade;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_produto.Focus();
                    txt_cod_produto.Clear();
                    txt_produto.Clear();
                    txt_unidade.Clear();

                }
            }
        }

        private void CadastroNotaCompra_Load(object sender, EventArgs e)
        {
            if (numNota != -1 && serie != -1 && fornecedor_ID != -1)
            {
                btn_cancelar_nota.Visible = true;
                btn_salvar.Visible = false;
            }
            else
            {
                txt_data_chegada.Text = DateTime.Now.ToString();
            }
        }
    }

}

