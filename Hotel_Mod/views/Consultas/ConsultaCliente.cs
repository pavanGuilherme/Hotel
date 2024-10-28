using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Hotel_Mod.Models;
using System.Windows.Forms;
using System.Linq;
using Hotel_Mod.views.Cadastros;

namespace Hotel_Mod.views
{
    public partial class ConsultaCliente : Hotel_Mod.views.ConsultaPai
    {

        private controllerCliente<Clientes> controllerCliente;
        private CadastroClientes cadastroCliente;

        public ConsultaCliente()
        {
            InitializeComponent();
            controllerCliente = new controllerCliente<Clientes>();
            cadastroCliente = new CadastroClientes();
            cadastroCliente.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroCliente.ShowDialog();
        }


        public override void Alterar()
        {
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                int cliente_ID = (int)dataGridViewCliente.SelectedRows[0].Cells["codigo"].Value;
                CadastroClientes CadastroCliente = new CadastroClientes(cliente_ID);
                CadastroCliente.Owner = this;
                CadastroCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este Cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int cliente_ID = (int)dataGridViewCliente.SelectedRows[0].Cells["codigo"].Value;
                    controllerCliente.excluir(cliente_ID);
                    dataGridViewCliente.DataSource = controllerCliente.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim(); //obtem a pesquisa do txt

            //verifica se há um termo de pesquisa
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    //filtra os dados dos países
                    List<Clientes> resultadosPesquisa = controllerCliente.GetAll(btn_buscainativos.Checked).Where(p => p.nome.ToLower().Contains(pesquisa.ToLower())).ToList();
                    dataGridViewCliente.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
                    txt_pesquisar.Text = string.Empty; //limpa o txt pesquisa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaClientes(btn_buscainativos.Checked);
            }
        }
        
        



        public void AtualizarConsultaClientes(bool incluirInativos)
        {
            try
            {
                //recarrega os dados das alunos na consulta 
                dataGridViewCliente.DataSource = controllerCliente.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de clientes: " + ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            cadastroCliente.LimparCampos();
        }



        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            try
            {

                CadastroClientes cadastroCliente = new CadastroClientes();
                cadastroCliente.FormClosed += (s, args) => AtualizarConsultaClientes(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta

                dataGridViewCliente.AutoGenerateColumns = false;
                dataGridViewCliente.Columns["codigo"].DataPropertyName = "cliente_ID";
                dataGridViewCliente.Columns["nome"].DataPropertyName = "nome";
                dataGridViewCliente.Columns["apelido"].DataPropertyName = "apelido";
                dataGridViewCliente.Columns["cpf_cnpj"].DataPropertyName = "cpf";
                dataGridViewCliente.Columns["email"].DataPropertyName = "email";
                dataGridViewCliente.Columns["celular"].DataPropertyName = "celular";

                AtualizarConsultaClientes(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewCliente.SelectedRows.Count > 0)
                {
                    int cliente_ID = Convert.ToInt32(dataGridViewCliente.SelectedRows[0].Cells["codigo"].Value);
                    string nome = dataGridViewCliente.SelectedRows[0].Cells["nome"].Value.ToString();
                    string cpf = dataGridViewCliente.SelectedRows[0].Cells["cpf_cnpj"].Value.ToString();
                    string celular = dataGridViewCliente.SelectedRows[0].Cells["celular"].Value.ToString();


                    this.Tag = new Tuple<int, string, string, string>(cliente_ID, nome, cpf, celular);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }

        private void btn_buscainativos_CheckedChanged_1(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaClientes(incluirInativos);
        }
    }
}



