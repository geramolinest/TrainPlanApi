using System;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainPlanApi.Infrastructure.Persistence;
using TrainPlanApi.Services;
using TrainPlanApi.Services.Interfaces;

namespace TrainPlanApi;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly( typeof(Startup).Assembly ));
        
        services.AddAutoMapper( typeof(Startup).Assembly );

        services.AddTransient( typeof(IResponseService<>), typeof(ResponseService<>) );

        services.AddDbContext<ApplicationDBContext>( 
            options => options.UseMySQL( _configuration.GetConnectionString("mysql") )
        );

        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>()
            .AddApiEndpoints();

        services.AddAuthentication();
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app)
    {

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
