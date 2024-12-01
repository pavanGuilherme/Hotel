namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroContaReceber
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
            this.txt_cod_reserva = new System.Windows.Forms.TextBox();
            this.txt_cod_cliente = new System.Windows.Forms.TextBox();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.btn_busca_reserva = new System.Windows.Forms.Button();
            this.btn_busca_cliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_busca_forma = new System.Windows.Forms.Button();
            this.txt_forma_pagamento = new System.Windows.Forms.TextBox();
            this.txt_cod_forma = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_num_parcela = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_vlr_parcela = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_juros = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_multa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_valor_recebido = new System.Windows.Forms.TextBox();
            this.lbl_data_cancelamento = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_total_receber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_desconto = new System.Windows.Forms.TextBox();
            this.btn_receber = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.txt_data_vencimento = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_recebimento = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_cancelamento = new System.Windows.Forms.MaskedTextBox();
            this.txt_observacao = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_data_emissao = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(685, 13);
            this.status.Size = new System.Drawing.Size(159, 60);
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.Location = new System.Drawing.Point(18, 11);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(22, 37);
            this.txt_codigo.Size = new System.Drawing.Size(72, 31);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(196, 584);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(200, 612);
            this.txt_dat_ult_alt.Size = new System.Drawing.Size(176, 31);
            this.txt_dat_ult_alt.Text = "25/11/2024 20:03:08";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(7, 584);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(12, 611);
            this.txt_dat_cad.Size = new System.Drawing.Size(179, 31);
            this.txt_dat_cad.Text = "25/11/2024 20:03:08";
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(635, 612);
            this.btn_salvar.Size = new System.Drawing.Size(105, 26);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(746, 612);
            this.btn_sair.Size = new System.Drawing.Size(98, 26);
            // 
            // txt_cod_reserva
            // 
            this.txt_cod_reserva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod_reserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_reserva.Location = new System.Drawing.Point(118, 40);
            this.txt_cod_reserva.Name = "txt_cod_reserva";
            this.txt_cod_reserva.Size = new System.Drawing.Size(119, 29);
            this.txt_cod_reserva.TabIndex = 136;
            // 
            // txt_cod_cliente
            // 
            this.txt_cod_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_cliente.Location = new System.Drawing.Point(16, 122);
            this.txt_cod_cliente.Name = "txt_cod_cliente";
            this.txt_cod_cliente.Size = new System.Drawing.Size(140, 29);
            this.txt_cod_cliente.TabIndex = 137;
            this.txt_cod_cliente.Leave += new System.EventHandler(this.txt_cod_cliente_Leave);
            // 
            // txt_cliente
            // 
            this.txt_cliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cliente.Location = new System.Drawing.Point(233, 122);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.Size = new System.Drawing.Size(448, 29);
            this.txt_cliente.TabIndex = 138;
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_pais.Location = new System.Drawing.Point(114, 13);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(131, 24);
            this.lbl_pais.TabIndex = 140;
            this.lbl_pais.Text = "Cód. Reserva*";
            // 
            // btn_busca_reserva
            // 
            this.btn_busca_reserva.Location = new System.Drawing.Point(242, 40);
            this.btn_busca_reserva.Name = "btn_busca_reserva";
            this.btn_busca_reserva.Size = new System.Drawing.Size(65, 29);
            this.btn_busca_reserva.TabIndex = 142;
            this.btn_busca_reserva.Text = "search";
            this.btn_busca_reserva.UseVisualStyleBackColor = true;
            this.btn_busca_reserva.Click += new System.EventHandler(this.txt_busca_reserva_Click);
            // 
            // btn_busca_cliente
            // 
            this.btn_busca_cliente.Location = new System.Drawing.Point(162, 122);
            this.btn_busca_cliente.Name = "btn_busca_cliente";
            this.btn_busca_cliente.Size = new System.Drawing.Size(65, 29);
            this.btn_busca_cliente.TabIndex = 143;
            this.btn_busca_cliente.Text = "search";
            this.btn_busca_cliente.UseVisualStyleBackColor = true;
            this.btn_busca_cliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(19, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 144;
            this.label1.Text = "Cód. Cliente*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(240, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 145;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(229, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 24);
            this.label3.TabIndex = 150;
            this.label3.Text = "Forma de Pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 24);
            this.label4.TabIndex = 149;
            this.label4.Text = "Cód. Forma Pag.*";
            // 
            // btn_busca_forma
            // 
            this.btn_busca_forma.Location = new System.Drawing.Point(162, 200);
            this.btn_busca_forma.Name = "btn_busca_forma";
            this.btn_busca_forma.Size = new System.Drawing.Size(65, 29);
            this.btn_busca_forma.TabIndex = 148;
            this.btn_busca_forma.Text = "search";
            this.btn_busca_forma.UseVisualStyleBackColor = true;
            this.btn_busca_forma.Click += new System.EventHandler(this.txt_busca_forma_Click);
            // 
            // txt_forma_pagamento
            // 
            this.txt_forma_pagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_forma_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_forma_pagamento.Location = new System.Drawing.Point(233, 200);
            this.txt_forma_pagamento.Name = "txt_forma_pagamento";
            this.txt_forma_pagamento.Size = new System.Drawing.Size(448, 29);
            this.txt_forma_pagamento.TabIndex = 147;
            // 
            // txt_cod_forma
            // 
            this.txt_cod_forma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod_forma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cod_forma.Location = new System.Drawing.Point(16, 200);
            this.txt_cod_forma.Name = "txt_cod_forma";
            this.txt_cod_forma.Size = new System.Drawing.Size(140, 29);
            this.txt_cod_forma.TabIndex = 146;
            this.txt_cod_forma.Leave += new System.EventHandler(this.txt_cod_forma_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 24);
            this.label5.TabIndex = 152;
            this.label5.Text = "N° da Parcela";
            // 
            // txt_num_parcela
            // 
            this.txt_num_parcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_num_parcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_num_parcela.Location = new System.Drawing.Point(16, 271);
            this.txt_num_parcela.Name = "txt_num_parcela";
            this.txt_num_parcela.Size = new System.Drawing.Size(140, 29);
            this.txt_num_parcela.TabIndex = 151;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(188, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 24);
            this.label6.TabIndex = 154;
            this.label6.Text = "Valor da Parcela *";
            // 
            // txt_vlr_parcela
            // 
            this.txt_vlr_parcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_vlr_parcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_vlr_parcela.Location = new System.Drawing.Point(192, 271);
            this.txt_vlr_parcela.Name = "txt_vlr_parcela";
            this.txt_vlr_parcela.Size = new System.Drawing.Size(140, 29);
            this.txt_vlr_parcela.TabIndex = 153;
            this.txt_vlr_parcela.Text = "0";
            this.txt_vlr_parcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(15, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 24);
            this.label7.TabIndex = 156;
            this.label7.Text = "R$ Juros";
            // 
            // txt_juros
            // 
            this.txt_juros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_juros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_juros.Location = new System.Drawing.Point(19, 336);
            this.txt_juros.Name = "txt_juros";
            this.txt_juros.Size = new System.Drawing.Size(140, 29);
            this.txt_juros.TabIndex = 155;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.Location = new System.Drawing.Point(191, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 24);
            this.label8.TabIndex = 158;
            this.label8.Text = "R$ Multa";
            // 
            // txt_multa
            // 
            this.txt_multa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_multa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_multa.Location = new System.Drawing.Point(195, 336);
            this.txt_multa.Name = "txt_multa";
            this.txt_multa.Size = new System.Drawing.Size(140, 29);
            this.txt_multa.TabIndex = 157;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 20);
            this.label9.TabIndex = 160;
            this.label9.Text = "Data  Recebimento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label10.Location = new System.Drawing.Point(188, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 24);
            this.label10.TabIndex = 162;
            this.label10.Text = "Valor Recebido";
            // 
            // txt_valor_recebido
            // 
            this.txt_valor_recebido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_valor_recebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_valor_recebido.Location = new System.Drawing.Point(191, 409);
            this.txt_valor_recebido.Name = "txt_valor_recebido";
            this.txt_valor_recebido.Size = new System.Drawing.Size(140, 29);
            this.txt_valor_recebido.TabIndex = 161;
            this.txt_valor_recebido.Text = "0";
            this.txt_valor_recebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_data_cancelamento
            // 
            this.lbl_data_cancelamento.AutoSize = true;
            this.lbl_data_cancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_data_cancelamento.ForeColor = System.Drawing.Color.Red;
            this.lbl_data_cancelamento.Location = new System.Drawing.Point(371, 382);
            this.lbl_data_cancelamento.Name = "lbl_data_cancelamento";
            this.lbl_data_cancelamento.Size = new System.Drawing.Size(174, 24);
            this.lbl_data_cancelamento.TabIndex = 164;
            this.lbl_data_cancelamento.Text = "Data Cancelamento";
            this.lbl_data_cancelamento.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label12.Location = new System.Drawing.Point(577, 382);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 24);
            this.label12.TabIndex = 166;
            this.label12.Text = "Total a Receber";
            // 
            // txt_total_receber
            // 
            this.txt_total_receber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_total_receber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_total_receber.Location = new System.Drawing.Point(581, 409);
            this.txt_total_receber.Name = "txt_total_receber";
            this.txt_total_receber.Size = new System.Drawing.Size(140, 29);
            this.txt_total_receber.TabIndex = 165;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label13.Location = new System.Drawing.Point(371, 244);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(193, 24);
            this.label13.TabIndex = 168;
            this.label13.Text = "Data de Vencimento *";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label14.Location = new System.Drawing.Point(374, 309);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 24);
            this.label14.TabIndex = 170;
            this.label14.Text = "R$ Desconto";
            // 
            // txt_desconto
            // 
            this.txt_desconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_desconto.Location = new System.Drawing.Point(378, 336);
            this.txt_desconto.Name = "txt_desconto";
            this.txt_desconto.Size = new System.Drawing.Size(140, 29);
            this.txt_desconto.TabIndex = 169;
            // 
            // btn_receber
            // 
            this.btn_receber.ForeColor = System.Drawing.Color.Lime;
            this.btn_receber.Location = new System.Drawing.Point(549, 611);
            this.btn_receber.Name = "btn_receber";
            this.btn_receber.Size = new System.Drawing.Size(80, 29);
            this.btn_receber.TabIndex = 172;
            this.btn_receber.Text = "Receber";
            this.btn_receber.UseVisualStyleBackColor = true;
            this.btn_receber.Click += new System.EventHandler(this.btn_receber_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.ForeColor = System.Drawing.Color.Red;
            this.btn_cancelar.Location = new System.Drawing.Point(465, 611);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(78, 29);
            this.btn_cancelar.TabIndex = 171;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Visible = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // txt_data_vencimento
            // 
            this.txt_data_vencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_vencimento.Location = new System.Drawing.Point(375, 271);
            this.txt_data_vencimento.Mask = "00 /00 /0000";
            this.txt_data_vencimento.Name = "txt_data_vencimento";
            this.txt_data_vencimento.Size = new System.Drawing.Size(117, 29);
            this.txt_data_vencimento.TabIndex = 173;
            this.txt_data_vencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_vencimento.ValidatingType = typeof(System.DateTime);
            this.txt_data_vencimento.Leave += new System.EventHandler(this.txt_data_vencimento_Leave);
            // 
            // txt_data_recebimento
            // 
            this.txt_data_recebimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_recebimento.Location = new System.Drawing.Point(12, 409);
            this.txt_data_recebimento.Mask = "00 /00 /0000";
            this.txt_data_recebimento.Name = "txt_data_recebimento";
            this.txt_data_recebimento.Size = new System.Drawing.Size(112, 29);
            this.txt_data_recebimento.TabIndex = 174;
            this.txt_data_recebimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_recebimento.ValidatingType = typeof(System.DateTime);
            // 
            // txt_data_cancelamento
            // 
            this.txt_data_cancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_cancelamento.Location = new System.Drawing.Point(375, 409);
            this.txt_data_cancelamento.Mask = "00 /00 /0000";
            this.txt_data_cancelamento.Name = "txt_data_cancelamento";
            this.txt_data_cancelamento.Size = new System.Drawing.Size(117, 29);
            this.txt_data_cancelamento.TabIndex = 175;
            this.txt_data_cancelamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_cancelamento.ValidatingType = typeof(System.DateTime);
            this.txt_data_cancelamento.Visible = false;
            // 
            // txt_observacao
            // 
            this.txt_observacao.Location = new System.Drawing.Point(12, 479);
            this.txt_observacao.Name = "txt_observacao";
            this.txt_observacao.Size = new System.Drawing.Size(709, 80);
            this.txt_observacao.TabIndex = 176;
            this.txt_observacao.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label15.Location = new System.Drawing.Point(12, 452);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 24);
            this.label15.TabIndex = 177;
            this.label15.Text = "Observação";
            // 
            // txt_data_emissao
            // 
            this.txt_data_emissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_emissao.Location = new System.Drawing.Point(330, 40);
            this.txt_data_emissao.Mask = "00 /00 /0000";
            this.txt_data_emissao.Name = "txt_data_emissao";
            this.txt_data_emissao.Size = new System.Drawing.Size(147, 29);
            this.txt_data_emissao.TabIndex = 179;
            this.txt_data_emissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_emissao.ValidatingType = typeof(System.DateTime);
            this.txt_data_emissao.Leave += new System.EventHandler(this.txt_data_emissao_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label11.Location = new System.Drawing.Point(326, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 24);
            this.label11.TabIndex = 178;
            this.label11.Text = "Data de Emissão";
            // 
            // CadastroContaReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(856, 655);
            this.Controls.Add(this.txt_data_emissao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_observacao);
            this.Controls.Add(this.txt_data_cancelamento);
            this.Controls.Add(this.txt_data_recebimento);
            this.Controls.Add(this.txt_data_vencimento);
            this.Controls.Add(this.btn_receber);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_desconto);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_total_receber);
            this.Controls.Add(this.lbl_data_cancelamento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_valor_recebido);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_multa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_juros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_vlr_parcela);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_num_parcela);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_busca_forma);
            this.Controls.Add(this.txt_forma_pagamento);
            this.Controls.Add(this.txt_cod_forma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_busca_cliente);
            this.Controls.Add(this.btn_busca_reserva);
            this.Controls.Add(this.lbl_pais);
            this.Controls.Add(this.txt_cliente);
            this.Controls.Add(this.txt_cod_cliente);
            this.Controls.Add(this.txt_cod_reserva);
            this.Name = "CadastroContaReceber";
            this.Load += new System.EventHandler(this.CadastroContaReceber_Load);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_cod_reserva, 0);
            this.Controls.SetChildIndex(this.txt_cod_cliente, 0);
            this.Controls.SetChildIndex(this.txt_cliente, 0);
            this.Controls.SetChildIndex(this.lbl_pais, 0);
            this.Controls.SetChildIndex(this.btn_busca_reserva, 0);
            this.Controls.SetChildIndex(this.btn_busca_cliente, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_cod_forma, 0);
            this.Controls.SetChildIndex(this.txt_forma_pagamento, 0);
            this.Controls.SetChildIndex(this.btn_busca_forma, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_num_parcela, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_vlr_parcela, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txt_juros, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txt_multa, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txt_valor_recebido, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lbl_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.txt_total_receber, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txt_desconto, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.btn_cancelar, 0);
            this.Controls.SetChildIndex(this.btn_receber, 0);
            this.Controls.SetChildIndex(this.txt_data_vencimento, 0);
            this.Controls.SetChildIndex(this.txt_data_recebimento, 0);
            this.Controls.SetChildIndex(this.txt_data_cancelamento, 0);
            this.Controls.SetChildIndex(this.txt_observacao, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txt_data_emissao, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cod_reserva;
        private System.Windows.Forms.TextBox txt_cod_cliente;
        private System.Windows.Forms.TextBox txt_cliente;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Button btn_busca_reserva;
        private System.Windows.Forms.Button btn_busca_cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_busca_forma;
        private System.Windows.Forms.TextBox txt_forma_pagamento;
        private System.Windows.Forms.TextBox txt_cod_forma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_num_parcela;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_vlr_parcela;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_juros;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_multa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_valor_recebido;
        private System.Windows.Forms.Label lbl_data_cancelamento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_total_receber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_desconto;
        private System.Windows.Forms.Button btn_receber;
        private System.Windows.Forms.Button btn_cancelar;
        protected System.Windows.Forms.MaskedTextBox txt_data_vencimento;
        protected System.Windows.Forms.MaskedTextBox txt_data_recebimento;
        protected System.Windows.Forms.MaskedTextBox txt_data_cancelamento;
        private System.Windows.Forms.RichTextBox txt_observacao;
        private System.Windows.Forms.Label label15;
        protected System.Windows.Forms.MaskedTextBox txt_data_emissao;
        private System.Windows.Forms.Label label11;
    }
}
