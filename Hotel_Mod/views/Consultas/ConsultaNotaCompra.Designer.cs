namespace Hotel_Mod.views.Consultas
{
    partial class ConsultaNotaCompra
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
            this.dataGridViewNFCompra = new System.Windows.Forms.DataGridView();
            this.numeroNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataChegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNFCompra)).BeginInit();
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(780, 12);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            // 
            // dataGridViewNFCompra
            // 
            this.dataGridViewNFCompra.AllowUserToAddRows = false;
            this.dataGridViewNFCompra.AllowUserToDeleteRows = false;
            this.dataGridViewNFCompra.AllowUserToResizeColumns = false;
            this.dataGridViewNFCompra.AllowUserToResizeRows = false;
            this.dataGridViewNFCompra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dataGridViewNFCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNFCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroNota,
            this.modelo,
            this.serie,
            this.idFornecedor,
            this.fornecedor,
            this.dataChegada,
            this.dataCancelamento});
            this.dataGridViewNFCompra.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewNFCompra.Location = new System.Drawing.Point(12, 69);
            this.dataGridViewNFCompra.Name = "dataGridViewNFCompra";
            this.dataGridViewNFCompra.ReadOnly = true;
            this.dataGridViewNFCompra.Size = new System.Drawing.Size(971, 403);
            this.dataGridViewNFCompra.TabIndex = 69;
            // 
            // numeroNota
            // 
            this.numeroNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroNota.HeaderText = "Número";
            this.numeroNota.Name = "numeroNota";
            this.numeroNota.ReadOnly = true;
            // 
            // modelo
            // 
            this.modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            // 
            // serie
            // 
            this.serie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serie.HeaderText = "Série";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            // 
            // idFornecedor
            // 
            this.idFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idFornecedor.HeaderText = "Código Fornecedor";
            this.idFornecedor.Name = "idFornecedor";
            this.idFornecedor.ReadOnly = true;
            // 
            // fornecedor
            // 
            this.fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fornecedor.HeaderText = "Fornecedor";
            this.fornecedor.Name = "fornecedor";
            this.fornecedor.ReadOnly = true;
            // 
            // dataChegada
            // 
            this.dataChegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataChegada.HeaderText = "Data Chegada";
            this.dataChegada.Name = "dataChegada";
            this.dataChegada.ReadOnly = true;
            // 
            // dataCancelamento
            // 
            this.dataCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataCancelamento.HeaderText = "Data Cancelamento";
            this.dataCancelamento.Name = "dataCancelamento";
            this.dataCancelamento.ReadOnly = true;
            // 
            // ConsultaNotaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridViewNFCompra);
            this.Name = "ConsultaNotaCompra";
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridViewNFCompra, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNFCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNFCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataChegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCancelamento;
    }
}
