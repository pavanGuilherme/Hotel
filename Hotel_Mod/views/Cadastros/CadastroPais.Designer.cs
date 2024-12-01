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
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_sigla = new System.Windows.Forms.Label();
            this.lbl_ddi = new System.Windows.Forms.Label();
            this.txt_pais = new System.Windows.Forms.TextBox();
            this.txt_ddi = new System.Windows.Forms.TextBox();
            this.txt_sigla = new System.Windows.Forms.TextBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(398, 23);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(31, 39);
            this.txt_codigo.Size = new System.Drawing.Size(106, 31);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(196, 513);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(200, 540);
            this.txt_dat_ult_alt.Size = new System.Drawing.Size(192, 31);
            this.txt_dat_ult_alt.Text = "19/06/2024 08:18:08";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(12, 513);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(12, 539);
            this.txt_dat_cad.Size = new System.Drawing.Size(178, 31);
            this.txt_dat_cad.Text = "19/06/2024 08:18:08";
            // 
            // btn_salvar
            // 
            this.btn_salvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(420, 539);
            this.btn_salvar.Size = new System.Drawing.Size(103, 30);
            // 
            // btn_sair
            // 
            this.btn_sair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(540, 539);
            this.btn_sair.Size = new System.Drawing.Size(94, 30);
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
            // txt_pais
            // 
            this.txt_pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_pais.Location = new System.Drawing.Point(31, 137);
            this.txt_pais.Name = "txt_pais";
            this.txt_pais.Size = new System.Drawing.Size(214, 29);
            this.txt_pais.TabIndex = 135;
            // 
            // txt_ddi
            // 
            this.txt_ddi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ddi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_ddi.Location = new System.Drawing.Point(31, 284);
            this.txt_ddi.Name = "txt_ddi";
            this.txt_ddi.Size = new System.Drawing.Size(138, 29);
            this.txt_ddi.TabIndex = 137;
            this.txt_ddi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ddi_KeyPress);
            // 
            // txt_sigla
            // 
            this.txt_sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_sigla.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_sigla.Location = new System.Drawing.Point(31, 209);
            this.txt_sigla.Name = "txt_sigla";
            this.txt_sigla.Size = new System.Drawing.Size(138, 29);
            this.txt_sigla.TabIndex = 136;
            this.txt_sigla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_sigla_KeyPress);
            // 
            // CadastroPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(646, 583);
            this.Controls.Add(this.txt_ddi);
            this.Controls.Add(this.txt_pais);
            this.Controls.Add(this.txt_sigla);
            this.Controls.Add(this.lbl_ddi);
            this.Controls.Add(this.lbl_sigla);
            this.Controls.Add(this.lbl_pais);
            this.Name = "CadastroPais";
            this.Text = "Cadastro Paises";
            this.Load += new System.EventHandler(this.CadastroPais_Load);
            this.Controls.SetChildIndex(this.lbl_pais, 0);
            this.Controls.SetChildIndex(this.lbl_sigla, 0);
            this.Controls.SetChildIndex(this.lbl_ddi, 0);
            this.Controls.SetChildIndex(this.txt_sigla, 0);
            this.Controls.SetChildIndex(this.txt_pais, 0);
            this.Controls.SetChildIndex(this.txt_ddi, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_sigla;
        private System.Windows.Forms.Label lbl_ddi;
        private System.Windows.Forms.TextBox txt_pais;
        private System.Windows.Forms.TextBox txt_ddi;
        private System.Windows.Forms.TextBox txt_sigla;
    }
}
