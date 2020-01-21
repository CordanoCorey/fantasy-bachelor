using Microsoft.EntityFrameworkCore;
using fantasy_bachelor.Entity.DataClasses;
using System;

namespace fantasy_bachelor.Entity.Context
{
    public partial class FantasyBachelorContext
    {
        public virtual DbSet<Contestant> Contestant { get; set; }
        public virtual DbSet<ContestantSeasonXref> ContestantSeason { get; set; }
        public virtual DbSet<FunFact> FunFact { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public void OnModelCreating_Common(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contestant>(entity =>
            {
                entity.ToTable("Contestant", "Common");

                entity.Property(e => e.Bio)
                    .HasMaxLength(1000);

                entity.Property(e => e.Hometown)
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Profession)
                    .HasMaxLength(100);

                entity.HasData(
                  new Contestant
                  {
                      Id = 1,
                      Name = "Alayah",
                      Age = 24,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 2,
                      Name = "Alexa",
                      Age = 27,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 3,
                      Name = "Avonlea",
                      Age = 27,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 4,
                      Name = "Courtney",
                      Age = 26,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 5,
                      Name = "Deandra",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 6,
                      Name = "Eunice",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 7,
                      Name = "Hannah Ann",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 8,
                      Name = "Jade",
                      Age = 26,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 9,
                      Name = "Jasmine",
                      Age = 25,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 10,
                      Name = "Jenna",
                      Age = 22,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 11,
                      Name = "Katrina",
                      Age = 28,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 12,
                      Name = "Kelley",
                      Age = 28,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 13,
                      Name = "Kelsey",
                      Age = 28,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 14,
                      Name = "Kiarra",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 15,
                      Name = "Kylie",
                      Age = 25,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 16,
                      Name = "Lauren",
                      Age = 26,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 17,
                      Name = "Lexi",
                      Age = 26,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 18,
                      Name = "Madison",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 19,
                      Name = "Maurissa",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 20,
                      Name = "Megan",
                      Age = 26,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 21,
                      Name = "Mykenna",
                      Age = 22,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 22,
                      Name = "Natasha",
                      Age = 31,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 23,
                      Name = "Payton",
                      Age = 23,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 24,
                      Name = "Sarah",
                      Age = 24,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 25,
                      Name = "Savannah",
                      Age = 27,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 26,
                      Name = "Shiann",
                      Age = 27,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 27,
                      Name = "Sydney",
                      Age = 24,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 28,
                      Name = "Tammy",
                      Age = 24,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 29,
                      Name = "Victoria F.",
                      Age = 25,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  },
                  new Contestant
                  {
                      Id = 30,
                      Name = "Victoria P.",
                      Age = 27,
                      Profession = "",
                      Hometown = "",
                      Bio = ""
                  }
                );
            });

            modelBuilder.Entity<ContestantSeasonXref>(entity =>
            {
                entity.ToTable("ContestantSeason_xref", "Common");

                entity.HasOne(d => d.Contestant)
                    .WithMany(p => p.Seasons)
                    .HasForeignKey(d => d.ContestantId)
                    .HasConstraintName("FK_ContestantSeason_Contestant");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Contestants)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("FK_ContestantSeason_Season");

                entity.HasData(
                  new ContestantSeasonXref
                  {
                      Id = 1,
                      ContestantId = 1,
                      SeasonId = 1,
                      Finish = 16
                  },
                  new ContestantSeasonXref
                  {
                      Id = 2,
                      ContestantId = 2,
                      SeasonId = 1,
                      Finish = 16
                  },
                  new ContestantSeasonXref
                  {
                      Id = 3,
                      ContestantId = 3,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 4,
                      ContestantId = 4,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 5,
                      ContestantId = 5,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 6,
                      ContestantId = 6,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 7,
                      ContestantId = 7,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 8,
                      ContestantId = 8,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 9,
                      ContestantId = 9,
                      SeasonId = 1,
                      Finish = 16
                  },
                  new ContestantSeasonXref
                  {
                      Id = 10,
                      ContestantId = 10,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 11,
                      ContestantId = 11,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 12,
                      ContestantId = 12,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 13,
                      ContestantId = 13,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 14,
                      ContestantId = 14,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 15,
                      ContestantId = 15,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 16,
                      ContestantId = 16,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 17,
                      ContestantId = 17,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 18,
                      ContestantId = 18,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 19,
                      ContestantId = 19,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 20,
                      ContestantId = 20,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 21,
                      ContestantId = 21,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 22,
                      ContestantId = 22,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 23,
                      ContestantId = 23,
                      SeasonId = 1,
                      Finish = 20
                  },
                  new ContestantSeasonXref
                  {
                      Id = 24,
                      ContestantId = 24,
                      SeasonId = 1,
                      Finish = 16
                  },
                  new ContestantSeasonXref
                  {
                      Id = 25,
                      ContestantId = 25,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 26,
                      ContestantId = 26,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 27,
                      ContestantId = 27,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 28,
                      ContestantId = 28,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 29,
                      ContestantId = 29,
                      SeasonId = 1
                  },
                  new ContestantSeasonXref
                  {
                      Id = 30,
                      ContestantId = 30,
                      SeasonId = 1
                  }
                );
            });

            modelBuilder.Entity<FunFact>(entity =>
            {
                entity.ToTable("FunFact", "Common");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Contestant)
                    .WithMany(p => p.FunFacts)
                    .HasForeignKey(d => d.ContestantId)
                    .HasConstraintName("FK_FunFact_Contestant");
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.ToTable("Ranking", "Common");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ContestantSeason)
                    .WithMany(p => p.Rankings)
                    .HasForeignKey(d => d.ContestantSeasonId)
                    .HasConstraintName("FK_Ranking_ContestantSeason");

                entity.HasOne(d => d.User)
                  .WithMany(p => p.RankingUser)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK_Ranking_User");

            });
        }
    }
}
