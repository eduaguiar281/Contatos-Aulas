using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using AgendaContatos.Infra.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AgendaContatos.Contatos
{
    public partial class FrmContatoManutencao : Form
    {

        private readonly IContatosDatabase _contatosDatabase;

        public readonly OperacaoCadastro _operacaoCadastro;
        protected Contato Contato { get; set; }

        public FrmContatoManutencao(OperacaoCadastro operacaoCadastro, Contato contato)
        {
            InitializeComponent();
            _contatosDatabase = Program.ServiceProvider.GetService<IContatosDatabase>();
            _operacaoCadastro = operacaoCadastro;
            Contato = contato;
            contatoBindingSource.DataSource = Contato;
            InicializarDados();
        }

        private void InicializarDados()
        {
            categoriaBindingSource.DataSource = _contatosDatabase.ObterLista();
            switch (_operacaoCadastro)
            {
                case OperacaoCadastro.Incluir:
                    {
                        Contato.DataCadastro = DateTime.UtcNow;
                        Contato.Ativo = true;
                        lblMensagem.Text = string.Format(lblMensagem.Text, "Inclusão");
                        this.Text = string.Format(this.Text, "[INCLUSÃO]");
                    }
                    break;
                case OperacaoCadastro.Alterar:
                    {
                        lblMensagem.Text = string.Format(lblMensagem.Text, "Alteração");
                        this.Text = string.Format(this.Text, "[ALTERAÇÃO]");
                    }
                    break;
                case OperacaoCadastro.Excluir:
                    {
                        lblMensagem.Text = string.Format(lblMensagem.Text, "Exclusão");
                        this.Text = string.Format(this.Text, "[EXCLUSÃO]");
                    }
                    break;
                case OperacaoCadastro.Consulta:
                    {
                        lblMensagem.Text = "Consulta Contato";
                        this.Text = string.Format(this.Text, "[CONSULTA]");
                        btnSim.Enabled = false;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSim_Click(object sender, EventArgs e)
        {
            switch (_operacaoCadastro)
            {
                case OperacaoCadastro.Incluir:
                    await _contatosDatabase.InsertContato(Contato);
                    break;
                case OperacaoCadastro.Alterar:
                    await _contatosDatabase.UpdateContato(Contato);
                    break;
                case OperacaoCadastro.Excluir:
                    await _contatosDatabase.DeleteContato(Contato.Id);
                    break;
            }
            Close();

        }
    }
}
