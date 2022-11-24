using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParticipanteRifa>()
                .HasKey(x => new { x.ParticipanteId, x.RifaId });
        }

        public DbSet<Participante> Participantes { get; set; }

        public DbSet<Rifa> Rifas { get; set; }

        public DbSet<ParticipanteRifa> ParticipantesRifas { get; set; }
    }
}
