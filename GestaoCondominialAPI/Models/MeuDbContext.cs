using Microsoft.EntityFrameworkCore;
using GestaoCondominialAPI.Models; // Ajuste o namespace conforme necessário

public class MeuDbContext : DbContext {
    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Manutencao> Manutencoes { get; set; }
    public DbSet<Servico> Servicos { get; set; }

    public MeuDbContext(DbContextOptions<MeuDbContext> options)
        : base(options) {
    }

    // O método OnConfiguring é opcional se a configuração for feita no Program.cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseOracle("User Id=RM550381;Password=RM221103;Data Source=localhost:1521/ORCL;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // Configurações adicionais de mapeamento, se necessário
    }
}
