using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using SchoolData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
.AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("SchoolConnection"))
           .EnableSensitiveDataLogging() // Move this method call here
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();