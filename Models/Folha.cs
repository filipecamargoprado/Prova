namespace API.Models;

public class Folha
{
    public Folha()
    {
        FuncionarioId = Guid.NewGuid().ToString();
    }
    public string? FuncionarioId { get; set; }
    public int Ano { get; set; }
    public int Mes { get; set; }
    public int Quantidade { get; set; }
    public float Valor { get; set; }
}
