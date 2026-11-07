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
        tabela = new TableLayoutPanel();
        botoes = new FlowLayoutPanel();
        btnCancelar = new Button();
        btnSalvar = new Button();
        txtCpf = new TextBox();
        txtNome = new TextBox();
        txtEmail = new TextBox();
        pickerNascimento = new DateTimePicker();
        tabela.SuspendLayout();
        botoes.SuspendLayout();
        SuspendLayout();
        // 
        // tabela
        // 
        tabela.ColumnCount = 2;
        tabela.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
        tabela.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tabela.Controls.Add(botoes, 0, 4);
        tabela.Dock = DockStyle.Fill;
        tabela.Location = new Point(0, 0);
        tabela.Name = "tabela";
        tabela.Padding = new Padding(12);
        tabela.RowCount = 5;
        tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        tabela.Size = new Size(430, 300);
        tabela.TabIndex = 0;
        // 
        // botoes
        // 
        tabela.SetColumnSpan(botoes, 2);
        botoes.Controls.Add(btnCancelar);
        botoes.Controls.Add(btnSalvar);
        botoes.Location = new Point(15, 167);
        botoes.Name = "botoes";
        botoes.Size = new Size(200, 100);
        botoes.TabIndex = 0;
        // 
        // btnCancelar
        // 
        btnCancelar.AutoSize = true;
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.Location = new Point(3, 3);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(75, 25);
        btnCancelar.TabIndex = 0;
        btnCancelar.Text = "Cancelar";
        // 
        // btnSalvar
        // 
        btnSalvar.AutoSize = true;
        btnSalvar.Location = new Point(84, 3);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(81, 25);
        btnSalvar.TabIndex = 1;
        btnSalvar.Text = "Salvar";
        btnSalvar.Click += btnSalvar_Click;
        // 
        // txtCpf
        // 
        txtCpf.Location = new Point(0, 0);
        txtCpf.Name = "txtCpf";
        txtCpf.Size = new Size(100, 23);
        txtCpf.TabIndex = 0;
        // 
        // txtNome
        // 
        txtNome.Location = new Point(0, 0);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(100, 23);
        txtNome.TabIndex = 0;
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(0, 0);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(100, 23);
        txtEmail.TabIndex = 0;
        // 
        // pickerNascimento
        // 
        pickerNascimento.Format = DateTimePickerFormat.Short;
        pickerNascimento.Location = new Point(0, 0);
        pickerNascimento.MaxDate = new DateTime(2026, 11, 7, 0, 0, 0, 0);
        pickerNascimento.Name = "pickerNascimento";
        pickerNascimento.Size = new Size(200, 23);
        pickerNascimento.TabIndex = 0;
        pickerNascimento.Value = new DateTime(2026, 11, 7, 0, 0, 0, 0);
        // 
        // ClienteForm
        // 
        AcceptButton = btnSalvar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(430, 300);
        Controls.Add(tabela);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ClienteForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Cliente";
        tabela.ResumeLayout(false);
        botoes.ResumeLayout(false);
        botoes.PerformLayout();
        ResumeLayout(false);
    }

    private void AdicionarCampo(string texto, Control controle, int linha)
    {
        tabela.Controls.Add(new Label { Text = texto, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 9, 3, 3) }, 0, linha);
        controle.Dock = DockStyle.Fill;
        tabela.Controls.Add(controle, 1, linha);
    }

    private FlowLayoutPanel botoes;
}
