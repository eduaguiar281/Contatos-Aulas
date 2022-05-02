using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using AgendaContatos.Infra.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaContatos.Contatos
{
    public partial class FrmContatos : Form
    {
        private readonly IContatosDatabase _contatosDatabase;

        public FrmContatos()
        {
            InitializeComponent();
            _contatosDatabase = Program.ServiceProvider.GetService<IContatosDatabase>();
        }

        private void FrmContatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private Contato ObterSelecionado()
        {
            if (dgvContatos.SelectedRows.Count == 0)
                return default;

            return dgvContatos.SelectedRows[0]?.DataBoundItem as Contato;
        }


        private void btnOk_Click(object sender, System.EventArgs e)
        {
            List<Contato> contatos;
            if (txtFiltro.Text == string.Empty)
                contatos = _contatosDatabase.ObterLista();
            else
                contatos = _contatosDatabase.ObterLista(txtFiltro.Text);
            dgvContatos.DataSource = contatos;
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            FrmContatoManutencao manutencao = new(OperacaoCadastro.Incluir, new Contato());
            manutencao.ShowDialog();
            btnOk_Click(this, e);
        }

        private void btnAlterar_Click(object sender, System.EventArgs e)
        {
            Contato contato = ObterSelecionado();
            if (contato is null)
            {
                MessageBox.Show("Selecione uma contato no Grid!");
                return;
            }
            FrmContatoManutencao manutencao = new(OperacaoCadastro.Alterar, contato);
            manutencao.ShowDialog();
            btnOk_Click(this, e);
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            Contato contato = ObterSelecionado();
            if (contato is null)
            {
                MessageBox.Show("Selecione uma contato no Grid!");
                return;
            }
            FrmContatoManutencao manutencao = new(OperacaoCadastro.Excluir, contato);
            manutencao.ShowDialog();
            btnOk_Click(this, e);
        }

        private void btnDetalhes_Click(object sender, System.EventArgs e)
        {

            Contato contato = ObterSelecionado();
            if (contato is null)
            {
                MessageBox.Show("Selecione uma contato no Grid!");
                return;
            }
            FrmContatoManutencao manutencao = new(OperacaoCadastro.Consulta, contato);
            manutencao.ShowDialog();
            btnOk_Click(this, e);
        }
    }
}
