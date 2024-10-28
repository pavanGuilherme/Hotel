using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_Mod.Controller;
using Hotel_Mod.Class;
using System.Linq;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaNotaCompra : Hotel_Mod.views.ConsultaPai
    {
        private CadastroNotaCompra cadastroNotaCompra;
        private ControllerNotaCompra<nota_Compra> controllerNotaCompra;
        private ControllerFornecedor<Fornecedor> controllerFornecedor;
        public ConsultaNotaCompra()
        {
            InitializeComponent();
            cadastroNotaCompra = new CadastroNotaCompra();
            controllerNotaCompra = new ControllerNotaCompra<nota_Compra>();
            controllerFornecedor = new ControllerFornecedor<Fornecedor>();
            cadastroNotaCompra.Owner = this;
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroNotaCompra.ShowDialog();
        }

        private void ResetCadastro()
        {
            cadastroNotaCompra.LimparCampos();
        }

        private void ResetCadastro(int numNota, int modelo, int serie, int fornecedor_ID)
        {
            cadastroNotaCompra.SetID(numNota, modelo, serie, fornecedor_ID);
            cadastroNotaCompra.BloqueiaTudo();
            cadastroNotaCompra.carrega();
        }

        public void Visualizar()
        {
            if (dataGridViewNFCompra.SelectedRows.Count > 0)
            {
                int numNota = (int)dataGridViewNFCompra.SelectedRows[0].Cells["num_Nota"].Value;
                int modelo = (int)dataGridViewNFCompra.SelectedRows[0].Cells["modelo"].Value;
                int serie = (int)dataGridViewNFCompra.SelectedRows[0].Cells["serie"].Value;
                int fornecedor_ID = (int)dataGridViewNFCompra.SelectedRows[0].Cells["fornecedor_ID"].Value;
                ResetCadastro(numNota, modelo, serie, fornecedor_ID);
                cadastroNotaCompra.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma nota para visualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        public void AtualizarConsultaNotaCompra(bool incluirInativos)
        {
            try
            {
                dataGridViewNFCompra.DataSource = controllerNotaCompra.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de Notas de Compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaNotaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                cadastroNotaCompra.FormClosed += (s, args) => AtualizarConsultaNotaCompra(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta
                dataGridViewNFCompra.Columns["num_Nota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewNFCompra.Columns["modelo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewNFCompra.Columns["serie"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewNFCompra.Columns["fornecedor_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewNFCompra.AutoGenerateColumns = false;
                dataGridViewNFCompra.Columns["num_Nota"].DataPropertyName = "num_Nota";
                dataGridViewNFCompra.Columns["modelo"].DataPropertyName = "modelo";
                dataGridViewNFCompra.Columns["serie"].DataPropertyName = "serie";
                dataGridViewNFCompra.Columns["fornecedor_ID"].DataPropertyName = "fornecedor_ID";
                dataGridViewNFCompra.Columns["data_chegada"].DataPropertyName = "data_chegada";
                dataGridViewNFCompra.Columns["data_chegada"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewNFCompra.Columns["data_cancelamento"].DataPropertyName = "data_cancelamento";
                dataGridViewNFCompra.Columns["data_cancelamento"].DefaultCellStyle.Format = "dd/MM/yyyy";

                AtualizarConsultaNotaCompra(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as Notas de Compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<nota_Compra> resultadosPesquisa = new List<nota_Compra>();
                    bool buscaInativos = btn_buscainativos.Checked;

                    if (int.TryParse(pesquisa, out int numeroNotaPesquisa))
                    {
                        resultadosPesquisa = controllerNotaCompra.GetAll(buscaInativos).Where(p => p.num_Nota == numeroNotaPesquisa).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira um número de nota válido.", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataGridViewNFCompra.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaNotaCompra(btn_buscainativos.Checked);
            }
        }

        private void dataGridViewNFCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int numNota = (int)dataGridViewNFCompra.Rows[e.RowIndex].Cells["num_Nota"].Value;
                int modelo = (int)dataGridViewNFCompra.Rows[e.RowIndex].Cells["modelo"].Value;
                int serie = (int)dataGridViewNFCompra.Rows[e.RowIndex].Cells["serie"].Value;
                int fornecedor_ID = (int)dataGridViewNFCompra.Rows[e.RowIndex].Cells["fornecedor_ID"].Value;
                ResetCadastro(numNota, modelo, serie, fornecedor_ID);
                cadastroNotaCompra.ShowDialog();
            }
        }

        private void dataGridViewNFCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewNFCompra.Columns[e.ColumnIndex].Name == "fornecedor" && e.RowIndex >= 0)
            {
                int fornecedor_ID = (int)dataGridViewNFCompra.Rows[e.RowIndex].Cells["fornecedor_ID"].Value;
                Fornecedor fornecedor = controllerFornecedor.GetById(fornecedor_ID);

                if (fornecedor != null)
                {
                    e.Value = fornecedor.fornecedor_razao_social;
                }
                else
                {
                    e.Value = "Fornecedor não encontrado";
                }

                e.FormattingApplied = true;
            }
            if (dataGridViewNFCompra.Columns[e.ColumnIndex].Name == "data_cancelamento" && e.RowIndex >= 0)
            {
                var dataCancelamento = dataGridViewNFCompra.Rows[e.RowIndex].Cells["data_cancelamento"].Value;
                if (dataCancelamento != DBNull.Value && dataCancelamento != null)
                {
                    dataGridViewNFCompra.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridViewNFCompra.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dataGridViewNFCompra.DefaultCellStyle.ForeColor;
                }
            }
        }
    }
}

