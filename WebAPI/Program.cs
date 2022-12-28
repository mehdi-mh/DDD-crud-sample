using Application.Interfaces.Contexts;
using Application.Service.Customers.Commands.AddCustomer;
using Application.Service.Customers.Commands.DeleteCustomer;
using Application.Service.Customers.Commands.EditCustomer;
using Application.Service.Customers.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString =
    "Server=localhost;Database=crud-project;Trusted_Connection=True;User Id=sa;Password=sapassword!;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));


//DI
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetCustomersService, GetCustomersService>();
builder.Services.AddScoped<IAddCustomerService, AddCustomerService>();
builder.Services.AddScoped<IEditCustomerService, EditCustomerService>();
builder.Services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.MapControllers();

app.Run();