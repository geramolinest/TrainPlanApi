using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using TrainPlanApi;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup( builder.Configuration );

startup.ConfigureServices( builder.Services ); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

startup.Configure( app );

app.MapIdentityApi<IdentityUser>();

await app.RunAsync();
