namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroQuarto
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
            this.txt_andar = new System.Windows.Forms.RichTextBox();
            this.lbl_andar = new System.Windows.Forms.Label();
            this.txt_numero = new System.Windows.Forms.RichTextBox();
            this.lbl_numero = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_indisponivel = new System.Windows.Forms.CheckBox();
            this.check_disponivel = new System.Windows.Forms.CheckBox();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_descricao = new System.Windows.Forms.RichTextBox();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_valor = new System.Windows.Forms.TextBox();
            this.status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.txt_dat_ult_alt.Text = "14/08/2024 21:08:22";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Text = "14/08/2024 21:08:22";
            // 
            // txt_andar
            // 
            this.txt_andar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_andar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_andar.Location = new System.Drawing.Point(150, 131);
            this.txt_andar.Name = "txt_andar";
            this.txt_andar.Size = new System.Drawing.Size(93, 31);
            this.txt_andar.TabIndex = 120;
            this.txt_andar.Text = "";
            // 
            // lbl_andar
            // 
            this.lbl_andar.AutoSize = true;
            this.lbl_andar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_andar.Location = new System.Drawing.Point(146, 104);
            this.lbl_andar.Name = "lbl_andar";
            this.lbl_andar.Size = new System.Drawing.Size(61, 24);
            this.lbl_andar.TabIndex = 119;
            this.lbl_andar.Text = "Andar";
            // 
            // txt_numero
            // 
            this.txt_numero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_numero.Location = new System.Drawing.Point(32, 131);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(93, 31);
            this.txt_numero.TabIndex = 114;
            this.txt_numero.Text = "";
            // 
            // lbl_numero
            // 
            this.lbl_numero.AutoSize = true;
            this.lbl_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_numero.Location = new System.Drawing.Point(28, 104);
            this.lbl_numero.Name = "lbl_numero";
            this.lbl_numero.Size = new System.Drawing.Size(79, 24);
            this.lbl_numero.TabIndex = 113;
            this.lbl_numero.Text = "Numero";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_indisponivel);
            this.groupBox1.Controls.Add(this.check_disponivel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(443, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 88);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ocupação";
            // 
            // check_indisponivel
            // 
            this.check_indisponivel.AutoSize = true;
            this.check_indisponivel.Location = new System.Drawing.Point(122, 42);
            this.check_indisponivel.Name = "check_indisponivel";
            this.check_indisponivel.Size = new System.Drawing.Size(129, 28);
            this.check_indisponivel.TabIndex = 1;
            this.check_indisponivel.Text = "Indisponível";
            this.check_indisponivel.UseVisualStyleBackColor = true;
            // 
            // check_disponivel
            // 
            this.check_disponivel.AutoSize = true;
            this.check_disponivel.Checked = true;
            this.check_disponivel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_disponivel.Location = new System.Drawing.Point(6, 42);
            this.check_disponivel.Name = "check_disponivel";
            this.check_disponivel.Size = new System.Drawing.Size(116, 28);
            this.check_disponivel.TabIndex = 0;
            this.check_disponivel.Text = "Disponível";
            this.check_disponivel.UseVisualStyleBackColor = true;
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_tipo.Location = new System.Drawing.Point(30, 174);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(48, 24);
            this.lbl_tipo.TabIndex = 123;
            this.lbl_tipo.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(31, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 125;
            this.label1.Text = "Descrição";
            // 
            // txt_descricao
            // 
            this.txt_descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descricao.Location = new System.Drawing.Point(35, 359);
            this.txt_descricao.Name = "txt_descricao";
            this.txt_descricao.Size = new System.Drawing.Size(677, 123);
            this.txt_descricao.TabIndex = 126;
            this.txt_descricao.Text = "";
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Items.AddRange(new object[] {
            "Solteiro",
            "Casal",
            "Compartilhado"});
            this.cmb_tipo.Location = new System.Drawing.Point(31, 201);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(211, 33);
            this.cmb_tipo.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(30, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 129;
            this.label2.Text = "Valor Diária";
            // 
            // txt_valor
            // 
            this.txt_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor.Location = new System.Drawing.Point(31, 287);
            this.txt_valor.Name = "txt_valor";
            this.txt_valor.Size = new System.Drawing.Size(149, 29);
            this.txt_valor.TabIndex = 130;
            // 
            // CadastroQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.txt_valor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.txt_descricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_tipo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_andar);
            this.Controls.Add(this.lbl_andar);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.lbl_numero);
            this.Name = "CadastroQuarto";
            this.Text = "Cadastro Quartos";
            this.Controls.SetChildIndex(this.lbl_numero, 0);
            this.Controls.SetChildIndex(this.txt_numero, 0);
            this.Controls.SetChildIndex(this.lbl_andar, 0);
            this.Controls.SetChildIndex(this.txt_andar, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lbl_tipo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_descricao, 0);
            this.Controls.SetChildIndex(this.cmb_tipo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_valor, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_andar;
        private System.Windows.Forms.Label lbl_andar;
        private System.Windows.Forms.RichTextBox txt_numero;
        private System.Windows.Forms.Label lbl_numero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox check_indisponivel;
        private System.Windows.Forms.CheckBox check_disponivel;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_descricao;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor;
    }
}
