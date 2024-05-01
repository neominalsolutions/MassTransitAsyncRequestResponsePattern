
using Contracts.Orders;
using Contracts.Orders.GetOrderById;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(cfg =>
{

  // Request g�nderip Async olarak Response alabilmek i�in AddRequestClient tan�m� yap�l�r.
  // Hangi request i�in bir client oldu�u a��k�a yaz�l�r.
  cfg.AddRequestClient<GetOrderByIdRequest>(new Uri("exchange:get-order-by-id"));

  cfg.UsingRabbitMq((context, cfg) =>
  {
    cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));
    cfg.ConfigureEndpoints(context);
  });

});


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
