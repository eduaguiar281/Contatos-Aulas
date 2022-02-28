﻿using AgendaContatos.Categorias.Models;
using AgendaContatos.Contatos.Models;
using AgendaContatos.Core;
using System;
using System.Windows.Forms;

namespace AgendaContatos.Contatos
{
    public partial class FrmContatoManutencao : Form
    {

        public readonly OperacaoCadastro _operacaoCadastro;
        protected Contato Contato { get; set; }

        public FrmContatoManutencao(OperacaoCadastro operacaoCadastro, Contato contato)
        {
            InitializeComponent();
            _operacaoCadastro = operacaoCadastro;
            Contato = contato;
            contatoBindingSource.DataSource = Contato;
            InicializarDados();
        }

        private void InicializarDados()
        {
            categoriaBindingSource.DataSource = CategoriasDatabase.ObterLista();
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
                    await ContatosDatabase.InsertContato(Contato);
                    break;
                case OperacaoCadastro.Alterar:
                    await ContatosDatabase.UpdateContato(Contato);
                    break;
                case OperacaoCadastro.Excluir:
                    await ContatosDatabase.DeleteContato(Contato.Id);
                    break;
            }
            Close();

        }
    }
}