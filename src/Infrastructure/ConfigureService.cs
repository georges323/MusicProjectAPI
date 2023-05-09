using Application.Common.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<DbContext, ApplicationDbContext>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddTransient<IFileService, FileService>();

        return services;
    }
}