var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres(name: "postgres")
    .WithPgAdmin();

var database = postgres.AddDatabase(name: "RentalDb");

var apiService = builder.AddProject<Projects.TP1_Voiture_ApiService>(name: "apiservice")
    .WithHttpHealthCheck(path: "/health")
    .WithReference(database);

builder.AddProject<Projects.Location_Gateway>("gateway")
    .WithReference(apiService)
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.TP1_Voiture_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();