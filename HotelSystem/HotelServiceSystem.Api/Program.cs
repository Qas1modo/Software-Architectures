using HotelServiceSystem.Api;
using HotelServiceSystem.Api.Middleware;
using HotelSystem.ServiceDefaults;
using Wolverine;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.ConfigureServices(builder.Configuration);

builder.Host.UseWolverine(opts =>
{
    opts.MultipleHandlerBehavior = MultipleHandlerBehavior.Separated;
    opts.Durability.MessageIdentity = MessageIdentity.IdAndDestination;
    opts.Policies.AutoApplyTransactions();
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUiOptions => {
            swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Service System API");
            swaggerUiOptions.RoutePrefix = string.Empty;
        }
    );
}
app.UseCustomExceptionHandler();

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
