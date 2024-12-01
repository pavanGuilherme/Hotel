namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroTipoQuarto
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
            this.lbl_ddd = new System.Windows.Forms.Label();
            this.txt_descricao = new System.Windows.Forms.RichTextBox();
            this.lbl_cidade = new System.Windows.Forms.Label();
            this.txt_tipo = new System.Windows.Forms.RichTextBox();
            this.txt_valor = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_capacidade_max = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_lotacao_maxima = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(481, 28);
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Location = new System.Drawing.Point(13, 22);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(15, 49);
            this.txt_codigo.Size = new System.Drawing.Size(104, 31);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(204, 437);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(208, 464);
            this.txt_dat_ult_alt.Size = new System.Drawing.Size(196, 31);
            this.txt_dat_ult_alt.Text = "07/11/2024 15:08:42";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(11, 437);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(11, 464);
            this.txt_dat_cad.Size = new System.Drawing.Size(177, 31);
            this.txt_dat_cad.Text = "07/11/2024 15:08:42";
            // 
            // check_inativo
            // 
            this.check_inativo.Enabled = false;
            // 
            // check_ativo
            // 
            this.check_ativo.Enabled = false;
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(445, 465);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(558, 465);
            // 
            // lbl_ddd
            // 
            this.lbl_ddd.AutoSize = true;
            this.lbl_ddd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_ddd.Location = new System.Drawing.Point(12, 236);
            this.lbl_ddd.Name = "lbl_ddd";
            this.lbl_ddd.Size = new System.Drawing.Size(106, 24);
            this.lbl_ddd.TabIndex = 95;
            this.lbl_ddd.Text = "Descrição *";
            // 
            // txt_descricao
            // 
            this.txt_descricao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_descricao.Location = new System.Drawing.Point(15, 263);
            this.txt_descricao.Name = "txt_descricao";
            this.txt_descricao.Size = new System.Drawing.Size(456, 153);
            this.txt_descricao.TabIndex = 141;
            this.txt_descricao.Text = "";
            this.txt_descricao.Leave += new System.EventHandler(this.txt_descricao_Leave);
            // 
            // lbl_cidade
            // 
            this.lbl_cidade.AutoSize = true;
            this.lbl_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cidade.Location = new System.Drawing.Point(14, 94);
            this.lbl_cidade.Name = "lbl_cidade";
            this.lbl_cidade.Size = new System.Drawing.Size(55, 24);
            this.lbl_cidade.TabIndex = 93;
            this.lbl_cidade.Text = "Tipo*";
            // 
            // txt_tipo
            // 
            this.txt_tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_tipo.Location = new System.Drawing.Point(18, 121);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(453, 31);
            this.txt_tipo.TabIndex = 92;
            this.txt_tipo.Text = "";
            this.txt_tipo.Leave += new System.EventHandler(this.txt_tipo_Leave_1);
            // 
            // txt_valor
            // 
            this.txt_valor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor.Location = new System.Drawing.Point(17, 192);
            this.txt_valor.Name = "txt_valor";
            this.txt_valor.Size = new System.Drawing.Size(156, 31);
            this.txt_valor.TabIndex = 136;
            this.txt_valor.Text = "";
            this.txt_valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_valor_KeyPress);
            this.txt_valor.Leave += new System.EventHandler(this.txt_valor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 135;
            this.label2.Text = "Valor Diária *";
            // 
            // txt_capacidade_max
            // 
            this.txt_capacidade_max.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_capacidade_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_capacidade_max.Location = new System.Drawing.Point(188, 192);
            this.txt_capacidade_max.Name = "txt_capacidade_max";
            this.txt_capacidade_max.Size = new System.Drawing.Size(101, 31);
            this.txt_capacidade_max.TabIndex = 140;
            this.txt_capacidade_max.Text = "";
            this.txt_capacidade_max.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_capacidade_max_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(183, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 138;
            this.label1.Text = "Capacidade Máx *";
            // 
            // txt_lotacao_maxima
            // 
            this.txt_lotacao_maxima.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_lotacao_maxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_lotacao_maxima.Location = new System.Drawing.Point(356, 192);
            this.txt_lotacao_maxima.Name = "txt_lotacao_maxima";
            this.txt_lotacao_maxima.Size = new System.Drawing.Size(81, 31);
            this.txt_lotacao_maxima.TabIndex = 143;
            this.txt_lotacao_maxima.Text = "";
            this.txt_lotacao_maxima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_lotacao_maxima_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(351, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 142;
            this.label3.Text = "Quantidade Máx *";
            // 
            // CadastroTipoQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(680, 508);
            this.Controls.Add(this.txt_lotacao_maxima);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_capacidade_max);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_valor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_ddd);
            this.Controls.Add(this.txt_descricao);
            this.Controls.Add(this.lbl_cidade);
            this.Controls.Add(this.txt_tipo);
            this.Name = "CadastroTipoQuarto";
            this.Load += new System.EventHandler(this.CadastroTipoQuarto_Load_1);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_tipo, 0);
            this.Controls.SetChildIndex(this.lbl_cidade, 0);
            this.Controls.SetChildIndex(this.txt_descricao, 0);
            this.Controls.SetChildIndex(this.lbl_ddd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_valor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_capacidade_max, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_lotacao_maxima, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ddd;
        private System.Windows.Forms.RichTextBox txt_descricao;
        private System.Windows.Forms.Label lbl_cidade;
        private System.Windows.Forms.RichTextBox txt_tipo;
        private System.Windows.Forms.RichTextBox txt_valor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_capacidade_max;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_lotacao_maxima;
        private System.Windows.Forms.Label label3;
    }
}
