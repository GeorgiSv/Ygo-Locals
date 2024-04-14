namespace YgoLocals.Data.Seeders
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using YgoLocals.Data.Entities;
    using YgoLocals.Infrastructure;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var initCred = configuration.GetValue<string>($"{Constants.AppConfig}:{Constants.InitCred}");

            var user = new User()
            {
                Email = initCred,
                UserName = initCred
            };

            var result = await userManager.CreateAsync(user, initCred);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Constants.AdministratorRoleName);
            }
        }
    }
}
