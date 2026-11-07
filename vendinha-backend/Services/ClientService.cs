using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using vendinha_backend.Contexts;
using vendinha_backend.Models;

namespace vendinha_backend.Services;

public class ClienteService
{
    private readonly string connectionString;

    public ClienteService(string connectionString = "Data Source=vendinha.db")
    {
        this.connectionString = connectionString;
    }

    public List<Cliente> Consultar(int pagina)
    {
        return Consultar(null, pagina);
    }

    public List<Cliente> BuscarPorNome(string nome, int pagina)
    {
        return Consultar(nome, pagina);
    }

    private List<Cliente> Consultar(string? nome, int pagina)
    {
        pagina = Math.Max(1, pagina);
        using var context = new VendinhaDbContext(connectionString);
        var clientes = context.Clientes.AsNoTracking().ToList();
        var dividas = context.Dividas.AsNoTracking().Where(d => !d.Paga).ToList();

        if (!string.IsNullOrWhiteSpace(nome))
        {
            clientes = clientes
                .Where(c => c.Nome.Contains(nome.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        foreach (var cliente in clientes)
        {
            cliente.TotalDividas = dividas
                .Where(d => d.ClienteCpf == cliente.Cpf)
                .Sum(d => d.Valor);
        }

        return clientes
            .OrderByDescending(c => c.TotalDividas)
            .ThenBy(c => c.Nome)
            .Skip((pagina - 1) * 10)
            .Take(10)
            .ToList();
    }

    public Cliente? BuscarPorCpf(string cpf)
    {
        using var context = new VendinhaDbContext(connectionString);
        var cliente = context.Clientes.AsNoTracking().FirstOrDefault(c => c.Cpf == cpf);
        if (cliente == null)
        {
            return null;
        }

        cliente.TotalDividas = context.Dividas
            .AsNoTracking()
            .Where(d => d.ClienteCpf == cpf && !d.Paga)
            .Select(d => d.Valor)
            .ToList()
            .Sum();
        return cliente;
    }

    private bool CpfExiste(string cpf)
    {
        using var context = new VendinhaDbContext(connectionString);
        return context.Clientes.Any(c => c.Cpf == cpf);
    }

    public bool Validar(Cliente cliente)
    {
        var validationContext = new ValidationContext(cliente);
        var erros = new List<ValidationResult>();
        return Validator.TryValidateObject(cliente, validationContext, erros, true);
    }

    public bool Criar(Cliente cliente)
    {
        if (!Validar(cliente) || CpfExiste(cliente.Cpf))
        {
            return false;
        }

        using var context = new VendinhaDbContext(connectionString);
        context.Clientes.Add(cliente);
        try
        {
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }

    public bool Atualizar(string cpf, Cliente cliente)
    {
        cliente.Cpf = cpf;
        if (!Validar(cliente))
        {
            return false;
        }

        using var context = new VendinhaDbContext(connectionString);
        var clienteExistente = context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
        if (clienteExistente == null)
        {
            return false;
        }

        clienteExistente.Nome = cliente.Nome;
        clienteExistente.Email = cliente.Email;
        clienteExistente.DataNascimento = cliente.DataNascimento;
        return context.SaveChanges() == 1;
    }

    public bool Excluir(string cpf)
    {
        using var context = new VendinhaDbContext(connectionString);
        var cliente = context.Clientes.FirstOrDefault(c => c.Cpf == cpf);
        if (cliente == null)
        {
            return false;
        }

        var dividas = context.Dividas.Where(d => d.ClienteCpf == cpf).ToList();
        context.Dividas.RemoveRange(dividas);
        context.Clientes.Remove(cliente);
        return context.SaveChanges() > 0;
    }
}