using Microsoft.EntityFrameworkCore;
using APICatalogo.Models;

public class MeuDbContext : DbContext {
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) {
    }

    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

    // Configure the relationships and table mappings here, if necessary
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // Example of configuring relationships
        modelBuilder.Entity<Condominio>()
            .HasMany(c => c.Moradores)
            .WithOne(m => m.Condominio)
            .HasForeignKey(m => m.CondominioId);

        modelBuilder.Entity<Condominio>()
            .HasMany(c => c.Pagamentos)
            .WithOne(p => p.Condominio)
            .HasForeignKey(p => p.CondominioId);

        // Additional configurations for other entities, if necessary
    }
}
