using vendinha_backend.Models;
using vendinha_backend.Services;

namespace vendinha_backend.Desktop;

public partial class ClienteForm : Form
{
    private readonly ClienteService service;
    private readonly Cliente? clienteOriginal;

    public ClienteForm(ClienteService service, Cliente? cliente = null)
    {
        this.service = service;
        clienteOriginal = cliente;
        InitializeComponent();
        Text = cliente == null ? "Cadastrar cliente" : "Editar cliente";

        if (cliente != null)
        {
            txtCpf.Text = cliente.Cpf;
            txtCpf.ReadOnly = true;
            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email ?? string.Empty;
            pickerNascimento.Value = cliente.DataNascimento;
        }
    }

    private void btnSalvar_Click(object? sender, EventArgs e) => Salvar();

    private void Salvar()
    {
        var cliente = new Cliente
        {
            Cpf = txtCpf.Text,
            Nome = txtNome.Text,
            Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
            DataNascimento = pickerNascimento.Value.Date
        };

        var sucesso = clienteOriginal == null
            ? service.Criar(cliente)
            : service.Atualizar(clienteOriginal.Cpf, cliente);

        if (sucesso)
        {
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        MessageBox.Show(this, "Não foi possível salvar. Verifique CPF, nome, data de nascimento e e-mail.", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
