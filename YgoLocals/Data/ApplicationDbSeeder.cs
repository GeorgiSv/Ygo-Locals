namespace YgoLocals.Data
{
    using YgoLocals.Data.Seeders;

    public class ApplicationDbSeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("DbContext is null on start seeder!");
            }

            if (serviceProvider == null)
            {
                throw new ArgumentException("ServiceProvider is null on start seeder!");
            }

            var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(ApplicationDbSeeder));
            var seeders = new List<ISeeder>
                          {
                              new RoleSeeder(),
                              new UserSeeder(),
                              new TournamentTypeSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"{seeder.GetType().Name} done seeding.");
            }
        }
    }
}
