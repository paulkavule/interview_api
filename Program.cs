using Interview.Api.Repositories;
using Interview.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddDbContext<DataDbContext>(options =>
{
    options.UseSqlite("Data Source=Products.db");
});


builder.Services.AddControllers();


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

