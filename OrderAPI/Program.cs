using Contracts.Orders.GetOrderById;
using MassTransit;
using OrderAPI.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(cfg =>
{

  //cfg.AddRequestClient<GetOrderByIdRequest>(new Uri("exchange:get-order-by-id"));

  // AddConsumer daki endpoint ile AddRequestClient daki endpoint Name ayný olmak zorundadýr.
  // isteðin atýldýðý yere isteði iþleyebilecek bir request consumer eklenir.
  cfg.AddConsumer<GetOrderRequestConsumer>().Endpoint(e=> e.Name = "get-order-by-id");


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
