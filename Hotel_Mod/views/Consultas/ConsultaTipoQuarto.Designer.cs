namespace Hotel_Mod.views.Consultas
{
    partial class ConsultaTipoQuarto
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
            this.dataGridView_tipo_quarto = new System.Windows.Forms.DataGridView();
            this.tipo_quarto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_diaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidade_maxima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tipo_quarto)).BeginInit();
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
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // btn_buscainativos
            // 
            this.btn_buscainativos.CheckedChanged += new System.EventHandler(this.btn_buscainativos_CheckedChanged);
            // 
            // dataGridView_tipo_quarto
            // 
            this.dataGridView_tipo_quarto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_tipo_quarto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tipo_quarto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo_quarto_id,
            this.tipo,
            this.valor_diaria,
            this.capacidade_maxima,
            this.descricao});
            this.dataGridView_tipo_quarto.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_tipo_quarto.Location = new System.Drawing.Point(13, 81);
            this.dataGridView_tipo_quarto.Name = "dataGridView_tipo_quarto";
            this.dataGridView_tipo_quarto.Size = new System.Drawing.Size(970, 392);
            this.dataGridView_tipo_quarto.TabIndex = 70;
            // 
            // tipo_quarto_id
            // 
            this.tipo_quarto_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tipo_quarto_id.HeaderText = "Código";
            this.tipo_quarto_id.Name = "tipo_quarto_id";
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            // 
            // valor_diaria
            // 
            this.valor_diaria.HeaderText = "Valor da Diária";
            this.valor_diaria.Name = "valor_diaria";
            // 
            // capacidade_maxima
            // 
            this.capacidade_maxima.HeaderText = "Capacidade Máx";
            this.capacidade_maxima.Name = "capacidade_maxima";
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            // 
            // ConsultaTipoQuarto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridView_tipo_quarto);
            this.Name = "ConsultaTipoQuarto";
            this.Load += new System.EventHandler(this.ConsultaTipoQuarto_Load);
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.dataGridView_tipo_quarto, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tipo_quarto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_tipo_quarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_quarto_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_diaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidade_maxima;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
