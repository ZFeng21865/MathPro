using IMathLib;
using MathLib;
using MathProApi.Common;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

#region ---Configure Services----------

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            string traceID = Guid.NewGuid().ToString();

            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError($"{traceID} - Model validation error on [{context.HttpContext.Request.Method}]{context.HttpContext.Request.Path}.");

            string errMsg = string.Empty;

            foreach(var k in context.ModelState.Keys)
            {
                var val = context.ModelState[k];
                if(val != null)
                {
                    foreach(var err in val.Errors)
                    {
                        errMsg = err.ErrorMessage; //just keep the last one to return.
                        logger.LogError($"{traceID} - Key:{k}, Error:{err.ErrorMessage}");
                    }
                }
            }

            return new BadRequestObjectResult(
                        new MathProApiError
                            {
                                Code = MathProApiErrorEnum.InvalidInput,
                                Message = "Invalid input",
                                TraceID = traceID
                            });
        };
    });

//builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

// Add services to the container.
builder.Services.AddSingleton<IMyMathLib, MyMathLib>();

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

#endregion ================================

#region ---Configure Applications----------

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion ==============================

app.Run();
