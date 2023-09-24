using Domain.Entidades;
using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class BaseContext : IdentityDbContext<ApplicationUser>
    {
        public BaseContext(DbContextOptions options) : base(options) { }

        public DbSet<SistemaFinanceiro> SistemaFinanceiros { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiros { set; get; }
        public DbSet<Categoria> Categorias { set; get; }
        public DbSet<Despesa> Despesas { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Server=localhost; Database=SISTEMA_FINACEIRO; Integrated Security=True; trustServerCertificate=true";
        }

    }
}