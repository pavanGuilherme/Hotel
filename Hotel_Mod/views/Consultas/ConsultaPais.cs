using Hotel_Mod.Class;
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
    public partial class ConsultaPais : Hotel_Mod.views.ConsultaPai
    {
        private controllerPais<Pais> controllerPais;
        private CadastroPais CadastroPais;
        public ConsultaPais()
        {
            InitializeComponent();
            controllerPais = new controllerPais<Pais>();
            CadastroPais = new CadastroPais();
            CadastroPais.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            CadastroPais.ShowDialog();
        }


        public override void Alterar()
        {
            if (dataGridViewPais.SelectedRows.Count > 0)
            {
                int pais_ID = (int)dataGridViewPais.SelectedRows[0].Cells["Código"].Value;
                CadastroPais CadastroPais = new CadastroPais(pais_ID);
                CadastroPais.Owner = this;
                CadastroPais.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um país para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridViewPais.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este país?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int pais_ID = (int)dataGridViewPais.CurrentRow.Cells[0].Value;
                    controllerPais.excluir(pais_ID);
                    dataGridViewPais.DataSource = controllerPais.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um país para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    List<Pais> resultadosPesquisa = controllerPais.GetAll(btn_buscainativos.Checked).Where(p => p.pais.ToLower().Contains(pesquisa.ToLower())).ToList();
                    dataGridViewPais.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
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

        public void AtualizarConsultaPaises(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos países na consulta de países
                dataGridViewPais.DataSource = controllerPais.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            CadastroPais.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (dataGridViewPais.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do país selecionado
                    int pais_ID = Convert.ToInt32(dataGridViewPais.SelectedRows[0].Cells["Código"].Value);
                    string nome = dataGridViewPais.SelectedRows[0].Cells["País"].Value.ToString();

                    // Passar os detalhes do país selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(pais_ID, nome);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um país.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ConsultaPais_Load(object sender, EventArgs e)
        {
            try
            {
                CadastroPais cadastroPais = new CadastroPais();
                cadastroPais.FormClosed += (s, args) => AtualizarConsultaPaises(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta

                dataGridViewPais.AutoGenerateColumns = false;
                dataGridViewPais.Columns["Código"].DataPropertyName = "pais_ID";
                dataGridViewPais.Columns["País"].DataPropertyName = "pais";
                dataGridViewPais.Columns["Sigla"].DataPropertyName = "sigla";
                dataGridViewPais.Columns["DDI"].DataPropertyName = "ddi";

                AtualizarConsultaPaises(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

