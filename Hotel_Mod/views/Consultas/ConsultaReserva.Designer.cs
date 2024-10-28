namespace Hotel_Mod.views.Consultas
{
    partial class ConsultaReserva
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
            this.dataGridViewReserva = new System.Windows.Forms.DataGridView();
            this.cod_reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.andar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva)).BeginInit();
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
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click_1);
            // 
            // dataGridViewReserva
            // 
            this.dataGridViewReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReserva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_reserva,
            this.nome,
            this.quarto,
            this.andar,
            this.check_in,
            this.check_out,
            this.telefone});
            this.dataGridViewReserva.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewReserva.Name = "dataGridViewReserva";
            this.dataGridViewReserva.Size = new System.Drawing.Size(971, 413);
            this.dataGridViewReserva.TabIndex = 69;
            // 
            // cod_reserva
            // 
            this.cod_reserva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cod_reserva.HeaderText = "Cód Reserva";
            this.cod_reserva.Name = "cod_reserva";
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            // 
            // quarto
            // 
            this.quarto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quarto.HeaderText = "Quarto";
            this.quarto.Name = "quarto";
            // 
            // andar
            // 
            this.andar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.andar.HeaderText = "Andar";
            this.andar.Name = "andar";
            // 
            // check_in
            // 
            this.check_in.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.check_in.HeaderText = "Data Check_in";
            this.check_in.Name = "check_in";
            // 
            // check_out
            // 
            this.check_out.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.check_out.HeaderText = "Data Check_out";
            this.check_out.Name = "check_out";
            // 
            // telefone
            // 
            this.telefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefone.HeaderText = "telefone";
            this.telefone.Name = "telefone";
            // 
            // ConsultaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridViewReserva);
            this.Name = "ConsultaReserva";
            this.Text = "Consulta Reserva";
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridViewReserva, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn quarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn andar;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone;
    }
}
