WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
//builder.Services.AddReverseProxy()
//     .LoadFromMemory(
//          GetRoutes.PharmacyGetRoutes(),
//          GetClusters.PharmacyGetCluster()
//          );
WebApplication app = builder.Build();

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapReverseProxy();

await app.RunAsync();
