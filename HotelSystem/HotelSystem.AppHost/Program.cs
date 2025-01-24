var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HotelServiceSystem_Api>("hotelservicesystem-api");

builder.Build().Run();
