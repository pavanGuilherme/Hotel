using Hotel_Mod.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaFuncionario : Hotel_Mod.views.ConsultaPai
    {


        private controllerFuncionario<Funcionario> controllerFuncionario;
        private CadastroFuncionario cadastroFuncionario;
        public ConsultaFuncionario()
        {
            InitializeComponent();
            controllerFuncionario = new controllerFuncionario<Funcionario>();
            cadastroFuncionario = new CadastroFuncionario();
            cadastroFuncionario.Owner = this;
        }
        public override void Incluir()
        {
            ResetCadastro();
            cadastroFuncionario.ShowDialog();

        }
        public override void Alterar()
        {
            if (dataGridViewFuncionario.SelectedRows.Count > 0)
            {
                int idFuncionario = (int)dataGridViewFuncionario.SelectedRows[0].Cells["Código"].Value;
                ResetCadastro(idFuncionario);
                cadastroFuncionario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public override void Excluir()
        {
            if (dataGridViewFuncionario.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Tem certeza de que deseja excluir este funcionário?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idFuncinario = (int)dataGridViewFuncionario.SelectedRows[0].Cells["Código"].Value;
                    controllerFuncionario.excluir(idFuncinario);
                    dataGridViewFuncionario.DataSource = controllerFuncionario.GetAll(btn_buscainativos.Checked);
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<Funcionario> resultadosPesquisa = new List<Funcionario>();
                    bool buscaInativos = btn_buscainativos.Checked;
                    if (btn_nome.Checked)
                    {
                        resultadosPesquisa = controllerFuncionario.GetAll(buscaInativos).Where(p => p.nome.ToLower().Contains(pesquisa.ToLower())).ToList();
                    }
                    else if (btn_Codigo.Checked)
                    {
                        if (int.TryParse(pesquisa, out int codigoPesquisa))
                        {
                            resultadosPesquisa = controllerFuncionario.GetAll(buscaInativos).Where(p => p.funcionario_ID == codigoPesquisa).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Por favor, insira um código válido.", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    dataGridViewFuncionario.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaFuncionarios(btn_buscainativos.Checked);
            }
        }

        public void AtualizarConsultaFuncionarios(bool incluirInativos)
        {
            try
            {
                dataGridViewFuncionario.DataSource = controllerFuncionario.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de funcionários: " + ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void ResetCadastro()
        {
            cadastroFuncionario.LimparCampos();
        }

        private void ResetCadastro(int id)
        {
            cadastroFuncionario.SetID(id);
            cadastroFuncionario.carrega();
        }

        private void cbBuscaInativos_CheckedChanged(object sender, EventArgs e)
        {
            bool incluirInativos = btn_buscainativos.Checked;
            AtualizarConsultaFuncionarios(incluirInativos);
        }

       
        private void ConsultaFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                cadastroFuncionario.FormClosed += (s, args) => AtualizarConsultaFuncionarios(btn_buscainativos.Checked);

                dataGridViewFuncionario.AutoGenerateColumns = false;
                dataGridViewFuncionario.Columns["funcionario_ID"].DataPropertyName = "funcionario_ID";
                dataGridViewFuncionario.Columns["nome"].DataPropertyName = "nome";
                dataGridViewFuncionario.Columns["apelido"].DataPropertyName = "apelido";
                dataGridViewFuncionario.Columns["telefone"].DataPropertyName = "celular";
                dataGridViewFuncionario.Columns["Cargo"].DataPropertyName = "cargo";
                dataGridViewFuncionario.Columns["cpf"].DataPropertyName = "cpf";

                AtualizarConsultaFuncionarios(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewFuncionario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewFuncionario.Columns["Telefone"].Index && e.Value != null)
            {
                //formata o número de celular
                string celular = e.Value.ToString();
                if (celular.Length == 11)
                {
                    e.Value = string.Format("({0}) {1}-{2}", celular.Substring(0, 2), celular.Substring(2, 5), celular.Substring(7));
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewFuncionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int idFuncionario = (int)dataGridViewFuncionario.Rows[e.RowIndex].Cells["Código"].Value;
                ResetCadastro(idFuncionario);
                cadastroFuncionario.ShowDialog();
            }
        }
    }
}
