using AgendaContatos.Categorias;
using AgendaContatos.Contatos;
using System.Windows.Forms;

namespace AgendaContatos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void contatosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AbrirFormContatos();
        }

        private void categoriasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AbrirFormCategoria();
        }

        private void AbrirFormCategoria()
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is FrmCategoria)
                {
                    form.Show();
                    Ativar(form);
                    return;
                }
            }
            FrmCategoria categoria = new ()
            {
                MdiParent = this
            };
            categoria.Show();
            Ativar(categoria);
        }

        private void Ativar(Form form)
        {
            this.ActivateMdiChild(form);
        }

        private void AbrirFormContatos()
        {
            foreach (var form in this.MdiChildren)
            {
                if (form is FrmContatos)
                {
                    form.Show();
                    Ativar(form);
                    return;
                }
            }
            FrmContatos contatos = new()
            {
                MdiParent = this
            };
            contatos.Show();
            Ativar(contatos);
        }
    }
}
