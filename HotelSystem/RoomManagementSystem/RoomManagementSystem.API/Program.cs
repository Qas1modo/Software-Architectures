using HotelSystem.ServiceDefaults;
using RoomManagementSystem.API;
using RoomManagementSystem.BL.Installers;
using RoomManagementSystem.DAL.EFCore;
using RoomManagementSystem.DAL.EFCore.Database;
using Wolverine;
using Wolverine.Transports.Tcp;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallBL();
builder.Services.InstallDAL(builder.Configuration.GetConnectionString("RoomManagementDb"));

builder.Services.AddMediatR(cfg => {
    // Register handlers from BL assembly
    cfg.RegisterServicesFromAssembly(typeof(BLInstaller).Assembly);
    // Register handlers from API assembly if you have any there
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Run DB migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RoomManagementDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
