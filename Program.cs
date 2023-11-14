using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using CourseContentManagement.Data;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using CourseContentManagement.Handlers;
using System.Text.Json.Serialization;
using CourseContentManagement.IntegrationEvents.Events;
using CourseContentManagement.IntegrationEvents.Handlers;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.Data.Models;
using CourseContentManagement;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var services = builder.Services;
{

  // Cors
  services.AddCors((options) =>
    {
      options.AddDefaultPolicy(policy =>
      {
        policy.WithOrigins("https://localhost", "http://localhost", "http://localhost:3000", "https://nadegamraolpfrontend.azurewebsites.net")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
      });
    });

  // Setup Controllers
  builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
  );

  builder.Services.AddEndpointsApiExplorer();

  // Authorization
  builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(options =>
  {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = false,
      ValidateAudience = false,
      ClockSkew = TimeSpan.Zero,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
  });

  // Swagger
  builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
      Title = "My API",
      Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
      Type = SecuritySchemeType.Http,
      BearerFormat = "JWT",
      In = ParameterLocation.Header,
      Scheme = "bearer",
      Description = "Please insert JWT with Bearer into field",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
    });
  });

  // Database
  string connectionString = builder.Configuration.GetSection("Database")["ConnectionString"];
  services.AddDbContext<CourseContentDbContext>(options =>
      options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

  // Repositories
  services.AddScoped<IRepository<InfoPage>, InfoPagesRepository>();
  services.AddScoped<IRepository<Section>, SectionsRepository>();
  services.AddScoped<IRepository<Course>, CoursesRepository>();

  // Handlers
  services.AddTransient<SectionsHandler>();
  services.AddTransient<InfoPagesHandler>();
  services.AddTransient<CoursesHandler>();

  // Event Bus
  ConfigureServices.AddEventBus(builder);


  services.AddTransient<CourseCreatedIntegrationEventHandler>();
  services.AddTransient<CourseDeletedIntegrationEventHandler>();
  services.AddTransient<CourseUpdatedIntegrationEventHandler>();
}
var app = builder.Build();
{
  app.UseCors();

  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
  }
  else
  {
    app.UseProductionExceptionHandler();
  }

  // app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  var eventBus = app.Services.GetRequiredService<Infrastructure.EventBus.Generic.IEventBus>();
  eventBus.Subscribe<CourseCreatedIntegrationEvent, CourseCreatedIntegrationEventHandler>();
  eventBus.Subscribe<CourseDeletedIntegrationEvent, CourseDeletedIntegrationEventHandler>();
  eventBus.Subscribe<CourseUpdatedIntegrationEvent, CourseUpdatedIntegrationEventHandler>();
}
app.Run();
