#nullable disable

namespace vendinha_backend.Desktop;

partial class ClienteForm
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tabela = null!;
    private TextBox txtCpf = null!;
    private TextBox txtNome = null!;
    private TextBox txtEmail = null!;
    private DateTimePicker pickerNascimento = null!;
    private Button btnCancelar = null!;
    private Button btnSalvar = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        tabela = new TableLayoutPanel();
        txtCpf = new TextBox();
        txtNome = new TextBox();
        txtEmail = new TextBox();
        pickerNascimento = new DateTimePicker();
        btnCancelar = new Button();
        btnSalvar = new Button();
        SuspendLayout();

        tabela.ColumnCount = 2;
        tabela.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
        tabela.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tabela.Dock = DockStyle.Fill;
        tabela.Padding = new Padding(12);
        tabela.RowCount = 5;
        for (var i = 0; i < 5; i++)
        {
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        }

        AdicionarCampo("CPF:", txtCpf, 0);
        AdicionarCampo("Nome completo:", txtNome, 1);
        AdicionarCampo("E-mail:", txtEmail, 2);
        pickerNascimento.Format = DateTimePickerFormat.Short;
        pickerNascimento.MaxDate = DateTime.Today;
        AdicionarCampo("Nascimento:", pickerNascimento, 3);

        var botoes = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        btnCancelar.AutoSize = true;
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.Text = "Cancelar";
        btnSalvar.AutoSize = true;
        btnSalvar.Text = "Salvar";
        btnSalvar.Click += btnSalvar_Click;
        botoes.Controls.Add(btnCancelar);
        botoes.Controls.Add(btnSalvar);
        tabela.Controls.Add(botoes, 0, 4);
        tabela.SetColumnSpan(botoes, 2);

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(430, 300);
        Controls.Add(tabela);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ClienteForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Cliente";
        AcceptButton = btnSalvar;
        CancelButton = btnCancelar;
        ResumeLayout(false);
    }

    private void AdicionarCampo(string texto, Control controle, int linha)
    {
        tabela.Controls.Add(new Label { Text = texto, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 9, 3, 3) }, 0, linha);
        controle.Dock = DockStyle.Fill;
        tabela.Controls.Add(controle, 1, linha);
    }
}
