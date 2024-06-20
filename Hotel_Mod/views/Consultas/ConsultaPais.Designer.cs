namespace Hotel_Mod.views
{
    partial class ConsultaPais
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
            this.dataGridViewPais = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.País = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPais)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_buscainativos
            // 
            this.btn_buscainativos.Location = new System.Drawing.Point(583, 21);
            this.btn_buscainativos.TabStop = false;
            this.btn_buscainativos.CheckedChanged += new System.EventHandler(this.btn_buscainativos_CheckedChanged);
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(770, 12);
            // 
            // dataGridViewPais
            // 
            this.dataGridViewPais.AllowUserToOrderColumns = true;
            this.dataGridViewPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.País,
            this.Sigla,
            this.DDI});
            this.dataGridViewPais.Location = new System.Drawing.Point(13, 67);
            this.dataGridViewPais.Name = "dataGridViewPais";
            this.dataGridViewPais.Size = new System.Drawing.Size(970, 417);
            this.dataGridViewPais.TabIndex = 68;
            // 
            // Código
            // 
            this.Código.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            // 
            // País
            // 
            this.País.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.País.HeaderText = "País";
            this.País.Name = "País";
            // 
            // Sigla
            // 
            this.Sigla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sigla.HeaderText = "Sigla";
            this.Sigla.Name = "Sigla";
            // 
            // DDI
            // 
            this.DDI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DDI.HeaderText = "DDI";
            this.DDI.Name = "DDI";
            // 
            // ConsultaPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1005, 545);
            this.Controls.Add(this.dataGridViewPais);
            this.Name = "ConsultaPais";
            this.Text = "ConsultaPais";
            this.Load += new System.EventHandler(this.ConsultaPais_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.dataGridViewPais, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn País;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDI;
    }
}
