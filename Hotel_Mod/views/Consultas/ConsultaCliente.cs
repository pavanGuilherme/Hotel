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

namespace Hotel_Mod.views
{
    public partial class ConsultaCliente : Hotel_Mod.views.ConsultaPai
    {

        private controllerCliente<Clientes> controllerCliente;
        private CadastroCliente CadastroCliente;
        public ConsultaCliente()
        {
            InitializeComponent();
            controllerCliente = new controllerCliente<Clientes>();
            CadastroCliente = new CadastroCliente();
            CadastroCliente.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            CadastroCliente.ShowDialog();
        }


        public override void Alterar()
        {
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                int cliente_ID = (int)dataGridViewCliente.SelectedRows[0].Cells["Código"].Value;
                CadastroCliente CadastroCliente = new CadastroCliente(cliente_ID);
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
                    int cliente_ID = (int)dataGridViewCliente.SelectedRows[0].Cells["Código"].Value;
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
                AtualizarConsultaPaises(btn_buscainativos.Checked);
            }
        }
        public void AtualizarConsultaEstados(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos estados na consulta de estados
                dataGridViewCliente.DataSource = controllerCliente.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de clientes: " + ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AtualizarConsultaPaises(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos países na consulta de países
                dataGridViewCliente.DataSource = controllerCliente.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            CadastroCliente.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewCliente.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do país selecionado
                    int cliente_ID = Convert.ToInt32(dataGridViewCliente.SelectedRows[0].Cells["Código"].Value);
                    string nome = dataGridViewCliente.SelectedRows[0].Cells["Nome"].Value.ToString();

                    // Passar os detalhes do país selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(cliente_ID, nome);
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

        private void btn_buscainativos_CheckedChanged(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaPaises(incluirInativos);
        }
    }
}


