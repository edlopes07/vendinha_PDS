using vendinha_backend.Models;
using vendinha_backend.Services;

namespace vendinha_backend.Desktop;

public partial class DividasForm : Form
{
    private readonly Cliente cliente;
    private readonly DividaService service = new();

    public DividasForm(Cliente cliente)
    {
        this.cliente = cliente;
        InitializeComponent();
        Text = $"Dívidas - {cliente.Nome}";
    }

    private void DividasForm_Shown(object? sender, EventArgs e) => CarregarDividas();

    private void btnAdicionar_Click(object? sender, EventArgs e) => AdicionarDivida();

    private void btnPagar_Click(object? sender, EventArgs e) => AlternarPagamento();

    private void gridDividas_SelectionChanged(object? sender, EventArgs e) => AtualizarBotaoPagamento();

    private void CarregarDividas()
    {
        gridDividas.DataSource = service.Consultar(cliente.Cpf);
        if (gridDividas.Columns.Count == 0)
        {
            return;
        }

        gridDividas.Columns[nameof(Divida.ClienteCpf)]!.Visible = false;
        gridDividas.Columns[nameof(Divida.Id)]!.HeaderText = "Código";
        gridDividas.Columns[nameof(Divida.Valor)]!.HeaderText = "Valor";
        gridDividas.Columns[nameof(Divida.Valor)]!.DefaultCellStyle.Format = "C2";
        gridDividas.Columns[nameof(Divida.Paga)]!.HeaderText = "Paga";
        gridDividas.Columns[nameof(Divida.DataCriacao)]!.HeaderText = "Criada em";
        gridDividas.Columns[nameof(Divida.DataCriacao)]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        gridDividas.Columns[nameof(Divida.DataPagamento)]!.HeaderText = "Paga em";
        gridDividas.Columns[nameof(Divida.DataPagamento)]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        AtualizarBotaoPagamento();
    }

    private void AdicionarDivida()
    {
        if (service.Criar(cliente.Cpf, new Divida { Valor = nudValor.Value }))
        {
            nudValor.Value = nudValor.Minimum;
            CarregarDividas();
            return;
        }

        MessageBox.Show(this, "Não foi possível adicionar a dívida. Verifique se já existe uma dívida em aberto para este cliente.", "Operação não realizada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void AlternarPagamento()
    {
        if (gridDividas.CurrentRow?.DataBoundItem is not Divida divida)
        {
            return;
        }

        if (service.AlternarPagamento(divida.Id))
        {
            CarregarDividas();
        }
    }

    private void AtualizarBotaoPagamento()
    {
        if (gridDividas.CurrentRow?.DataBoundItem is Divida divida)
        {
            btnPagar.Enabled = true;
            btnPagar.Text = divida.Paga ? "Marcar como não paga" : "Marcar como paga";
            return;
        }

        btnPagar.Enabled = false;
        btnPagar.Text = "Marcar como paga";
    }
}
