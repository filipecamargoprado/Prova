using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options) { }

        
    }
}