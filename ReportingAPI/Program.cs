
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

  // Request gönderip Async olarak Response alabilmek için AddRequestClient tanýmý yapýlýr.
  // Hangi request için bir client olduðu açýkça yazýlýr.
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
