using HvexTransformerReports.Data;
using HvexTransformerReports.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("UserDatabaseSettings"));
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("TransformerDatabaseSettings"));
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("TestDatabaseSettings"));
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ReportDatabaseSettings"));

builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TransformersService>();
builder.Services.AddSingleton<TestsService>();
builder.Services.AddSingleton<ReportsService>();

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
