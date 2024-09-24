using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Spoonacular.API.Contracts;
using Spoonacular.API.Data;
using Spoonacular.API.Repository;
using Spoonacular.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<CostomerDbContext>(options =>
{
    var connectionstring = builder.Configuration.GetConnectionString("HealthDbString");
    options.UseSqlServer(connectionstring);
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwtOption =>
{
    var key = builder.Configuration["JWTAuth:SecretKey"];
    var keyBytes = Encoding.ASCII.GetBytes(key);
    jwtOption.SaveToken = true;
    jwtOption.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWTAuth:ValidIssuerURL"],
        ValidAudience = builder.Configuration["JWTAuth:ValidAudienceURL"],

    };
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

builder.Services.AddHttpClient<SearchRecipeClientService>();

builder.Services.AddScoped<CustomerNutrientsManagementService>();

builder.Services.AddHttpClient<RecipesByNutrientsClientService>();

builder.Services.AddHttpClient<RecipesPlanWeekByTargetCalorieClientService>();

builder.Services.AddHttpClient<RecipesPlanDayByTargetCalorieClientService>();

builder.Services.AddHttpClient<ExerciseSuggestionClientService>();

builder.Services.AddHttpClient<CaloriesBurnedClientService>();

builder.Services.AddHttpClient<CaloriesGainedClientService>();
builder.Services.AddScoped<CaloriesGainedManagementService>();

builder.Services.AddScoped<CaloriesBurnedManagementService>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("EnableCORS");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
