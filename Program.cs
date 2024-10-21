using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpresaContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>
{
    new Funcionario { Nome = "Filipe Camargo Prado", Salario = 999.99, Cpf = 10 },
    new Funcionario { Nome = "Bruno Miguel", Salario = 899.99, Cpf = 5 },
    new Funcionario { Nome = "Arthur Rafael", Salario = 349.99, Cpf = 20 },
    new Funcionario { Nome = "Matheus", Salario = 1199.99, Cpf = 8 },
};

app.MapPost("api/funcionario/cadastrar", async (EmpresaContext db,[FromBody] Funcionario funcionario) => 
{
    funcionarios.Add(funcionario);
    await db.SaveChangesAsync();
    return Results.Created("", funcionario);
});

app.MapGet("api/funcionario/listar", () => 
{
    if (funcionarios.Count > 0)
    {
        return Results.Ok(funcionarios);
    }
    return Results.NotFound();
});

List<Folha> folhas = new List<Folha>
{
    new Folha { FuncionarioId = "Filipe Camargo Prado", Ano = 2024, Mes = 10, Quantidade = 1, Valor = 999.99 },
    new Folha { FuncionarioId = "Bruno Miguel", Ano = 2024, Mes = 5, Quantidade = 1, Valor=899.99 },
    new Folha { FuncionarioId = "Arthur Rafael", Ano = 2024, Mes = 20, Quantidade = 1,Valor=349.99 },
    new Folha { FuncionarioId = "Matheus", Ano = 2024, Mes = 8, Quantidade = 1, Valor= 1199.99 },
};


app.MapPost("api/folha/cadastrar", () => 
{
    Folhas.Add(folha);
    await db.SaveChangesAsync();
    return Results.Created("", folha);
});

app.MapGet("api/folha/listar", () => 
{
    if (Folha.Count > 0)
    {
        return Results.Ok(folhas);
    }
    return Results.NotFound();
});

app.Run();
