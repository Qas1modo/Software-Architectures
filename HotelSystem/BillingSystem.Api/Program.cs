using BillingSystem.Api;
using BillingSystem.Api.Middlewares;
using HotelSystem.ServiceDefaults;
using Wolverine;
using Wolverine.Transports.Tcp;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("BillingDatabase")
    ?? throw new ArgumentException("Connection string was not found");

builder.Services.ConfigureServices(connectionString);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Host.UseWolverine(opts =>
{
    opts.MultipleHandlerBehavior = MultipleHandlerBehavior.Separated;
    opts.Durability.MessageIdentity = MessageIdentity.IdAndDestination;
    opts.Policies.AutoApplyTransactions();

    var wolverineConfig = builder.Configuration.GetSection("Wolverine");
    var listenPort = wolverineConfig.GetValue<int>("ListenPort");
    var publishPorts = wolverineConfig.GetSection("PublishPorts").Get<int[]>() ?? [];

    opts.ListenAtPort(listenPort);

    foreach (var port in publishPorts)
    {
        opts.PublishAllMessages().ToPort(port);
    }
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