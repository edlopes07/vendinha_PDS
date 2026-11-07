#nullable disable

namespace vendinha_backend.Desktop;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtBusca = null!;
    private NumericUpDown nudPagina = null!;
    private DataGridView gridClientes = null!;
    private Label lblPagina = null!;
    private FlowLayoutPanel barra = null!;
    private Button btnNovo = null!;
    private Button btnAtualizar = null!;
    private ContextMenuStrip menuClientes = null!;
    private ToolStripMenuItem menuEditar = null!;
    private ToolStripMenuItem menuExcluir = null!;
    private ToolStripMenuItem menuDividas = null!;

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
        txtBusca = new TextBox();
        nudPagina = new NumericUpDown();
        gridClientes = new DataGridView();
        lblPagina = new Label();
        barra = new FlowLayoutPanel();
        btnNovo = new Button();
        btnAtualizar = new Button();
        menuClientes = new ContextMenuStrip(components);
        menuEditar = new ToolStripMenuItem();
        menuExcluir = new ToolStripMenuItem();
        menuDividas = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)nudPagina).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridClientes).BeginInit();
        barra.SuspendLayout();
        menuClientes.SuspendLayout();
        SuspendLayout();

        barra.Dock = DockStyle.Top;
        barra.FlowDirection = FlowDirection.LeftToRight;
        barra.Height = 55;
        barra.Padding = new Padding(8);
        barra.WrapContents = false;
        barra.Controls.Add(new Label { Text = "Buscar por nome:", AutoSize = true, Margin = new Padding(3, 8, 3, 0) });
        barra.Controls.Add(txtBusca);
        barra.Controls.Add(btnNovo);
        barra.Controls.Add(btnAtualizar);
        barra.Controls.Add(new Label { Text = "Página:", AutoSize = true, Margin = new Padding(18, 8, 3, 0) });
        barra.Controls.Add(nudPagina);
        barra.Controls.Add(lblPagina);

        txtBusca.Margin = new Padding(3, 3, 12, 3);
        txtBusca.Width = 220;
        txtBusca.TextChanged += txtBusca_TextChanged;

        btnNovo.AutoSize = true;
        btnNovo.Text = "Novo cliente";
        btnNovo.Click += btnNovo_Click;

        btnAtualizar.AutoSize = true;
        btnAtualizar.Margin = new Padding(12, 3, 3, 3);
        btnAtualizar.Text = "Atualizar";
        btnAtualizar.Click += btnAtualizar_Click;

        nudPagina.Minimum = 1;
        nudPagina.Maximum = 100000;
        nudPagina.ValueChanged += nudPagina_ValueChanged;

        lblPagina.AutoSize = true;
        lblPagina.Margin = new Padding(3, 8, 3, 0);

        gridClientes.AllowUserToAddRows = false;
        gridClientes.AllowUserToDeleteRows = false;
        gridClientes.AutoGenerateColumns = true;
        gridClientes.Dock = DockStyle.Fill;
        gridClientes.ReadOnly = true;
        gridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridClientes.ContextMenuStrip = menuClientes;
        gridClientes.DoubleClick += gridClientes_DoubleClick;

        menuClientes.Items.AddRange(new ToolStripItem[] { menuEditar, menuExcluir, menuDividas });
        menuEditar.Text = "Editar";
        menuEditar.Click += menuEditar_Click;
        menuExcluir.Text = "Excluir";
        menuExcluir.Click += menuExcluir_Click;
        menuDividas.Text = "Dívidas";
        menuDividas.Click += menuDividas_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 650);
        Controls.Add(gridClientes);
        Controls.Add(barra);
        MinimumSize = new Size(850, 500);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Vendinha - Clientes";
        Shown += MainForm_Shown;

        menuClientes.ResumeLayout(false);
        barra.ResumeLayout(false);
        barra.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)gridClientes).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPagina).EndInit();
        ResumeLayout(false);
    }
}
