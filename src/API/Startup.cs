using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    private readonly string PolicyName = "VueCorsPolicy";

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(Configuration);
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicProjectAPI", Version = "v1" });
        });
        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, builder =>
            {
                builder.WithOrigins("http://localhost:5173", "http://localhost:5000","http://127.0.0.1:5173");
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicProjectAPI v1"));
        }
        app.UseCors(PolicyName);
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSpa(builder =>
        {
            if (env.IsDevelopment())
            {
                builder.UseProxyToSpaDevelopmentServer("http://127.0.0.1:5173/");
            }
        });
    }
}
