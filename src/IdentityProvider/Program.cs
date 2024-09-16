using AspNetCoreHero.ToastNotification;
using IdentityProvider;
using IdentityProvider.Database;
using IdentityProvider.Database.InitialSeed;
using IdentityProvider.Entites;
using IdentityProvider.Services;
using IdentityProvider.Services.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<IdentityDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("IdentityDb"));
    });

    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddScoped<ILocalUserService, LocalUserService>();


    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    // Toast Notification
    builder.Services.AddNotyf(config => 
    { 
        config.DurationInSeconds = 5; 
        config.IsDismissable = true; 
        config.Position = NotyfPosition.TopRight; 
    });

    // Email Service
    builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
    builder.Services.AddScoped<IMailService, MailService>();

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    app.MigrateDatabase().Run();

    app.UseHttpsRedirection();

    app.Run();
}
catch (HostAbortedException)
{

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}