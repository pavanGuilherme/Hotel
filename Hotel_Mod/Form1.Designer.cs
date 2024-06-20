namespace Hotel_Mod
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quartosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paísToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reservas = new System.Windows.Forms.Button();
            this.btn_vendas = new System.Windows.Forms.Button();
            this.btn_gastos = new System.Windows.Forms.Button();
            this.btn_hospedes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1286, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.quartosToolStripMenuItem,
            this.usuáriosToolStripMenuItem,
            this.formasDePagamentoToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.paísToolStripMenuItem,
            this.estadoToolStripMenuItem,
            this.cidadeToolStripMenuItem,
            this.serviçosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cadastrosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cadastrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cadastrosToolStripMenuItem.Image")));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(107, 25);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // quartosToolStripMenuItem
            // 
            this.quartosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.quartosToolStripMenuItem.Name = "quartosToolStripMenuItem";
            this.quartosToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.quartosToolStripMenuItem.Text = "Quartos";
            this.quartosToolStripMenuItem.Click += new System.EventHandler(this.quartosToolStripMenuItem_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            this.usuáriosToolStripMenuItem.Click += new System.EventHandler(this.usuáriosToolStripMenuItem_Click);
            // 
            // formasDePagamentoToolStripMenuItem
            // 
            this.formasDePagamentoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formasDePagamentoToolStripMenuItem.Name = "formasDePagamentoToolStripMenuItem";
            this.formasDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.formasDePagamentoToolStripMenuItem.Text = "Formas de Pagamento";
            this.formasDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formasDePagamentoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.sairToolStripMenuItem.Text = "Condição de Pagamento";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            this.funcionáriosToolStripMenuItem.Click += new System.EventHandler(this.funcionáriosToolStripMenuItem_Click);
            // 
            // paísToolStripMenuItem
            // 
            this.paísToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.paísToolStripMenuItem.Name = "paísToolStripMenuItem";
            this.paísToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.paísToolStripMenuItem.Text = "País";
            this.paísToolStripMenuItem.Click += new System.EventHandler(this.paísToolStripMenuItem_Click);
            // 
            // estadoToolStripMenuItem
            // 
            this.estadoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            this.estadoToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.estadoToolStripMenuItem.Text = "Estado";
            this.estadoToolStripMenuItem.Click += new System.EventHandler(this.estadoToolStripMenuItem_Click);
            // 
            // cidadeToolStripMenuItem
            // 
            this.cidadeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cidadeToolStripMenuItem.Name = "cidadeToolStripMenuItem";
            this.cidadeToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.cidadeToolStripMenuItem.Text = "Cidade";
            this.cidadeToolStripMenuItem.Click += new System.EventHandler(this.cidadeToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fornecedorToolStripMenuItem,
            this.produtosToolStripMenuItem1});
            this.produtosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.produtosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("produtosToolStripMenuItem.Image")));
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(101, 25);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // fornecedorToolStripMenuItem
            // 
            this.fornecedorToolStripMenuItem.Name = "fornecedorToolStripMenuItem";
            this.fornecedorToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.fornecedorToolStripMenuItem.Text = "Fornecedor";
            // 
            // produtosToolStripMenuItem1
            // 
            this.produtosToolStripMenuItem1.Name = "produtosToolStripMenuItem1";
            this.produtosToolStripMenuItem1.Size = new System.Drawing.Size(159, 26);
            this.produtosToolStripMenuItem1.Text = "Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.btn_reservas);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn_vendas);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_gastos);
            this.panel1.Controls.Add(this.btn_hospedes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 666);
            this.panel1.TabIndex = 2;
            // 
            // btn_reservas
            // 
            this.btn_reservas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btn_reservas.FlatAppearance.BorderSize = 0;
            this.btn_reservas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reservas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reservas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_reservas.Image = ((System.Drawing.Image)(resources.GetObject("btn_reservas.Image")));
            this.btn_reservas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reservas.Location = new System.Drawing.Point(0, 143);
            this.btn_reservas.Name = "btn_reservas";
            this.btn_reservas.Size = new System.Drawing.Size(231, 64);
            this.btn_reservas.TabIndex = 7;
            this.btn_reservas.Text = "   Reservas";
            this.btn_reservas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reservas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reservas.UseVisualStyleBackColor = false;
            // 
            // btn_vendas
            // 
            this.btn_vendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btn_vendas.FlatAppearance.BorderSize = 0;
            this.btn_vendas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_vendas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_vendas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_vendas.Image = ((System.Drawing.Image)(resources.GetObject("btn_vendas.Image")));
            this.btn_vendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_vendas.Location = new System.Drawing.Point(0, 283);
            this.btn_vendas.Name = "btn_vendas";
            this.btn_vendas.Size = new System.Drawing.Size(231, 64);
            this.btn_vendas.TabIndex = 9;
            this.btn_vendas.Text = "   Vendas";
            this.btn_vendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_vendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_vendas.UseVisualStyleBackColor = false;
            // 
            // btn_gastos
            // 
            this.btn_gastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btn_gastos.FlatAppearance.BorderSize = 0;
            this.btn_gastos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_gastos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_gastos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_gastos.Image = ((System.Drawing.Image)(resources.GetObject("btn_gastos.Image")));
            this.btn_gastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gastos.Location = new System.Drawing.Point(-3, 353);
            this.btn_gastos.Name = "btn_gastos";
            this.btn_gastos.Size = new System.Drawing.Size(234, 64);
            this.btn_gastos.TabIndex = 10;
            this.btn_gastos.Text = "   Gastos";
            this.btn_gastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_gastos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_gastos.UseVisualStyleBackColor = false;
            // 
            // btn_hospedes
            // 
            this.btn_hospedes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btn_hospedes.FlatAppearance.BorderSize = 0;
            this.btn_hospedes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hospedes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_hospedes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_hospedes.Image = ((System.Drawing.Image)(resources.GetObject("btn_hospedes.Image")));
            this.btn_hospedes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hospedes.Location = new System.Drawing.Point(0, 213);
            this.btn_hospedes.Name = "btn_hospedes";
            this.btn_hospedes.Size = new System.Drawing.Size(231, 64);
            this.btn_hospedes.TabIndex = 8;
            this.btn_hospedes.Text = "   Hóspedes";
            this.btn_hospedes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hospedes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_hospedes.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 64);
            this.button1.TabIndex = 8;
            this.button1.Text = "   Reservas";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 64);
            this.button2.TabIndex = 9;
            this.button2.Text = "   Reservas";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.menuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuToolStripMenuItem.Image")));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(65, 25);
            this.menuToolStripMenuItem.Text = "Sai&r";
            this.menuToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 695);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quartosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem paísToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadeToolStripMenuItem;
        private System.Windows.Forms.Button btn_reservas;
        private System.Windows.Forms.Button btn_vendas;
        private System.Windows.Forms.Button btn_gastos;
        private System.Windows.Forms.Button btn_hospedes;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
    }
}