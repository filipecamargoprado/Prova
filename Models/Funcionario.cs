namespace API.Models;

public class Funcionario
{
    public Funcionario()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public double Salario { get; set; }
    public int Cpf { get; set; }

}