namespace YgoLocals.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using YgoLocals.Data.Entities;
    using YgoLocals.Data.Entities.Base.Contracts;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Deck> Deck { get; set; }

        public DbSet<Match> Match { get; set; }

        public DbSet<Tournament> Tournament { get; set; }

        public DbSet<TournamentType> TournamentType { get; set; }

        public DbSet<TournamentPlayer> TournamentPlayer { get; set; }

        public DbSet<TournamentPlayerDeck> TournamentPlayerDeck { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<User>(entity =>
            {
                entity
                .HasMany(u => u.Decks)
                .WithOne(d => d.User);

                entity.HasQueryFilter(c => !c.IsDeleted);
            });

            builder.Entity<Deck>(entity =>
            {
                entity.HasQueryFilter(c => !c.IsDeleted);
            });

            builder
             .Entity<Match>()
             .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<Tournament>(entity =>
            {
                entity
                .HasMany(t => t.Players)
                .WithOne(t => t.Tournament);

                entity.HasQueryFilter(c => !c.IsDeleted);
            });

            builder
             .Entity<TournamentType>()
             .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<TournamentPlayer>(entity =>
            {
                entity.HasQueryFilter(t => !t.Tournament.IsDeleted);
            });

            builder.Entity<TournamentPlayerDeck>(entity =>
            {
                entity.HasKey(e => new { e.TournamentPlayerId, e.DeckId });
            });

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInfoRules()
          => ChangeTracker
                .Entries()
                .ToList()
            .ForEach(entry =>
            {
                if (entry.Entity is IDeletableEntity deletableEntity && entry.State == EntityState.Deleted)
                {
                    deletableEntity.DeletedOn = DateTime.UtcNow;
                    deletableEntity.IsDeleted = true;

                    entry.State = EntityState.Modified;

                    return;
                }

                if (entry.Entity is IAuditInfo entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                }
            });
    }
}