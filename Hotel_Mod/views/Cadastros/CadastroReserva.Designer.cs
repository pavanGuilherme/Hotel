namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroReserva
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
            this.lbl_nome = new System.Windows.Forms.Label();
            this.txt_nome_cliente = new System.Windows.Forms.RichTextBox();
            this.lbl_cod_cliente = new System.Windows.Forms.Label();
            this.txt_cod_cliente = new System.Windows.Forms.RichTextBox();
            this.btn_busca_cod_cliente = new System.Windows.Forms.Button();
            this.txt_cpf = new System.Windows.Forms.MaskedTextBox();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.txt_andar = new System.Windows.Forms.RichTextBox();
            this.lbl_andar = new System.Windows.Forms.Label();
            this.txt_numero = new System.Windows.Forms.RichTextBox();
            this.lbl_numero_quarto = new System.Windows.Forms.Label();
            this.txt_cod_quarto = new System.Windows.Forms.RichTextBox();
            this.lbl_quarto_id = new System.Windows.Forms.Label();
            this.btn_busca_cod_quarto = new System.Windows.Forms.Button();
            this.txt_valor_diaria = new System.Windows.Forms.RichTextBox();
            this.lbl_vlr_diaria = new System.Windows.Forms.Label();
            this.lbl_checkout = new System.Windows.Forms.Label();
            this.lbl_checkin = new System.Windows.Forms.Label();
            this.dtp_checkin = new System.Windows.Forms.DateTimePicker();
            this.dtp_checkout = new System.Windows.Forms.DateTimePicker();
            this.btn_cancelar_reserva = new System.Windows.Forms.Button();
            this.lbl_data_cancelamento = new System.Windows.Forms.Label();
            this.lbl_cancelada = new System.Windows.Forms.Label();
            this.txt_valor_total = new System.Windows.Forms.RichTextBox();
            this.lbl_valor_total = new System.Windows.Forms.Label();
            this.txt_num_dias = new System.Windows.Forms.RichTextBox();
            this.lbl_num_dias = new System.Windows.Forms.Label();
            this.check_pago = new System.Windows.Forms.CheckBox();
            this.check_n_pago = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_telefone = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView_parcelas = new System.Windows.Forms.DataGridView();
            this.numeroParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorParcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_add_cond_pag = new System.Windows.Forms.Button();
            this.btn_busca_cond_pagamento = new System.Windows.Forms.Button();
            this.lbl_cod_cond_pagamento = new System.Windows.Forms.Label();
            this.txt_cod_cond_pagamento = new System.Windows.Forms.RichTextBox();
            this.lbl_cond_pagamento = new System.Windows.Forms.Label();
            this.txt_cond_pagamento = new System.Windows.Forms.RichTextBox();
            this.lbl_observacao = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_hospede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hospede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.txt_data_cancelamento = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cod_hospede = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_excluir_cond_pagamento = new System.Windows.Forms.Button();
            this.btn_excluir_hospede = new System.Windows.Forms.Button();
            this.txt_observacao = new System.Windows.Forms.RichTextBox();
            this.status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(987, 12);
            this.status.Size = new System.Drawing.Size(162, 60);
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Location = new System.Drawing.Point(8, 9);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(12, 33);
            this.txt_codigo.Size = new System.Drawing.Size(79, 31);
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(923, 734);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(1039, 734);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(227, 706);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(231, 733);
            this.txt_dat_ult_alt.Text = "04/10/2024 10:18:51";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(10, 706);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(14, 733);
            this.txt_dat_cad.Text = "04/10/2024 10:18:51";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_nome.Location = new System.Drawing.Point(263, 3);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(62, 24);
            this.lbl_nome.TabIndex = 111;
            this.lbl_nome.Text = "Nome";
            // 
            // txt_nome_cliente
            // 
            this.txt_nome_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_nome_cliente.Enabled = false;
            this.txt_nome_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_nome_cliente.Location = new System.Drawing.Point(265, 30);
            this.txt_nome_cliente.Name = "txt_nome_cliente";
            this.txt_nome_cliente.Size = new System.Drawing.Size(350, 31);
            this.txt_nome_cliente.TabIndex = 110;
            this.txt_nome_cliente.Text = "";
            // 
            // lbl_cod_cliente
            // 
            this.lbl_cod_cliente.AutoSize = true;
            this.lbl_cod_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cod_cliente.Location = new System.Drawing.Point(125, 4);
            this.lbl_cod_cliente.Name = "lbl_cod_cliente";
            this.lbl_cod_cliente.Size = new System.Drawing.Size(120, 24);
            this.lbl_cod_cliente.TabIndex = 113;
            this.lbl_cod_cliente.Text = "Cód Cliente *";
            // 
            // txt_cod_cliente
            // 
            this.txt_cod_cliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_cliente.Enabled = false;
            this.txt_cod_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_cliente.Location = new System.Drawing.Point(129, 31);
            this.txt_cod_cliente.Name = "txt_cod_cliente";
            this.txt_cod_cliente.Size = new System.Drawing.Size(82, 31);
            this.txt_cod_cliente.TabIndex = 112;
            this.txt_cod_cliente.Text = "";
            // 
            // btn_busca_cod_cliente
            // 
            this.btn_busca_cod_cliente.Location = new System.Drawing.Point(213, 33);
            this.btn_busca_cod_cliente.Name = "btn_busca_cod_cliente";
            this.btn_busca_cod_cliente.Size = new System.Drawing.Size(48, 29);
            this.btn_busca_cod_cliente.TabIndex = 187;
            this.btn_busca_cod_cliente.Text = "search";
            this.btn_busca_cod_cliente.UseVisualStyleBackColor = true;
            this.btn_busca_cod_cliente.Click += new System.EventHandler(this.btn_busca_cod_cliente_Click);
            // 
            // txt_cpf
            // 
            this.txt_cpf.Enabled = false;
            this.txt_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(621, 30);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(127, 29);
            this.txt_cpf.TabIndex = 205;
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cpf.Location = new System.Drawing.Point(617, 8);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(47, 24);
            this.lbl_cpf.TabIndex = 204;
            this.lbl_cpf.Text = "CPF";
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(780, 3);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(159, 24);
            this.lbl_telefone.TabIndex = 207;
            this.lbl_telefone.Text = "Telefone / Celular";
            // 
            // txt_andar
            // 
            this.txt_andar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_andar.Enabled = false;
            this.txt_andar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_andar.Location = new System.Drawing.Point(294, 151);
            this.txt_andar.Name = "txt_andar";
            this.txt_andar.Size = new System.Drawing.Size(93, 31);
            this.txt_andar.TabIndex = 211;
            this.txt_andar.Text = "";
            // 
            // lbl_andar
            // 
            this.lbl_andar.AutoSize = true;
            this.lbl_andar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_andar.Location = new System.Drawing.Point(290, 128);
            this.lbl_andar.Name = "lbl_andar";
            this.lbl_andar.Size = new System.Drawing.Size(61, 24);
            this.lbl_andar.TabIndex = 210;
            this.lbl_andar.Text = "Andar";
            // 
            // txt_numero
            // 
            this.txt_numero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_numero.Enabled = false;
            this.txt_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_numero.Location = new System.Drawing.Point(153, 151);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(107, 31);
            this.txt_numero.TabIndex = 209;
            this.txt_numero.Text = "";
            // 
            // lbl_numero_quarto
            // 
            this.lbl_numero_quarto.AutoSize = true;
            this.lbl_numero_quarto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_numero_quarto.Location = new System.Drawing.Point(149, 124);
            this.lbl_numero_quarto.Name = "lbl_numero_quarto";
            this.lbl_numero_quarto.Size = new System.Drawing.Size(113, 24);
            this.lbl_numero_quarto.TabIndex = 208;
            this.lbl_numero_quarto.Text = "Num Quarto";
            // 
            // txt_cod_quarto
            // 
            this.txt_cod_quarto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_quarto.Enabled = false;
            this.txt_cod_quarto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_quarto.Location = new System.Drawing.Point(13, 154);
            this.txt_cod_quarto.Name = "txt_cod_quarto";
            this.txt_cod_quarto.Size = new System.Drawing.Size(79, 31);
            this.txt_cod_quarto.TabIndex = 213;
            this.txt_cod_quarto.Text = "";
            // 
            // lbl_quarto_id
            // 
            this.lbl_quarto_id.AutoSize = true;
            this.lbl_quarto_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_quarto_id.Location = new System.Drawing.Point(9, 128);
            this.lbl_quarto_id.Name = "lbl_quarto_id";
            this.lbl_quarto_id.Size = new System.Drawing.Size(107, 24);
            this.lbl_quarto_id.TabIndex = 212;
            this.lbl_quarto_id.Text = "Cód Quarto";
            // 
            // btn_busca_cod_quarto
            // 
            this.btn_busca_cod_quarto.Location = new System.Drawing.Point(96, 154);
            this.btn_busca_cod_quarto.Name = "btn_busca_cod_quarto";
            this.btn_busca_cod_quarto.Size = new System.Drawing.Size(51, 29);
            this.btn_busca_cod_quarto.TabIndex = 214;
            this.btn_busca_cod_quarto.Text = "search";
            this.btn_busca_cod_quarto.UseVisualStyleBackColor = true;
            this.btn_busca_cod_quarto.Click += new System.EventHandler(this.btn_busca_cod_quarto_Click);
            // 
            // txt_valor_diaria
            // 
            this.txt_valor_diaria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_valor_diaria.Enabled = false;
            this.txt_valor_diaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor_diaria.Location = new System.Drawing.Point(409, 152);
            this.txt_valor_diaria.Name = "txt_valor_diaria";
            this.txt_valor_diaria.Size = new System.Drawing.Size(128, 31);
            this.txt_valor_diaria.TabIndex = 216;
            this.txt_valor_diaria.Text = "";
            // 
            // lbl_vlr_diaria
            // 
            this.lbl_vlr_diaria.AutoSize = true;
            this.lbl_vlr_diaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_vlr_diaria.Location = new System.Drawing.Point(405, 128);
            this.lbl_vlr_diaria.Name = "lbl_vlr_diaria";
            this.lbl_vlr_diaria.Size = new System.Drawing.Size(106, 24);
            this.lbl_vlr_diaria.TabIndex = 215;
            this.lbl_vlr_diaria.Text = "Valor Diária";
            // 
            // lbl_checkout
            // 
            this.lbl_checkout.AutoSize = true;
            this.lbl_checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_checkout.Location = new System.Drawing.Point(251, 69);
            this.lbl_checkout.Name = "lbl_checkout";
            this.lbl_checkout.Size = new System.Drawing.Size(96, 24);
            this.lbl_checkout.TabIndex = 220;
            this.lbl_checkout.Text = "Check-out";
            // 
            // lbl_checkin
            // 
            this.lbl_checkin.AutoSize = true;
            this.lbl_checkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_checkin.Location = new System.Drawing.Point(12, 69);
            this.lbl_checkin.Name = "lbl_checkin";
            this.lbl_checkin.Size = new System.Drawing.Size(85, 24);
            this.lbl_checkin.TabIndex = 219;
            this.lbl_checkin.Text = "Check-in";
            // 
            // dtp_checkin
            // 
            this.dtp_checkin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_checkin.Location = new System.Drawing.Point(12, 96);
            this.dtp_checkin.Name = "dtp_checkin";
            this.dtp_checkin.Size = new System.Drawing.Size(233, 20);
            this.dtp_checkin.TabIndex = 221;
            this.dtp_checkin.ValueChanged += new System.EventHandler(this.dtp_checkin_ValueChanged_1);
            // 
            // dtp_checkout
            // 
            this.dtp_checkout.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_checkout.Location = new System.Drawing.Point(251, 96);
            this.dtp_checkout.Name = "dtp_checkout";
            this.dtp_checkout.Size = new System.Drawing.Size(216, 20);
            this.dtp_checkout.TabIndex = 222;
            this.dtp_checkout.ValueChanged += new System.EventHandler(this.dtp_checkout_ValueChanged);
            // 
            // btn_cancelar_reserva
            // 
            this.btn_cancelar_reserva.Location = new System.Drawing.Point(744, 733);
            this.btn_cancelar_reserva.Name = "btn_cancelar_reserva";
            this.btn_cancelar_reserva.Size = new System.Drawing.Size(160, 31);
            this.btn_cancelar_reserva.TabIndex = 243;
            this.btn_cancelar_reserva.Text = "Cancelar Reserva";
            this.btn_cancelar_reserva.UseVisualStyleBackColor = true;
            this.btn_cancelar_reserva.Click += new System.EventHandler(this.btn_cancelar_reserva_Click);
            // 
            // lbl_data_cancelamento
            // 
            this.lbl_data_cancelamento.AutoSize = true;
            this.lbl_data_cancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data_cancelamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_data_cancelamento.Location = new System.Drawing.Point(450, 706);
            this.lbl_data_cancelamento.Name = "lbl_data_cancelamento";
            this.lbl_data_cancelamento.Size = new System.Drawing.Size(214, 20);
            this.lbl_data_cancelamento.TabIndex = 245;
            this.lbl_data_cancelamento.Text = "DATA DE CANCELAMENTO";
            this.lbl_data_cancelamento.Visible = false;
            // 
            // lbl_cancelada
            // 
            this.lbl_cancelada.AutoSize = true;
            this.lbl_cancelada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cancelada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_cancelada.Location = new System.Drawing.Point(955, 79);
            this.lbl_cancelada.Name = "lbl_cancelada";
            this.lbl_cancelada.Size = new System.Drawing.Size(196, 20);
            this.lbl_cancelada.TabIndex = 246;
            this.lbl_cancelada.Text = "RESERVA CANCELADA*";
            this.lbl_cancelada.Visible = false;
            // 
            // txt_valor_total
            // 
            this.txt_valor_total.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_valor_total.Enabled = false;
            this.txt_valor_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor_total.Location = new System.Drawing.Point(681, 155);
            this.txt_valor_total.Name = "txt_valor_total";
            this.txt_valor_total.Size = new System.Drawing.Size(128, 31);
            this.txt_valor_total.TabIndex = 255;
            this.txt_valor_total.Text = "";
            // 
            // lbl_valor_total
            // 
            this.lbl_valor_total.AutoSize = true;
            this.lbl_valor_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_valor_total.Location = new System.Drawing.Point(677, 128);
            this.lbl_valor_total.Name = "lbl_valor_total";
            this.lbl_valor_total.Size = new System.Drawing.Size(100, 24);
            this.lbl_valor_total.TabIndex = 254;
            this.lbl_valor_total.Text = "Valor Total";
            // 
            // txt_num_dias
            // 
            this.txt_num_dias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_num_dias.Enabled = false;
            this.txt_num_dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_num_dias.Location = new System.Drawing.Point(550, 152);
            this.txt_num_dias.Name = "txt_num_dias";
            this.txt_num_dias.Size = new System.Drawing.Size(78, 31);
            this.txt_num_dias.TabIndex = 257;
            this.txt_num_dias.Text = "";
            // 
            // lbl_num_dias
            // 
            this.lbl_num_dias.AutoSize = true;
            this.lbl_num_dias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_num_dias.Location = new System.Drawing.Point(546, 128);
            this.lbl_num_dias.Name = "lbl_num_dias";
            this.lbl_num_dias.Size = new System.Drawing.Size(97, 24);
            this.lbl_num_dias.TabIndex = 256;
            this.lbl_num_dias.Text = "Num. Dias";
            // 
            // check_pago
            // 
            this.check_pago.AutoSize = true;
            this.check_pago.Location = new System.Drawing.Point(6, 45);
            this.check_pago.Name = "check_pago";
            this.check_pago.Size = new System.Drawing.Size(65, 24);
            this.check_pago.TabIndex = 260;
            this.check_pago.Text = "Pago";
            this.check_pago.UseVisualStyleBackColor = true;
            // 
            // check_n_pago
            // 
            this.check_n_pago.AutoSize = true;
            this.check_n_pago.Location = new System.Drawing.Point(92, 45);
            this.check_n_pago.Name = "check_n_pago";
            this.check_n_pago.Size = new System.Drawing.Size(98, 24);
            this.check_n_pago.TabIndex = 261;
            this.check_n_pago.Text = "Não Pago";
            this.check_n_pago.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_pago);
            this.groupBox1.Controls.Add(this.check_n_pago);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(959, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 83);
            this.groupBox1.TabIndex = 262;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status Pagamento";
            // 
            // txt_telefone
            // 
            this.txt_telefone.Enabled = false;
            this.txt_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(784, 31);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(155, 26);
            this.txt_telefone.TabIndex = 263;
            // 
            // dataGridView_parcelas
            // 
            this.dataGridView_parcelas.AllowUserToAddRows = false;
            this.dataGridView_parcelas.AllowUserToDeleteRows = false;
            this.dataGridView_parcelas.AllowUserToResizeColumns = false;
            this.dataGridView_parcelas.AllowUserToResizeRows = false;
            this.dataGridView_parcelas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dataGridView_parcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_parcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroParcela,
            this.idFormaPagamento,
            this.FormaPagamento,
            this.dataVencimento,
            this.valorParcela});
            this.dataGridView_parcelas.Enabled = false;
            this.dataGridView_parcelas.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView_parcelas.Location = new System.Drawing.Point(14, 284);
            this.dataGridView_parcelas.Name = "dataGridView_parcelas";
            this.dataGridView_parcelas.ReadOnly = true;
            this.dataGridView_parcelas.Size = new System.Drawing.Size(524, 114);
            this.dataGridView_parcelas.TabIndex = 270;
            // 
            // numeroParcela
            // 
            this.numeroParcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeroParcela.HeaderText = "Parcela";
            this.numeroParcela.Name = "numeroParcela";
            this.numeroParcela.ReadOnly = true;
            // 
            // idFormaPagamento
            // 
            this.idFormaPagamento.HeaderText = "Cód. Forma Pagamento";
            this.idFormaPagamento.Name = "idFormaPagamento";
            this.idFormaPagamento.ReadOnly = true;
            this.idFormaPagamento.Width = 80;
            // 
            // FormaPagamento
            // 
            this.FormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FormaPagamento.HeaderText = "Forma de Pagamento";
            this.FormaPagamento.Name = "FormaPagamento";
            this.FormaPagamento.ReadOnly = true;
            // 
            // dataVencimento
            // 
            this.dataVencimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataVencimento.HeaderText = "Data Vencimento";
            this.dataVencimento.Name = "dataVencimento";
            this.dataVencimento.ReadOnly = true;
            // 
            // valorParcela
            // 
            this.valorParcela.HeaderText = "Valor Parcela";
            this.valorParcela.Name = "valorParcela";
            this.valorParcela.ReadOnly = true;
            this.valorParcela.Width = 153;
            // 
            // btn_add_cond_pag
            // 
            this.btn_add_cond_pag.Location = new System.Drawing.Point(493, 253);
            this.btn_add_cond_pag.Name = "btn_add_cond_pag";
            this.btn_add_cond_pag.Size = new System.Drawing.Size(45, 29);
            this.btn_add_cond_pag.TabIndex = 269;
            this.btn_add_cond_pag.Text = "ADD";
            this.btn_add_cond_pag.UseVisualStyleBackColor = true;
            // 
            // btn_busca_cond_pagamento
            // 
            this.btn_busca_cond_pagamento.Location = new System.Drawing.Point(129, 250);
            this.btn_busca_cond_pagamento.Name = "btn_busca_cond_pagamento";
            this.btn_busca_cond_pagamento.Size = new System.Drawing.Size(62, 29);
            this.btn_busca_cond_pagamento.TabIndex = 268;
            this.btn_busca_cond_pagamento.Text = "search";
            this.btn_busca_cond_pagamento.UseVisualStyleBackColor = true;
            // 
            // lbl_cod_cond_pagamento
            // 
            this.lbl_cod_cond_pagamento.AutoSize = true;
            this.lbl_cod_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cod_cond_pagamento.Location = new System.Drawing.Point(12, 220);
            this.lbl_cod_cond_pagamento.Name = "lbl_cod_cond_pagamento";
            this.lbl_cod_cond_pagamento.Size = new System.Drawing.Size(197, 24);
            this.lbl_cod_cond_pagamento.TabIndex = 267;
            this.lbl_cod_cond_pagamento.Text = "Cód Cond Pagamento";
            // 
            // txt_cod_cond_pagamento
            // 
            this.txt_cod_cond_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cod_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_cond_pagamento.Location = new System.Drawing.Point(14, 250);
            this.txt_cod_cond_pagamento.Name = "txt_cod_cond_pagamento";
            this.txt_cod_cond_pagamento.Size = new System.Drawing.Size(110, 31);
            this.txt_cod_cond_pagamento.TabIndex = 266;
            this.txt_cod_cond_pagamento.Text = "";
            // 
            // lbl_cond_pagamento
            // 
            this.lbl_cond_pagamento.AutoSize = true;
            this.lbl_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_cond_pagamento.Location = new System.Drawing.Point(227, 220);
            this.lbl_cond_pagamento.Name = "lbl_cond_pagamento";
            this.lbl_cond_pagamento.Size = new System.Drawing.Size(219, 24);
            this.lbl_cond_pagamento.TabIndex = 265;
            this.lbl_cond_pagamento.Text = "Condição de Pagamento";
            // 
            // txt_cond_pagamento
            // 
            this.txt_cond_pagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cond_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cond_pagamento.Location = new System.Drawing.Point(231, 251);
            this.txt_cond_pagamento.Name = "txt_cond_pagamento";
            this.txt_cond_pagamento.Size = new System.Drawing.Size(256, 31);
            this.txt_cond_pagamento.TabIndex = 264;
            this.txt_cond_pagamento.Text = "";
            // 
            // lbl_observacao
            // 
            this.lbl_observacao.AutoSize = true;
            this.lbl_observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_observacao.Location = new System.Drawing.Point(12, 458);
            this.lbl_observacao.Name = "lbl_observacao";
            this.lbl_observacao.Size = new System.Drawing.Size(112, 24);
            this.lbl_observacao.TabIndex = 272;
            this.lbl_observacao.Text = "Observação";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_hospede,
            this.hospede});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(590, 284);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(559, 114);
            this.dataGridView1.TabIndex = 273;
            // 
            // codigo_hospede
            // 
            this.codigo_hospede.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigo_hospede.HeaderText = "Cód Hóspede";
            this.codigo_hospede.Name = "codigo_hospede";
            // 
            // hospede
            // 
            this.hospede.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hospede.HeaderText = "Hóspede";
            this.hospede.Name = "hospede";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(590, 252);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(107, 30);
            this.richTextBox1.TabIndex = 274;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(800, 252);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(298, 29);
            this.richTextBox2.TabIndex = 275;
            this.richTextBox2.Text = "";
            // 
            // txt_data_cancelamento
            // 
            this.txt_data_cancelamento.Location = new System.Drawing.Point(454, 733);
            this.txt_data_cancelamento.Name = "txt_data_cancelamento";
            this.txt_data_cancelamento.Size = new System.Drawing.Size(210, 31);
            this.txt_data_cancelamento.TabIndex = 276;
            this.txt_data_cancelamento.Text = "";
            this.txt_data_cancelamento.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1104, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 29);
            this.button1.TabIndex = 277;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 29);
            this.button2.TabIndex = 278;
            this.button2.Text = "search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cod_hospede
            // 
            this.cod_hospede.AutoSize = true;
            this.cod_hospede.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cod_hospede.Location = new System.Drawing.Point(586, 226);
            this.cod_hospede.Name = "cod_hospede";
            this.cod_hospede.Size = new System.Drawing.Size(128, 24);
            this.cod_hospede.TabIndex = 279;
            this.cod_hospede.Text = "Cód Hóspede";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(798, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 280;
            this.label2.Text = "Hóspede";
            // 
            // btn_excluir_cond_pagamento
            // 
            this.btn_excluir_cond_pagamento.Location = new System.Drawing.Point(468, 404);
            this.btn_excluir_cond_pagamento.Name = "btn_excluir_cond_pagamento";
            this.btn_excluir_cond_pagamento.Size = new System.Drawing.Size(70, 29);
            this.btn_excluir_cond_pagamento.TabIndex = 281;
            this.btn_excluir_cond_pagamento.Text = "excluir";
            this.btn_excluir_cond_pagamento.UseVisualStyleBackColor = true;
            // 
            // btn_excluir_hospede
            // 
            this.btn_excluir_hospede.Location = new System.Drawing.Point(1069, 404);
            this.btn_excluir_hospede.Name = "btn_excluir_hospede";
            this.btn_excluir_hospede.Size = new System.Drawing.Size(80, 29);
            this.btn_excluir_hospede.TabIndex = 282;
            this.btn_excluir_hospede.Text = "Excluir";
            this.btn_excluir_hospede.UseVisualStyleBackColor = true;
            // 
            // txt_observacao
            // 
            this.txt_observacao.Location = new System.Drawing.Point(16, 485);
            this.txt_observacao.Name = "txt_observacao";
            this.txt_observacao.Size = new System.Drawing.Size(522, 153);
            this.txt_observacao.TabIndex = 283;
            this.txt_observacao.Text = "";
            // 
            // CadastroReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1161, 787);
            this.Controls.Add(this.txt_observacao);
            this.Controls.Add(this.btn_excluir_hospede);
            this.Controls.Add(this.btn_excluir_cond_pagamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cod_hospede);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_data_cancelamento);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_observacao);
            this.Controls.Add(this.dataGridView_parcelas);
            this.Controls.Add(this.btn_add_cond_pag);
            this.Controls.Add(this.btn_busca_cond_pagamento);
            this.Controls.Add(this.lbl_cod_cond_pagamento);
            this.Controls.Add(this.txt_cod_cond_pagamento);
            this.Controls.Add(this.lbl_cond_pagamento);
            this.Controls.Add(this.txt_cond_pagamento);
            this.Controls.Add(this.txt_telefone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_num_dias);
            this.Controls.Add(this.lbl_num_dias);
            this.Controls.Add(this.txt_valor_total);
            this.Controls.Add(this.lbl_valor_total);
            this.Controls.Add(this.lbl_cancelada);
            this.Controls.Add(this.lbl_data_cancelamento);
            this.Controls.Add(this.btn_cancelar_reserva);
            this.Controls.Add(this.dtp_checkout);
            this.Controls.Add(this.dtp_checkin);
            this.Controls.Add(this.lbl_checkout);
            this.Controls.Add(this.lbl_checkin);
            this.Controls.Add(this.txt_valor_diaria);
            this.Controls.Add(this.lbl_vlr_diaria);
            this.Controls.Add(this.btn_busca_cod_quarto);
            this.Controls.Add(this.txt_cod_quarto);
            this.Controls.Add(this.lbl_quarto_id);
            this.Controls.Add(this.txt_andar);
            this.Controls.Add(this.lbl_andar);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.lbl_numero_quarto);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.txt_cpf);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.btn_busca_cod_cliente);
            this.Controls.Add(this.lbl_cod_cliente);
            this.Controls.Add(this.txt_cod_cliente);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.txt_nome_cliente);
            this.Name = "CadastroReserva";
            this.Text = "Cadastro Reserva";
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_nome_cliente, 0);
            this.Controls.SetChildIndex(this.lbl_nome, 0);
            this.Controls.SetChildIndex(this.txt_cod_cliente, 0);
            this.Controls.SetChildIndex(this.lbl_cod_cliente, 0);
            this.Controls.SetChildIndex(this.btn_busca_cod_cliente, 0);
            this.Controls.SetChildIndex(this.lbl_cpf, 0);
            this.Controls.SetChildIndex(this.txt_cpf, 0);
            this.Controls.SetChildIndex(this.lbl_telefone, 0);
            this.Controls.SetChildIndex(this.lbl_numero_quarto, 0);
            this.Controls.SetChildIndex(this.txt_numero, 0);
            this.Controls.SetChildIndex(this.lbl_andar, 0);
            this.Controls.SetChildIndex(this.txt_andar, 0);
            this.Controls.SetChildIndex(this.lbl_quarto_id, 0);
            this.Controls.SetChildIndex(this.txt_cod_quarto, 0);
            this.Controls.SetChildIndex(this.btn_busca_cod_quarto, 0);
            this.Controls.SetChildIndex(this.lbl_vlr_diaria, 0);
            this.Controls.SetChildIndex(this.txt_valor_diaria, 0);
            this.Controls.SetChildIndex(this.lbl_checkin, 0);
            this.Controls.SetChildIndex(this.lbl_checkout, 0);
            this.Controls.SetChildIndex(this.dtp_checkin, 0);
            this.Controls.SetChildIndex(this.dtp_checkout, 0);
            this.Controls.SetChildIndex(this.btn_cancelar_reserva, 0);
            this.Controls.SetChildIndex(this.lbl_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.lbl_cancelada, 0);
            this.Controls.SetChildIndex(this.lbl_valor_total, 0);
            this.Controls.SetChildIndex(this.txt_valor_total, 0);
            this.Controls.SetChildIndex(this.lbl_num_dias, 0);
            this.Controls.SetChildIndex(this.txt_num_dias, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txt_telefone, 0);
            this.Controls.SetChildIndex(this.txt_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.lbl_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.txt_cod_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.lbl_cod_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_busca_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_add_cond_pag, 0);
            this.Controls.SetChildIndex(this.dataGridView_parcelas, 0);
            this.Controls.SetChildIndex(this.lbl_observacao, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.richTextBox1, 0);
            this.Controls.SetChildIndex(this.richTextBox2, 0);
            this.Controls.SetChildIndex(this.txt_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.cod_hospede, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btn_excluir_cond_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_excluir_hospede, 0);
            this.Controls.SetChildIndex(this.txt_observacao, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.RichTextBox txt_nome_cliente;
        private System.Windows.Forms.Label lbl_cod_cliente;
        private System.Windows.Forms.RichTextBox txt_cod_cliente;
        private System.Windows.Forms.Button btn_busca_cod_cliente;
        private System.Windows.Forms.MaskedTextBox txt_cpf;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.Label lbl_telefone;
        private System.Windows.Forms.RichTextBox txt_andar;
        private System.Windows.Forms.Label lbl_andar;
        private System.Windows.Forms.RichTextBox txt_numero;
        private System.Windows.Forms.Label lbl_numero_quarto;
        private System.Windows.Forms.RichTextBox txt_cod_quarto;
        private System.Windows.Forms.Label lbl_quarto_id;
        private System.Windows.Forms.Button btn_busca_cod_quarto;
        private System.Windows.Forms.RichTextBox txt_valor_diaria;
        private System.Windows.Forms.Label lbl_vlr_diaria;
        protected System.Windows.Forms.Label lbl_checkout;
        protected System.Windows.Forms.Label lbl_checkin;
        private System.Windows.Forms.DateTimePicker dtp_checkin;
        private System.Windows.Forms.DateTimePicker dtp_checkout;
        private System.Windows.Forms.Button btn_cancelar_reserva;
        public System.Windows.Forms.Label lbl_data_cancelamento;
        public System.Windows.Forms.Label lbl_cancelada;
        private System.Windows.Forms.RichTextBox txt_valor_total;
        private System.Windows.Forms.Label lbl_valor_total;
        private System.Windows.Forms.RichTextBox txt_num_dias;
        private System.Windows.Forms.Label lbl_num_dias;
        private System.Windows.Forms.CheckBox check_pago;
        private System.Windows.Forms.CheckBox check_n_pago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txt_telefone;
        private System.Windows.Forms.DataGridView dataGridView_parcelas;
        private System.Windows.Forms.Button btn_add_cond_pag;
        private System.Windows.Forms.Button btn_busca_cond_pagamento;
        private System.Windows.Forms.Label lbl_cod_cond_pagamento;
        private System.Windows.Forms.RichTextBox txt_cod_cond_pagamento;
        private System.Windows.Forms.Label lbl_cond_pagamento;
        private System.Windows.Forms.RichTextBox txt_cond_pagamento;
        private System.Windows.Forms.Label lbl_observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroParcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorParcela;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox txt_data_cancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_hospede;
        private System.Windows.Forms.DataGridViewTextBoxColumn hospede;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label cod_hospede;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_excluir_cond_pagamento;
        private System.Windows.Forms.Button btn_excluir_hospede;
        private System.Windows.Forms.RichTextBox txt_observacao;
    }
}
