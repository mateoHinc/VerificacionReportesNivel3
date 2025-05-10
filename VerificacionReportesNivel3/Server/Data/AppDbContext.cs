using Microsoft.EntityFrameworkCore;
using VerificacionReportesNivel3.Server.DTOs;
using VerificacionReportesNivel3.Server.Models;

namespace VerificacionReportesNivel3.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Verificacion> Verificaciones { get; set; }
        public DbSet<ArticuloCaroDto> ArticuloCaro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>().HasKey(f => new { f.NoFactura, f.Producto });

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.ClienteNav)
                .WithMany()
                .HasForeignKey(f => f.Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.ProductoNav)
                .WithMany()
                .HasForeignKey(f => f.Producto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Verificacion>()
                .HasOne(v => v.ClienteNav)
                .WithMany()
                .HasForeignKey(v => v.CedulaCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>().HasKey(f => new { f.NoFactura, f.Producto });

            modelBuilder.Entity<ArticuloCaroDto>().HasNoKey();
        }

    }
}
