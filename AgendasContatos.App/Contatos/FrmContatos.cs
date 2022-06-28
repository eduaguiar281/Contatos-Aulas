using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using AgendaContatos.Infra.Models;
using AgendasContatos.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaContatos.Contatos
{
    public partial class FrmContatos : Form
    {
        private readonly IRepository<Contato, int> _contatosRepository;

        public FrmContatos()
        {
            InitializeComponent();
            _contatosRepository = Program.ServiceProvider.GetService<IRepository<Contato, int>>();
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


        private async void btnOk_Click(object sender, System.EventArgs e)
        {
            IEnumerable<Contato> contatos;
            if (txtFiltro.Text == string.Empty)
                contatos = await _contatosRepository.ObterTodosAsync();
            else
                contatos = await _contatosRepository.ObterAsync(txtFiltro.Text);
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

        private void dgvContatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
