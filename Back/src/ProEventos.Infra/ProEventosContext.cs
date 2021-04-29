using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;

namespace ProEventos.Infra
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) {}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PalestranteEvento>().
            HasKey(palestranteEventos => new { palestranteEventos.EventoId, palestranteEventos.PalestranteId} );
        
            modelBuilder.Entity<Evento>().
                 HasMany(e => e.RedesSociais).
                 WithOne(rs => rs.Evento).
                 OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>().
                 HasMany(e => e.RedesSociais).
                 WithOne(rs => rs.Palestrante).
                 OnDelete(DeleteBehavior.Cascade);
        }
    }
}