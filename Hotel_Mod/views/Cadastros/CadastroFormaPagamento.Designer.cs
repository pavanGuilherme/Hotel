namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroFormaPagamento
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
            this.txt_forma_pagamento = new System.Windows.Forms.TextBox();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.lbl_Forma_Pagamento = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(596, 12);
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Location = new System.Drawing.Point(12, 12);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(16, 39);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(249, 374);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(253, 401);
            this.txt_dat_ult_alt.Text = "21/08/2024 21:09:50";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(8, 374);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(12, 401);
            this.txt_dat_cad.Text = "21/08/2024 21:09:50";
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(552, 401);
            this.btn_salvar.Size = new System.Drawing.Size(109, 30);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(678, 400);
            this.btn_sair.Size = new System.Drawing.Size(98, 30);
            // 
            // txt_forma_pagamento
            // 
            this.txt_forma_pagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_forma_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_forma_pagamento.Location = new System.Drawing.Point(16, 119);
            this.txt_forma_pagamento.Name = "txt_forma_pagamento";
            this.txt_forma_pagamento.Size = new System.Drawing.Size(343, 29);
            this.txt_forma_pagamento.TabIndex = 86;
            // 
            // lbl_Forma_Pagamento
            // 
            this.lbl_Forma_Pagamento.AutoSize = true;
            this.lbl_Forma_Pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_Forma_Pagamento.Location = new System.Drawing.Point(16, 92);
            this.lbl_Forma_Pagamento.Name = "lbl_Forma_Pagamento";
            this.lbl_Forma_Pagamento.Size = new System.Drawing.Size(205, 24);
            this.lbl_Forma_Pagamento.TabIndex = 87;
            this.lbl_Forma_Pagamento.Text = "Forma de Pagamento *";
            // 
            // CadastroFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(787, 444);
            this.Controls.Add(this.lbl_Forma_Pagamento);
            this.Controls.Add(this.txt_forma_pagamento);
            this.Name = "CadastroFormaPagamento";
            this.Text = "Cadastro Forma Pagamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CadastroFormaPagamento_FormClosed_1);
            this.Load += new System.EventHandler(this.CadastroFormaPagamento_Load_1);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_forma_pagamento, 0);
            this.Controls.SetChildIndex(this.lbl_Forma_Pagamento, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_forma_pagamento;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.Label lbl_Forma_Pagamento;
    }
}
