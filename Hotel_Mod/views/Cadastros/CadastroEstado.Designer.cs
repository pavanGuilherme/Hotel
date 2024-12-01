namespace Hotel_Mod.views
{
    partial class CadastroEstado
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
            this.btn_cod_pais = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.txt_uf = new System.Windows.Forms.TextBox();
            this.txt_cod_pais = new System.Windows.Forms.RichTextBox();
            this.txt_pais = new System.Windows.Forms.RichTextBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Text = "19/06/2024 10:04:11";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Text = "19/06/2024 10:04:11";
            // 
            // check_inativo
            // 
            this.check_inativo.CheckedChanged += new System.EventHandler(this.check_inativo_CheckedChanged);
            // 
            // check_ativo
            // 
            this.check_ativo.CheckedChanged += new System.EventHandler(this.check_ativo_CheckedChanged);
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
            // btn_cod_pais
            // 
            this.btn_cod_pais.Location = new System.Drawing.Point(139, 309);
            this.btn_cod_pais.Name = "btn_cod_pais";
            this.btn_cod_pais.Size = new System.Drawing.Size(73, 31);
            this.btn_cod_pais.TabIndex = 141;
            this.btn_cod_pais.Text = "search";
            this.btn_cod_pais.UseVisualStyleBackColor = true;
            this.btn_cod_pais.Click += new System.EventHandler(this.btn_cod_pais_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(28, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 24);
            this.label5.TabIndex = 110;
            this.label5.Text = "UF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(267, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 108;
            this.label4.Text = "País";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(28, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 106;
            this.label3.Text = "Código do País";
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_pais.Location = new System.Drawing.Point(28, 121);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(68, 24);
            this.lbl_pais.TabIndex = 104;
            this.lbl_pais.Text = "Estado";
            // 
            // txt_estado
            // 
            this.txt_estado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_estado.Location = new System.Drawing.Point(29, 148);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(214, 29);
            this.txt_estado.TabIndex = 138;
            // 
            // txt_uf
            // 
            this.txt_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_uf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_uf.Location = new System.Drawing.Point(31, 216);
            this.txt_uf.Name = "txt_uf";
            this.txt_uf.Size = new System.Drawing.Size(138, 29);
            this.txt_uf.TabIndex = 139;
            this.txt_uf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_uf_KeyPress);
            // 
            // txt_cod_pais
            // 
            this.txt_cod_pais.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_pais.Enabled = false;
            this.txt_cod_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_pais.Location = new System.Drawing.Point(29, 311);
            this.txt_cod_pais.Name = "txt_cod_pais";
            this.txt_cod_pais.Size = new System.Drawing.Size(104, 31);
            this.txt_cod_pais.TabIndex = 144;
            this.txt_cod_pais.Text = "";
            // 
            // txt_pais
            // 
            this.txt_pais.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_pais.Enabled = false;
            this.txt_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_pais.Location = new System.Drawing.Point(271, 309);
            this.txt_pais.Name = "txt_pais";
            this.txt_pais.Size = new System.Drawing.Size(211, 31);
            this.txt_pais.TabIndex = 143;
            this.txt_pais.Text = "";
            // 
            // CadastroEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.txt_cod_pais);
            this.Controls.Add(this.txt_pais);
            this.Controls.Add(this.txt_uf);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.btn_cod_pais);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_pais);
            this.Name = "CadastroEstado";
            this.Text = "Cadastro Estado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CadastroEstado_FormClosed);
            this.Load += new System.EventHandler(this.CadastroEstado_Load);
            this.Controls.SetChildIndex(this.lbl_pais, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btn_cod_pais, 0);
            this.Controls.SetChildIndex(this.txt_estado, 0);
            this.Controls.SetChildIndex(this.txt_uf, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_pais, 0);
            this.Controls.SetChildIndex(this.txt_cod_pais, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cod_pais;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.TextBox txt_uf;
        private System.Windows.Forms.RichTextBox txt_cod_pais;
        private System.Windows.Forms.RichTextBox txt_pais;
    }
}
