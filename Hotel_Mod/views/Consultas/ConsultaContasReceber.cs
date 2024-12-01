using Hotel_Mod.Controller;
using Hotel_Mod.Models;
using Hotel_Mod.views.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Mod.views.Consultas
{
    public partial class ConsultaContasReceber : Hotel_Mod.views.ConsultaPai
    {

        private CadastroContaReceber cadastroContaReceber;
        private controllerCliente<Cliente> controllerCliente;
        private controllerContasReceber<ContasReceber> controllerContasReceber;

        public ConsultaContasReceber()
        {
            InitializeComponent();
            cadastroContaReceber = new CadastroContaReceber();
            cadastroContaReceber.Owner = this;
            controllerCliente = new controllerCliente<Cliente>();
            controllerContasReceber = new controllerContasReceber<ContasReceber>();
        }

        public override void Incluir()
        {
            ResetCadastro();
            cadastroContaReceber.ShowDialog();
        }

        public override void Alterar()
        {
            if (dataGridView_contas_receber.SelectedRows.Count > 0)
            {
                int idReserva = (int)dataGridView_contas_receber.SelectedRows[0].Cells["reserva_ID"].Value;
                int idClienteNF = (int)dataGridView_contas_receber.SelectedRows[0].Cells["cliente_ID"].Value;
                int parcelaNF = (int)dataGridView_contas_receber.SelectedRows[0].Cells["num_parcela"].Value;
                ResetCadastro(idReserva, idClienteNF, parcelaNF);
                cadastroContaReceber.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione uma conta para visualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     

        private void ResetCadastro()
        {
            cadastroContaReceber.LimparCampos();
        }
        private void ResetCadastro(int idReserva, int idCliente, int parcela)
        {
            cadastroContaReceber.SetID(idReserva, idCliente, parcela);
            cadastroContaReceber.Bloqueia();
            cadastroContaReceber.carrega();
        }


        public void AtualizarConsultaContasReceber(bool incluirInativos)
        {
            try
            {
                dataGridView_contas_receber.DataSource = controllerContasReceber.GetAll(incluirInativos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a consulta de Contas a Receber: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void Pesquisar()
        {
            string pesquisa = txt_pesquisar.Text.Trim();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                try
                {
                    List<ContasReceber> resultadosPesquisa = new List<ContasReceber>();
                    bool buscaInativos = btn_buscainativos.Checked;

                    if (int.TryParse(pesquisa, out int numeroNotaPesquisa))
                    {
                        resultadosPesquisa = controllerContasReceber.GetAll(buscaInativos).Where(p => p.reserva_ID == numeroNotaPesquisa).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, insira um número de nota válido.", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataGridView_contas_receber.DataSource = resultadosPesquisa;
                    txt_pesquisar.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao pesquisar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                AtualizarConsultaContasReceber(btn_buscainativos.Checked);
            }
        }

        private void ConsultaContasReceber_Load(object sender, EventArgs e)
        {
            try
            {
                cadastroContaReceber.FormClosed += (s, args) => AtualizarConsultaContasReceber(btn_buscainativos.Checked); //quando aciona o Form Closed chama o AtualizarConsulta  

                dataGridView_contas_receber.AutoGenerateColumns = false;
                dataGridView_contas_receber.Columns["cliente_ID"].DataPropertyName = "cliente_ID";
                dataGridView_contas_receber.Columns["reserva_ID"].DataPropertyName = "reserva_ID";
                dataGridView_contas_receber.Columns["num_parcela"].DataPropertyName = "num_parcela";
                dataGridView_contas_receber.Columns["valor_parcela"].DataPropertyName = "valor_parcela";

                dataGridView_contas_receber.Columns["data_emissao"].DataPropertyName = "data_emissao";
                dataGridView_contas_receber.Columns["data_emissao"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_contas_receber.Columns["data_vencimento"].DataPropertyName = "data_vencimento";
                dataGridView_contas_receber.Columns["data_vencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_contas_receber.Columns["data_recebimento"].DataPropertyName = "data_recebimento";
                dataGridView_contas_receber.Columns["data_recebimento"].DefaultCellStyle.Format = "dd/MM/yyyy";


                AtualizarConsultaContasReceber(btn_buscainativos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as Contas a Receber: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
