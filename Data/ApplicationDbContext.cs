using ApiCompraventa.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCompraventa.Data
{
    public class ApplicationDbContext :  IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categorias> Categoriass { get; set; }
        public DbSet<Detalles> Detalless { get; set; }
        public DbSet<FotoArticulo> FotoArticulos { get; set; }
        //public DbSet<IdentityModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Articulo>()
                .HasOne(bc => bc.Categorias)
                .WithMany(b => b.Articulos)
                .HasForeignKey(bc => bc.CategoriaId);
            modelBuilder.Entity<Articulo>()
                .HasOne(bc => bc.Marca)
                .WithMany(b => b.Articulos)
                .HasForeignKey(bc => bc.MarcaId);

            modelBuilder.Entity<Historial>()
                .HasOne(bc => bc.articulo)
                .WithMany(b => b.Historiales)
                .HasForeignKey(bc => bc.articuloId);

            modelBuilder.Entity<Detalles>()
                .HasOne(bc => bc.historial)
                .WithMany(b => b.detalles)
                .HasForeignKey(bc => bc.HistorialId);
            modelBuilder.Entity<Detalles>()
                .HasOne(bc => bc.estado)
                .WithMany(b => b.detalles)
                .HasForeignKey(bc => bc.EstadoId);

            modelBuilder.Entity<FotoArticulo>()
                .HasOne(bc => bc.Articulo)
                .WithMany(b => b.FotoArticulos)
                .HasForeignKey(bc => bc.ArticuloId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
