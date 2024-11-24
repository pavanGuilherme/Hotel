using Hotel_Mod.Controller;
using Hotel_Mod.views.Consultas;
using System;
using System.Collections.Generic;
using System.Data;
using Hotel_Mod.Models;
using System.Windows.Forms;
using System.Linq;
using Hotel_Mod.Class;



namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroFuncionario : Hotel_Mod.views.CadastroPai
    {
        private controllerFuncionario<Funcionario> controllerFuncionario;
        private ConsultaCidades consultaCidades;
        private controllerCidade<Cidade> controllerCidade; 
        private ControllerFornecedor<Fornecedor> controllerFornecedor;
        public CadastroFuncionario()
        {
            InitializeComponent();
            controllerCidade = new controllerCidade<Cidade>();
            controllerFuncionario = new controllerFuncionario<Funcionario>();
            consultaCidades = new ConsultaCidades();
        }

        public CadastroFuncionario(int funcionario_ID) : this()
        {
            altera = funcionario_ID;
            carrega();
        }

        public override void salvar()
        {
            if (!VerificaCamposObrigatorios())
            {
                return;
            }
            int idAtual = altera != -1 ? altera : -1;
            string cpf = new string(txt_cpf.Text.Where(char.IsDigit).ToArray());

            if (controllerFuncionario.JaCadastrado(cpf, idAtual))
            {
                MessageBox.Show("Funcionário já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
            }
            else
            {
                try
                {
                    string nome = txt_nome.Text;
                    string sobrenome = txt_sobrenome.Text;
                    string endereco = txt_logradouro.Text;
                    string bairro = txt_bairro.Text;
                    int numero = Convert.ToInt32(txt_numero.Text);
                    string cep = new string(txt_cep.Text.Where(char.IsDigit).ToArray());
                    string complemento = txt_complemento.Text;
                    string email = txt_email.Text;
                    string telefone = new string(txt_telefone.Text.Where(char.IsDigit).ToArray());
                    string celular = new string(txt_celular.Text.Where(char.IsDigit).ToArray());
                    string rg = new string(txt_rg.Text.Where(char.IsDigit).ToArray());
                    string cargo = txt_cargo.Text;
                    decimal salario = Convert.ToDecimal(txt_salario.Text);
                    string pis = new string(txt_pis.Text.Where(char.IsDigit).ToArray());
                    int cidade_ID = int.Parse(txt_cod_cidade.Text);
                    string sexo = comboBox_sexo.SelectedItem.ToString();

                    validadores.AtualizarCampoComDataPadrao(txt_data_nascimento, out DateTime data_nascimento);
                    validadores.AtualizarCampoComDataPadrao(txt_data_admissao, out DateTime data_admissao);
                    validadores.AtualizarCampoComDataPadrao(txt_data_demissao, out DateTime data_demissao);

                    DateTime.TryParse(txt_dat_cad.Text, out DateTime data_cadastro);
                    DateTime data_ult_alt = altera != -1 ? DateTime.Now : DateTime.TryParse(txt_dat_ult_alt.Text, out DateTime result) ? result : DateTime.MinValue;

                    Funcionario novoFuncionario = new Funcionario
                    {
                        nome = nome,
                        apelido = sobrenome,
                        endereco = endereco,
                        bairro = bairro,
                        numero = numero,
                        cep = cep,
                        complemento = complemento,
                        sexo = sexo,
                        email = email,
                        telefone = telefone,
                        celular = celular,
                        data_nascimento = data_nascimento,
                        cpf = cpf,
                        rg = rg,
                        cargo = cargo,
                        salario = salario,
                        pis = pis,
                        data_admissao = data_admissao,
                        data_demissao = data_demissao,
                        ativo = ativo,
                        data_cadastro = data_cadastro,
                        data_ult_alt = data_ult_alt,
                        cidade_id = cidade_ID
                    };

                    if (altera == -1)
                    {
                        controllerFuncionario.salvar(novoFuncionario);
                    }
                    else
                    {
                        novoFuncionario.funcionario_ID = altera;
                        controllerFuncionario.alterar(novoFuncionario);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimparCampos()
        {
            altera = -1;
            txt_codigo.Clear();
            txt_nome.Clear();
            txt_sobrenome.Clear();
            txt_telefone.Clear();
            txt_celular.Clear();
            txt_email.Clear();
            txt_cep.Clear();
            txt_logradouro.Clear();
            txt_numero.Clear();
            txt_complemento.Clear();
            txt_bairro.Clear();
            txt_cod_cidade.Clear();
            txt_cidade.Clear();
            txt_uf.Clear();
            txt_pais.Clear();
            txt_cpf.Clear();
            txt_rg.Clear();
            txt_data_nascimento.Clear();
            txt_cargo.Clear();
            txt_salario.Clear();
            txt_pis.Clear();
            txt_data_admissao.Clear();
            txt_data_demissao.Clear();
            txt_dat_cad.Clear();
            txt_dat_ult_alt.Clear();
            check_ativo.Checked = true;
        }

        public void SetID(int id)
        {
            altera = id;
        }
        public override void carrega()
        {
            if (altera != -1)
            {
                Funcionario funcionario = controllerFuncionario.GetById(altera);
                if (funcionario != null)
                {
                    // Preenchendo os campos com os valores do funcionário
                    txt_codigo.Text = funcionario.funcionario_ID.ToString();
                    txt_nome.Text = funcionario.nome;
                    txt_sobrenome.Text = funcionario.apelido;
                    txt_logradouro.Text = funcionario.endereco;
                    txt_bairro.Text = funcionario.bairro;
                    txt_numero.Text = funcionario.numero.ToString();
                    txt_cep.Text = funcionario.cep;
                    txt_complemento.Text = funcionario.complemento;
                    txt_cod_cidade.Text = funcionario.cidade_id.ToString();
                    comboBox_sexo.SelectedItem = funcionario.sexo;
                    txt_email.Text = funcionario.email;
                    txt_telefone.Text = funcionario.telefone;
                    txt_celular.Text = funcionario.celular;
                    txt_cpf.Text = funcionario.cpf;
                    txt_rg.Text = funcionario.rg;
                    txt_cargo.Text = funcionario.cargo;
                    txt_salario.Text = funcionario.salario.ToString("F2"); // Formatação para valores monetários
                    txt_pis.Text = funcionario.pis;
                    txt_dat_cad.Text = funcionario.data_cadastro.ToString("dd/MM/yyyy HH:mm:ss"); // Formatação de data/hora
                    txt_dat_ult_alt.Text = funcionario.data_ult_alt.ToString("dd/MM/yyyy HH:mm:ss");
                    check_ativo.Checked = funcionario.ativo;
                    check_inativo.Checked = !funcionario.ativo;

                    // Atualização dos campos de data com validação para valores nulos
                    txt_data_nascimento.Text = funcionario.data_nascimento.HasValue
                        ? funcionario.data_nascimento.Value.ToString("dd/MM/yyyy")
                        : string.Empty;

                    txt_data_admissao.Text = funcionario.data_admissao.HasValue
                        ? funcionario.data_admissao.Value.ToString("dd/MM/yyyy")
                        : string.Empty;

                    txt_data_demissao.Text = funcionario.data_demissao.HasValue
                        ? funcionario.data_demissao.Value.ToString("dd/MM/yyyy")
                        : string.Empty;

                    // Carregando informações de cidade, estado e país
                    List<string> cidadeEstadoPais = controllerFuncionario.GetCEPByIdCidade(funcionario.cidade_id);

                    if (cidadeEstadoPais.Count > 0)
                    {
                        string[] info = cidadeEstadoPais[0].Split(',');
                        if (info.Length >= 3)
                        {
                            txt_cidade.Text = info[0].Trim();
                            txt_uf.Text = info[1].Trim();
                            txt_pais.Text = info[2].Trim();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConsultaCidades_Click(object sender, EventArgs e)
        {

        }

        private void txtCodCidade_Leave(object sender, EventArgs e)
        {

        }

        private void CadastroFuncionarios_Load(object sender, EventArgs e)
        {
        }

        private void CadastroFuncionarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ConsultaFuncionario)this.Owner).AtualizarConsultaFuncionarios(false);
        }

        protected bool VerificaCamposObrigatorios()
        {
            string cpf = new string(txt_cpf.Text.Where(char.IsDigit).ToArray());
            string pais = txt_pais.Text.ToLower();
            if (pais == "brasil")
            {
                if (!validadores.CampoObrigatorio(cpf))
                {
                    MessageBox.Show("CPF obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpf.Focus();
                    return false;
                }
            }
            if (!validadores.CampoObrigatorio(txt_nome.Text))
            {
                MessageBox.Show("Campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nome.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(comboBox_sexo.Text))
            {
                MessageBox.Show("Campo Sexo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox_sexo.Focus();
                return false;
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
            if (!validadores.CampoObrigatorio(txt_cargo.Text))
            {
                MessageBox.Show("Campo Cargo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cargo.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_salario.Text))
            {
                MessageBox.Show("Campo Salário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_salario.Focus();
                return false;
            }
            if (!validadores.CampoObrigatorio(txt_pis.Text))
            {
                MessageBox.Show("Campo PIS é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pis.Focus();
                return false;
            }
            string dataAdmissao = new string(txt_data_admissao.Text.Where(char.IsDigit).ToArray());
            if (!validadores.CampoObrigatorio(dataAdmissao))
            {
                MessageBox.Show("Campo Data Admissão é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_data_admissao.Focus();
                return false;
            }
            return true;
        }

        private void txt_nome_Leave(object sender, EventArgs e)
        {
            if (!validadores.CampoObrigatorio(txt_nome.Text))
            {
                MessageBox.Show("Campo Obrigatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nome.Focus();
            }
            int idAtual = altera != -1 ? altera : -1;
            if (controllerFuncionario.BuscaNome(txt_nome.Text, idAtual))
            {
                MessageBox.Show("Funcionário já cadastrado ! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_sobrenome_Leave(object sender, EventArgs e)
        {
           
        }

        private void txt_cpf_Leave(object sender, EventArgs e)
        {
            string cpf = new string(txt_cpf.Text.Where(char.IsDigit).ToArray());
            string pais = txt_pais.Text.ToLower();
            if (pais == "brasil")
            {
                if (!validadores.CampoObrigatorio(cpf))
                {
                    MessageBox.Show("CPF obrigatório para Brasileiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (!validadores.ValidaCPF(cpf))
            {
                MessageBox.Show("CPF inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpf.Focus();
            }
        }

        private void txt_celular_Leave(object sender, EventArgs e)
        {
            string celular = new string(txt_celular.Text.Where(char.IsDigit).ToArray());
            if (!validadores.VerificaNumeros(celular))
            {
                MessageBox.Show("Celular inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_celular.Focus();
            }

        }

        private void txt_rg_Leave(object sender, EventArgs e)
        {
            if (!validadores.VerificaNumeros(txt_rg.Text))
            {
                MessageBox.Show("RG inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_rg.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           txt_cod_cidade.Enabled = false;
            consultaCidades.btn_sair.Text = "Selecionar";
            consultaCidades.btn_buscainativos.Visible = false;

            if (consultaCidades.ShowDialog() == DialogResult.OK)
            {
                var cidadeDetalhes = consultaCidades.Tag as Tuple<int, string>;

                if (cidadeDetalhes != null)
                {
                    int cidadeID = cidadeDetalhes.Item1;
                    string cidadeNome = cidadeDetalhes.Item2;

                    txt_cod_cidade.Text = cidadeID.ToString();
                    txt_cidade.Text = cidadeNome;

                    List<string> cidadeEstadoPais = controllerFuncionario.GetCEPByIdCidade(cidadeID);

                    if (cidadeEstadoPais.Count > 0)
                    {
                        string[] info = cidadeEstadoPais[0].Split(',');
                        if (info.Length >= 3)
                        {
                            txt_uf.Text = info[1].Trim();
                            txt_pais.Text = info[2].Trim();
                        }
                    }
                }
            }
        }

        private void CadastroFuncionario_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerFuncionario.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            if (!validadores.ValidaEmail(txt_email.Text))
            {
                MessageBox.Show("Email inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_email.Focus();
            }
        }

        private void txt_cep_Leave(object sender, EventArgs e)
        {
           
        }

        private void txt_cod_cidade_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_cod_cidade.Text))
            {
                List<string> cidadeEstadoPais = controllerFuncionario.GetCEPByIdCidade(int.Parse(txt_cod_cidade.Text));

                if (cidadeEstadoPais.Count > 0)
                {
                    string[] info = cidadeEstadoPais[0].Split(',');
                    if (info.Length >= 3)
                    {
                        txt_cidade.Text = info[0].Trim();
                        txt_uf.Text = info[1].Trim();
                        txt_pais.Text = info[2].Trim();
                    }
                }
                else
                {
                    MessageBox.Show("Código Cidade não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cod_cidade.Focus();
                    txt_cod_cidade.Clear();
                    txt_cidade.Clear();
                    txt_uf.Clear();
                    txt_pais.Clear();
                }
            }
        }
    }
}



