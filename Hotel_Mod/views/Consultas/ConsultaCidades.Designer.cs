namespace Hotel_Mod.views
{
    partial class ConsultaCidades
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
            this.DataGridViewCidades = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            // 
            // btn_incluir
            // 
            this.btn_incluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_incluir.FlatAppearance.BorderSize = 0;
            // 
            // btn_alterar
            // 
            this.btn_alterar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_alterar.FlatAppearance.BorderSize = 0;
            // 
            // btn_excluir
            // 
            this.btn_excluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            // 
            // DataGridViewCidades
            // 
            this.DataGridViewCidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.Cidade,
            this.DDD});
            this.DataGridViewCidades.Location = new System.Drawing.Point(12, 72);
            this.DataGridViewCidades.Name = "DataGridViewCidades";
            this.DataGridViewCidades.Size = new System.Drawing.Size(971, 379);
            this.DataGridViewCidades.TabIndex = 69;
            // 
            // Código
            // 
            this.Código.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            // 
            // Cidade
            // 
            this.Cidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            // 
            // DDD
            // 
            this.DDD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DDD.HeaderText = "DDD";
            this.DDD.Name = "DDD";
            // 
            // ConsultaCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.DataGridViewCidades);
            this.Name = "ConsultaCidades";
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.DataGridViewCidades, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewCidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDD;
    }
}
