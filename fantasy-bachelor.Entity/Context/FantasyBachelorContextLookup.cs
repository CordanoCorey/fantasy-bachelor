using Microsoft.EntityFrameworkCore;
using fantasy_bachelor.Entity.DataClasses;
using System;

namespace fantasy_bachelor.Entity.Context
{
    public partial class FantasyBachelorContext
    {
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<SeasonType> SeasonType { get; set; }
        public void OnModelCreating_Lookup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("Season", "Lookup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.SeasonType)
                    .WithMany(p => p.Seasons)
                    .HasForeignKey(d => d.SeasonTypeId)
                    .HasConstraintName("FK_Season_SeasonType");

                entity.HasData(
                  new DataClasses.Season { Id = 1, Name = "Season 24", Sort = 1, IsActive = true, SeasonTypeId = 1, StartDate = new DateTime(2020, 1, 6), EndDate = new DateTime(2020, 3, 30) }
                );
            });
            modelBuilder.Entity<SeasonType>(entity =>
            {
                entity.ToTable("SeasonType", "Lookup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                  new DataClasses.SeasonType { Id = 1, Name = "Bachelor", Sort = 1, IsActive = true },
                  new DataClasses.SeasonType { Id = 2, Name = "Bachelorette", Sort = 2, IsActive = true },
                  new DataClasses.SeasonType { Id = 3, Name = "Bachelor Pad", Sort = 3, IsActive = true }
                );
            });
        }
    }
}
