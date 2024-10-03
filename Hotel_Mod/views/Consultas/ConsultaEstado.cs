using Hotel_Mod.Class;
using Hotel_Mod.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public partial class ConsultaEstado : Hotel_Mod.views.ConsultaPai
    {
        private controllerEstado<Estado> controllerestado;
        private CadastroEstado Cadastroestado;
        public ConsultaEstado()
        {
            InitializeComponent();
            controllerestado = new controllerEstado<Estado>();
            Cadastroestado = new CadastroEstado();
            Cadastroestado.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            Cadastroestado.ShowDialog();
        }


        public override void Alterar()
        {
            if (dataGridViewEstado.SelectedRows.Count > 0)
            {
                int idEstado = (int)dataGridViewEstado.SelectedRows[0].Cells["Código"].Value;
                CadastroEstado CadastroEstado = new CadastroEstado(idEstado);
                CadastroEstado.Owner = this;
                CadastroEstado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um estado para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewEstado.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este Estado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idEstado = (int)dataGridViewEstado.SelectedRows[0].Cells["Código"].Value;
                    controllerestado.excluir(idEstado);
                    dataGridViewEstado.DataSource = controllerestado.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um estado para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    List<Estado> resultadosPesquisa = controllerestado.GetAll(btn_buscainativos.Checked).Where(p => p.estado.ToLower().Contains(pesquisa.ToLower())).ToList();
                    dataGridViewEstado.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
                    txt_pesquisar.Text = string.Empty; //limpa o txt pesquisa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaEstado(btn_buscainativos.Checked);
            }
        }
        public void AtualizarConsultaEstados(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos estados na consulta de estados
                dataGridViewEstado.DataSource = controllerestado.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de estados: " + ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AtualizarConsultaEstado(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos países na consulta de países
                dataGridViewEstado.DataSource = controllerestado.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de estados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            Cadastroestado.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewEstado.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do país selecionado
                    int estadoID = Convert.ToInt32(dataGridViewEstado.SelectedRows[0].Cells["Código"].Value);
                    string estadoNome = dataGridViewEstado.SelectedRows[0].Cells["Estado"].Value.ToString();

                    // Passar os detalhes do país selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(estadoID, estadoNome);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            AtualizarConsultaEstado(incluirInativos);
        }

        private void ConsultaEstado_Load(object sender, EventArgs e)
        {
            try
            {
                CadastroEstado cadastroEstado = new CadastroEstado();
                cadastroEstado.FormClosed += (s, args) => AtualizarConsultaEstado(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta

                dataGridViewEstado.AutoGenerateColumns = false;
                dataGridViewEstado.Columns["Código"].DataPropertyName = "estado_ID";
                dataGridViewEstado.Columns["Estado"].DataPropertyName = "estado";
                dataGridViewEstado.Columns["UF"].DataPropertyName = "uf";
               

                AtualizarConsultaEstado(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os estados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sair_Click_1(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewEstado.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do país selecionado
                    int estado_ID = Convert.ToInt32(dataGridViewEstado.SelectedRows[0].Cells["Código"].Value);
                    string nome = dataGridViewEstado.SelectedRows[0].Cells["Estado"].Value.ToString();

                    // Passar os detalhes do país selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(estado_ID, nome);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Close();
            }
        }
    }
}
