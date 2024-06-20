namespace Hotel_Mod.views
{
    partial class CadastroPais
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
            this.Txt_pais = new System.Windows.Forms.RichTextBox();
            this.Txt_sigla = new System.Windows.Forms.RichTextBox();
            this.Txt_ddi = new System.Windows.Forms.RichTextBox();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_sigla = new System.Windows.Forms.Label();
            this.lbl_ddi = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
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
            this.txt_dat_ult_alt.Text = "19/06/2024 08:18:08";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Text = "19/06/2024 08:18:08";
            // 
            // Txt_pais
            // 
            this.Txt_pais.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Txt_pais.Location = new System.Drawing.Point(32, 137);
            this.Txt_pais.Name = "Txt_pais";
            this.Txt_pais.Size = new System.Drawing.Size(211, 31);
            this.Txt_pais.TabIndex = 87;
            this.Txt_pais.Text = "";
            this.Txt_pais.Leave += new System.EventHandler(this.Txt_pais_Leave_1);
            // 
            // Txt_sigla
            // 
            this.Txt_sigla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_sigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Txt_sigla.Location = new System.Drawing.Point(32, 209);
            this.Txt_sigla.Name = "Txt_sigla";
            this.Txt_sigla.Size = new System.Drawing.Size(211, 31);
            this.Txt_sigla.TabIndex = 88;
            this.Txt_sigla.Text = "";
            this.Txt_sigla.Leave += new System.EventHandler(this.Txt_sigla_Leave);
            // 
            // Txt_ddi
            // 
            this.Txt_ddi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_ddi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Txt_ddi.Location = new System.Drawing.Point(31, 286);
            this.Txt_ddi.Name = "Txt_ddi";
            this.Txt_ddi.Size = new System.Drawing.Size(211, 31);
            this.Txt_ddi.TabIndex = 89;
            this.Txt_ddi.Text = "";
            this.Txt_ddi.Leave += new System.EventHandler(this.Txt_ddi_Leave);
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_pais.Location = new System.Drawing.Point(30, 110);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(45, 24);
            this.lbl_pais.TabIndex = 90;
            this.lbl_pais.Text = "Pais";
            // 
            // lbl_sigla
            // 
            this.lbl_sigla.AutoSize = true;
            this.lbl_sigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_sigla.Location = new System.Drawing.Point(30, 182);
            this.lbl_sigla.Name = "lbl_sigla";
            this.lbl_sigla.Size = new System.Drawing.Size(51, 24);
            this.lbl_sigla.TabIndex = 91;
            this.lbl_sigla.Text = "Sigla";
            // 
            // lbl_ddi
            // 
            this.lbl_ddi.AutoSize = true;
            this.lbl_ddi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_ddi.Location = new System.Drawing.Point(30, 259);
            this.lbl_ddi.Name = "lbl_ddi";
            this.lbl_ddi.Size = new System.Drawing.Size(40, 24);
            this.lbl_ddi.TabIndex = 92;
            this.lbl_ddi.Text = "DDI";
            // 
            // CadastroPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.lbl_ddi);
            this.Controls.Add(this.lbl_sigla);
            this.Controls.Add(this.lbl_pais);
            this.Controls.Add(this.Txt_ddi);
            this.Controls.Add(this.Txt_sigla);
            this.Controls.Add(this.Txt_pais);
            this.Name = "CadastroPais";
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.Txt_pais, 0);
            this.Controls.SetChildIndex(this.Txt_sigla, 0);
            this.Controls.SetChildIndex(this.Txt_ddi, 0);
            this.Controls.SetChildIndex(this.lbl_pais, 0);
            this.Controls.SetChildIndex(this.lbl_sigla, 0);
            this.Controls.SetChildIndex(this.lbl_ddi, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Txt_pais;
        private System.Windows.Forms.RichTextBox Txt_sigla;
        private System.Windows.Forms.RichTextBox Txt_ddi;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_sigla;
        private System.Windows.Forms.Label lbl_ddi;
    }
}
