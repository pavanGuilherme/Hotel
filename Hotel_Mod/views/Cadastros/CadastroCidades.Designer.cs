namespace Hotel_Mod.views
{
    partial class CadastroCidades
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
            this.txt_ddd = new System.Windows.Forms.RichTextBox();
            this.lbl_cidade = new System.Windows.Forms.Label();
            this.txt_cidade = new System.Windows.Forms.RichTextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cod_estado = new System.Windows.Forms.RichTextBox();
            this.txt_estado = new System.Windows.Forms.RichTextBox();
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
            this.txt_dat_ult_alt.Text = "17/06/2024 23:09:54";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Text = "17/06/2024 23:09:54";
            // 
            // lbl_ddd
            // 
            this.lbl_ddd.AutoSize = true;
            this.lbl_ddd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_ddd.Location = new System.Drawing.Point(299, 121);
            this.lbl_ddd.Name = "lbl_ddd";
            this.lbl_ddd.Size = new System.Drawing.Size(49, 24);
            this.lbl_ddd.TabIndex = 91;
            this.lbl_ddd.Text = "DDD";
            // 
            // txt_ddd
            // 
            this.txt_ddd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_ddd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_ddd.Location = new System.Drawing.Point(303, 148);
            this.txt_ddd.Name = "txt_ddd";
            this.txt_ddd.Size = new System.Drawing.Size(137, 31);
            this.txt_ddd.TabIndex = 90;
            this.txt_ddd.Text = "";
            // 
            // lbl_cidade
            // 
            this.lbl_cidade.AutoSize = true;
            this.lbl_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cidade.Location = new System.Drawing.Point(32, 121);
            this.lbl_cidade.Name = "lbl_cidade";
            this.lbl_cidade.Size = new System.Drawing.Size(70, 24);
            this.lbl_cidade.TabIndex = 89;
            this.lbl_cidade.Text = "Cidade";
            // 
            // txt_cidade
            // 
            this.txt_cidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cidade.Location = new System.Drawing.Point(32, 148);
            this.txt_cidade.Name = "txt_cidade";
            this.txt_cidade.Size = new System.Drawing.Size(211, 31);
            this.txt_cidade.TabIndex = 88;
            this.txt_cidade.Text = "";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btn_search.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_search.Location = new System.Drawing.Point(189, 249);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(56, 31);
            this.btn_search.TabIndex = 101;
            this.btn_search.Text = "Search";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(310, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(33, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 99;
            this.label1.Text = "Código do Estado";
            // 
            // txt_cod_estado
            // 
            this.txt_cod_estado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_estado.Location = new System.Drawing.Point(36, 249);
            this.txt_cod_estado.Name = "txt_cod_estado";
            this.txt_cod_estado.Size = new System.Drawing.Size(147, 31);
            this.txt_cod_estado.TabIndex = 98;
            this.txt_cod_estado.Text = "";
            this.txt_cod_estado.Leave += new System.EventHandler(this.txt_cod_estado_Leave);
            // 
            // txt_estado
            // 
            this.txt_estado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_estado.Location = new System.Drawing.Point(309, 249);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(211, 31);
            this.txt_estado.TabIndex = 97;
            this.txt_estado.Text = "";
            // 
            // CadastroCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cod_estado);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.lbl_ddd);
            this.Controls.Add(this.txt_ddd);
            this.Controls.Add(this.lbl_cidade);
            this.Controls.Add(this.txt_cidade);
            this.Name = "CadastroCidades";
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_cidade, 0);
            this.Controls.SetChildIndex(this.lbl_cidade, 0);
            this.Controls.SetChildIndex(this.txt_ddd, 0);
            this.Controls.SetChildIndex(this.lbl_ddd, 0);
            this.Controls.SetChildIndex(this.txt_estado, 0);
            this.Controls.SetChildIndex(this.txt_cod_estado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btn_search, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ddd;
        private System.Windows.Forms.RichTextBox txt_ddd;
        private System.Windows.Forms.Label lbl_cidade;
        private System.Windows.Forms.RichTextBox txt_cidade;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_cod_estado;
        private System.Windows.Forms.RichTextBox txt_estado;
    }
}
