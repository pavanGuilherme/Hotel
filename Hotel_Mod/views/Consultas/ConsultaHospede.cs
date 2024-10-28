using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaHospede : Hotel_Mod.views.ConsultaPai
    {


        private controllerHospede<Hospede> controllerHospede;
        private CadastroHospede cadastroHospede;


        public ConsultaHospede()
        {
            InitializeComponent();
            controllerHospede = new controllerHospede<Hospede>();
            cadastroHospede = new CadastroHospede();
            cadastroHospede.Owner = this;
        }


        public override void Incluir()
        {
            ResetCadastro();
            cadastroHospede.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridView_hospede.SelectedRows.Count > 0)
            {
                int hospede_ID = (int)dataGridView_hospede.SelectedRows[0].Cells["codigo"].Value;
                CadastroHospede cadastroHospede = new CadastroHospede(hospede_ID);
                cadastroHospede.Owner = this;
                cadastroHospede.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um hospede para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (dataGridView_hospede.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este hospede?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int hospede_ID = (int)dataGridView_hospede.SelectedRows[0].Cells["codigo"].Value;
                    controllerHospede.excluir(hospede_ID);
                    dataGridView_hospede.DataSource = controllerHospede.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um hospede para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    List<Hospede> resultadosPesquisa = controllerHospede.GetAll(btn_buscainativos.Checked).Where(p => p.nome.ToLower().Contains(pesquisa.ToLower())).ToList();
                    dataGridView_hospede.DataSource = resultadosPesquisa; //atualiza o DataSource do DataGridView com os resultados da pesquisa
                    txt_pesquisar.Text = string.Empty; //limpa o txt pesquisa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar o hospede: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dataGridView_hospede.DataSource = controllerHospede.GetAll(incluirInativos);
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
                dataGridView_hospede.DataSource = controllerHospede.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizarConsultaClientes(bool incluirInativos)
        {
            try
            {
                //recarrega os dados das alunos na consulta 
                dataGridView_hospede.DataSource = controllerHospede.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de clientes: " + ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetCadastro()
        {
            cadastroHospede.LimparCampos();
        }

    }
}
