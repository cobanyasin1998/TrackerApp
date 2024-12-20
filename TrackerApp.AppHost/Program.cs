IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Identity_API>("identity-api");

builder.AddProject<Projects.Product_API>("product-api");

builder.AddProject<Projects.TrackerGateway_API>("trackergateway-api");

builder.AddProject<Projects.FileStorage_API>("filestorage-api");

builder.Build().Run();
