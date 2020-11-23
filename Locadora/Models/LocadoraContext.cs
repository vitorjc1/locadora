using Microsoft.EntityFrameworkCore;

namespace Locadora.Models
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> opt) : base(opt)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Aluguel> Alugueis {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.Filmes)
                .WithMany(p => p.Clientes)
                .UsingEntity<Aluguel>(
                    j => j
                        .HasOne(pt => pt.Filme)
                        .WithMany(t => t.Alugueis)
                        .HasForeignKey(pt => pt.FilmeId),
                    j => j
                        .HasOne(pt => pt.Cliente)
                        .WithMany(p => p.Alugueis)
                        .HasForeignKey(pt => pt.ClienteId),
                    j =>
                    {
                        j.HasKey(t => new { t.AluguelId });
                    });
        }
    }
}


