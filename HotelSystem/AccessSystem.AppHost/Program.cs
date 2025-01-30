var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AccessSystem_Api>("accesssystem-api");

builder.Build().Run();
