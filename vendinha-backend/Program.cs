using vendinha_backend.Contexts;

namespace vendinha_backend.Services
{
    public static class BancoInicializador
    {
        public static void Main(string[] args)
        {
            Criar();
        }

        public static void Criar(string connectionString = "Data Source=vendinha.db")
        {
            using var context = new VendinhaDbContext(connectionString);
            context.Database.EnsureCreated();
        }
    }
}