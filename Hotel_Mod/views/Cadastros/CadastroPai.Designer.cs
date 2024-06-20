namespace Hotel_Mod.views
{
    partial class CadastroPai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.status = new System.Windows.Forms.GroupBox();
            this.check_inativo = new System.Windows.Forms.CheckBox();
            this.check_ativo = new System.Windows.Forms.CheckBox();
            this.lbl_codigo = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.RichTextBox();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_sair = new System.Windows.Forms.Button();
            this.lbl_dat_ult_alt = new System.Windows.Forms.Label();
            this.txt_dat_ult_alt = new System.Windows.Forms.RichTextBox();
            this.lbl_data_cadastro = new System.Windows.Forms.Label();
            this.txt_dat_cad = new System.Windows.Forms.RichTextBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Controls.Add(this.check_inativo);
            this.status.Controls.Add(this.check_ativo);
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.status.Location = new System.Drawing.Point(754, 41);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(179, 60);
            this.status.TabIndex = 85;
            this.status.TabStop = false;
            this.status.Text = "STATUS";
            // 
            // check_inativo
            // 
            this.check_inativo.AutoSize = true;
            this.check_inativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.check_inativo.Location = new System.Drawing.Point(82, 24);
            this.check_inativo.Name = "check_inativo";
            this.check_inativo.Size = new System.Drawing.Size(82, 28);
            this.check_inativo.TabIndex = 60;
            this.check_inativo.Text = "Inativo";
            this.check_inativo.UseVisualStyleBackColor = true;
            // 
            // check_ativo
            // 
            this.check_ativo.AutoSize = true;
            this.check_ativo.Checked = true;
            this.check_ativo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_ativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.check_ativo.Location = new System.Drawing.Point(6, 24);
            this.check_ativo.Name = "check_ativo";
            this.check_ativo.Size = new System.Drawing.Size(70, 28);
            this.check_ativo.TabIndex = 59;
            this.check_ativo.Text = "Ativo";
            this.check_ativo.UseVisualStyleBackColor = true;
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.AutoSize = true;
            this.lbl_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_codigo.Location = new System.Drawing.Point(27, 12);
            this.lbl_codigo.Name = "lbl_codigo";
            this.lbl_codigo.Size = new System.Drawing.Size(71, 24);
            this.lbl_codigo.TabIndex = 84;
            this.lbl_codigo.Text = "Código";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_codigo.Location = new System.Drawing.Point(32, 43);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(211, 31);
            this.txt_codigo.TabIndex = 83;
            this.txt_codigo.Text = "";
            // 
            // btn_salvar
            // 
            this.btn_salvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btn_salvar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_salvar.Font = new System.Drawing.Font("Segoe UI", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar.ForeColor = System.Drawing.Color.White;
            this.btn_salvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.Location = new System.Drawing.Point(738, 537);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btn_salvar.Size = new System.Drawing.Size(110, 30);
            this.btn_salvar.TabIndex = 81;
            this.btn_salvar.Text = "Salvar";
            this.btn_salvar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_salvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_salvar.UseVisualStyleBackColor = false;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_sair
            // 
            this.btn_sair.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_sair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btn_sair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_sair.Font = new System.Drawing.Font("Segoe UI", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sair.ForeColor = System.Drawing.Color.White;
            this.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sair.Location = new System.Drawing.Point(854, 537);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btn_sair.Size = new System.Drawing.Size(110, 30);
            this.btn_sair.TabIndex = 82;
            this.btn_sair.Text = "Sair";
            this.btn_sair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sair.UseVisualStyleBackColor = false;
            this.btn_sair.Click += new System.EventHandler(this.btn_sair_Click);
            // 
            // lbl_dat_ult_alt
            // 
            this.lbl_dat_ult_alt.AutoSize = true;
            this.lbl_dat_ult_alt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_dat_ult_alt.Location = new System.Drawing.Point(305, 508);
            this.lbl_dat_ult_alt.Name = "lbl_dat_ult_alt";
            this.lbl_dat_ult_alt.Size = new System.Drawing.Size(145, 24);
            this.lbl_dat_ult_alt.TabIndex = 80;
            this.lbl_dat_ult_alt.Text = "Ultima Alteração";
            // 
            // txt_dat_ult_alt
            // 
            this.txt_dat_ult_alt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_dat_ult_alt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_dat_ult_alt.Location = new System.Drawing.Point(306, 537);
            this.txt_dat_ult_alt.Name = "txt_dat_ult_alt";
            this.txt_dat_ult_alt.Size = new System.Drawing.Size(211, 31);
            this.txt_dat_ult_alt.TabIndex = 79;
            this.txt_dat_ult_alt.Text = "";
            // 
            // lbl_data_cadastro
            // 
            this.lbl_data_cadastro.AutoSize = true;
            this.lbl_data_cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_data_cadastro.Location = new System.Drawing.Point(27, 508);
            this.lbl_data_cadastro.Name = "lbl_data_cadastro";
            this.lbl_data_cadastro.Size = new System.Drawing.Size(153, 24);
            this.lbl_data_cadastro.TabIndex = 78;
            this.lbl_data_cadastro.Text = "Data de Cadastro";
            // 
            // txt_dat_cad
            // 
            this.txt_dat_cad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_dat_cad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_dat_cad.Location = new System.Drawing.Point(32, 537);
            this.txt_dat_cad.Name = "txt_dat_cad";
            this.txt_dat_cad.Size = new System.Drawing.Size(211, 31);
            this.txt_dat_cad.TabIndex = 77;
            this.txt_dat_cad.Text = "";
            // 
            // CadastroPai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 583);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lbl_codigo);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.lbl_dat_ult_alt);
            this.Controls.Add(this.txt_dat_ult_alt);
            this.Controls.Add(this.lbl_data_cadastro);
            this.Controls.Add(this.txt_dat_cad);
            this.Name = "CadastroPai";
            this.Text = "CadastroPai";
            this.Load += new System.EventHandler(this.CadastroPai_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.GroupBox status;
        protected System.Windows.Forms.Label lbl_codigo;
        protected System.Windows.Forms.RichTextBox txt_codigo;
        protected System.Windows.Forms.Button btn_salvar;
        protected System.Windows.Forms.Button btn_sair;
        protected System.Windows.Forms.Label lbl_dat_ult_alt;
        protected System.Windows.Forms.RichTextBox txt_dat_ult_alt;
        protected System.Windows.Forms.Label lbl_data_cadastro;
        protected System.Windows.Forms.RichTextBox txt_dat_cad;
        protected System.Windows.Forms.CheckBox check_inativo;
        protected System.Windows.Forms.CheckBox check_ativo;
    }
}