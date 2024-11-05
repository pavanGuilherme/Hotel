using Hotel_Mod.Class;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroClientes : Hotel_Mod.views.CadastroPai
    {

        private ConsultaCidades consultaCidades;
        private controllerCliente<Cliente> controllerCliente;
        private controllerCondPagamento<CondicaoPagamento> ControllerCondicaoPagamento;
        private ConsultaCondPagamento consultaCondPagamento;

        public CadastroClientes()
        {

            controllerCliente = new controllerCliente<Cliente>();
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
                Cliente clientes = controllerCliente.GetById(altera);
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

        private Cliente PreencherCliente()
        {
            return new Cliente
            {
                cliente_ID = int.TryParse(txt_codigo.Text, out int id) ? id : 0,
                nome = txt_nome.Text,
                apelido = txt_apelido.Text,
                data_nascimento = DateTime.TryParse(txt_data_nascimento.Text, out DateTime dataNascimento) ? dataNascimento : DateTime.MinValue,
                telefone = txt_telefone.Text,
                cpf = txt_cpf.Text,
                contato = txt_nome_contato.Text,
                email = txt_email.Text,
                rg = txt_rg.Text,
                cep = txt_cep.Text,
                logradouro = txt_logradouro.Text,
                numero = txt_numero.Text,
                bairro = txt_bairro.Text,
                complemento = txt_complemento.Text,
                cidade_id = int.TryParse(txt_cod_cidade.Text, out int cidadeId) ? cidadeId : 0,
                estado = txt_estado.Text,
                pais = txt_pais.Text,
                condicao_pagamento = txt_condicao_pagamento.Text,
                CondPagamento_ID = int.TryParse(txt_cod_cond_pagamento.Text, out int condPagId) ? condPagId : 0,
                sexo = txt_sexo.Text,
                tipo_pessoa = check_fisica.Checked ? "Física" : check_juridica.Checked ? "Jurídica" : string.Empty,
                ativo = check_ativo.Checked,
                data_cadastro = DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro) ? dataCadastro : DateTime.Now,
                data_ult_alt = DateTime.Now
            };
        }


        private void PreencherCampos(Cliente clientes)
        {
            txt_codigo.Text = clientes.cliente_ID.ToString();
            txt_nome.Text = clientes.nome;
            txt_apelido.Text = clientes.apelido;
            txt_telefone.Text = clientes.telefone;
            txt_numero.Text = clientes.numero;
            txt_nome_contato.Text = clientes.contato;
            txt_email.Text = clientes.email;
            txt_cpf.Text = clientes.cpf;
            txt_estado.Text = clientes.estado;
            txt_logradouro.Text = clientes.logradouro;
            txt_sexo.Text = clientes.sexo;
            txt_rg.Text = clientes.rg;
            txt_cep.Text = clientes.cep;
            txt_data_nascimento.Text = clientes.data_nascimento.ToString("dd/MM/yyyy");
            txt_complemento.Text = clientes.complemento;
            txt_bairro.Text = clientes.bairro;
            txt_cod_cidade.Text = clientes.cidade_id.ToString();
            txt_dat_cad.Text = clientes.data_cadastro.ToString("dd/MM/yyyy HH:mm:ss");
            txt_dat_ult_alt.Text = clientes.data_ult_alt.ToString("dd/MM/yyyy HH:mm:ss");

            // Configuração do status ativo/inativo
            check_ativo.Checked = clientes.ativo;
            check_inativo.Checked = !clientes.ativo;

            // Definir o tipo de pessoa (física ou jurídica)
            if (clientes.tipo_pessoa == "Física")
            {
                check_fisica.Checked = true;
                check_juridica.Checked = false;
            }
            else if (clientes.tipo_pessoa == "Jurídica")
            {
                check_fisica.Checked = false;
                check_juridica.Checked = true;
            }
            else
            {
                check_fisica.Checked = false;
                check_juridica.Checked = false;
            }
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
                        Cliente novoCliente = PreencherCliente();

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

       

        private void check_fisica_CheckedChanged(object sender, EventArgs e)
        {
            if (check_fisica.Checked == true)
            {
                check_juridica.Checked = false;
            }
       
            lbl_apelido.Text = "Apelido";
            lbl_cpf.Text = "CPF";
            lbl_rg.Text = "RG";
        }

        private void check_juridica_CheckedChanged(object sender, EventArgs e)
        {
            if (check_juridica.Checked == true)
            {
                check_fisica.Checked = false;
            }
          
            lbl_apelido.Text = "Apelido";
            lbl_cpf.Text = "CNPJ";
            lbl_rg.Text = "IE";
        }

        private void CadastroClientes_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerCliente.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }

      

        private void Btn_busca_condicao_Click(object sender, EventArgs e)
        {
            consultaCondPagamento.btn_sair.Text = "Selecionar";

            if (consultaCondPagamento.ShowDialog() == DialogResult.OK)
            {
                var condicaoPagamentoDetalhes = consultaCondPagamento.Tag as Tuple<int, string>;

                if (condicaoPagamentoDetalhes != null)
                {
                    int condicaoPagamentoID = condicaoPagamentoDetalhes.Item1;
                    string condicaoPagamentoNome = condicaoPagamentoDetalhes.Item2;

                    txt_cod_cond_pagamento.Text = condicaoPagamentoID.ToString();
                    txt_condicao_pagamento.Text = condicaoPagamentoNome;

                   
                }
            }

        }

        private void CadastroClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaCliente)this.Owner).AtualizarConsultaClientes(false);
        }
    }
}
