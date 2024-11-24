namespace Hotel_Mod.views.Consultas
{
    partial class ConsultaOcupacao
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_preparacao = new System.Windows.Forms.CheckBox();
            this.check_reservado = new System.Windows.Forms.CheckBox();
            this.check_livre = new System.Windows.Forms.CheckBox();
            this.check_ocupado = new System.Windows.Forms.CheckBox();
            this.comboBoxAndar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelQuartos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btn_checkout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanelQuartos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            this.btn_pesquisar.Location = new System.Drawing.Point(299, 33);
            this.btn_pesquisar.Size = new System.Drawing.Size(107, 30);
            this.btn_pesquisar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // txt_pesquisar
            // 
            this.txt_pesquisar.Location = new System.Drawing.Point(25, 34);
            this.txt_pesquisar.Size = new System.Drawing.Size(268, 31);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(512, 516);
            this.groupBox2.Size = new System.Drawing.Size(137, 45);
            this.groupBox2.Visible = false;
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(1036, 520);
            this.btn_sair.Size = new System.Drawing.Size(105, 34);
            // 
            // btn_buscainativos
            // 
            this.btn_buscainativos.Location = new System.Drawing.Point(1009, 44);
            // 
            // btn_incluir
            // 
            this.btn_incluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_incluir.FlatAppearance.BorderSize = 0;
            this.btn_incluir.Location = new System.Drawing.Point(703, 520);
            this.btn_incluir.Size = new System.Drawing.Size(105, 34);
            // 
            // btn_alterar
            // 
            this.btn_alterar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_alterar.FlatAppearance.BorderSize = 0;
            this.btn_alterar.Location = new System.Drawing.Point(814, 520);
            this.btn_alterar.Size = new System.Drawing.Size(105, 34);
            // 
            // btn_excluir
            // 
            this.btn_excluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.Location = new System.Drawing.Point(925, 520);
            this.btn_excluir.Size = new System.Drawing.Size(105, 34);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_preparacao);
            this.groupBox1.Controls.Add(this.check_reservado);
            this.groupBox1.Controls.Add(this.check_livre);
            this.groupBox1.Controls.Add(this.check_ocupado);
            this.groupBox1.Location = new System.Drawing.Point(425, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 45);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // check_preparacao
            // 
            this.check_preparacao.AutoSize = true;
            this.check_preparacao.Location = new System.Drawing.Point(260, 15);
            this.check_preparacao.Name = "check_preparacao";
            this.check_preparacao.Size = new System.Drawing.Size(98, 17);
            this.check_preparacao.TabIndex = 74;
            this.check_preparacao.Text = "Em preparação";
            this.check_preparacao.UseVisualStyleBackColor = true;
            // 
            // check_reservado
            // 
            this.check_reservado.AutoSize = true;
            this.check_reservado.Location = new System.Drawing.Point(159, 15);
            this.check_reservado.Name = "check_reservado";
            this.check_reservado.Size = new System.Drawing.Size(78, 17);
            this.check_reservado.TabIndex = 73;
            this.check_reservado.Text = "Reservado";
            this.check_reservado.UseVisualStyleBackColor = true;
            // 
            // check_livre
            // 
            this.check_livre.AutoSize = true;
            this.check_livre.Location = new System.Drawing.Point(6, 15);
            this.check_livre.Name = "check_livre";
            this.check_livre.Size = new System.Drawing.Size(49, 17);
            this.check_livre.TabIndex = 71;
            this.check_livre.Text = "Livre";
            this.check_livre.UseVisualStyleBackColor = true;
            // 
            // check_ocupado
            // 
            this.check_ocupado.AutoSize = true;
            this.check_ocupado.Location = new System.Drawing.Point(72, 15);
            this.check_ocupado.Name = "check_ocupado";
            this.check_ocupado.Size = new System.Drawing.Size(70, 17);
            this.check_ocupado.TabIndex = 72;
            this.check_ocupado.Text = "Ocupado";
            this.check_ocupado.UseVisualStyleBackColor = true;
            // 
            // comboBoxAndar
            // 
            this.comboBoxAndar.FormattingEnabled = true;
            this.comboBoxAndar.Location = new System.Drawing.Point(896, 44);
            this.comboBoxAndar.Name = "comboBoxAndar";
            this.comboBoxAndar.Size = new System.Drawing.Size(85, 21);
            this.comboBoxAndar.TabIndex = 71;
            this.comboBoxAndar.SelectedIndexChanged += new System.EventHandler(this.comboBoxAndar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(896, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Andar";
            // 
            // flowLayoutPanelQuartos
            // 
            this.flowLayoutPanelQuartos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelQuartos.Controls.Add(this.panel3);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel2);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel1);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel4);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel5);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel7);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel6);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel8);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel9);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel10);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel11);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel13);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel12);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel14);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel15);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel16);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel17);
            this.flowLayoutPanelQuartos.Controls.Add(this.panel18);
            this.flowLayoutPanelQuartos.Location = new System.Drawing.Point(25, 74);
            this.flowLayoutPanelQuartos.Name = "flowLayoutPanelQuartos";
            this.flowLayoutPanelQuartos.Size = new System.Drawing.Size(1116, 435);
            this.flowLayoutPanelQuartos.TabIndex = 75;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(179, 137);
            this.panel3.TabIndex = 2;
            this.panel3.Tag = "quarto_ID";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(188, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 137);
            this.panel2.TabIndex = 1;
            this.panel2.Tag = "quarto_ID";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(373, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 137);
            this.panel1.TabIndex = 2;
            this.panel1.Tag = "quarto_ID";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(558, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 137);
            this.panel4.TabIndex = 3;
            this.panel4.Tag = "quarto_ID";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(743, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(179, 137);
            this.panel5.TabIndex = 2;
            this.panel5.Tag = "quarto_ID";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(928, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(179, 137);
            this.panel7.TabIndex = 2;
            this.panel7.Tag = "quarto_ID";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(3, 146);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(179, 137);
            this.panel6.TabIndex = 2;
            this.panel6.Tag = "quarto_ID";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(188, 146);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(179, 137);
            this.panel8.TabIndex = 4;
            this.panel8.Tag = "quarto_ID";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(373, 146);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(179, 137);
            this.panel9.TabIndex = 5;
            this.panel9.Tag = "quarto_ID";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(558, 146);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(179, 137);
            this.panel10.TabIndex = 5;
            this.panel10.Tag = "quarto_ID";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Location = new System.Drawing.Point(743, 146);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(179, 137);
            this.panel11.TabIndex = 5;
            this.panel11.Tag = "quarto_ID";
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Location = new System.Drawing.Point(928, 146);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(179, 137);
            this.panel13.TabIndex = 5;
            this.panel13.Tag = "quarto_ID";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Location = new System.Drawing.Point(3, 289);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(179, 137);
            this.panel12.TabIndex = 5;
            this.panel12.Tag = "quarto_ID";
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Location = new System.Drawing.Point(188, 289);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(179, 137);
            this.panel14.TabIndex = 6;
            this.panel14.Tag = "quarto_ID";
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Location = new System.Drawing.Point(373, 289);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(179, 137);
            this.panel15.TabIndex = 5;
            this.panel15.Tag = "quarto_ID";
            // 
            // panel16
            // 
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Location = new System.Drawing.Point(558, 289);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(179, 137);
            this.panel16.TabIndex = 5;
            this.panel16.Tag = "quarto_ID";
            // 
            // panel17
            // 
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Location = new System.Drawing.Point(743, 289);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(179, 137);
            this.panel17.TabIndex = 5;
            this.panel17.Tag = "quarto_ID";
            // 
            // panel18
            // 
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Location = new System.Drawing.Point(928, 289);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(179, 137);
            this.panel18.TabIndex = 5;
            this.panel18.Tag = "quarto_ID";
            // 
            // btn_checkout
            // 
            this.btn_checkout.BackColor = System.Drawing.Color.Red;
            this.btn_checkout.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_checkout.Location = new System.Drawing.Point(25, 515);
            this.btn_checkout.Name = "btn_checkout";
            this.btn_checkout.Size = new System.Drawing.Size(122, 36);
            this.btn_checkout.TabIndex = 336;
            this.btn_checkout.Text = "Checkout";
            this.btn_checkout.UseVisualStyleBackColor = false;
            this.btn_checkout.Click += new System.EventHandler(this.btn_checkout_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(153, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 36);
            this.button1.TabIndex = 337;
            this.button1.Text = "Limpo";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ConsultaOcupacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1170, 608);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_checkout);
            this.Controls.Add(this.flowLayoutPanelQuartos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAndar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultaOcupacao";
            this.Text = "Consulta Ocupações";
            this.Load += new System.EventHandler(this.newConsultaQuartos_Load_1);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.comboBoxAndar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanelQuartos, 0);
            this.Controls.SetChildIndex(this.txt_pesquisar, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_excluir, 0);
            this.Controls.SetChildIndex(this.btn_alterar, 0);
            this.Controls.SetChildIndex(this.btn_incluir, 0);
            this.Controls.SetChildIndex(this.btn_pesquisar, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btn_buscainativos, 0);
            this.Controls.SetChildIndex(this.btn_checkout, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanelQuartos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox check_reservado;
        private System.Windows.Forms.CheckBox check_livre;
        private System.Windows.Forms.CheckBox check_ocupado;
        private System.Windows.Forms.ComboBox comboBoxAndar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQuartos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.CheckBox check_preparacao;
        private System.Windows.Forms.Button btn_checkout;
        private System.Windows.Forms.Button button1;
    }
}
