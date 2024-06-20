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
    public partial class ConsultaCidades : Hotel_Mod.views.ConsultaPai
    {
        private controllerCidade<Cidade> controllerCidade;
        private CadastroCidades CadastroCidades;
        public ConsultaCidades()
        {
            InitializeComponent();
            controllerCidade = new controllerCidade<Cidade>();
            CadastroCidades = new CadastroCidades();
            CadastroCidades.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            CadastroCidades.ShowDialog();
        }


        public override void Alterar()
        {
            if (DataGridViewCidades.SelectedRows.Count > 0)
            {
                int idCidade = (int)DataGridViewCidades.SelectedRows[0].Cells["Código"].Value;
                CadastroCidades cadastroCidades = new CadastroCidades(idCidade);
                CadastroCidades.Owner = this;
                CadastroCidades.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um país para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (DataGridViewCidades.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este país?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idCidade = (int)DataGridViewCidades.CurrentRow.Cells[0].Value;
                    controllerCidade.excluir(idCidade);
                    DataGridViewCidades.DataSource = controllerCidade.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma cidade para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    List<Cidade> resultadosPesquisa = controllerCidade.GetAll(btn_buscainativos.Checked).Where(p => p.cidade.ToLower().Contains(pesquisa.ToLower())).ToList();
                    DataGridViewCidades.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
                    txt_pesquisar.Text = string.Empty; //limpa o txt pesquisa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaCidades(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaCidades(bool incluirInativos)
        {
            try
            {
                //recarrega os dados dos países na consulta de países
                DataGridViewCidades.DataSource = controllerCidade.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de países: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            CadastroCidades.LimparCampos();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            if (btn_sair.Text == "Selecionar")
            {
                if (DataGridViewCidades.SelectedRows.Count > 0)
                {
                    // Capturar o ID e o nome do país selecionado
                    int cidadeID = Convert.ToInt32(DataGridViewCidades.SelectedRows[0].Cells["Código"].Value);
                    string cidadeNome = DataGridViewCidades.SelectedRows[0].Cells["Cidade"].Value.ToString();

                    // Passar os detalhes do país selecionado de volta para a tela principal
                    this.Tag = new Tuple<int, string>(cidadeID, cidadeNome);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma cidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            AtualizarConsultaCidades(incluirInativos);
        }

        private void ConsultaPais_Load(object sender, EventArgs e)
        {
            try
            {
                CadastroPais cadastroPaises = new CadastroPais();
                cadastroPaises.FormClosed += (s, args) => AtualizarConsultaCidades(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta

                DataGridViewCidades.AutoGenerateColumns = false;
                DataGridViewCidades.Columns["Código"].DataPropertyName = "pais_ID";
                DataGridViewCidades.Columns["Cidade"].DataPropertyName = "cidade";
                DataGridViewCidades.Columns["DDD"].DataPropertyName = "ddd";
            

                AtualizarConsultaCidades(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as cidades: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
