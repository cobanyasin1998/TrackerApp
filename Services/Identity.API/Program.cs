using Identity.Application.ServiceRegistration;
using Identity.Persistence.ServiceRegistration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
    opt.SerializerSettings.Formatting = Formatting.Indented;
});

builder.Services.IdentityApplicationAddServices();
builder.Services.IdentityPersistenceAddServices(builder.Configuration);
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "My API";
        document.Info.Description = "A sample API using NSwag in .NET Core";
    };
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

await app.RunAsync();
