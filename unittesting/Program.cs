using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using unittesting;
using unittesting.AutoMapper;
using unittesting.Interfaces;
using unittesting.Interfaces.Repos;
using unittesting.Repos;
using unittesting.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericEFRepository<>));
builder.Services.AddTransient<ICustomerRepository, CustomerEFRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderRepository, OrderDapperRepository>(provider => new OrderDapperRepository(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
    //.AddNewtonsoftJson(option =>
    //        //Ignore circular references
    //        option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore   
    //        );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
