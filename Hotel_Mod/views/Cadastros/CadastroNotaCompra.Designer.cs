namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroNotaCompra
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_serie = new System.Windows.Forms.Label();
            this.txt_serie = new System.Windows.Forms.RichTextBox();
            this.lbl_cod_fornecedor = new System.Windows.Forms.Label();
            this.txt_cod_fornecedor = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fornecedor = new System.Windows.Forms.RichTextBox();
            this.btn_busca_fornecedor = new System.Windows.Forms.Button();
            this.txt_data_emissao = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_chegada = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cancelada = new System.Windows.Forms.Label();
            this.txt_data_cancelamento = new System.Windows.Forms.MaskedTextBox();
            this.lbl_data_cancelamento = new System.Windows.Forms.Label();
            this.btn_buscaproduto = new System.Windows.Forms.Button();
            this.lbl_cod_produto = new System.Windows.Forms.Label();
            this.txt_cod_produto = new System.Windows.Forms.RichTextBox();
            this.lbl_produto = new System.Windows.Forms.Label();
            this.txt_produto = new System.Windows.Forms.RichTextBox();
            this.lbl_quantidade = new System.Windows.Forms.Label();
            this.txt_qtd = new System.Windows.Forms.RichTextBox();
            this.lbl_unidade = new System.Windows.Forms.Label();
            this.txt_unidade = new System.Windows.Forms.RichTextBox();
            this.lbl_preco = new System.Windows.Forms.Label();
            this.txt_preco = new System.Windows.Forms.RichTextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dataGridView_produtos = new System.Windows.Forms.DataGridView();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_total_pagar = new System.Windows.Forms.Label();
            this.txt_total_pagar = new System.Windows.Forms.RichTextBox();
            this.lbl_total_produtos = new System.Windows.Forms.Label();
            this.txt_total_produtos = new System.Windows.Forms.RichTextBox();
            this.btn_excluir_produto = new System.Windows.Forms.Button();
            this.tipo_frete = new System.Windows.Forms.GroupBox();
            this.check_fob = new System.Windows.Forms.RadioButton();
            this.check_cif = new System.Windows.Forms.RadioButton();
            this.lbl_cond_pagamento = new System.Windows.Forms.Label();
            this.txt_cond_pagamento = new System.Windows.Forms.RichTextBox();
            this.lbl_cod_cond_pagamento = new System.Windows.Forms.Label();
            this.txt_cod_cond_pagamento = new System.Windows.Forms.RichTextBox();
            this.btn_busca_cond_pagamento = new System.Windows.Forms.Button();
            this.btn_add_cond_pag = new System.Windows.Forms.Button();
            this.dataGridView_parcelas = new System.Windows.Forms.DataGridView();
            this.numeroParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_obs = new System.Windows.Forms.Label();
            this.txt_obs = new System.Windows.Forms.RichTextBox();
            this.btn_cancelar_nota = new System.Windows.Forms.Button();
            this.txt_valor_frete = new System.Windows.Forms.RichTextBox();
            this.txt_valor_seguro = new System.Windows.Forms.RichTextBox();
            this.txt_outros = new System.Windows.Forms.RichTextBox();
            this.lbl_valor_frete = new System.Windows.Forms.Label();
            this.lbl_valor_seguro = new System.Windows.Forms.Label();
            this.lbl_outros = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_produtos)).BeginInit();
            this.tipo_frete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(879, 14);
            this.status.Size = new System.Drawing.Size(165, 60);
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Location = new System.Drawing.Point(8, 14);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(12, 37);
            this.txt_codigo.Size = new System.Drawing.Size(101, 31);
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(811, 907);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(927, 907);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(244, 877);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(251, 904);
            this.txt_dat_ult_alt.Text = "03/10/2024 21:43:21";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(12, 877);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(12, 904);
            this.txt_dat_cad.Text = "03/10/2024 21:43:21";
            // 
            // lbl_serie
            // 
            this.lbl_serie.AutoSize = true;
            this.lbl_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_serie.Location = new System.Drawing.Point(121, 14);
            this.lbl_serie.Name = "lbl_serie";
            this.lbl_serie.Size = new System.Drawing.Size(54, 24);
            this.lbl_serie.TabIndex = 96;
            this.lbl_serie.Text = "Serie";
            // 
            // txt_serie
            // 
            this.txt_serie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_serie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_serie.Location = new System.Drawing.Point(124, 38);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.Size = new System.Drawing.Size(107, 31);
            this.txt_serie.TabIndex = 95;
            this.txt_serie.Text = "";
            this.txt_serie.Leave += new System.EventHandler(this.txt_serie_Leave);
            // 
            // lbl_cod_fornecedor
            // 
            this.lbl_cod_fornecedor.AutoSize = true;
            this.lbl_cod_fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cod_fornecedor.Location = new System.Drawing.Point(244, 11);
            this.lbl_cod_fornecedor.Name = "lbl_cod_fornecedor";
            this.lbl_cod_fornecedor.Size = new System.Drawing.Size(177, 24);
            this.lbl_cod_fornecedor.TabIndex = 98;
            this.lbl_cod_fornecedor.Text = "Cód do Fornecedor";
            // 
            // txt_cod_fornecedor
            // 
            this.txt_cod_fornecedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_fornecedor.Location = new System.Drawing.Point(251, 38);
            this.txt_cod_fornecedor.Name = "txt_cod_fornecedor";
            this.txt_cod_fornecedor.Size = new System.Drawing.Size(107, 31);
            this.txt_cod_fornecedor.TabIndex = 97;
            this.txt_cod_fornecedor.Text = "";
            this.txt_cod_fornecedor.Leave += new System.EventHandler(this.txt_cod_fornecedor_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(436, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 100;
            this.label3.Text = "Fornecedor";
            // 
            // txt_fornecedor
            // 
            this.txt_fornecedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_fornecedor.Location = new System.Drawing.Point(440, 35);
            this.txt_fornecedor.Name = "txt_fornecedor";
            this.txt_fornecedor.Size = new System.Drawing.Size(218, 31);
            this.txt_fornecedor.TabIndex = 99;
            this.txt_fornecedor.Text = "";
            // 
            // btn_busca_fornecedor
            // 
            this.btn_busca_fornecedor.Location = new System.Drawing.Point(362, 38);
            this.btn_busca_fornecedor.Name = "btn_busca_fornecedor";
            this.btn_busca_fornecedor.Size = new System.Drawing.Size(62, 29);
            this.btn_busca_fornecedor.TabIndex = 187;
            this.btn_busca_fornecedor.Text = "search";
            this.btn_busca_fornecedor.UseVisualStyleBackColor = true;
            this.btn_busca_fornecedor.Click += new System.EventHandler(this.btn_busca_fornecedor_Click);
            // 
            // txt_data_emissao
            // 
            this.txt_data_emissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_data_emissao.Location = new System.Drawing.Point(12, 113);
            this.txt_data_emissao.Mask = "____ /_____ / ______";
            this.txt_data_emissao.Name = "txt_data_emissao";
            this.txt_data_emissao.Size = new System.Drawing.Size(153, 26);
            this.txt_data_emissao.TabIndex = 206;
            this.txt_data_emissao.Leave += new System.EventHandler(this.txt_data_emissao_Leave);
            // 
            // txt_data_chegada
            // 
            this.txt_data_chegada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_data_chegada.Location = new System.Drawing.Point(195, 113);
            this.txt_data_chegada.Mask = "____ /_____ / ______";
            this.txt_data_chegada.Name = "txt_data_chegada";
            this.txt_data_chegada.Size = new System.Drawing.Size(153, 26);
            this.txt_data_chegada.TabIndex = 208;
            this.txt_data_chegada.Leave += new System.EventHandler(this.txt_data_chegada_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 209;
            this.label1.Text = "Data Emissao";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(191, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 210;
            this.label2.Text = "Data Chegada";
            // 
            // lbl_cancelada
            // 
            this.lbl_cancelada.AutoSize = true;
            this.lbl_cancelada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cancelada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_cancelada.Location = new System.Drawing.Point(687, 38);
            this.lbl_cancelada.Name = "lbl_cancelada";
            this.lbl_cancelada.Size = new System.Drawing.Size(166, 20);
            this.lbl_cancelada.TabIndex = 211;
            this.lbl_cancelada.Text = "*NOTA CANCELADA*";
            this.lbl_cancelada.Visible = false;
            // 
            // txt_data_cancelamento
            // 
            this.txt_data_cancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_data_cancelamento.Location = new System.Drawing.Point(402, 109);
            this.txt_data_cancelamento.Mask = "____ /_____ / ______";
            this.txt_data_cancelamento.Name = "txt_data_cancelamento";
            this.txt_data_cancelamento.Size = new System.Drawing.Size(210, 26);
            this.txt_data_cancelamento.TabIndex = 212;
            // 
            // lbl_data_cancelamento
            // 
            this.lbl_data_cancelamento.AutoSize = true;
            this.lbl_data_cancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data_cancelamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_data_cancelamento.Location = new System.Drawing.Point(398, 86);
            this.lbl_data_cancelamento.Name = "lbl_data_cancelamento";
            this.lbl_data_cancelamento.Size = new System.Drawing.Size(214, 20);
            this.lbl_data_cancelamento.TabIndex = 213;
            this.lbl_data_cancelamento.Text = "DATA DE CANCELAMENTO";
            this.lbl_data_cancelamento.Visible = false;
            // 
            // btn_buscaproduto
            // 
            this.btn_buscaproduto.Location = new System.Drawing.Point(124, 192);
            this.btn_buscaproduto.Name = "btn_buscaproduto";
            this.btn_buscaproduto.Size = new System.Drawing.Size(51, 29);
            this.btn_buscaproduto.TabIndex = 216;
            this.btn_buscaproduto.Text = "search";
            this.btn_buscaproduto.UseVisualStyleBackColor = true;
            this.btn_buscaproduto.Click += new System.EventHandler(this.btn_buscaproduto_Click);
            // 
            // lbl_cod_produto
            // 
            this.lbl_cod_produto.AutoSize = true;
            this.lbl_cod_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cod_produto.Location = new System.Drawing.Point(8, 165);
            this.lbl_cod_produto.Name = "lbl_cod_produto";
            this.lbl_cod_produto.Size = new System.Drawing.Size(143, 24);
            this.lbl_cod_produto.TabIndex = 215;
            this.lbl_cod_produto.Text = "Cód do Produto";
            // 
            // txt_cod_produto
            // 
            this.txt_cod_produto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_produto.Location = new System.Drawing.Point(12, 192);
            this.txt_cod_produto.Name = "txt_cod_produto";
            this.txt_cod_produto.Size = new System.Drawing.Size(107, 31);
            this.txt_cod_produto.TabIndex = 214;
            this.txt_cod_produto.Text = "";
            this.txt_cod_produto.Leave += new System.EventHandler(this.txt_cod_produto_Leave);
            // 
            // lbl_produto
            // 
            this.lbl_produto.AutoSize = true;
            this.lbl_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_produto.Location = new System.Drawing.Point(178, 165);
            this.lbl_produto.Name = "lbl_produto";
            this.lbl_produto.Size = new System.Drawing.Size(76, 24);
            this.lbl_produto.TabIndex = 218;
            this.lbl_produto.Text = "Produto";
            // 
            // txt_produto
            // 
            this.txt_produto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_produto.Location = new System.Drawing.Point(181, 189);
            this.txt_produto.Name = "txt_produto";
            this.txt_produto.Size = new System.Drawing.Size(176, 31);
            this.txt_produto.TabIndex = 217;
            this.txt_produto.Text = "";
            // 
            // lbl_quantidade
            // 
            this.lbl_quantidade.AutoSize = true;
            this.lbl_quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_quantidade.Location = new System.Drawing.Point(378, 160);
            this.lbl_quantidade.Name = "lbl_quantidade";
            this.lbl_quantidade.Size = new System.Drawing.Size(108, 24);
            this.lbl_quantidade.TabIndex = 220;
            this.lbl_quantidade.Text = "Quantidade";
            // 
            // txt_qtd
            // 
            this.txt_qtd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_qtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_qtd.Location = new System.Drawing.Point(382, 187);
            this.txt_qtd.Name = "txt_qtd";
            this.txt_qtd.Size = new System.Drawing.Size(80, 31);
            this.txt_qtd.TabIndex = 219;
            this.txt_qtd.Text = "";
            // 
            // lbl_unidade
            // 
            this.lbl_unidade.AutoSize = true;
            this.lbl_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_unidade.Location = new System.Drawing.Point(488, 160);
            this.lbl_unidade.Name = "lbl_unidade";
            this.lbl_unidade.Size = new System.Drawing.Size(81, 24);
            this.lbl_unidade.TabIndex = 222;
            this.lbl_unidade.Text = "Unidade";
            // 
            // txt_unidade
            // 
            this.txt_unidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_unidade.Location = new System.Drawing.Point(492, 187);
            this.txt_unidade.Name = "txt_unidade";
            this.txt_unidade.Size = new System.Drawing.Size(112, 31);
            this.txt_unidade.TabIndex = 221;
            this.txt_unidade.Text = "";
            // 
            // lbl_preco
            // 
            this.lbl_preco.AutoSize = true;
            this.lbl_preco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_preco.Location = new System.Drawing.Point(624, 160);
            this.lbl_preco.Name = "lbl_preco";
            this.lbl_preco.Size = new System.Drawing.Size(60, 24);
            this.lbl_preco.TabIndex = 224;
            this.lbl_preco.Text = "Preço";
            // 
            // txt_preco
            // 
            this.txt_preco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_preco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_preco.Location = new System.Drawing.Point(628, 187);
            this.txt_preco.Name = "txt_preco";
            this.txt_preco.Size = new System.Drawing.Size(107, 31);
            this.txt_preco.TabIndex = 223;
            this.txt_preco.Text = "";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(975, 203);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(62, 29);
            this.btn_add.TabIndex = 225;
            this.btn_add.Text = "ADD";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dataGridView_produtos
            // 
            this.dataGridView_produtos.AllowUserToAddRows = false;
            this.dataGridView_produtos.AllowUserToDeleteRows = false;
            this.dataGridView_produtos.AllowUserToResizeColumns = false;
            this.dataGridView_produtos.AllowUserToResizeRows = false;
            this.dataGridView_produtos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dataGridView_produtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_produtos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProduto,
            this.produto,
            this.UNProd,
            this.quantidadeProduto,
            this.PrecoUN,
            this.precoTotal});
            this.dataGridView_produtos.Enabled = false;
            this.dataGridView_produtos.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView_produtos.Location = new System.Drawing.Point(12, 238);
            this.dataGridView_produtos.Name = "dataGridView_produtos";
            this.dataGridView_produtos.ReadOnly = true;
            this.dataGridView_produtos.Size = new System.Drawing.Size(1025, 149);
            this.dataGridView_produtos.TabIndex = 226;
            this.dataGridView_produtos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_produtos_RowsAdded_1);
            this.dataGridView_produtos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_produtos_RowsRemoved);
            // 
            // idProduto
            // 
            this.idProduto.HeaderText = "Código";
            this.idProduto.Name = "idProduto";
            this.idProduto.ReadOnly = true;
            this.idProduto.Width = 80;
            // 
            // produto
            // 
            this.produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.produto.HeaderText = "Produto";
            this.produto.Name = "produto";
            this.produto.ReadOnly = true;
            // 
            // UNProd
            // 
            this.UNProd.HeaderText = "Unidade";
            this.UNProd.Name = "UNProd";
            this.UNProd.ReadOnly = true;
            // 
            // quantidadeProduto
            // 
            this.quantidadeProduto.HeaderText = "Quantidade";
            this.quantidadeProduto.Name = "quantidadeProduto";
            this.quantidadeProduto.ReadOnly = true;
            this.quantidadeProduto.Width = 80;
            // 
            // PrecoUN
            // 
            this.PrecoUN.HeaderText = "Preço UN";
            this.PrecoUN.Name = "PrecoUN";
            this.PrecoUN.ReadOnly = true;
            // 
            // precoTotal
            // 
            this.precoTotal.HeaderText = "Preço Total";
            this.precoTotal.Name = "precoTotal";
            this.precoTotal.ReadOnly = true;
            // 
            // lbl_total_pagar
            // 
            this.lbl_total_pagar.AutoSize = true;
            this.lbl_total_pagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_total_pagar.Location = new System.Drawing.Point(145, 390);
            this.lbl_total_pagar.Name = "lbl_total_pagar";
            this.lbl_total_pagar.Size = new System.Drawing.Size(120, 24);
            this.lbl_total_pagar.TabIndex = 230;
            this.lbl_total_pagar.Text = "Total a Pagar";
            // 
            // txt_total_pagar
            // 
            this.txt_total_pagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_total_pagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_total_pagar.Location = new System.Drawing.Point(149, 414);
            this.txt_total_pagar.Name = "txt_total_pagar";
            this.txt_total_pagar.Size = new System.Drawing.Size(123, 31);
            this.txt_total_pagar.TabIndex = 229;
            this.txt_total_pagar.Text = "";
            // 
            // lbl_total_produtos
            // 
            this.lbl_total_produtos.AutoSize = true;
            this.lbl_total_produtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_total_produtos.Location = new System.Drawing.Point(5, 390);
            this.lbl_total_produtos.Name = "lbl_total_produtos";
            this.lbl_total_produtos.Size = new System.Drawing.Size(131, 24);
            this.lbl_total_produtos.TabIndex = 228;
            this.lbl_total_produtos.Text = "Total Produtos";
            // 
            // txt_total_produtos
            // 
            this.txt_total_produtos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_total_produtos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_total_produtos.Location = new System.Drawing.Point(12, 414);
            this.txt_total_produtos.Name = "txt_total_produtos";
            this.txt_total_produtos.Size = new System.Drawing.Size(112, 31);
            this.txt_total_produtos.TabIndex = 227;
            this.txt_total_produtos.Text = "";
            // 
            // btn_excluir_produto
            // 
            this.btn_excluir_produto.Location = new System.Drawing.Point(961, 393);
            this.btn_excluir_produto.Name = "btn_excluir_produto";
            this.btn_excluir_produto.Size = new System.Drawing.Size(76, 29);
            this.btn_excluir_produto.TabIndex = 231;
            this.btn_excluir_produto.Text = "excluir";
            this.btn_excluir_produto.UseVisualStyleBackColor = true;
            this.btn_excluir_produto.Click += new System.EventHandler(this.btn_excluir_produto_Click);
            // 
            // tipo_frete
            // 
            this.tipo_frete.Controls.Add(this.check_fob);
            this.tipo_frete.Controls.Add(this.check_cif);
            this.tipo_frete.Enabled = false;
            this.tipo_frete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipo_frete.Location = new System.Drawing.Point(16, 477);
            this.tipo_frete.Name = "tipo_frete";
            this.tipo_frete.Size = new System.Drawing.Size(149, 49);
            this.tipo_frete.TabIndex = 232;
            this.tipo_frete.TabStop = false;
            this.tipo_frete.Text = "Tipo Frete";
            // 
            // check_fob
            // 
            this.check_fob.AutoSize = true;
            this.check_fob.Enabled = false;
            this.check_fob.Location = new System.Drawing.Point(80, 20);
            this.check_fob.Name = "check_fob";
            this.check_fob.Size = new System.Drawing.Size(60, 24);
            this.check_fob.TabIndex = 15;
            this.check_fob.TabStop = true;
            this.check_fob.Text = "FOB";
            this.check_fob.UseVisualStyleBackColor = true;
            this.check_fob.CheckedChanged += new System.EventHandler(this.check_fob_CheckedChanged_1);
            // 
            // check_cif
            // 
            this.check_cif.AutoSize = true;
            this.check_cif.Checked = true;
            this.check_cif.Enabled = false;
            this.check_cif.Location = new System.Drawing.Point(16, 20);
            this.check_cif.Name = "check_cif";
            this.check_cif.Size = new System.Drawing.Size(53, 24);
            this.check_cif.TabIndex = 14;
            this.check_cif.TabStop = true;
            this.check_cif.Text = "CIF";
            this.check_cif.UseVisualStyleBackColor = true;
            this.check_cif.CheckedChanged += new System.EventHandler(this.check_cif_CheckedChanged_1);
            // 
            // lbl_cond_pagamento
            // 
            this.lbl_cond_pagamento.AutoSize = true;
            this.lbl_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cond_pagamento.Location = new System.Drawing.Point(282, 550);
            this.lbl_cond_pagamento.Name = "lbl_cond_pagamento";
            this.lbl_cond_pagamento.Size = new System.Drawing.Size(219, 24);
            this.lbl_cond_pagamento.TabIndex = 234;
            this.lbl_cond_pagamento.Text = "Condição de Pagamento";
            // 
            // txt_cond_pagamento
            // 
            this.txt_cond_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cond_pagamento.Location = new System.Drawing.Point(286, 577);
            this.txt_cond_pagamento.Name = "txt_cond_pagamento";
            this.txt_cond_pagamento.Size = new System.Drawing.Size(406, 31);
            this.txt_cond_pagamento.TabIndex = 233;
            this.txt_cond_pagamento.Text = "";
            // 
            // lbl_cod_cond_pagamento
            // 
            this.lbl_cod_cond_pagamento.AutoSize = true;
            this.lbl_cod_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cod_cond_pagamento.Location = new System.Drawing.Point(16, 550);
            this.lbl_cod_cond_pagamento.Name = "lbl_cod_cond_pagamento";
            this.lbl_cod_cond_pagamento.Size = new System.Drawing.Size(197, 24);
            this.lbl_cod_cond_pagamento.TabIndex = 236;
            this.lbl_cod_cond_pagamento.Text = "Cód Cond Pagamento";
            // 
            // txt_cod_cond_pagamento
            // 
            this.txt_cod_cond_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_cond_pagamento.Location = new System.Drawing.Point(20, 577);
            this.txt_cod_cond_pagamento.Name = "txt_cod_cond_pagamento";
            this.txt_cod_cond_pagamento.Size = new System.Drawing.Size(123, 31);
            this.txt_cod_cond_pagamento.TabIndex = 235;
            this.txt_cod_cond_pagamento.Text = "";
            this.txt_cod_cond_pagamento.Leave += new System.EventHandler(this.txt_cod_cond_pagamento_Leave);
            // 
            // btn_busca_cond_pagamento
            // 
            this.btn_busca_cond_pagamento.Location = new System.Drawing.Point(149, 577);
            this.btn_busca_cond_pagamento.Name = "btn_busca_cond_pagamento";
            this.btn_busca_cond_pagamento.Size = new System.Drawing.Size(62, 29);
            this.btn_busca_cond_pagamento.TabIndex = 237;
            this.btn_busca_cond_pagamento.Text = "search";
            this.btn_busca_cond_pagamento.UseVisualStyleBackColor = true;
            this.btn_busca_cond_pagamento.Click += new System.EventHandler(this.btn_busca_cond_pagamento_Click);
            // 
            // btn_add_cond_pag
            // 
            this.btn_add_cond_pag.Location = new System.Drawing.Point(699, 577);
            this.btn_add_cond_pag.Name = "btn_add_cond_pag";
            this.btn_add_cond_pag.Size = new System.Drawing.Size(62, 29);
            this.btn_add_cond_pag.TabIndex = 238;
            this.btn_add_cond_pag.Text = "ADD";
            this.btn_add_cond_pag.UseVisualStyleBackColor = true;
            this.btn_add_cond_pag.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView_parcelas
            // 
            this.dataGridView_parcelas.AllowUserToAddRows = false;
            this.dataGridView_parcelas.AllowUserToDeleteRows = false;
            this.dataGridView_parcelas.AllowUserToResizeColumns = false;
            this.dataGridView_parcelas.AllowUserToResizeRows = false;
            this.dataGridView_parcelas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dataGridView_parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroParcela,
            this.idFormaPagamento,
            this.FormaPagamento,
            this.dataVencimento,
            this.valorParcela});
            this.dataGridView_parcelas.Enabled = false;
            this.dataGridView_parcelas.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView_parcelas.Location = new System.Drawing.Point(20, 614);
            this.dataGridView_parcelas.Name = "dataGridView_parcelas";
            this.dataGridView_parcelas.ReadOnly = true;
            this.dataGridView_parcelas.Size = new System.Drawing.Size(1017, 140);
            this.dataGridView_parcelas.TabIndex = 239;
            // 
            // numeroParcela
            // 
            this.numeroParcela.HeaderText = "Parcela";
            this.numeroParcela.Name = "numeroParcela";
            this.numeroParcela.ReadOnly = true;
            this.numeroParcela.Width = 120;
            // 
            // idFormaPagamento
            // 
            this.idFormaPagamento.HeaderText = "Cód. Forma Pagamento";
            this.idFormaPagamento.Name = "idFormaPagamento";
            this.idFormaPagamento.ReadOnly = true;
            this.idFormaPagamento.Width = 80;
            // 
            // FormaPagamento
            // 
            this.FormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FormaPagamento.HeaderText = "Forma de Pagamento";
            this.FormaPagamento.Name = "FormaPagamento";
            this.FormaPagamento.ReadOnly = true;
            // 
            // dataVencimento
            // 
            this.dataVencimento.HeaderText = "Data Vencimento";
            this.dataVencimento.Name = "dataVencimento";
            this.dataVencimento.ReadOnly = true;
            this.dataVencimento.Width = 150;
            // 
            // valorParcela
            // 
            this.valorParcela.HeaderText = "Valor Parcela";
            this.valorParcela.Name = "valorParcela";
            this.valorParcela.ReadOnly = true;
            this.valorParcela.Width = 153;
            // 
            // lbl_obs
            // 
            this.lbl_obs.AutoSize = true;
            this.lbl_obs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_obs.Location = new System.Drawing.Point(24, 757);
            this.lbl_obs.Name = "lbl_obs";
            this.lbl_obs.Size = new System.Drawing.Size(112, 24);
            this.lbl_obs.TabIndex = 240;
            this.lbl_obs.Text = "Observação";
            // 
            // txt_obs
            // 
            this.txt_obs.Location = new System.Drawing.Point(20, 784);
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.Size = new System.Drawing.Size(1017, 90);
            this.txt_obs.TabIndex = 241;
            this.txt_obs.Text = "";
            // 
            // btn_cancelar_nota
            // 
            this.btn_cancelar_nota.Location = new System.Drawing.Point(628, 908);
            this.btn_cancelar_nota.Name = "btn_cancelar_nota";
            this.btn_cancelar_nota.Size = new System.Drawing.Size(160, 31);
            this.btn_cancelar_nota.TabIndex = 242;
            this.btn_cancelar_nota.Text = "Cancelar Nota";
            this.btn_cancelar_nota.UseVisualStyleBackColor = true;
            this.btn_cancelar_nota.Click += new System.EventHandler(this.btn_cancelar_nota_Click);
            // 
            // txt_valor_frete
            // 
            this.txt_valor_frete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_valor_frete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor_frete.Location = new System.Drawing.Point(195, 490);
            this.txt_valor_frete.Name = "txt_valor_frete";
            this.txt_valor_frete.Size = new System.Drawing.Size(123, 31);
            this.txt_valor_frete.TabIndex = 243;
            this.txt_valor_frete.Text = "";
            this.txt_valor_frete.Leave += new System.EventHandler(this.txt_valor_frete_Leave);
            // 
            // txt_valor_seguro
            // 
            this.txt_valor_seguro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_valor_seguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor_seguro.Location = new System.Drawing.Point(339, 490);
            this.txt_valor_seguro.Name = "txt_valor_seguro";
            this.txt_valor_seguro.Size = new System.Drawing.Size(123, 31);
            this.txt_valor_seguro.TabIndex = 244;
            this.txt_valor_seguro.Text = "";
            this.txt_valor_seguro.Leave += new System.EventHandler(this.txt_valor_seguro_Leave);
            // 
            // txt_outros
            // 
            this.txt_outros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_outros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_outros.Location = new System.Drawing.Point(521, 490);
            this.txt_outros.Name = "txt_outros";
            this.txt_outros.Size = new System.Drawing.Size(123, 31);
            this.txt_outros.TabIndex = 245;
            this.txt_outros.Text = "";
            this.txt_outros.Leave += new System.EventHandler(this.txt_outros_Leave);
            // 
            // lbl_valor_frete
            // 
            this.lbl_valor_frete.AutoSize = true;
            this.lbl_valor_frete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_valor_frete.Location = new System.Drawing.Point(191, 463);
            this.lbl_valor_frete.Name = "lbl_valor_frete";
            this.lbl_valor_frete.Size = new System.Drawing.Size(130, 24);
            this.lbl_valor_frete.TabIndex = 246;
            this.lbl_valor_frete.Text = "Valor do Frete";
            // 
            // lbl_valor_seguro
            // 
            this.lbl_valor_seguro.AutoSize = true;
            this.lbl_valor_seguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_valor_seguro.Location = new System.Drawing.Point(335, 463);
            this.lbl_valor_seguro.Name = "lbl_valor_seguro";
            this.lbl_valor_seguro.Size = new System.Drawing.Size(148, 24);
            this.lbl_valor_seguro.TabIndex = 247;
            this.lbl_valor_seguro.Text = "Valor do Seguro";
            // 
            // lbl_outros
            // 
            this.lbl_outros.AutoSize = true;
            this.lbl_outros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_outros.Location = new System.Drawing.Point(517, 463);
            this.lbl_outros.Name = "lbl_outros";
            this.lbl_outros.Size = new System.Drawing.Size(66, 24);
            this.lbl_outros.TabIndex = 248;
            this.lbl_outros.Text = "Outros";
            // 
            // CadastroNotaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1049, 951);
            this.Controls.Add(this.lbl_outros);
            this.Controls.Add(this.lbl_valor_seguro);
            this.Controls.Add(this.lbl_valor_frete);
            this.Controls.Add(this.txt_outros);
            this.Controls.Add(this.txt_valor_seguro);
            this.Controls.Add(this.txt_valor_frete);
            this.Controls.Add(this.btn_cancelar_nota);
            this.Controls.Add(this.txt_obs);
            this.Controls.Add(this.lbl_obs);
            this.Controls.Add(this.dataGridView_parcelas);
            this.Controls.Add(this.btn_add_cond_pag);
            this.Controls.Add(this.btn_busca_cond_pagamento);
            this.Controls.Add(this.lbl_cod_cond_pagamento);
            this.Controls.Add(this.txt_cod_cond_pagamento);
            this.Controls.Add(this.lbl_cond_pagamento);
            this.Controls.Add(this.txt_cond_pagamento);
            this.Controls.Add(this.tipo_frete);
            this.Controls.Add(this.btn_excluir_produto);
            this.Controls.Add(this.lbl_total_pagar);
            this.Controls.Add(this.txt_total_pagar);
            this.Controls.Add(this.lbl_total_produtos);
            this.Controls.Add(this.txt_total_produtos);
            this.Controls.Add(this.dataGridView_produtos);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lbl_preco);
            this.Controls.Add(this.txt_preco);
            this.Controls.Add(this.lbl_unidade);
            this.Controls.Add(this.txt_unidade);
            this.Controls.Add(this.lbl_quantidade);
            this.Controls.Add(this.txt_qtd);
            this.Controls.Add(this.lbl_produto);
            this.Controls.Add(this.txt_produto);
            this.Controls.Add(this.btn_buscaproduto);
            this.Controls.Add(this.lbl_cod_produto);
            this.Controls.Add(this.txt_cod_produto);
            this.Controls.Add(this.lbl_data_cancelamento);
            this.Controls.Add(this.txt_data_cancelamento);
            this.Controls.Add(this.lbl_cancelada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_data_chegada);
            this.Controls.Add(this.txt_data_emissao);
            this.Controls.Add(this.btn_busca_fornecedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_fornecedor);
            this.Controls.Add(this.lbl_cod_fornecedor);
            this.Controls.Add(this.txt_cod_fornecedor);
            this.Controls.Add(this.lbl_serie);
            this.Controls.Add(this.txt_serie);
            this.Name = "CadastroNotaCompra";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CadastroNotaCompra_FormClosed);
            this.Load += new System.EventHandler(this.CadastroNotaCompra_Load);
            this.Controls.SetChildIndex(this.txt_serie, 0);
            this.Controls.SetChildIndex(this.lbl_serie, 0);
            this.Controls.SetChildIndex(this.txt_cod_fornecedor, 0);
            this.Controls.SetChildIndex(this.lbl_cod_fornecedor, 0);
            this.Controls.SetChildIndex(this.txt_fornecedor, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btn_busca_fornecedor, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_data_emissao, 0);
            this.Controls.SetChildIndex(this.txt_data_chegada, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbl_cancelada, 0);
            this.Controls.SetChildIndex(this.txt_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.lbl_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.txt_cod_produto, 0);
            this.Controls.SetChildIndex(this.lbl_cod_produto, 0);
            this.Controls.SetChildIndex(this.btn_buscaproduto, 0);
            this.Controls.SetChildIndex(this.txt_produto, 0);
            this.Controls.SetChildIndex(this.lbl_produto, 0);
            this.Controls.SetChildIndex(this.txt_qtd, 0);
            this.Controls.SetChildIndex(this.lbl_quantidade, 0);
            this.Controls.SetChildIndex(this.txt_unidade, 0);
            this.Controls.SetChildIndex(this.lbl_unidade, 0);
            this.Controls.SetChildIndex(this.txt_preco, 0);
            this.Controls.SetChildIndex(this.lbl_preco, 0);
            this.Controls.SetChildIndex(this.btn_add, 0);
            this.Controls.SetChildIndex(this.dataGridView_produtos, 0);
            this.Controls.SetChildIndex(this.txt_total_produtos, 0);
            this.Controls.SetChildIndex(this.lbl_total_produtos, 0);
            this.Controls.SetChildIndex(this.txt_total_pagar, 0);
            this.Controls.SetChildIndex(this.lbl_total_pagar, 0);
            this.Controls.SetChildIndex(this.btn_excluir_produto, 0);
            this.Controls.SetChildIndex(this.tipo_frete, 0);
            this.Controls.SetChildIndex(this.txt_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.lbl_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.txt_cod_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.lbl_cod_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_busca_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_add_cond_pag, 0);
            this.Controls.SetChildIndex(this.dataGridView_parcelas, 0);
            this.Controls.SetChildIndex(this.lbl_obs, 0);
            this.Controls.SetChildIndex(this.txt_obs, 0);
            this.Controls.SetChildIndex(this.btn_cancelar_nota, 0);
            this.Controls.SetChildIndex(this.txt_valor_frete, 0);
            this.Controls.SetChildIndex(this.txt_valor_seguro, 0);
            this.Controls.SetChildIndex(this.txt_outros, 0);
            this.Controls.SetChildIndex(this.lbl_valor_frete, 0);
            this.Controls.SetChildIndex(this.lbl_valor_seguro, 0);
            this.Controls.SetChildIndex(this.lbl_outros, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_produtos)).EndInit();
            this.tipo_frete.ResumeLayout(false);
            this.tipo_frete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_serie;
        private System.Windows.Forms.RichTextBox txt_serie;
        private System.Windows.Forms.Label lbl_cod_fornecedor;
        private System.Windows.Forms.RichTextBox txt_cod_fornecedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txt_fornecedor;
        private System.Windows.Forms.Button btn_busca_fornecedor;
        private System.Windows.Forms.MaskedTextBox txt_data_emissao;
        private System.Windows.Forms.MaskedTextBox txt_data_chegada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbl_cancelada;
        private System.Windows.Forms.MaskedTextBox txt_data_cancelamento;
        public System.Windows.Forms.Label lbl_data_cancelamento;
        private System.Windows.Forms.Button btn_buscaproduto;
        private System.Windows.Forms.Label lbl_cod_produto;
        private System.Windows.Forms.RichTextBox txt_cod_produto;
        private System.Windows.Forms.Label lbl_produto;
        private System.Windows.Forms.RichTextBox txt_produto;
        private System.Windows.Forms.Label lbl_quantidade;
        private System.Windows.Forms.RichTextBox txt_qtd;
        private System.Windows.Forms.Label lbl_unidade;
        private System.Windows.Forms.RichTextBox txt_unidade;
        private System.Windows.Forms.Label lbl_preco;
        private System.Windows.Forms.RichTextBox txt_preco;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dataGridView_produtos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoTotal;
        private System.Windows.Forms.Label lbl_total_pagar;
        private System.Windows.Forms.RichTextBox txt_total_pagar;
        private System.Windows.Forms.Label lbl_total_produtos;
        private System.Windows.Forms.RichTextBox txt_total_produtos;
        private System.Windows.Forms.Button btn_excluir_produto;
        protected System.Windows.Forms.GroupBox tipo_frete;
        protected System.Windows.Forms.RadioButton check_fob;
        protected System.Windows.Forms.RadioButton check_cif;
        private System.Windows.Forms.Label lbl_cond_pagamento;
        private System.Windows.Forms.RichTextBox txt_cond_pagamento;
        private System.Windows.Forms.Label lbl_cod_cond_pagamento;
        private System.Windows.Forms.RichTextBox txt_cod_cond_pagamento;
        private System.Windows.Forms.Button btn_busca_cond_pagamento;
        private System.Windows.Forms.Button btn_add_cond_pag;
        private System.Windows.Forms.DataGridView dataGridView_parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorParcela;
        private System.Windows.Forms.Label lbl_obs;
        private System.Windows.Forms.RichTextBox txt_obs;
        private System.Windows.Forms.Button btn_cancelar_nota;
        private System.Windows.Forms.RichTextBox txt_valor_frete;
        private System.Windows.Forms.RichTextBox txt_valor_seguro;
        private System.Windows.Forms.RichTextBox txt_outros;
        private System.Windows.Forms.Label lbl_valor_frete;
        private System.Windows.Forms.Label lbl_valor_seguro;
        private System.Windows.Forms.Label lbl_outros;
    }
}
