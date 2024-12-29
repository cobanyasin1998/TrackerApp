using MassTransit;
using Notification.API.Consumers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();


builder.Services.AddControllers();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserAddedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("amqps://foomgkgi:3XRQbC1RsE3dIcZj7FuusV3PZTdkvoCH@rattlesnake.rmq.cloudamqp.com/foomgkgi"));

        cfg.ReceiveEndpoint("user-added-event-queue", e =>
        {
            e.ConfigureConsumer<UserAddedEventConsumer>(context);
        });
    });
});

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
