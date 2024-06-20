using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hotel_Mod.views
{

    public partial class CadastroCliente : Hotel_Mod.views.CadastroPai
    {

        private controllerCliente<Clientes> controllerClientes;

        public CadastroCliente()
        {
            InitializeComponent();
            controllerClientes = new controllerCliente<Clientes>();

        }

        public CadastroCliente(int cliente_ID) : this()
        {
            altera = cliente_ID;
            carrega();
        }

        public override void carrega()
        {
            //verifica se há um país a ser alterado
            if (altera != -1)
            {
                Clientes clientes = controllerClientes.pesquisar(altera);
                if (clientes != null)
                {
                    txt_codigo.Text = clientes.cliente_ID.ToString();
                    txt_nome.Text = clientes.nome;
                    txt_sobrenome.Text = clientes.sobrenome;
                    txt_telefone.Text = clientes.telefone;
                    txt_numero.Text = clientes.numero;
                    txt_email.Text = clientes.email;
                    txt_cpf.Text = clientes.cpf;
                    check_pcd.Checked = clientes.tipo_pcd;
                    check_estrangeiro.Checked = clientes.estrangeriro;
                    txt_rg.Text = clientes.rg;
                    txt_cep.Text = clientes.cep;
                    txt_logradouro.Text = clientes.logradouro;
                    txt_data_nascimento.Text = clientes.data_nascimento.ToString();
                    txt_numero.Text = clientes.numero;
                    txt_complemento.Text = clientes.complemento;
                    txt_bairro.Text = clientes.bairro;
                    txt_cod_cidade.Text = clientes.cidade_ID.ToString();
                    combo_profissao.Text = clientes.profissao;
                    combo_pais.Text = clientes.pais;
                    combo_estado.Text = clientes.estado;
                    combo_cidade.Text = clientes.cidade;
                    txt_dat_cad.Text = clientes.data_cadastro.ToString();
                    txt_dat_ult_alt.Text = clientes.data_ult_alt.ToString();
                    check_ativo.Checked = clientes.ativo;
                    check_inativo.Checked = !clientes.ativo;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_nome.Text))
            {
                MessageBox.Show("Campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nome.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_sobrenome.Text))
            {
                MessageBox.Show("Campo Sobrenome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sobrenome.Focus();
            }

            else if (!validadores.CampoObrigatorio(comboBox_sexo.Text))
            {
                MessageBox.Show("Campo sexo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox_sexo.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_email.Text))
            {
                MessageBox.Show("Campo email é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_email.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_cpf.Text))
            {
                MessageBox.Show("Campo cpf é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_rg.Text))
            {
                MessageBox.Show("Campo RG é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_celular.Focus();
            }
            else if (!validadores.CampoObrigatorio(groupBox1.Text))
            {
                MessageBox.Show("PREENCHA OS CAMPOS DE ENDEREÇO.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : -1;

                if (controllerClientes.JaCadastrado(txt_cpf.Text, idAtual))
                {
                    MessageBox.Show("Cliente já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpf.Focus();
                }
                else
                {
                    try
                    {
                        int cliente_ID = int.Parse(txt_codigo.Text);
                        string nome = txt_nome.Text;
                        string sobrenome = txt_sobrenome.Text;
                        DateTime data_nascimento = DateTime.Parse(txt_data_nascimento.Text);
                        string telefone = txt_telefone.Text;
                        string cpf = txt_cpf.Text;
                        string email = txt_email.Text;
                        string rg = txt_rg.Text;
                        bool tipo_pcd = check_pcd.Checked;
                        bool estrangeriro = check_estrangeiro.Checked;
                        string profissao = combo_profissao.Text;
                        string cep = txt_cep.Text;
                        string logradouro = txt_logradouro.Text;
                        string numero = txt_numero.Text;
                        string bairro = txt_bairro.Text;
                        string complemento = txt_complemento.Text;
                        int cidade_ID = int.Parse(txt_cod_cidade.Text);
                        string cidade = combo_cidade.Text;
                        string estado = combo_estado.Text;
                        string pais = combo_pais.Text;
                        bool ativo = check_ativo.Checked;

                        DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                        DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                        Clientes novoCliente = new Clientes
                        {
                            cliente_ID = cliente_ID,
                            nome = nome,
                            sobrenome = sobrenome,
                            data_nascimento = data_nascimento,
                            telefone = telefone,
                            cpf = cpf,
                            email = email,
                            rg = rg,
                            tipo_pcd = tipo_pcd,
                            estrangeriro = estrangeriro,
                            profissao = profissao,
                            cep = cep,
                            logradouro = logradouro,
                            numero = numero,
                            bairro = bairro,
                            complemento = complemento,
                            cidade_ID = cidade_ID,
                            cidade = cidade,
                            estado = estado,
                            pais = pais,
                            ativo = ativo,
                            data_cadastro = data_cadastro,
                            data_ult_alt = data_ult_alt
                        };

                        if (altera == -1)
                        {
                            controllerClientes.salvar(novoCliente);
                        }
                        else
                        {
                            novoCliente.cliente_ID = altera; // ID do país alterado
                            controllerClientes.alterar(novoCliente);
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_nome.Clear();
            txt_sobrenome.Clear();
            txt_data_nascimento.Clear();
            txt_telefone.Clear();
            txt_cpf.Clear();
            txt_email.Clear();
            txt_rg.Clear();
            check_pcd.Checked = false;
            check_estrangeiro.Checked = false;
            combo_profissao.SelectedIndex = -1;  // Se combo_profissao for um ComboBox
            txt_cep.Clear();
            txt_logradouro.Clear();
            txt_numero.Clear();
            txt_bairro.Clear();
            txt_complemento.Clear();
            txt_cod_cidade.Clear();
            combo_cidade.SelectedIndex = -1;  // Se combo_cidade for um ComboBox
            combo_estado.SelectedIndex = -1;  // Se combo_estado for um ComboBox
            combo_pais.SelectedIndex = -1;  // Se combo_pais for um ComboBox
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
            check_inativo.Checked = false;
        }

        public void SetID(int id)
        {
            altera = id;
        }

        

        private void CadastroCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            //atualiza a consulta de países ao fechar o formulário de cadastro
            ((ConsultaCliente)this.Owner).AtualizarConsultaPaises(false);

        }

      
    }
}









