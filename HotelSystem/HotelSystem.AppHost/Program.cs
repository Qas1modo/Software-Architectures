var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HotelServiceSystem_Api>("hotelservicesystem-api");
builder.AddProject<Projects.AccessSystem_Api>("accesssystem-api");
builder.AddProject<Projects.RoomManagementSystem_API>("roommanagementsystem-api");
builder.AddProject<Projects.BillingSystem_Api>("billingsystem-api");

builder.Build().Run();
