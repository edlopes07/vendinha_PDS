#nullable disable

namespace vendinha_backend.Desktop;

partial class DividasForm
{
    private System.ComponentModel.IContainer components = null;
    private FlowLayoutPanel barra = null!;
    private NumericUpDown nudValor = null!;
    private DataGridView gridDividas = null!;
    private Button btnAdicionar = null!;
    private Button btnPagar = null!;

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
        barra = new FlowLayoutPanel();
        nudValor = new NumericUpDown();
        gridDividas = new DataGridView();
        btnAdicionar = new Button();
        btnPagar = new Button();
        ((System.ComponentModel.ISupportInitialize)nudValor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridDividas).BeginInit();
        barra.SuspendLayout();
        SuspendLayout();

        barra.Dock = DockStyle.Top;
        barra.Height = 52;
        barra.Padding = new Padding(8);
        barra.WrapContents = false;
        barra.Controls.Add(new Label { Text = "Valor da nova dívida:", AutoSize = true, Margin = new Padding(3, 8, 3, 0) });
        barra.Controls.Add(nudValor);
        barra.Controls.Add(btnAdicionar);
        barra.Controls.Add(btnPagar);

        nudValor.DecimalPlaces = 2;
        nudValor.Maximum = 100000000;
        nudValor.Minimum = 0.01m;
        nudValor.Width = 110;

        btnAdicionar.AutoSize = true;
        btnAdicionar.Margin = new Padding(8, 3, 3, 3);
        btnAdicionar.Text = "Adicionar dívida";
        btnAdicionar.Click += btnAdicionar_Click;

        btnPagar.AutoSize = true;
        btnPagar.Margin = new Padding(8, 3, 3, 3);
        btnPagar.Text = "Marcar como paga";
        btnPagar.Click += btnPagar_Click;

        gridDividas.AllowUserToAddRows = false;
        gridDividas.Dock = DockStyle.Fill;
        gridDividas.ReadOnly = true;
        gridDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(gridDividas);
        Controls.Add(barra);
        Name = "DividasForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Dívidas";
        Shown += DividasForm_Shown;

        barra.ResumeLayout(false);
        barra.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)gridDividas).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudValor).EndInit();
        ResumeLayout(false);
    }
}
