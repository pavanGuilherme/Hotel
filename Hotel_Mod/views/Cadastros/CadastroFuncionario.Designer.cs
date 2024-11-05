namespace Hotel_Mod.views.Cadastros
{
    partial class CadastroFuncionario
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
            this.txt_rg = new System.Windows.Forms.MaskedTextBox();
            this.txt_cpf = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_pais = new System.Windows.Forms.TextBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.txt_uf = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
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
            this.lbl_data_nascimento = new System.Windows.Forms.Label();
            this.lbl_rg = new System.Windows.Forms.Label();
            this.lbl_cpf = new System.Windows.Forms.Label();
            this.comboBox_sexo = new System.Windows.Forms.ComboBox();
            this.lbl_sexo = new System.Windows.Forms.Label();
            this.lbl_sobrenome = new System.Windows.Forms.Label();
            this.txt_sobrenome = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_celular = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_telefone = new System.Windows.Forms.Label();
            this.txt_telefone = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDataDemissao = new System.Windows.Forms.Label();
            this.lblDataAdmissao = new System.Windows.Forms.Label();
            this.txt_data_demissao = new System.Windows.Forms.MaskedTextBox();
            this.txt_data_admissao = new System.Windows.Forms.MaskedTextBox();
            this.lblPis = new System.Windows.Forms.Label();
            this.lblSalario = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txt_pis = new System.Windows.Forms.TextBox();
            this.txt_salario = new System.Windows.Forms.TextBox();
            this.txt_cargo = new System.Windows.Forms.TextBox();
            this.status.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(1019, 23);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(31, 41);
            // 
            // btn_salvar
            // 
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.Location = new System.Drawing.Point(985, 603);
            // 
            // btn_sair
            // 
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.Location = new System.Drawing.Point(1101, 603);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(305, 566);
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(305, 593);
            this.txt_dat_ult_alt.Text = "24/06/2024 19:13:48";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.Location = new System.Drawing.Point(27, 566);
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Location = new System.Drawing.Point(31, 593);
            this.txt_dat_cad.Text = "24/06/2024 19:13:48";
            // 
            // txt_data_nascimento
            // 
            this.txt_data_nascimento.Location = new System.Drawing.Point(305, 121);
            this.txt_data_nascimento.Mask = "____ /_____ / ______";
            this.txt_data_nascimento.Name = "txt_data_nascimento";
            this.txt_data_nascimento.Size = new System.Drawing.Size(124, 20);
            this.txt_data_nascimento.TabIndex = 205;
            // 
            // txt_rg
            // 
            this.txt_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rg.Location = new System.Drawing.Point(166, 121);
            this.txt_rg.Mask = "________-_";
            this.txt_rg.Name = "txt_rg";
            this.txt_rg.Size = new System.Drawing.Size(99, 26);
            this.txt_rg.TabIndex = 204;
            this.txt_rg.Leave += new System.EventHandler(this.txt_rg_Leave);
            // 
            // txt_cpf
            // 
            this.txt_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(31, 121);
            this.txt_cpf.Mask = "_________-__";
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(103, 26);
            this.txt_cpf.TabIndex = 203;
            this.txt_cpf.Leave += new System.EventHandler(this.txt_cpf_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_pais);
            this.groupBox1.Controls.Add(this.lblUF);
            this.groupBox1.Controls.Add(this.txt_uf);
            this.groupBox1.Controls.Add(this.lblCidade);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1156, 175);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço ";
            // 
            // txt_pais
            // 
            this.txt_pais.Enabled = false;
            this.txt_pais.Location = new System.Drawing.Point(622, 134);
            this.txt_pais.Name = "txt_pais";
            this.txt_pais.Size = new System.Drawing.Size(141, 26);
            this.txt_pais.TabIndex = 191;
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblUF.Location = new System.Drawing.Point(510, 112);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(35, 24);
            this.lblUF.TabIndex = 193;
            this.lblUF.Text = "UF";
            // 
            // txt_uf
            // 
            this.txt_uf.Enabled = false;
            this.txt_uf.Location = new System.Drawing.Point(513, 134);
            this.txt_uf.Name = "txt_uf";
            this.txt_uf.Size = new System.Drawing.Size(61, 26);
            this.txt_uf.TabIndex = 190;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblCidade.Location = new System.Drawing.Point(288, 111);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(70, 24);
            this.lblCidade.TabIndex = 192;
            this.lblCidade.Text = "Cidade";
            // 
            // txt_cidade
            // 
            this.txt_cidade.Enabled = false;
            this.txt_cidade.Location = new System.Drawing.Point(292, 134);
            this.txt_cidade.Name = "txt_cidade";
            this.txt_cidade.Size = new System.Drawing.Size(180, 26);
            this.txt_cidade.TabIndex = 189;
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
            this.label4.Location = new System.Drawing.Point(618, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 171;
            this.label4.Text = "País";
            // 
            // lbl_data_nascimento
            // 
            this.lbl_data_nascimento.AutoSize = true;
            this.lbl_data_nascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_data_nascimento.Location = new System.Drawing.Point(301, 86);
            this.lbl_data_nascimento.Name = "lbl_data_nascimento";
            this.lbl_data_nascimento.Size = new System.Drawing.Size(179, 24);
            this.lbl_data_nascimento.TabIndex = 197;
            this.lbl_data_nascimento.Text = "Data de Nascimento";
            // 
            // lbl_rg
            // 
            this.lbl_rg.AutoSize = true;
            this.lbl_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rg.Location = new System.Drawing.Point(162, 86);
            this.lbl_rg.Name = "lbl_rg";
            this.lbl_rg.Size = new System.Drawing.Size(37, 24);
            this.lbl_rg.TabIndex = 194;
            this.lbl_rg.Text = "RG";
            // 
            // lbl_cpf
            // 
            this.lbl_cpf.AutoSize = true;
            this.lbl_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cpf.Location = new System.Drawing.Point(28, 86);
            this.lbl_cpf.Name = "lbl_cpf";
            this.lbl_cpf.Size = new System.Drawing.Size(47, 24);
            this.lbl_cpf.TabIndex = 193;
            this.lbl_cpf.Text = "CPF";
            // 
            // comboBox_sexo
            // 
            this.comboBox_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_sexo.FormattingEnabled = true;
            this.comboBox_sexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            ""});
            this.comboBox_sexo.Location = new System.Drawing.Point(780, 41);
            this.comboBox_sexo.Name = "comboBox_sexo";
            this.comboBox_sexo.Size = new System.Drawing.Size(134, 32);
            this.comboBox_sexo.TabIndex = 211;
            // 
            // lbl_sexo
            // 
            this.lbl_sexo.AutoSize = true;
            this.lbl_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sexo.Location = new System.Drawing.Point(776, 10);
            this.lbl_sexo.Name = "lbl_sexo";
            this.lbl_sexo.Size = new System.Drawing.Size(54, 24);
            this.lbl_sexo.TabIndex = 210;
            this.lbl_sexo.Text = "Sexo";
            // 
            // lbl_sobrenome
            // 
            this.lbl_sobrenome.AutoSize = true;
            this.lbl_sobrenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sobrenome.Location = new System.Drawing.Point(526, 7);
            this.lbl_sobrenome.Name = "lbl_sobrenome";
            this.lbl_sobrenome.Size = new System.Drawing.Size(110, 24);
            this.lbl_sobrenome.TabIndex = 209;
            this.lbl_sobrenome.Text = "Sobrenome";
            // 
            // txt_sobrenome
            // 
            this.txt_sobrenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sobrenome.Location = new System.Drawing.Point(529, 41);
            this.txt_sobrenome.Name = "txt_sobrenome";
            this.txt_sobrenome.Size = new System.Drawing.Size(230, 29);
            this.txt_sobrenome.TabIndex = 208;
            this.txt_sobrenome.Leave += new System.EventHandler(this.txt_sobrenome_Leave);
            // 
            // txt_nome
            // 
            this.txt_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome.Location = new System.Drawing.Point(277, 41);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(227, 29);
            this.txt_nome.TabIndex = 207;
            this.txt_nome.Leave += new System.EventHandler(this.txt_nome_Leave);
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nome.Location = new System.Drawing.Point(274, 7);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(62, 24);
            this.lbl_nome.TabIndex = 206;
            this.lbl_nome.Text = "Nome";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(276, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 24);
            this.label9.TabIndex = 217;
            this.label9.Text = "Celular";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 24);
            this.label8.TabIndex = 216;
            this.label8.Text = "E-mail";
            // 
            // txt_celular
            // 
            this.txt_celular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_celular.Location = new System.Drawing.Point(280, 358);
            this.txt_celular.Name = "txt_celular";
            this.txt_celular.Size = new System.Drawing.Size(204, 29);
            this.txt_celular.TabIndex = 215;
            this.txt_celular.Leave += new System.EventHandler(this.txt_celular_Leave);
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(35, 360);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(230, 29);
            this.txt_email.TabIndex = 214;
            // 
            // lbl_telefone
            // 
            this.lbl_telefone.AutoSize = true;
            this.lbl_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_telefone.Location = new System.Drawing.Point(538, 335);
            this.lbl_telefone.Name = "lbl_telefone";
            this.lbl_telefone.Size = new System.Drawing.Size(85, 24);
            this.lbl_telefone.TabIndex = 213;
            this.lbl_telefone.Text = "Telefone";
            // 
            // txt_telefone
            // 
            this.txt_telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_telefone.Location = new System.Drawing.Point(540, 360);
            this.txt_telefone.Name = "txt_telefone";
            this.txt_telefone.Size = new System.Drawing.Size(184, 29);
            this.txt_telefone.TabIndex = 212;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDataDemissao);
            this.groupBox2.Controls.Add(this.lblDataAdmissao);
            this.groupBox2.Controls.Add(this.txt_data_demissao);
            this.groupBox2.Controls.Add(this.txt_data_admissao);
            this.groupBox2.Controls.Add(this.lblPis);
            this.groupBox2.Controls.Add(this.lblSalario);
            this.groupBox2.Controls.Add(this.lblCargo);
            this.groupBox2.Controls.Add(this.txt_pis);
            this.groupBox2.Controls.Add(this.txt_salario);
            this.groupBox2.Controls.Add(this.txt_cargo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(27, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1156, 143);
            this.groupBox2.TabIndex = 218;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // lblDataDemissao
            // 
            this.lblDataDemissao.AutoSize = true;
            this.lblDataDemissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblDataDemissao.Location = new System.Drawing.Point(850, 52);
            this.lblDataDemissao.Name = "lblDataDemissao";
            this.lblDataDemissao.Size = new System.Drawing.Size(93, 24);
            this.lblDataDemissao.TabIndex = 104;
            this.lblDataDemissao.Text = "Demissão";
            // 
            // lblDataAdmissao
            // 
            this.lblDataAdmissao.AutoSize = true;
            this.lblDataAdmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblDataAdmissao.Location = new System.Drawing.Point(726, 52);
            this.lblDataAdmissao.Name = "lblDataAdmissao";
            this.lblDataAdmissao.Size = new System.Drawing.Size(105, 24);
            this.lblDataAdmissao.TabIndex = 103;
            this.lblDataAdmissao.Text = "Admissão *";
            // 
            // txt_data_demissao
            // 
            this.txt_data_demissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_demissao.Location = new System.Drawing.Point(853, 68);
            this.txt_data_demissao.Mask = "00/00/0000";
            this.txt_data_demissao.Name = "txt_data_demissao";
            this.txt_data_demissao.Size = new System.Drawing.Size(90, 29);
            this.txt_data_demissao.TabIndex = 102;
            this.txt_data_demissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_demissao.ValidatingType = typeof(System.DateTime);
            // 
            // txt_data_admissao
            // 
            this.txt_data_admissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_data_admissao.Location = new System.Drawing.Point(726, 68);
            this.txt_data_admissao.Mask = "00/00/0000";
            this.txt_data_admissao.Name = "txt_data_admissao";
            this.txt_data_admissao.Size = new System.Drawing.Size(83, 29);
            this.txt_data_admissao.TabIndex = 101;
            this.txt_data_admissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_data_admissao.ValidatingType = typeof(System.DateTime);
            // 
            // lblPis
            // 
            this.lblPis.AutoSize = true;
            this.lblPis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblPis.Location = new System.Drawing.Point(493, 52);
            this.lblPis.Name = "lblPis";
            this.lblPis.Size = new System.Drawing.Size(50, 24);
            this.lblPis.TabIndex = 100;
            this.lblPis.Text = "PIS *";
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblSalario.Location = new System.Drawing.Point(317, 52);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(79, 24);
            this.lblSalario.TabIndex = 99;
            this.lblSalario.Text = "Salário *";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblCargo.Location = new System.Drawing.Point(10, 52);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(73, 24);
            this.lblCargo.TabIndex = 98;
            this.lblCargo.Text = "Cargo *";
            // 
            // txt_pis
            // 
            this.txt_pis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_pis.Location = new System.Drawing.Point(496, 68);
            this.txt_pis.MaxLength = 14;
            this.txt_pis.Name = "txt_pis";
            this.txt_pis.Size = new System.Drawing.Size(100, 29);
            this.txt_pis.TabIndex = 97;
            // 
            // txt_salario
            // 
            this.txt_salario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_salario.Location = new System.Drawing.Point(320, 68);
            this.txt_salario.Name = "txt_salario";
            this.txt_salario.Size = new System.Drawing.Size(137, 29);
            this.txt_salario.TabIndex = 96;
            // 
            // txt_cargo
            // 
            this.txt_cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cargo.Location = new System.Drawing.Point(13, 68);
            this.txt_cargo.MaxLength = 50;
            this.txt_cargo.Name = "txt_cargo";
            this.txt_cargo.Size = new System.Drawing.Size(258, 29);
            this.txt_cargo.TabIndex = 95;
            // 
            // CadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1223, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_celular);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.lbl_telefone);
            this.Controls.Add(this.txt_telefone);
            this.Controls.Add(this.comboBox_sexo);
            this.Controls.Add(this.lbl_sexo);
            this.Controls.Add(this.lbl_sobrenome);
            this.Controls.Add(this.txt_sobrenome);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.txt_data_nascimento);
            this.Controls.Add(this.txt_rg);
            this.Controls.Add(this.txt_cpf);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_data_nascimento);
            this.Controls.Add(this.lbl_rg);
            this.Controls.Add(this.lbl_cpf);
            this.Name = "CadastroFuncionario";
            this.Text = "Cadastro Funcionários";
            this.Load += new System.EventHandler(this.CadastroFuncionario_Load);
            this.Controls.SetChildIndex(this.lbl_cpf, 0);
            this.Controls.SetChildIndex(this.lbl_rg, 0);
            this.Controls.SetChildIndex(this.lbl_data_nascimento, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txt_cpf, 0);
            this.Controls.SetChildIndex(this.txt_rg, 0);
            this.Controls.SetChildIndex(this.txt_data_nascimento, 0);
            this.Controls.SetChildIndex(this.lbl_nome, 0);
            this.Controls.SetChildIndex(this.txt_nome, 0);
            this.Controls.SetChildIndex(this.txt_sobrenome, 0);
            this.Controls.SetChildIndex(this.lbl_sobrenome, 0);
            this.Controls.SetChildIndex(this.lbl_sexo, 0);
            this.Controls.SetChildIndex(this.comboBox_sexo, 0);
            this.Controls.SetChildIndex(this.txt_dat_cad, 0);
            this.Controls.SetChildIndex(this.lbl_data_cadastro, 0);
            this.Controls.SetChildIndex(this.txt_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.lbl_dat_ult_alt, 0);
            this.Controls.SetChildIndex(this.btn_sair, 0);
            this.Controls.SetChildIndex(this.btn_salvar, 0);
            this.Controls.SetChildIndex(this.txt_codigo, 0);
            this.Controls.SetChildIndex(this.lbl_codigo, 0);
            this.Controls.SetChildIndex(this.status, 0);
            this.Controls.SetChildIndex(this.txt_telefone, 0);
            this.Controls.SetChildIndex(this.lbl_telefone, 0);
            this.Controls.SetChildIndex(this.txt_email, 0);
            this.Controls.SetChildIndex(this.txt_celular, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox txt_data_nascimento;
        private System.Windows.Forms.MaskedTextBox txt_rg;
        private System.Windows.Forms.MaskedTextBox txt_cpf;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label lbl_data_nascimento;
        private System.Windows.Forms.Label lbl_rg;
        private System.Windows.Forms.Label lbl_cpf;
        private System.Windows.Forms.ComboBox comboBox_sexo;
        private System.Windows.Forms.Label lbl_sexo;
        private System.Windows.Forms.Label lbl_sobrenome;
        private System.Windows.Forms.TextBox txt_sobrenome;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_celular;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_telefone;
        private System.Windows.Forms.TextBox txt_telefone;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label lblDataDemissao;
        protected System.Windows.Forms.Label lblDataAdmissao;
        protected System.Windows.Forms.MaskedTextBox txt_data_demissao;
        protected System.Windows.Forms.MaskedTextBox txt_data_admissao;
        protected System.Windows.Forms.Label lblPis;
        protected System.Windows.Forms.Label lblSalario;
        protected System.Windows.Forms.Label lblCargo;
        protected System.Windows.Forms.TextBox txt_pis;
        protected System.Windows.Forms.TextBox txt_salario;
        protected System.Windows.Forms.TextBox txt_cargo;
        protected System.Windows.Forms.TextBox txt_pais;
        protected System.Windows.Forms.Label lblUF;
        protected System.Windows.Forms.TextBox txt_uf;
        protected System.Windows.Forms.Label lblCidade;
        protected System.Windows.Forms.TextBox txt_cidade;
    }
}
