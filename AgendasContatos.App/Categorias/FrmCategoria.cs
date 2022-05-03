using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using AgendaContatos.Infra.Models;
using AgendasContatos.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaContatos.Categorias
{
    public partial class FrmCategoria : Form
    {
        private readonly IRepository<Categoria, int> _categoriaRepository;

        public FrmCategoria()
        {
            InitializeComponent();
            _categoriaRepository = Program.ServiceProvider.GetService<IRepository<Categoria, int>>();
        }

        private void FrmCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<Categoria> categorias;
            if (textBox1.Text == string.Empty)
                categorias = await _categoriaRepository.ObterTodosAsync();
            else
                categorias = await _categoriaRepository.ObterAsync(textBox1.Text);
            dataGridView1.DataSource = categorias;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCategoriaManutencao manutencao = new(OperacaoCadastro.Incluir, new Categoria());
            manutencao.ShowDialog();
            button1_Click(this, e);
        }

        private Categoria ObterSelecionado()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return default;

            return dataGridView1.SelectedRows[0]?.DataBoundItem as Categoria;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Categoria categoria = ObterSelecionado();
            if (categoria is null)
            {
                MessageBox.Show("Selecione uma categoria no Grid!");
                return;
            }
            FrmCategoriaManutencao manutencao = new(OperacaoCadastro.Alterar, categoria);
            manutencao.ShowDialog();
            button1_Click(this, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Categoria categoria = ObterSelecionado();
            if (categoria is null)
            {
                MessageBox.Show("Selecione uma categoria no Grid!");
                return;
            }
            FrmCategoriaManutencao manutencao = new(OperacaoCadastro.Excluir, categoria);
            manutencao.ShowDialog();
            button1_Click(this, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Categoria categoria = ObterSelecionado();
            if (categoria is null)
            {
                MessageBox.Show("Selecione uma categoria no Grid!");
                return;
            }
            FrmCategoriaManutencao manutencao = new(OperacaoCadastro.Consulta, categoria);
            manutencao.ShowDialog();
            button1_Click(this, e);
        }
    }
}
