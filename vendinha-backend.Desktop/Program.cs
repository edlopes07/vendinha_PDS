using vendinha_backend.Services;

namespace vendinha_backend.Desktop;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        BancoInicializador.Criar();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
