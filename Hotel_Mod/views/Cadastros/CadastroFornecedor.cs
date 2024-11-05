using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroFornecedor : Hotel_Mod.views.CadastroPai
    {

        public bool Ativo = true;
        public bool Fisico = true;
        private ControllerFornecedor<Fornecedor> controllerFornecedor;
        private ConsultaCidades consultaCidades;




        public CadastroFornecedor()
        {
            InitializeComponent();
            controllerFornecedor = new ControllerFornecedor<Fornecedor>();
            consultaCidades = new ConsultaCidades();
        }


        public CadastroFornecedor(int idFornecedor) : this()
        {
            // Verifica se há um cliente a ser alterado
            if (altera != -1)
            {
                Fornecedor fornecedor = controllerFornecedor.GetById(altera);
                if (fornecedor != null)
                {
                    PreencherCampos(fornecedor);
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Fornecedor PreencherFornecedor()
        {
            return new Fornecedor
            {
                fornecedor_ID = int.TryParse(txt_codigo.Text, out int id) ? id : 0,
                fornecedor_razao_social = txt_nome_fantasia.Text,
                nome_contato = txt_contato.Text,
                telefone = txt_telefone.Text,
                email = txt_email.Text,
                cpf_cnpj = txt_cpf_cnpj.Text,
                logradouro = txt_logradouro.Text,
                numero = int.TryParse(txt_numero.Text, out int numero) ? numero: 0 ,
                bairro = txt_bairro.Text,
                cidade_ID = int.TryParse(txt_cod_cidade.Text, out int cidadeId) ? cidadeId : 0,
                cep = txt_cep.Text,
                Ativo = check_ativo.Checked,
                dataCadastro = DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro) ? dataCadastro : DateTime.Now,
                dataUltAlt = DateTime.Now
            };
        }

        private void PreencherCampos(Fornecedor fornecedor)
        {
            txt_codigo.Text = fornecedor.fornecedor_ID.ToString();
            txt_nome_fantasia.Text = fornecedor.apelido_nome_fantasia;
            txt_contato.Text = fornecedor.nome_contato;
            txt_telefone.Text = fornecedor.telefone;
            txt_email.Text = fornecedor.email;
            txt_cpf_cnpj.Text = fornecedor.cpf_cnpj;
            txt_logradouro.Text = fornecedor.logradouro;
            txt_numero.Text = fornecedor.numero.ToString();
            txt_bairro.Text = fornecedor.bairro;
            txt_cod_cidade.Text = fornecedor.cidade_ID.ToString();
            txt_cep.Text = fornecedor.cep;
            txt_dat_cad.Text = fornecedor.dataCadastro.ToString("dd/MM/yyyy HH:mm:ss");
            txt_dat_ult_alt.Text = fornecedor.dataUltAlt.ToString("dd/MM/yyyy HH:mm:ss");

            // Configuração do status ativo/inativo
            check_ativo.Checked = fornecedor.Ativo;
            check_inativo.Checked = !fornecedor.Ativo;
        }

        protected bool VerificaCamposObrigatorios()
        {
            string cpf_cnpj = new string(txt_cpf_cnpj.Text.Where(char.IsDigit).ToArray());
            string pais = txt_pais.Text.ToLower();
            if (pais == "brasil")
            {
                if (!validadores.CampoObrigatorio(cpf_cnpj))
                {
                    MessageBox.Show("CPF / CNPJ obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpf_cnpj.Focus();
                    return false;
                }
            }
            if (!validadores.CampoObrigatorio(txt_razao_social.Text))
            {
                MessageBox.Show("Campo obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_razao_social.Focus();
                return false;
            }
            if (check_juridica.Checked)
            {
                if (!validadores.CampoObrigatorio(txt_contato.Text))
                {
                    MessageBox.Show("Campo Nome Contato é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_contato.Focus();
                    return false;
                }
            }
            string celular = new string(txt_celular.Text.Where(char.IsDigit).ToArray());
            if (!validadores.CampoObrigatorio(celular))
            {
                MessageBox.Show("Campo Celular é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_celular.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_email.Text))
            {
                MessageBox.Show("Campo Email é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_email.Focus();
                return false;
            }
            string cep = new string(txt_cep.Text.Where(char.IsDigit).ToArray());
            if (!validadores.CampoObrigatorio(cep))
            {
                MessageBox.Show("Campo CEP é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cep.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_logradouro.Text))
            {
                MessageBox.Show("Campo Endereço é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_logradouro.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_numero.Text))
            {
                MessageBox.Show("Campo Número é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_numero.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_bairro.Text))
            {
                MessageBox.Show("Campo Bairro é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_bairro.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_cod_cidade.Text))
            {
                MessageBox.Show("Campo Código Cidade é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cod_cidade.Focus();
                return false;
            }

            return true;
        }

        public override void salvar()
        {
            if (!VerificaCamposObrigatorios())
            {
                return;
            }
            int idAtual = altera != -1 ? altera : -1;
            string cpf_cnpj = new string(txt_cpf_cnpj.Text.Where(char.IsDigit).ToArray());

            if (controllerFornecedor.JaCadastrado(cpf_cnpj, idAtual))
            {
                MessageBox.Show("Fornecedor já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf_cnpj.Focus();
            }
            else
            {
                try
                {
                    string fornecedor_razao_social = txt_razao_social.Text;
                    string apelido_nome_fantasia = txt_nome_fantasia.Text;
                    string logradouro = txt_logradouro.Text;
                    string bairro = txt_bairro.Text;
                    int numero = Convert.ToInt32(txt_numero.Text);
                    string cep = new string(txt_cep.Text.Where(char.IsDigit).ToArray());
                    string complemento = txt_complemento.Text;
                    string email = txt_email.Text;
                    string telefone = new string(txt_telefone.Text.Where(char.IsDigit).ToArray());
                    string celular = new string(txt_celular.Text.Where(char.IsDigit).ToArray());
                    string nome_contato = txt_contato.Text;
                    string rg_ie = new string(txt_rg_ie.Text.Where(char.IsDigit).ToArray());
                    int cidade_ID = int.Parse(txt_cod_cidade.Text);

                    DateTime.TryParse(txt_dat_cad.Text, out DateTime dataCadastro);
                    DateTime dataUltAlt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;


                    Fornecedor novoFornecedor = new Fornecedor
                    {
                        tipo_pessoa = Fisico,
                        fornecedor_razao_social = fornecedor_razao_social,
                        apelido_nome_fantasia = apelido_nome_fantasia,
                        logradouro = logradouro,
                        bairro = bairro,
                        numero = numero,
                        cep = cep,
                        complemento = complemento,
                        email = email,
                        telefone = telefone,
                        celular = celular,
                        nome_contato = nome_contato,
                        cpf_cnpj = cpf_cnpj,
                        rg_ie = rg_ie,
                        Ativo = Ativo,
                        dataCadastro = dataCadastro,
                        dataUltAlt = dataUltAlt,
                        cidade_ID = cidade_ID
                    };

                    if (altera == -1)
                    {
                        controllerFornecedor.salvar(novoFornecedor);
                    }
                    else
                    {
                        novoFornecedor.fornecedor_ID = altera;
                        controllerFornecedor.alterar(novoFornecedor);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void carrega()
        {
            if (altera != -1)
            {
                Fornecedor fornecedor = controllerFornecedor.GetById(altera);
                if (fornecedor != null)
                {
                    txt_codigo.Text = fornecedor.fornecedor_ID.ToString();
                    check_fisica.Checked = fornecedor.tipo_pessoa;
                    check_juridica.Checked = !fornecedor.tipo_pessoa;
                    txt_razao_social.Text = fornecedor.fornecedor_razao_social;
                    txt_nome_fantasia.Text = fornecedor.apelido_nome_fantasia;
                    txt_logradouro.Text = fornecedor.logradouro;
                    txt_bairro.Text = fornecedor.bairro;
                    txt_numero.Text = fornecedor.numero.ToString();
                    txt_cep.Text = fornecedor.cep;
                    txt_complemento.Text = fornecedor.complemento;
                    txt_cod_cidade.Text = fornecedor.cidade_ID.ToString();
                    txt_email.Text = fornecedor.email;
                    txt_telefone.Text = fornecedor.telefone;
                    txt_celular.Text = fornecedor.celular;
                    txt_contato.Text = fornecedor.nome_contato;
                    txt_cpf_cnpj.Text = fornecedor.cpf_cnpj;
                    txt_rg_ie.Text = fornecedor.rg_ie;
                    txt_dat_cad.Text = fornecedor.dataCadastro.ToString();
                    txt_dat_ult_alt.Text = fornecedor.dataUltAlt.ToString();
                    check_ativo.Checked = fornecedor.Ativo;
                    check_inativo.Checked = !fornecedor.Ativo;

                    List<string> cidadeEstadoPais = controllerFornecedor.GetCidadeEstadoEPaisByCidadeId(fornecedor.cidade_ID);

                    if (cidadeEstadoPais.Count > 0)
                    {
                        string[] info = cidadeEstadoPais[0].Split(',');
                        if (info.Length >= 3)
                        {
                            txt_cidade.Text = info[0].Trim();
                            txt_estado.Text = info[1].Trim();
                            txt_pais.Text = info[2].Trim();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CadastroFornecedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaFornecedor)this.Owner).AtualizarConsultaFornecedores(false);
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

                    List<string> cidadeEstadoPais = controllerFornecedor.GetCidadeEstadoEPaisByCidadeId(cidadeID);

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
            
      
        }

        private void check_fisica_CheckedChanged(object sender, EventArgs e)
        {
           
            if (check_fisica.Checked == true)
            {
                check_juridica.Checked = false;
            }

            lbl_fornecedor.Text = "Fornecedor *";
            lbl_cpf.Text = "CPF *";
            txt_cpf_cnpj.Mask = "000.000.000-00";
            lbl_rg.Text = "RG";
            comboBox_sexo.Visible = true;
            lbl_sexo.Visible = true;
            lbl_contato.Visible = false;
            txt_contato.Visible = false;
            lbl_data_nascimento.Text = "Data Nasc.";
            txt_cpf_cnpj.Clear();

        }

        private void check_juridica_CheckedChanged(object sender, EventArgs e)
        {
            if (check_juridica.Checked == true)
            {
                check_fisica.Checked = false;
            }

            lbl_fornecedor.Text = "Razão Social *";
            lbl_apelido.Text = "Nome Fantasia";
            lbl_cpf.Text = "CNPJ *";
            txt_cpf_cnpj.Mask = "00.000.000/0000-00";
            lbl_rg.Text = "Inscrição Estadual";
            comboBox_sexo.Visible = false;
            lbl_sexo.Visible = false;
            lbl_contato.Visible = true;
            txt_contato.Visible = true;
            lbl_data_nascimento.Text = "Data Fund.";
            txt_cpf_cnpj.Clear();
        }

        private void CadastroFornecedor_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerFornecedor.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }
    }
}

