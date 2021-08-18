using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RestApiMusic.Models
{
    public partial class MusicModel : DbContext
    {
        public MusicModel()
            : base("name=MusicModel")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Records)
                .WithMany(e => e.Artists)
                .Map(m => m.ToTable("RecordArtists").MapLeftKey("ArtistId").MapRightKey("RecordId"));

            }
    }
}
