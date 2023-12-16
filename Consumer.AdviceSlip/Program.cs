using Consumer.AdviceSlip;
using Consumer.AdviceSlip.Data;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        IConfiguration configuration = hostBuilder.Configuration;

        AppSettings.ConnectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(AppSettings.ConnectionString);

        services.AddScoped<ApplicationDbContext>(db => new ApplicationDbContext(optionsBuilder.Options));

        services.AddHostedService<Worker>();

    })
    .Build();

CreateDbIfNoneExist(host);

host.Run();

static void CreateDbIfNoneExist(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var service = scope.ServiceProvider;

        try
        {
            var context = service.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

