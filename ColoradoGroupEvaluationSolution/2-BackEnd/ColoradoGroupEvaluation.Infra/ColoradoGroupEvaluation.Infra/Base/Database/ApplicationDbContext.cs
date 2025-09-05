using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

using Microsoft.EntityFrameworkCore;

namespace ColoradoGroupEvaluation.Infra.Base.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TipoTelefoneModel> TiposTelefone { get; set; }
        public DbSet<TelefoneModel> Telefones { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTelefoneModel>().HasKey(t => t.CodigoTipoTelefone);
            modelBuilder.Entity<TelefoneModel>().HasKey(t => t.CodigoTelefone);
            modelBuilder.Entity<ClienteModel>().HasKey(t => t.CodigoCliente);
        }
    }
}