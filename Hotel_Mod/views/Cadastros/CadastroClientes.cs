using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroClientes : Hotel_Mod.views.CadastroPai
    {

        private ConsultaCidades consultaCidades;
        private controllerCliente<Clientes> controllerCliente;
        private controllerCondPagamento<CondicaoPagamento> ControllerCondicaoPagamento;
        private ConsultaCondPagamento consultaCondPagamento;

        


        public CadastroClientes()
        {

            controllerCliente = new controllerCliente<Clientes>();
            consultaCidades = new ConsultaCidades();
            consultaCondPagamento = new ConsultaCondPagamento();
            InitializeComponent();
            check_fisica.Checked = true;
            check_juridica.Checked = false;
        }

        public CadastroClientes(int cliente_ID) : this()
        {
            altera = cliente_ID;
            carrega();

        }

        public override void carrega()
        {
            // Verifica se há um cliente a ser alterado
            if (altera != -1)
            {
                Clientes clientes = controllerCliente.GetById(altera);
                if (clientes != null)
                {
                    PreencherCampos(clientes);
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Clientes PreencherCliente()
        {
            return new Clientes
            {
                nome = txt_nome.Text,
                apelido = txt_apelido.Text,
                data_nascimento = DateTime.Parse(txt_data_nascimento.Text),
                telefone = txt_telefone.Text,
                celular = txt_celular.Text,
                cpf = txt_cpf.Text,
                email = txt_email.Text,
                rg = txt_rg.Text,
                cep = txt_cep.Text,
                logradouro = txt_logradouro.Text,
                numero = txt_numero.Text,
                bairro = txt_bairro.Text,
                complemento = txt_complemento.Text,
                cidade_id = int.Parse(txt_cod_cidade.Text),
                ativo = ativo,
                data_cadastro = DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro) ? dataCadastro : DateTime.Now,
                data_ult_alt = DateTime.Now
            };
        }

        private void PreencherCampos(Clientes clientes)
        {
            txt_codigo.Text = clientes.cliente_ID.ToString();
            txt_nome.Text = clientes.nome;
            txt_apelido.Text = clientes.apelido;
            txt_telefone.Text = clientes.telefone;
            txt_celular.Text = clientes.celular;
            txt_numero.Text = clientes.numero;
            txt_email.Text = clientes.email;
            txt_cpf.Text = clientes.cpf;
            txt_rg.Text = clientes.rg;
            txt_cep.Text = clientes.cep;
            txt_logradouro.Text = clientes.logradouro;
            txt_data_nascimento.Text = clientes.data_nascimento.ToString();
            txt_complemento.Text = clientes.complemento;
            txt_bairro.Text = clientes.bairro;
            txt_cod_cidade.Text = clientes.cidade_id.ToString();
            txt_dat_cad.Text = clientes.data_cadastro.ToString();
            txt_dat_ult_alt.Text = clientes.data_ult_alt.ToString();
            check_ativo.Checked = clientes.ativo;
            check_inativo.Checked = !clientes.ativo;
            check_juridica.Checked.ToString();
            check_fisica.Checked.ToString();
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_nome.Text))
            {
                MessageBox.Show("Campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nome.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_apelido.Text))
            {
                MessageBox.Show("Campo apelido é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_apelido.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_sexo.Text))
            {
                MessageBox.Show("Campo sexo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sexo.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_email.Text))
            {
                MessageBox.Show("Campo email é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_email.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_cpf.Text))
            {
                MessageBox.Show("Campo CPF é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
            }
            else if (!validadores.CampoObrigatorio(txt_rg.Text))
            {
                MessageBox.Show("Campo RG é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_rg.Focus();
            }
            else if (!validadores.CampoObrigatorio(groupBox1.Text))
            {
                MessageBox.Show("PREENCHA OS CAMPOS DE ENDEREÇO.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : 0;

                if (controllerCliente.JaCadastrado(txt_cpf.Text, idAtual))
                {
                    MessageBox.Show("Cliente já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpf.Focus();
                }
                else
                {
                    try
                    {
                        Clientes novoCliente = PreencherCliente();

                        if (altera == -1)
                        {
                            controllerCliente.salvar(novoCliente);
                        }
                        else
                        {
                            controllerCliente.alterar(novoCliente);
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

      
        private void check_ativo_CheckedChanged(object sender, EventArgs e)
        {
            ativo = check_ativo.Checked;
        }

        private void check_inativo_CheckedChanged(object sender, EventArgs e)
        {
            ativo = !check_inativo.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultaCidades.btn_sair.Text = "Selecionar";

            if (consultaCidades.ShowDialog() == DialogResult.OK)
            {
                var cidadeDetalhes = consultaCidades.Tag as Tuple<int, string>;

                if (cidadeDetalhes != null)
                {
                    int cidadeID = cidadeDetalhes.Item1;
                    string cidadeNome = cidadeDetalhes.Item2;

                    txt_cod_cidade.Text = cidadeID.ToString();
                    txt_cidade.Text = cidadeNome;

                    List<string> cidadeEstadoPais = controllerCliente.GetCidadeEstadoEPaisByCidadeId(cidadeID);

                    if (cidadeEstadoPais.Count > 0)
                    {
                        string[] info = cidadeEstadoPais[0].Split(',');
                        if (info.Length >= 3)
                        {
                            txt_estado.Text = info[1].Trim();
                            txt_pais.Text = info[2].Trim();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultaCondPagamento.btn_sair.Text = "Selecionar";

            if (consultaCondPagamento.ShowDialog() == DialogResult.OK)
            {
                // Receber os detalhes da condição de pagamento selecionada
                var condPagamentoDetalhes = consultaCondPagamento.Tag as Tuple<int, string>;
                if (condPagamentoDetalhes != null)
                {
                    int condPagamento_ID = condPagamentoDetalhes.Item1;
                    string condicaoPagamento = condPagamentoDetalhes.Item2;

                    // Atualizar os campos com os valores corretos
                    txt_cod_cond_pagamento.Text = condPagamento_ID.ToString(); // Atualiza o campo Código com o ID
                    txt_condicao_pagamento.Text = condicaoPagamento; // Atualiza o campo Condição de Pagamento com o nome
                }
            }

        }

        private void check_fisica_CheckedChanged(object sender, EventArgs e)
        {
       
            check_juridica.Checked = false;
            lbl_apelido.Text = "Apelido";
            lbl_cpf.Text = "CPF";
            lbl_rg.Text = "RG";
        }

        private void check_juridica_CheckedChanged(object sender, EventArgs e)
        {
        
            check_fisica.Checked = false;
            lbl_apelido.Text = "Apelido";
            lbl_cpf.Text = "CNPJ";
            lbl_rg.Text = "IE";
        }
    }
}
