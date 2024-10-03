namespace Hotel_Mod.views
{
    partial class ConsultaFornecedor
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
            this.dataGridViewFornecedor = new System.Windows.Forms.DataGridView();
            this.ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpf_cnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_razao_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFornecedor)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscainativos
            // 
            this.btn_buscainativos.CheckedChanged += new System.EventHandler(this.btn_buscainativos_CheckedChanged_1);
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
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // dataGridViewFornecedor
            // 
            this.dataGridViewFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.fornecedor_razao_social,
            this.cpf_cnpj,
            this.ativo});
            this.dataGridViewFornecedor.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewFornecedor.Name = "dataGridViewFornecedor";
            this.dataGridViewFornecedor.Size = new System.Drawing.Size(971, 397);
            this.dataGridViewFornecedor.TabIndex = 69;
            // 
            // ativo
            // 
            this.ativo.HeaderText = "ativo";
            this.ativo.Name = "ativo";
            // 
            // cpf_cnpj
            // 
            this.cpf_cnpj.HeaderText = "cpf/cnpj";
            this.cpf_cnpj.Name = "cpf_cnpj";
            // 
            // fornecedor_razao_social
            // 
            this.fornecedor_razao_social.HeaderText = "fornecedor";
            this.fornecedor_razao_social.Name = "fornecedor_razao_social";
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            // 
            // ConsultaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridViewFornecedor);
            this.Name = "ConsultaFornecedor";
            this.Text = "Consulta Fornecedor";
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridViewFornecedor, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFornecedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_razao_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpf_cnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativo;
    }
}
