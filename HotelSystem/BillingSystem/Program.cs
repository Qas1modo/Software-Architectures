using BillingSystem.Presentation;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Wolverine;
using Wolverine.Http;
using Wolverine.Transports.Tcp;

var builder = WebApplication.CreateBuilder(args);
const string serviceName = "BillingSystemService";

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();

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

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
        .AddOtlpExporter();
});

builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
          .AddAspNetCoreInstrumentation()
          .AddHttpClientInstrumentation()
          .AddEntityFrameworkCoreInstrumentation()
          .AddSource("Wolverine")
          .AddOtlpExporter())
      .WithMetrics(metrics => metrics
          .AddAspNetCoreInstrumentation()
          .AddHttpClientInstrumentation()
          .AddOtlpExporter());

builder.Services.AddWolverineHttp();

var connectionString = builder.Configuration.GetConnectionString("BillingDatabase")
    ?? throw new ArgumentException("Connection string was not found");
builder.Services.InstallPresentation(connectionString!);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapWolverineEndpoints();

app.Run();
