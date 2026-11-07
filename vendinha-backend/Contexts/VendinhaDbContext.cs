using Microsoft.EntityFrameworkCore;
using vendinha_backend.Models;

namespace vendinha_backend.Contexts;

public class VendinhaDbContext : DbContext
{
    private readonly string? connectionString;

    public VendinhaDbContext(string? connectionString = "Data Source=vendinha.db")
    {
        this.connectionString = connectionString;
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Divida> Dividas => Set<Divida>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cliente = modelBuilder.Entity<Cliente>();
        cliente.ToTable("clientes");
        cliente.HasKey(c => c.Cpf);
        cliente.Property(c => c.Cpf).HasColumnName("cpf");
        cliente.Property(c => c.Nome).HasColumnName("nome");
        cliente.Property(c => c.Email).HasColumnName("email");
        cliente.Property(c => c.DataNascimento).HasColumnName("datanascimento");
        cliente.Ignore(c => c.Idade);
        cliente.Ignore(c => c.TotalDividas);

        var divida = modelBuilder.Entity<Divida>();
        divida.ToTable("dividas");
        divida.HasKey(d => d.Id);
        divida.Property(d => d.Id).HasColumnName("id");
        divida.Property(d => d.ClienteCpf).HasColumnName("clientecpf");
        divida.Property(d => d.Valor).HasColumnName("valor").HasConversion<double>();
        divida.Property(d => d.Paga).HasColumnName("paga");
        divida.Property(d => d.DataCriacao).HasColumnName("datacriacao");
        divida.Property(d => d.DataPagamento).HasColumnName("datapagamento");
        divida.HasIndex(d => d.ClienteCpf).HasDatabaseName("idx_dividas_clientecpf");
        divida.HasIndex(d => d.ClienteCpf)
            .HasDatabaseName("ux_dividas_aberta_por_cliente")
            .IsUnique()
            .HasFilter("paga = 0");

        base.OnModelCreating(modelBuilder);
    }
}
