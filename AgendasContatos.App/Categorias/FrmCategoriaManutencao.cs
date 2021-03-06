using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using AgendaContatos.Infra.Models;
using AgendasContatos.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace AgendaContatos.Categorias
{
    public partial class FrmCategoriaManutencao : Form
    {
        private readonly IRepository<Categoria, int> _categoriasRepository;
        public readonly OperacaoCadastro _operacaoCadastro;
        protected Categoria Categoria { get; set; }
        public FrmCategoriaManutencao(OperacaoCadastro operacaoCadastro, Categoria categoria)
        {
            InitializeComponent();
            _categoriasRepository = Program.ServiceProvider.GetService<IRepository<Categoria, int>>();
            _operacaoCadastro = operacaoCadastro;
            Categoria = categoria;
            categoriaBindingSource.DataSource = Categoria;
            InicializarDados();
        }

        private void InicializarDados()
        {
            switch (_operacaoCadastro)
            {
                case OperacaoCadastro.Incluir:
                    {
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
                        lblMensagem.Text = "Consulta Categoria";
                        this.Text = string.Format(this.Text, "[CONSULTA]");
                        btnSim.Enabled = false;
                    }
                    break;
            }
        }

        private async void btnSim_Click(object sender, System.EventArgs e)
        {
            switch (_operacaoCadastro)
            {
                case OperacaoCadastro.Incluir:
                    await _categoriasRepository.InsertAsync(Categoria);
                    break;
                case OperacaoCadastro.Alterar:
                    await _categoriasRepository.UpdateAsync(Categoria);
                    break;
                case OperacaoCadastro.Excluir:
                    await _categoriasRepository.DeleteAsync(Categoria);
                    break;
            }
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
