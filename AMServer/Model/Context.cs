using Microsoft.EntityFrameworkCore;
namespace Model;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Sala> Sala { get; set; }
    public DbSet<Itens> Itens { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<ItensColetados> ItensColetados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = SNCCH01LABF113\\TEW_SQLEXPRESS; Initial Catalog = AbsolsMask; Integrated Security = True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.id);
            entity.Property(u => u.login);
            entity.Property(u => u.password);
        });
        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(s => s.id);
            entity.Property(s => s.portaEntrada);
        });
        modelBuilder.Entity<Itens>(entity =>
        {
            entity.HasKey(i => i.id);
            entity.Property(i => i.name);
        });
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(g => g.id);
            entity.Property(g => g.date);
            entity.Property(g => g.seed);
            entity.HasOne(g => g.user);
            entity.HasOne(g => g.sala);
        });
        modelBuilder.Entity<ItensColetados>(entity =>
        {
            entity.HasKey(it => it.id);
            entity.HasOne(it => it.game);
        });
    }
}