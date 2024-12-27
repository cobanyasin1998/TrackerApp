using MassTransit;
using Notification.API.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMassTransit(x =>
{
    // Consumer ekleme
    x.AddConsumer<UserAddedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("amqps://foomgkgi:3XRQbC1RsE3dIcZj7FuusV3PZTdkvoCH@rattlesnake.rmq.cloudamqp.com/foomgkgi"));

        // Consumer için queue ayarý
        cfg.ReceiveEndpoint("user-added-event-queue", e =>
        {
            e.ConfigureConsumer<UserAddedEventConsumer>(context);
        });
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
