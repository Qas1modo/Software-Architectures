var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HotelServiceSystem_Api>("hotelservicesystem-api");
builder.AddProject<Projects.BillingSystem>("billingsystem");

builder.Build().Run();
