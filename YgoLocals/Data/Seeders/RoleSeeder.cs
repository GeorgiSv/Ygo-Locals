namespace YgoLocals.Data.Seeders
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using YgoLocals.Infrastructure;

    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var role = await roleManager.FindByNameAsync(Constants.AdministratorRoleName);

            if (role is null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRoleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
