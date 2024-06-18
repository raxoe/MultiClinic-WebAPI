using MultiClinic.DataAccess;
using MultiClinic.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//**Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//**Register service for EF Core Dependencies

DbMultiClinicDI.ConfigureServices(builder.Services, builder.Configuration, builder.Configuration.GetSection("ConnectionStrings").GetChildren().First().Key);

//**Register service for DataAccess Dependencies
DataAccessDI.ConfigureServices(builder.Services, builder.Configuration);

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

// Make DB to EnsureCreated, and Initize Default Data
using (var scope = app.Services.CreateScope())
{
    //DbMultiClinicDI.DbEnsureCreate(scope);
    DbMultiClinicDI.MigrateDatabase(scope);
}

app.Run();
