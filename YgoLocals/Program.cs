using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YgoLocals;
using YgoLocals.Core.Email;
using YgoLocals.Core.EntityServices.Deck;
using YgoLocals.Core.EntityServices.Match;
using YgoLocals.Core.EntityServices.Tournament;
using YgoLocals.Core.EntityServices.TournamentPlayer;
using YgoLocals.Core.ProcessorServices;
using YgoLocals.Data;
using YgoLocals.Data.Entities;
using YgoLocals.Infrastructure.Automapper;
using YgoLocals.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<Config>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<User>(options =>{
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 3;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
    }) // 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDeckService, DeckService>();
builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<ITournamentService, TournamentService>();
builder.Services.AddTransient<ITournamentPlayerService, TournamentPlayerService>();
builder.Services.AddTransient<TournamentProcessorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using var services = app.Services.CreateScope();
var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();
dbContext.Database.Migrate();
new ApplicationDbSeeder().SeedAsync(dbContext, services.ServiceProvider).GetAwaiter().GetResult();

app.Run();
