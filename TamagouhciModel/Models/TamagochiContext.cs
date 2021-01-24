using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TamagouhciModel.Models
{
    public partial class TamagochiContext : DbContext
    {
        public TamagochiContext()
        {
        }

        public TamagochiContext(DbContextOptions<TamagochiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalCycle> AnimalCycles { get; set; }
        public virtual DbSet<HealthAnimal> HealthAnimals { get; set; }
        public virtual DbSet<HistoryOfFunction> HistoryOfFunctions { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = localhost\\SQLEXPRESS; Database=tamagochi; Trusted_Connection=true; MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalBd).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AnimalCycle)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalCycle");

                entity.HasOne(d => d.HealthconditionNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.Healthcondition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_healthcondition");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayersAnimals");
            });

            modelBuilder.Entity<HealthAnimal>(entity =>
            {
                entity.HasKey(e => e.HealthId)
                    .HasName("PK__healthAn__AD242160ACB2E867");
            });

            modelBuilder.Entity<HistoryOfFunction>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.FunctionDate })
                    .HasName("PK_");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.HistoryOfFunctions)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.PactiveAnimal, "ActiveAnimal")
                    .IsUnique()
                    .HasFilter("([PActiveAnimal] IS NOT NULL)");

                entity.HasOne(d => d.PactiveAnimalNavigation)
                    .WithOne(p => p.PlayerNavigation)
                    .HasForeignKey<Player>(d => d.PactiveAnimal)
                    .HasConstraintName("FK_AnimalsPlayers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
