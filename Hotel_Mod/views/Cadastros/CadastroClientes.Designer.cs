namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroClientes
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
            this.txt_data_nascimento = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.condicao_pagamento = new System.Windows.Forms.TextBox();
            this.txt_cod_pagamento = new System.Windows.Forms.TextBox();
            this.check_pcd = new System.Windows.Forms.CheckBox();
            this.txt_rg = new System.Windows.Forms.MaskedTextBox();
            this.txt_cpf = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_pais = new System.Windows.Forms.TextBox();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.txt_cidade = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_cod_cidade = new System.Windows.Forms.TextBox();
            this.txt_logradouro = new System.Windows.Forms.TextBox();
            this.txt_complemento = new System.Windows.Forms.TextBox();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bairro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cep = new System.Windows.Forms.TextBox();
            this.lbl_cep = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.check_estrangeiro = new System.Windows.Forms.CheckBox();
            this.lbl_data_nascimento = new System.Windows.Forms.Label();
            this.lbl_orgao_emissor = new System.Windows.Forms.Label();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.lbl_rg = new System.Windows.Forms.Label();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.txt_orgao_emissor = new System.Windows.Forms.TextBox();
            this.comboBox_sexo = new System.Windows.Forms.ComboBox();
            this.lbl_sexo = new System.Windows.Forms.Label();
            this.lbl_sobrenome = new System.Windows.Forms.Label();
            this.txt_sobrenome = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_profissao = new System.Windows.Forms.TextBox();
            this.txt_passaporte = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_telefone = new System.Windows.Forms.TextBox();
            this.status.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(1013, 21);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(31, 42);
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(966, 629);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(1082, 629);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(256, 602);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(260, 629);
            this.txt_dat_ult_alt.Text = "23/08/2024 21:50:42";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(17, 602);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(21, 630);
            this.txt_dat_cad.Text = "23/08/2024 21:50:42";
            // 
            // check_inativo
            // 
            this.check_inativo.CheckedChanged += new System.EventHandler(this.check_inativo_CheckedChanged);
            // 
            // check_ativo
            // 
            this.check_ativo.CheckedChanged += new System.EventHandler(this.check_ativo_CheckedChanged);
            // 
            // txt_data_nascimento
            // 
            this.txt_data_nascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_data_nascimento.Location = new System.Drawing.Point(512, 131);
            this.txt_data_nascimento.Mask = "00/00/0000";
            this.txt_data_nascimento.Name = "txt_data_nascimento";
            this.txt_data_nascimento.Size = new System.Drawing.Size(153, 35);
            this.txt_data_nascimento.TabIndex = 212;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.condicao_pagamento);
            this.groupBox2.Controls.Add(this.txt_cod_pagamento);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(21, 472);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 114);
            this.groupBox2.TabIndex = 211;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pagamento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(247, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(219, 24);
            this.label12.TabIndex = 187;
            this.label12.Text = "Condição de Pagamento";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 29);
            this.button2.TabIndex = 187;
            this.button2.Text = "search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 24);
            this.label11.TabIndex = 186;
            this.label11.Text = "Código ";
            // 
            // condicao_pagamento
            // 
            this.condicao_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.condicao_pagamento.Location = new System.Drawing.Point(251, 58);
            this.condicao_pagamento.Name = "condicao_pagamento";
            this.condicao_pagamento.Size = new System.Drawing.Size(335, 29);
            this.condicao_pagamento.TabIndex = 187;
            // 
            // txt_cod_pagamento
            // 
            this.txt_cod_pagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod_pagamento.Location = new System.Drawing.Point(18, 58);
            this.txt_cod_pagamento.Name = "txt_cod_pagamento";
            this.txt_cod_pagamento.Size = new System.Drawing.Size(110, 29);
            this.txt_cod_pagamento.TabIndex = 186;
            // 
            // check_pcd
            // 
            this.check_pcd.AutoSize = true;
            this.check_pcd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.check_pcd.Location = new System.Drawing.Point(1050, 121);
            this.check_pcd.Name = "check_pcd";
            this.check_pcd.Size = new System.Drawing.Size(72, 28);
            this.check_pcd.TabIndex = 210;
            this.check_pcd.Text = "PCD ";
            this.check_pcd.UseVisualStyleBackColor = true;
            this.check_pcd.CheckedChanged += new System.EventHandler(this.check_pcd_CheckedChanged);
            // 
            // txt_rg
            // 
            this.txt_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_rg.Location = new System.Drawing.Point(268, 223);
            this.txt_rg.Mask = "00.000.000-0";
            this.txt_rg.Name = "txt_rg";
            this.txt_rg.Size = new System.Drawing.Size(158, 29);
            this.txt_rg.TabIndex = 209;
            // 
            // txt_cpf
            // 
            this.txt_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cpf.Location = new System.Drawing.Point(34, 223);
            this.txt_cpf.Mask = "000.000.000-00";
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(158, 29);
            this.txt_cpf.TabIndex = 208;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_pais);
            this.groupBox1.Controls.Add(this.txt_estado);
            this.groupBox1.Controls.Add(this.txt_cidade);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_cod_cidade);
            this.groupBox1.Controls.Add(this.txt_logradouro);
            this.groupBox1.Controls.Add(this.txt_complemento);
            this.groupBox1.Controls.Add(this.txt_numero);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_bairro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_cep);
            this.groupBox1.Controls.Add(this.lbl_cep);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 175);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço ";
            // 
            // txt_pais
            // 
            this.txt_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pais.Location = new System.Drawing.Point(778, 133);
            this.txt_pais.Name = "txt_pais";
            this.txt_pais.Size = new System.Drawing.Size(173, 29);
            this.txt_pais.TabIndex = 189;
            // 
            // txt_estado
            // 
            this.txt_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estado.Location = new System.Drawing.Point(545, 137);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(173, 29);
            this.txt_estado.TabIndex = 188;
            // 
            // txt_cidade
            // 
            this.txt_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cidade.Location = new System.Drawing.Point(312, 137);
            this.txt_cidade.Name = "txt_cidade";
            this.txt_cidade.Size = new System.Drawing.Size(173, 29);
            this.txt_cidade.TabIndex = 187;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 29);
            this.button1.TabIndex = 186;
            this.button1.Text = "search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_cod_cidade
            // 
            this.txt_cod_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod_cidade.Location = new System.Drawing.Point(8, 137);
            this.txt_cod_cidade.Name = "txt_cod_cidade";
            this.txt_cod_cidade.Size = new System.Drawing.Size(172, 29);
            this.txt_cod_cidade.TabIndex = 185;
            // 
            // txt_logradouro
            // 
            this.txt_logradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_logradouro.Location = new System.Drawing.Point(218, 57);
            this.txt_logradouro.Name = "txt_logradouro";
            this.txt_logradouro.Size = new System.Drawing.Size(266, 29);
            this.txt_logradouro.TabIndex = 162;
            // 
            // txt_complemento
            // 
            this.txt_complemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_complemento.Location = new System.Drawing.Point(659, 54);
            this.txt_complemento.Name = "txt_complemento";
            this.txt_complemento.Size = new System.Drawing.Size(172, 29);
            this.txt_complemento.TabIndex = 163;
            // 
            // txt_numero
            // 
            this.txt_numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numero.Location = new System.Drawing.Point(527, 54);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(69, 29);
            this.txt_numero.TabIndex = 164;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(655, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 24);
            this.label10.TabIndex = 167;
            this.label10.Text = "Complemento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 168;
            this.label2.Text = "Logradouro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 24);
            this.label3.TabIndex = 169;
            this.label3.Text = "N°";
            // 
            // txt_bairro
            // 
            this.txt_bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bairro.Location = new System.Drawing.Point(915, 54);
            this.txt_bairro.Name = "txt_bairro";
            this.txt_bairro.Size = new System.Drawing.Size(177, 29);
            this.txt_bairro.TabIndex = 170;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(911, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 24);
            this.label5.TabIndex = 172;
            this.label5.Text = "Bairro";
            // 
            // txt_cep
            // 
            this.txt_cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cep.Location = new System.Drawing.Point(8, 57);
            this.txt_cep.Name = "txt_cep";
            this.txt_cep.Size = new System.Drawing.Size(188, 29);
            this.txt_cep.TabIndex = 165;
            // 
            // lbl_cep
            // 
            this.lbl_cep.AutoSize = true;
            this.lbl_cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cep.Location = new System.Drawing.Point(9, 30);
            this.lbl_cep.Name = "lbl_cep";
            this.lbl_cep.Size = new System.Drawing.Size(48, 24);
            this.lbl_cep.TabIndex = 166;
            this.lbl_cep.Text = "CEP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 184;
            this.label1.Text = "Código Cidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(774, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 171;
            this.label4.Text = "País";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 173;
            this.label6.Text = "Cidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(550, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 24);
            this.label7.TabIndex = 174;
            this.label7.Text = "Estado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 24);
            this.label8.TabIndex = 204;
            this.label8.Text = "E-mail";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(31, 137);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(212, 29);
            this.txt_email.TabIndex = 202;
            // 
            // check_estrangeiro
            // 
            this.check_estrangeiro.AutoSize = true;
            this.check_estrangeiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_estrangeiro.Location = new System.Drawing.Point(1031, 87);
            this.check_estrangeiro.Name = "check_estrangeiro";
            this.check_estrangeiro.Size = new System.Drawing.Size(125, 28);
            this.check_estrangeiro.TabIndex = 201;
            this.check_estrangeiro.Text = "Estrangeiro";
            this.check_estrangeiro.UseVisualStyleBackColor = true;
            this.check_estrangeiro.CheckedChanged += new System.EventHandler(this.check_estrangeiro_CheckedChanged);
            // 
            // lbl_data_nascimento
            // 
            this.lbl_data_nascimento.AutoSize = true;
            this.lbl_data_nascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data_nascimento.Location = new System.Drawing.Point(508, 104);
            this.lbl_data_nascimento.Name = "lbl_data_nascimento";
            this.lbl_data_nascimento.Size = new System.Drawing.Size(179, 24);
            this.lbl_data_nascimento.TabIndex = 200;
            this.lbl_data_nascimento.Text = "Data de Nascimento";
            // 
            // lbl_orgao_emissor
            // 
            this.lbl_orgao_emissor.AutoSize = true;
            this.lbl_orgao_emissor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orgao_emissor.Location = new System.Drawing.Point(483, 196);
            this.lbl_orgao_emissor.Name = "lbl_orgao_emissor";
            this.lbl_orgao_emissor.Size = new System.Drawing.Size(136, 24);
            this.lbl_orgao_emissor.TabIndex = 199;
            this.lbl_orgao_emissor.Text = "Órgão Emissor";
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(263, 110);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(159, 24);
            this.lbl_telefone.TabIndex = 197;
            this.lbl_telefone.Text = "Telefone / Celular";
            // 
            // lbl_rg
            // 
            this.lbl_rg.AutoSize = true;
            this.lbl_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rg.Location = new System.Drawing.Point(272, 196);
            this.lbl_rg.Name = "lbl_rg";
            this.lbl_rg.Size = new System.Drawing.Size(37, 24);
            this.lbl_rg.TabIndex = 196;
            this.lbl_rg.Text = "RG";
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cpf.Location = new System.Drawing.Point(35, 196);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(47, 24);
            this.lbl_cpf.TabIndex = 195;
            this.lbl_cpf.Text = "CPF";
            // 
            // txt_orgao_emissor
            // 
            this.txt_orgao_emissor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_orgao_emissor.Location = new System.Drawing.Point(483, 223);
            this.txt_orgao_emissor.Name = "txt_orgao_emissor";
            this.txt_orgao_emissor.Size = new System.Drawing.Size(134, 29);
            this.txt_orgao_emissor.TabIndex = 194;
            // 
            // comboBox_sexo
            // 
            this.comboBox_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_sexo.FormattingEnabled = true;
            this.comboBox_sexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            ""});
            this.comboBox_sexo.Location = new System.Drawing.Point(763, 38);
            this.comboBox_sexo.Name = "comboBox_sexo";
            this.comboBox_sexo.Size = new System.Drawing.Size(230, 32);
            this.comboBox_sexo.TabIndex = 218;
            // 
            // lbl_sexo
            // 
            this.lbl_sexo.AutoSize = true;
            this.lbl_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sexo.Location = new System.Drawing.Point(759, 12);
            this.lbl_sexo.Name = "lbl_sexo";
            this.lbl_sexo.Size = new System.Drawing.Size(54, 24);
            this.lbl_sexo.TabIndex = 217;
            this.lbl_sexo.Text = "Sexo";
            // 
            // lbl_sobrenome
            // 
            this.lbl_sobrenome.AutoSize = true;
            this.lbl_sobrenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sobrenome.Location = new System.Drawing.Point(508, 21);
            this.lbl_sobrenome.Name = "lbl_sobrenome";
            this.lbl_sobrenome.Size = new System.Drawing.Size(110, 24);
            this.lbl_sobrenome.TabIndex = 216;
            this.lbl_sobrenome.Text = "Sobrenome";
            // 
            // txt_sobrenome
            // 
            this.txt_sobrenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sobrenome.Location = new System.Drawing.Point(512, 42);
            this.txt_sobrenome.Name = "txt_sobrenome";
            this.txt_sobrenome.Size = new System.Drawing.Size(230, 29);
            this.txt_sobrenome.TabIndex = 215;
            // 
            // txt_nome
            // 
            this.txt_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome.Location = new System.Drawing.Point(260, 42);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(227, 29);
            this.txt_nome.TabIndex = 214;
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome.Location = new System.Drawing.Point(256, 21);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(62, 24);
            this.lbl_nome.TabIndex = 213;
            this.lbl_nome.Text = "Nome";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(761, 110);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(86, 24);
            this.lbl_email.TabIndex = 198;
            this.lbl_email.Text = "Profissão";
            // 
            // txt_profissao
            // 
            this.txt_profissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_profissao.Location = new System.Drawing.Point(763, 137);
            this.txt_profissao.Name = "txt_profissao";
            this.txt_profissao.Size = new System.Drawing.Size(185, 29);
            this.txt_profissao.TabIndex = 219;
            // 
            // txt_passaporte
            // 
            this.txt_passaporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_passaporte.Location = new System.Drawing.Point(652, 223);
            this.txt_passaporte.Mask = ">L<LLLLLLL";
            this.txt_passaporte.Name = "txt_passaporte";
            this.txt_passaporte.Size = new System.Drawing.Size(122, 29);
            this.txt_passaporte.TabIndex = 220;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(648, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 24);
            this.label13.TabIndex = 221;
            this.label13.Text = "Passaporte";
            // 
            // txt_telefone
            // 
            this.txt_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(265, 135);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(222, 29);
            this.txt_telefone.TabIndex = 193;
            // 
            // CadastroClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1204, 673);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_passaporte);
            this.Controls.Add(this.txt_profissao);
            this.Controls.Add(this.comboBox_sexo);
            this.Controls.Add(this.lbl_sexo);
            this.Controls.Add(this.lbl_sobrenome);
            this.Controls.Add(this.txt_sobrenome);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.txt_data_nascimento);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.check_pcd);
            this.Controls.Add(this.txt_rg);
            this.Controls.Add(this.txt_cpf);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.check_estrangeiro);
            this.Controls.Add(this.lbl_data_nascimento);
            this.Controls.Add(this.lbl_orgao_emissor);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.lbl_rg);
            this.Controls.Add(this.lbl_cpf);
            this.Controls.Add(this.txt_orgao_emissor);
            this.Controls.Add(this.txt_telefone);
            this.Name = "CadastroClientes";
            this.Text = "Cadastro Clientes";
            this.Controls.SetChildIndex(this.txt_telefone, 0);
            this.Controls.SetChildIndex(this.txt_orgao_emissor, 0);
            this.Controls.SetChildIndex(this.lbl_cpf, 0);
            this.Controls.SetChildIndex(this.lbl_rg, 0);
            this.Controls.SetChildIndex(this.lbl_telefone, 0);
            this.Controls.SetChildIndex(this.lbl_email, 0);
            this.Controls.SetChildIndex(this.lbl_orgao_emissor, 0);
            this.Controls.SetChildIndex(this.lbl_data_nascimento, 0);
            this.Controls.SetChildIndex(this.check_estrangeiro, 0);
            this.Controls.SetChildIndex(this.txt_email, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txt_cpf, 0);
            this.Controls.SetChildIndex(this.txt_rg, 0);
            this.Controls.SetChildIndex(this.check_pcd, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txt_data_nascimento, 0);
            this.Controls.SetChildIndex(this.lbl_nome, 0);
            this.Controls.SetChildIndex(this.txt_nome, 0);
            this.Controls.SetChildIndex(this.txt_sobrenome, 0);
            this.Controls.SetChildIndex(this.lbl_sobrenome, 0);
            this.Controls.SetChildIndex(this.lbl_sexo, 0);
            this.Controls.SetChildIndex(this.comboBox_sexo, 0);
            this.Controls.SetChildIndex(this.txt_profissao, 0);
            this.Controls.SetChildIndex(this.txt_passaporte, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txt_data_nascimento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox condicao_pagamento;
        private System.Windows.Forms.TextBox txt_cod_pagamento;
        private System.Windows.Forms.CheckBox check_pcd;
        private System.Windows.Forms.MaskedTextBox txt_rg;
        private System.Windows.Forms.MaskedTextBox txt_cpf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_pais;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.TextBox txt_cidade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_cod_cidade;
        private System.Windows.Forms.TextBox txt_logradouro;
        private System.Windows.Forms.TextBox txt_complemento;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bairro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cep;
        private System.Windows.Forms.Label lbl_cep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.CheckBox check_estrangeiro;
        private System.Windows.Forms.Label lbl_data_nascimento;
        private System.Windows.Forms.Label lbl_orgao_emissor;
        private System.Windows.Forms.Label lbl_telefone;
        private System.Windows.Forms.Label lbl_rg;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.TextBox txt_orgao_emissor;
        private System.Windows.Forms.ComboBox comboBox_sexo;
        private System.Windows.Forms.Label lbl_sexo;
        private System.Windows.Forms.Label lbl_sobrenome;
        private System.Windows.Forms.TextBox txt_sobrenome;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_profissao;
        private System.Windows.Forms.MaskedTextBox txt_passaporte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_telefone;
    }
}
