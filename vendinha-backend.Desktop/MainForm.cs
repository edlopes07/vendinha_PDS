using vendinha_backend.Models;
using vendinha_backend.Services;

namespace vendinha_backend.Desktop;

public partial class MainForm : Form
{
    private readonly ClienteService clienteService = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Shown(object? sender, EventArgs e) => CarregarClientes();

    private void txtBusca_TextChanged(object? sender, EventArgs e) => CarregarClientes();

    private void nudPagina_ValueChanged(object? sender, EventArgs e) => CarregarClientes();

    private void btnNovo_Click(object? sender, EventArgs e) => AbrirCadastro();

    private void btnAtualizar_Click(object? sender, EventArgs e) => CarregarClientes();

    private void gridClientes_DoubleClick(object? sender, EventArgs e) => EditarSelecionado();

    private void menuEditar_Click(object? sender, EventArgs e) => EditarSelecionado();

    private void menuExcluir_Click(object? sender, EventArgs e) => ExcluirSelecionado();

    private void menuDividas_Click(object? sender, EventArgs e) => AbrirDividas();

    private void CarregarClientes()
    {
        var pagina = (int)nudPagina.Value;
        var clientes = string.IsNullOrWhiteSpace(txtBusca.Text)
            ? clienteService.Consultar(pagina)
            : clienteService.BuscarPorNome(txtBusca.Text.Trim(), pagina);

        gridClientes.DataSource = clientes;
        ConfigurarColunas();
        lblPagina.Text = $"({clientes.Count} clientes)";
    }

    private void ConfigurarColunas()
    {
        if (gridClientes.Columns.Count == 0)
        {
            return;
        }

        gridClientes.Columns[nameof(Cliente.Cpf)]!.HeaderText = "CPF";
        gridClientes.Columns[nameof(Cliente.Nome)]!.HeaderText = "Nome";
        gridClientes.Columns[nameof(Cliente.Email)]!.HeaderText = "E-mail";
        gridClientes.Columns[nameof(Cliente.DataNascimento)]!.HeaderText = "Nascimento";
        gridClientes.Columns[nameof(Cliente.DataNascimento)]!.DefaultCellStyle.Format = "dd/MM/yyyy";
        gridClientes.Columns[nameof(Cliente.Idade)]!.HeaderText = "Idade";
        gridClientes.Columns[nameof(Cliente.TotalDividas)]!.HeaderText = "Total em aberto";
        gridClientes.Columns[nameof(Cliente.TotalDividas)]!.DefaultCellStyle.Format = "C2";
    }

    private Cliente? ClienteSelecionado()
    {
        return gridClientes.CurrentRow?.DataBoundItem as Cliente;
    }

    private void AbrirCadastro()
    {
        using var tela = new ClienteForm(clienteService);
        if (tela.ShowDialog(this) == DialogResult.OK)
        {
            CarregarClientes();
        }
    }

    private void EditarSelecionado()
    {
        var cliente = ClienteSelecionado();
        if (cliente == null)
        {
            return;
        }

        using var tela = new ClienteForm(clienteService, cliente);
        if (tela.ShowDialog(this) == DialogResult.OK)
        {
            CarregarClientes();
        }
    }

    private void ExcluirSelecionado()
    {
        var cliente = ClienteSelecionado();
        if (cliente == null)
        {
            return;
        }

        var resposta = MessageBox.Show(this, $"Excluir o cliente {cliente.Nome} e suas dívidas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (resposta == DialogResult.Yes && clienteService.Excluir(cliente.Cpf))
        {
            CarregarClientes();
        }
    }

    private void AbrirDividas()
    {
        var cliente = ClienteSelecionado();
        if (cliente == null)
        {
            return;
        }

        using var tela = new DividasForm(cliente);
        tela.ShowDialog(this);
        CarregarClientes();
    }
}
