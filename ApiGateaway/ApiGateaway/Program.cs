using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Configuration.AddJsonFile("ocelot.json" , optional:false , reloadOnChange:true);

builder.Services.AddOcelot(builder.Configuration);

// Add Swagger UI
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


await app.UseOcelot();

app.Run();

