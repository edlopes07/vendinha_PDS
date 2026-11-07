using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using vendinha_backend.Contexts;
using vendinha_backend.Models;

namespace vendinha_backend.Services;

public class DividaService
{
    private readonly string connectionString;

    public DividaService(string connectionString = "Data Source=vendinha.db")
    {
        this.connectionString = connectionString;
    }

    public List<Divida> Consultar(string clienteCpf)
    {
        using var context = new VendinhaDbContext(connectionString);
        return context.Dividas
            .AsNoTracking()
            .Where(d => d.ClienteCpf == clienteCpf)
            .OrderByDescending(d => d.DataCriacao)
            .ToList();
    }

    public bool Validar(Divida divida)
    {
        var validationContext = new ValidationContext(divida);
        var erros = new List<ValidationResult>();
        return Validator.TryValidateObject(divida, validationContext, erros, true);
    }

    private static bool TemDivida(VendinhaDbContext context, string clienteCpf)
    {
        return context.Dividas.Any(d => d.ClienteCpf == clienteCpf && !d.Paga);
    }

    private static bool ClienteExiste(VendinhaDbContext context, string clienteCpf)
    {
        return context.Clientes.Any(c => c.Cpf == clienteCpf);
    }

    public bool Criar(string clienteCpf, Divida divida)
    {
        divida.ClienteCpf = clienteCpf;
        divida.Paga = false;
        divida.DataPagamento = null;
        if (!Validar(divida))
        {
            return false;
        }

        using var context = new VendinhaDbContext(connectionString);
        if (!ClienteExiste(context, clienteCpf) || TemDivida(context, clienteCpf))
        {
            return false;
        }

        context.Dividas.Add(divida);
        try
        {
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }

    public bool AlternarPagamento(int id)
    {
        using var context = new VendinhaDbContext(connectionString);
        var divida = context.Dividas.FirstOrDefault(d => d.Id == id);
        if (divida == null)
        {
            return false;
        }

        divida.Paga = !divida.Paga;
        divida.DataPagamento = divida.Paga ? DateTime.Now : null;
        return context.SaveChanges() == 1;
    }
}