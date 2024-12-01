namespace Hotel_Mod.views.Consultas
{
    partial class ConsultaContasReceber
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
            this.dataGridView_contas_receber = new System.Windows.Forms.DataGridView();
            this.reserva_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_emissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_recebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_contas_receber)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            // 
            // btn_buscainativos
            // 
            this.btn_buscainativos.Size = new System.Drawing.Size(137, 24);
            this.btn_buscainativos.Text = "Buscar Inativos";
            // 
            // btn_incluir
            // 
            this.btn_incluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_incluir.FlatAppearance.BorderSize = 0;
            this.btn_incluir.Location = new System.Drawing.Point(641, 499);
            // 
            // btn_alterar
            // 
            this.btn_alterar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_alterar.FlatAppearance.BorderSize = 0;
            this.btn_alterar.Location = new System.Drawing.Point(757, 499);
            // 
            // btn_excluir
            // 
            this.btn_excluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.Location = new System.Drawing.Point(13, 499);
            this.btn_excluir.Visible = false;
            // 
            // dataGridView_contas_receber
            // 
            this.dataGridView_contas_receber.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_contas_receber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_contas_receber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reserva_ID,
            this.num_parcela,
            this.valor_parcela,
            this.cliente_ID,
            this.data_emissao,
            this.data_vencimento,
            this.data_recebimento});
            this.dataGridView_contas_receber.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView_contas_receber.Location = new System.Drawing.Point(13, 63);
            this.dataGridView_contas_receber.Name = "dataGridView_contas_receber";
            this.dataGridView_contas_receber.Size = new System.Drawing.Size(970, 414);
            this.dataGridView_contas_receber.TabIndex = 70;
            // 
            // reserva_ID
            // 
            this.reserva_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reserva_ID.HeaderText = "Reserva Id";
            this.reserva_ID.Name = "reserva_ID";
            // 
            // num_parcela
            // 
            this.num_parcela.HeaderText = "Num. Parcela";
            this.num_parcela.Name = "num_parcela";
            // 
            // valor_parcela
            // 
            this.valor_parcela.HeaderText = "Valor Parcela";
            this.valor_parcela.Name = "valor_parcela";
            // 
            // cliente_ID
            // 
            this.cliente_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente_ID.HeaderText = "Cliente Id";
            this.cliente_ID.Name = "cliente_ID";
            // 
            // data_emissao
            // 
            this.data_emissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_emissao.HeaderText = "Data Emissao";
            this.data_emissao.Name = "data_emissao";
            // 
            // data_vencimento
            // 
            this.data_vencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_vencimento.HeaderText = "Data de Vencimento";
            this.data_vencimento.Name = "data_vencimento";
            // 
            // data_recebimento
            // 
            this.data_recebimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_recebimento.HeaderText = "Data de Recebimento";
            this.data_recebimento.Name = "data_recebimento";
            // 
            // ConsultaContasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridView_contas_receber);
            this.Name = "ConsultaContasReceber";
            this.Text = "Consulta Contas a Receber";
            this.Load += new System.EventHandler(this.ConsultaContasReceber_Load);
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.dataGridView_contas_receber, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_contas_receber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_contas_receber;
        private System.Windows.Forms.DataGridViewTextBoxColumn reserva_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_emissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_recebimento;
    }
}
