namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroCondPagamento
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
            this.txt_cond_pagamento = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_porcentagem = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_juros = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_parcela = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_desconto = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_multa = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_porcentagem_total = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_cod_forma = new System.Windows.Forms.RichTextBox();
            this.btn_cod_forma = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_forma_pagamento = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_parcelas = new System.Windows.Forms.DataGridView();
            this.numeroParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagamento_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_excluir_parcela = new System.Windows.Forms.Button();
            this.txt_dias = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(754, 14);
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Text = "23/08/2024 19:33:32";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Text = "23/08/2024 19:33:32";
            // 
            // txt_cond_pagamento
            // 
            this.txt_cond_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cond_pagamento.Location = new System.Drawing.Point(29, 113);
            this.txt_cond_pagamento.Name = "txt_cond_pagamento";
            this.txt_cond_pagamento.Size = new System.Drawing.Size(387, 31);
            this.txt_cond_pagamento.TabIndex = 111;
            this.txt_cond_pagamento.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(25, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 24);
            this.label4.TabIndex = 110;
            this.label4.Text = "Condição de Pagamento";
            // 
            // txt_porcentagem
            // 
            this.txt_porcentagem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_porcentagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_porcentagem.Location = new System.Drawing.Point(262, 174);
            this.txt_porcentagem.Name = "txt_porcentagem";
            this.txt_porcentagem.Size = new System.Drawing.Size(59, 31);
            this.txt_porcentagem.TabIndex = 113;
            this.txt_porcentagem.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(427, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 112;
            this.label1.Text = "Juros %";
            // 
            // txt_juros
            // 
            this.txt_juros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_juros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_juros.Location = new System.Drawing.Point(431, 113);
            this.txt_juros.Name = "txt_juros";
            this.txt_juros.Size = new System.Drawing.Size(153, 31);
            this.txt_juros.TabIndex = 115;
            this.txt_juros.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(25, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 24);
            this.label2.TabIndex = 114;
            this.label2.Text = "N° da Parcela";
            // 
            // txt_parcela
            // 
            this.txt_parcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_parcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_parcela.Location = new System.Drawing.Point(28, 176);
            this.txt_parcela.Name = "txt_parcela";
            this.txt_parcela.Size = new System.Drawing.Size(131, 31);
            this.txt_parcela.TabIndex = 117;
            this.txt_parcela.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(258, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 116;
            this.label3.Text = "%";
            // 
            // txt_desconto
            // 
            this.txt_desconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_desconto.Location = new System.Drawing.Point(799, 113);
            this.txt_desconto.Name = "txt_desconto";
            this.txt_desconto.Size = new System.Drawing.Size(153, 31);
            this.txt_desconto.TabIndex = 119;
            this.txt_desconto.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(795, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 24);
            this.label5.TabIndex = 118;
            this.label5.Text = "Desconto %";
            // 
            // txt_multa
            // 
            this.txt_multa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_multa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_multa.Location = new System.Drawing.Point(627, 113);
            this.txt_multa.Name = "txt_multa";
            this.txt_multa.Size = new System.Drawing.Size(153, 31);
            this.txt_multa.TabIndex = 121;
            this.txt_multa.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(623, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 24);
            this.label6.TabIndex = 120;
            this.label6.Text = "Multa %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(333, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 123;
            this.label7.Text = "% Total";
            // 
            // txt_porcentagem_total
            // 
            this.txt_porcentagem_total.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_porcentagem_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_porcentagem_total.Location = new System.Drawing.Point(337, 174);
            this.txt_porcentagem_total.Name = "txt_porcentagem_total";
            this.txt_porcentagem_total.Size = new System.Drawing.Size(67, 31);
            this.txt_porcentagem_total.TabIndex = 122;
            this.txt_porcentagem_total.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.Location = new System.Drawing.Point(427, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 125;
            this.label8.Text = "Código";
            // 
            // txt_cod_forma
            // 
            this.txt_cod_forma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_forma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_forma.Location = new System.Drawing.Point(431, 176);
            this.txt_cod_forma.Name = "txt_cod_forma";
            this.txt_cod_forma.Size = new System.Drawing.Size(100, 31);
            this.txt_cod_forma.TabIndex = 124;
            this.txt_cod_forma.Text = "";
            // 
            // btn_cod_forma
            // 
            this.btn_cod_forma.Location = new System.Drawing.Point(537, 176);
            this.btn_cod_forma.Name = "btn_cod_forma";
            this.btn_cod_forma.Size = new System.Drawing.Size(73, 31);
            this.btn_cod_forma.TabIndex = 126;
            this.btn_cod_forma.Text = "search";
            this.btn_cod_forma.UseVisualStyleBackColor = true;
            this.btn_cod_forma.Click += new System.EventHandler(this.btn_cod_forma_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label9.Location = new System.Drawing.Point(623, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 24);
            this.label9.TabIndex = 128;
            this.label9.Text = "Forma de Pagamento";
            // 
            // txt_forma_pagamento
            // 
            this.txt_forma_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_forma_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_forma_pagamento.Location = new System.Drawing.Point(627, 176);
            this.txt_forma_pagamento.Name = "txt_forma_pagamento";
            this.txt_forma_pagamento.Size = new System.Drawing.Size(230, 31);
            this.txt_forma_pagamento.TabIndex = 127;
            this.txt_forma_pagamento.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 31);
            this.button1.TabIndex = 129;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_parcelas
            // 
            this.dataGridView_parcelas.AllowUserToAddRows = false;
            this.dataGridView_parcelas.AllowUserToDeleteRows = false;
            this.dataGridView_parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroParcela,
            this.porcentagem,
            this.formaPagamento_ID,
            this.formaPagamento,
            this.dias});
            this.dataGridView_parcelas.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView_parcelas.Location = new System.Drawing.Point(29, 230);
            this.dataGridView_parcelas.Name = "dataGridView_parcelas";
            this.dataGridView_parcelas.ReadOnly = true;
            this.dataGridView_parcelas.Size = new System.Drawing.Size(924, 236);
            this.dataGridView_parcelas.TabIndex = 130;
            // 
            // numeroParcela
            // 
            this.numeroParcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroParcela.HeaderText = "N° de Parcelas";
            this.numeroParcela.Name = "numeroParcela";
            this.numeroParcela.ReadOnly = true;
            // 
            // porcentagem
            // 
            this.porcentagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.porcentagem.HeaderText = "%";
            this.porcentagem.Name = "porcentagem";
            this.porcentagem.ReadOnly = true;
            // 
            // formaPagamento_ID
            // 
            this.formaPagamento_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.formaPagamento_ID.HeaderText = "Cod. Forma Pagamento";
            this.formaPagamento_ID.Name = "formaPagamento_ID";
            this.formaPagamento_ID.ReadOnly = true;
            // 
            // formaPagamento
            // 
            this.formaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.formaPagamento.HeaderText = "Forma de Pagamento";
            this.formaPagamento.Name = "formaPagamento";
            this.formaPagamento.ReadOnly = true;
            // 
            // dias
            // 
            this.dias.HeaderText = "N° de Dias";
            this.dias.Name = "dias";
            this.dias.ReadOnly = true;
            // 
            // btn_excluir_parcela
            // 
            this.btn_excluir_parcela.Location = new System.Drawing.Point(836, 472);
            this.btn_excluir_parcela.Name = "btn_excluir_parcela";
            this.btn_excluir_parcela.Size = new System.Drawing.Size(116, 31);
            this.btn_excluir_parcela.TabIndex = 131;
            this.btn_excluir_parcela.Text = "Excluir";
            this.btn_excluir_parcela.UseVisualStyleBackColor = true;
            this.btn_excluir_parcela.Click += new System.EventHandler(this.btn_excluir_parcela_Click);
            // 
            // txt_dias
            // 
            this.txt_dias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_dias.Location = new System.Drawing.Point(165, 174);
            this.txt_dias.Name = "txt_dias";
            this.txt_dias.Size = new System.Drawing.Size(79, 31);
            this.txt_dias.TabIndex = 132;
            this.txt_dias.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label10.Location = new System.Drawing.Point(165, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 133;
            this.label10.Text = "Dias";
            // 
            // CadastroCondPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_dias);
            this.Controls.Add(this.btn_excluir_parcela);
            this.Controls.Add(this.dataGridView_parcelas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_forma_pagamento);
            this.Controls.Add(this.btn_cod_forma);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_cod_forma);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_porcentagem_total);
            this.Controls.Add(this.txt_multa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_desconto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_parcela);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_juros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_porcentagem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cond_pagamento);
            this.Controls.Add(this.label4);
            this.Name = "CadastroCondPagamento";
            this.Text = "Cadastro Condição de Pagamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CadastroCondPagamento_FormClosed);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txt_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_porcentagem, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_juros, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_parcela, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_desconto, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txt_multa, 0);
            this.Controls.SetChildIndex(this.txt_porcentagem_total, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txt_cod_forma, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btn_cod_forma, 0);
            this.Controls.SetChildIndex(this.txt_forma_pagamento, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.dataGridView_parcelas, 0);
            this.Controls.SetChildIndex(this.btn_excluir_parcela, 0);
            this.Controls.SetChildIndex(this.txt_dias, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_cond_pagamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txt_porcentagem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_juros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_parcela;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txt_desconto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txt_multa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txt_porcentagem_total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txt_cod_forma;
        private System.Windows.Forms.Button btn_cod_forma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txt_forma_pagamento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_parcelas;
        private System.Windows.Forms.Button btn_excluir_parcela;
        private System.Windows.Forms.RichTextBox txt_dias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagamento_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias;
    }
}
