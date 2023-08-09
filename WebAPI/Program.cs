using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System.Text;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; // i�erik pazarl���na a��k...
    config.ReturnHttpNotAcceptable = true;
})
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Davran��� de�i�tirdik. Validation'dan gelen hata objesini de�i�tirdik.
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShapper();

builder.Services.AddIdentity<User, Role>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequiredLength = 6; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
    cfg.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
    cfg.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
    cfg.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
    cfg.Password.RequireDigit = true; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz
    cfg.SignIn.RequireConfirmedEmail = true;
    cfg.Lockout.AllowedForNewUsers = true;
    cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1000);
    cfg.Lockout.MaxFailedAccessAttempts = 3;
}).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    //Adding Jwt Bearer
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("secretsecretsecretsecretsecretsecretsecret")),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Apms Api",
        Description = ".Net 6 Application",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
       "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {new OpenApiSecurityScheme
                        {
                     Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                         },
                      Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                  },
                  new List<string>()
                   }
                   });
});

var app = builder.Build();



var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseCors("CorsPolicy"); // Herhangi bir istemci, herhangi bir verb ile istek atabilir. Herhangi bir Headers datas�na ula�abilir.

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
