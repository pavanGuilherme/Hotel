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

namespace Hotel_Mod.views.Cadastros
{
    public partial class CadastroHospede : Hotel_Mod.views.CadastroPai
    {

        private controllerHospede<Hospede> controllerHospede;
        private ConsultaCidades consultaCidades;
 
        public CadastroHospede()
        {
            InitializeComponent();
            consultaCidades = new ConsultaCidades();
            controllerHospede = new controllerHospede<Hospede>();

        }

        public CadastroHospede(int hospede_ID) : this()
        {
            altera = hospede_ID;
            carrega();

        }


        private void CadastroHospede_Load(object sender, EventArgs e)
        {
            if (altera == -1)
            {
                int novoCodigo = controllerHospede.GetUltimoCodigo() + 1;
                txt_codigo.Text = novoCodigo.ToString();
            }
        }

        public override void salvar()
        {
            if (!validadores.CampoObrigatorio(txt_nome.Text))
            {
                MessageBox.Show("Campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nome.Focus();
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

            else if (!validadores.ValidaCPF(txt_cpf.Text))
            {
                MessageBox.Show("cpf inválido !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Focus();
            }
            else
            {
                int idAtual = altera != -1 ? altera : 0;

                if (controllerHospede.JaCadastrado(txt_cpf.Text, idAtual))
                {
                    MessageBox.Show("Hospede já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_cpf.Focus();
                }
                else
                {
                    try
                    {
                        Hospede novoHospede = PreencherHospede();

                        if (altera == -1)
                        {
                            controllerHospede.salvar(novoHospede);
                        }
                        else
                        {
                            controllerHospede.alterar(novoHospede);
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

        public override void carrega()
        {
            // Verifica se há um Hospede a ser alterado
            if (altera != -1)
            {
                Hospede hospede = controllerHospede.GetById(altera);
                if (hospede != null)
                {
                    PreencherCampos(hospede);
                }
                else
                {
                    MessageBox.Show("Hospede não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Hospede PreencherHospede()
        {
            return new Hospede
            {
                nome = txt_nome.Text,
                data_nascimento = DateTime.Parse(txt_data_nascimento.Text),
                telefone = txt_telefone.Text,
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

        private void PreencherCampos(Hospede hospede)
        {
            txt_codigo.Text = hospede.hospede_id.ToString();      
            txt_nome.Text = hospede.nome;                                    
            txt_telefone.Text = hospede.telefone;                
            txt_numero.Text = hospede.numero;                     
            txt_email.Text = hospede.email;                       
            txt_cpf.Text = hospede.cpf;                       
            txt_rg.Text = hospede.rg;                          
            txt_cep.Text = hospede.cep;                         
            txt_logradouro.Text = hospede.logradouro;            
            txt_data_nascimento.Text = hospede.data_nascimento?.ToString(); 
            txt_complemento.Text = hospede.complemento;          
            txt_bairro.Text = hospede.bairro;                    
            txt_cod_cidade.Text = hospede.cidade_id.ToString();   
            txt_dat_cad.Text = hospede.data_cadastro.ToString();  
            txt_dat_ult_alt.Text = hospede.data_ult_alt.ToString(); 
            check_ativo.Checked = hospede.ativo;             
            check_inativo.Checked = !hospede.ativo;
            comboBox_sexo.SelectedIndex = hospede.sexo; 

        }
        private void btn_busca_cidade_Click_1(object sender, EventArgs e)
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

                    List<string> cidadeEstadoPais = controllerHospede.GetCidadeEstadoEPaisByCidadeId(cidadeID);

                    if (cidadeEstadoPais.Count > 0)
                    {
                        string[] info = cidadeEstadoPais[0].Split(',');
                        if (info.Length >= 3)
                        {
                            txt_estado.Text = info[1].Trim();
                            txt_pais.Text = info[2].Trim();

                            // Valida se o país é diferente de "Brasil" e marca o campo de estrangeiro
                            if (txt_pais.Text.ToUpper() != "BRASIL")
                            {
                                check_estrangeiro.Checked = true;
                            }
                            else
                            {
                                check_estrangeiro.Checked = false;
                            }
                        }
                    }
                }
            }

        }

        private void check_inativo_CheckedChanged(object sender, EventArgs e)
        {
           
            ativo = !check_inativo.Checked;
        }

        private void check_ativo_CheckedChanged(object sender, EventArgs e)
        {
            ativo = check_ativo.Checked;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_rg_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_data_nascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_cod_cidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_passaporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }

        private void txt_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e teclas de controle (ex.: backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a entrada do caractere
            }
        }
    }
}
