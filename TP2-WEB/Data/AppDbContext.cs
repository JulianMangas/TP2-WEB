using Microsoft.EntityFrameworkCore;
using TP2_WEB.Models;
namespace TP2_WEB.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Producto> Productos => Set<Producto>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Producto>().Property(p => p.Precio).HasPrecision(18, 2);

        mb.Entity<Producto>()
            .HasOne(p => p.Categoria).WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId).OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Producto>()
            .HasOne(p => p.Proveedor).WithMany(v => v.Productos)
            .HasForeignKey(p => p.ProveedorId).OnDelete(DeleteBehavior.Restrict);
    }
}