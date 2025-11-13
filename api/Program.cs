using application.Interfaces.Services;
using application.Services;
using domain.Interfaces.Repository;
using infrastructure.Extensions;
using infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICounterRepository, CounterRepository>();
builder.Services.AddScoped<ICounterService, CounterService>();

builder.Services.AddScoped<IReasonRespository, ReasonRepository>();
builder.Services.AddScoped<IReasonService, ReasonService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDevOrigin", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowDevOrigin");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
