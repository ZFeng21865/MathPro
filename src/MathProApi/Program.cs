using IMathLib;
using MathLib;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
builder.Services.AddSingleton<IMyMathLib, MyMathLib>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title= "MathPro API",
        Description = "This is a Sample API to demonstrate the common practices of several areas, including API documentation, Exception handling, as well as logging."
    });

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MathProApi.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MathProApi.Common.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
