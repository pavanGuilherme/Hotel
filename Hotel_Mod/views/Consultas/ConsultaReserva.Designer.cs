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
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoQuarto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.andar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_reserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_checkin = new System.Windows.Forms.Button();
            this.btn_cancelar_reserva = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva)).BeginInit();
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
            this.btn_sair.Location = new System.Drawing.Point(873, 489);
            // 
            // btn_incluir
            // 
            this.btn_incluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_incluir.FlatAppearance.BorderSize = 0;
            this.btn_incluir.Location = new System.Drawing.Point(525, 489);
            // 
            // btn_alterar
            // 
            this.btn_alterar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_alterar.FlatAppearance.BorderSize = 0;
            this.btn_alterar.Location = new System.Drawing.Point(641, 489);
            // 
            // btn_excluir
            // 
            this.btn_excluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.Location = new System.Drawing.Point(757, 489);
            // 
            // dataGridViewReserva
            // 
            this.dataGridViewReserva.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReserva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.TipoQuarto_id,
            this.nome,
            this.quarto,
            this.andar,
            this.checkin,
            this.checkout,
            this.status_reserva,
            this.telefone});
            this.dataGridViewReserva.GridColor = System.Drawing.Color.Honeydew;
            this.dataGridViewReserva.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewReserva.Name = "dataGridViewReserva";
            this.dataGridViewReserva.Size = new System.Drawing.Size(971, 413);
            this.dataGridViewReserva.TabIndex = 69;
            this.dataGridViewReserva.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReserva_CellEnter);
            this.dataGridViewReserva.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.PintarReservasComCheckin);
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codigo.HeaderText = "Cód Reserva";
            this.codigo.Name = "codigo";
            // 
            // TipoQuarto_id
            // 
            this.TipoQuarto_id.HeaderText = "Tipo Quarto ID";
            this.TipoQuarto_id.Name = "TipoQuarto_id";
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
            // checkin
            // 
            this.checkin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.checkin.HeaderText = "Checkin";
            this.checkin.Name = "checkin";
            // 
            // checkout
            // 
            this.checkout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.checkout.HeaderText = "Checkout";
            this.checkout.Name = "checkout";
            // 
            // status_reserva
            // 
            this.status_reserva.HeaderText = "Status";
            this.status_reserva.Name = "status_reserva";
            // 
            // telefone
            // 
            this.telefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.telefone.HeaderText = "telefone";
            this.telefone.Name = "telefone";
            // 
            // btn_checkin
            // 
            this.btn_checkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_checkin.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_checkin.Location = new System.Drawing.Point(12, 487);
            this.btn_checkin.Name = "btn_checkin";
            this.btn_checkin.Size = new System.Drawing.Size(143, 36);
            this.btn_checkin.TabIndex = 334;
            this.btn_checkin.Text = "Checkin";
            this.btn_checkin.UseVisualStyleBackColor = false;
            this.btn_checkin.Click += new System.EventHandler(this.btn_checkin_Click);
            // 
            // btn_cancelar_reserva
            // 
            this.btn_cancelar_reserva.BackColor = System.Drawing.Color.Red;
            this.btn_cancelar_reserva.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancelar_reserva.Location = new System.Drawing.Point(161, 487);
            this.btn_cancelar_reserva.Name = "btn_cancelar_reserva";
            this.btn_cancelar_reserva.Size = new System.Drawing.Size(151, 36);
            this.btn_cancelar_reserva.TabIndex = 335;
            this.btn_cancelar_reserva.Text = "Cancelar Reserva";
            this.btn_cancelar_reserva.UseVisualStyleBackColor = false;
            this.btn_cancelar_reserva.Click += new System.EventHandler(this.btn_cancelar_reserva_Click);
            // 
            // ConsultaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.btn_cancelar_reserva);
            this.Controls.Add(this.btn_checkin);
            this.Controls.Add(this.dataGridViewReserva);
            this.Name = "ConsultaReserva";
            this.Text = "Consulta Reserva";
            this.Load += new System.EventHandler(this.ConsultaReserva_Load);
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridViewReserva, 0);
            this.Controls.SetChildIndex(this.btn_checkin, 0);
            this.Controls.SetChildIndex(this.btn_cancelar_reserva, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReserva;
        private System.Windows.Forms.Button btn_checkin;
        private System.Windows.Forms.Button btn_cancelar_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoQuarto_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn quarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn andar;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkin;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkout;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_reserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone;
    }
}
