var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BillingSystem>("billingsystem");

builder.Build().Run();
