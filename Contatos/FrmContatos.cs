using System.Windows.Forms;

namespace AgendaContatos.Contatos
{
    public partial class FrmContatos : Form
    {
        public FrmContatos()
        {
            InitializeComponent();
        }

        private void FrmContatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
