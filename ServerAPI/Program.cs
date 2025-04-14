using BussinessObject;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ServerContext>();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var modelbuilder = new ODataConventionModelBuilder();
modelbuilder.EntitySet<Account>("Accounts");
modelbuilder.EntitySet<Role>("Roles");
modelbuilder.EntitySet<Product>("Products");
modelbuilder.EntitySet<Category>("Categories");
modelbuilder.EntitySet<Order>("Orders");

modelbuilder.EntityType<OrderDetails>().HasKey(x => new { x.OrderId, x.ProductId });
modelbuilder.EntityType<Category_Product>().HasKey(x => new { x.CategoryId, x.ProductId });

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().SetMaxTop(null).Count().Expand().AddRouteComponents("odata", modelbuilder.GetEdmModel()));


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
