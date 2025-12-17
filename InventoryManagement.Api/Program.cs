
    using System;
using System.Reflection;
using System.Text;
using FluentValidation;
using InventoryManagement.Api.Middleware;
using InventoryManagement.Application.Command.UserCommand;
using InventoryManagement.Application.Command.UserCommandValidation;
using InventoryManagement.Application.Interface;
using InventoryManagement.Application.Security;
using InventoryManagement.Application.Service;
using InventoryManagement.Infrastructure;
    using InventoryManagement.Infrastructure.Data;
using InventoryManagement.Infrastructure.Implemantation;
using InventoryManagement.Infrastructure.Persistence;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Scalar.AspNetCore;
    using Serilog;

    var builder = WebApplication.CreateBuilder(args);
    var _configuration = builder.Configuration;

    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
    builder.Services.AddProblemDetails(options =>
    {
        options.CustomizeProblemDetails = ctx =>
        {
            // Always include useful metadata
            ctx.ProblemDetails.Extensions["traceId"] = ctx.HttpContext.TraceIdentifier;
            ctx.ProblemDetails.Extensions["timestamp"] = DateTime.UtcNow;
            ctx.ProblemDetails.Instance = $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}";
        };
    });
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.WriteTo.Console();
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });
    builder.Services.Configure<JWT>(_configuration.GetSection("JWT"));
    builder.Services.AddSingleton<JwtTokenGenerator>();
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })

         .AddJwtBearer(o =>
         {
             o.RequireHttpsMetadata = false;
             o.SaveToken = false;
             o.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ClockSkew = TimeSpan.Zero,

                 ValidIssuer = _configuration["JWT:Issuer"],
                 ValidAudience = _configuration["JWT:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]))
             };
         });
    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
        cfg.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    }
    );

builder.Services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidation).Assembly);


var app = builder.Build();
    app.UseStatusCodePages();
    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();
app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();


    app.MapControllers();

    app.Run();
