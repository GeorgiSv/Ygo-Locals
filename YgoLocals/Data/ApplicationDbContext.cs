namespace YgoLocals.Data
{
    using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            }

            //builder.Entity<Match>()
            //    .HasOne(m => m.PlayerOne)
            //    .WithMany(t => t.PlayerOneMatches)
            //    .HasForeignKey(m => m.PlayerOneId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Match>()
            //    .HasOne(m => m.PlayerTwo)
            //    .WithMany(t => t.PlayerTwoMatches)
            //    .HasForeignKey(m => m.PlayerTwoId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Deck>()
               .HasQueryFilter(c => !c.IsDeleted);

            builder
             .Entity<Match>()
             .HasQueryFilter(c => !c.IsDeleted);

            builder
             .Entity<Tournament>()
             .HasQueryFilter(c => !c.IsDeleted);

            builder
             .Entity<TournamentType>()
             .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<TournamentPlayer>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.TournamentId });
                entity.HasQueryFilter(t => !t.Tournament.IsDeleted);
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