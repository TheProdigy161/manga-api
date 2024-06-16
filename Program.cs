using System.Text.Json.Serialization;
using MangaApi.Database;
using Microsoft.EntityFrameworkCore;
using MangaApi.Services;
using Microsoft.AspNetCore.Identity;

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

#region Builder

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
// Add swagger.
builder.Services.AddSwaggerGen();

// Add appsettings.json file.
builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true);

// Add controllers.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Add Authentication.
builder.Services
    .AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

// Add authorization.
builder.Services.AddAuthorizationBuilder();

// Configure DBContext.
builder.Services.AddDbContext<MangaContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["Database:ConnectionString"],
        options => options.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    );
});

// Add IdentityCore.
builder.Services
    .AddIdentityCore<User>()
    .AddEntityFrameworkStores<MangaContext>()
    .AddApiEndpoints();

// Add DI Services.
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<MangaService>();

// Add AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));

#endregion

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

string[] origins = app.Configuration
    .GetSection("OriginUrls")
    .GetChildren()
    .Select(x => x.Value)
    .ToArray();

app.UseCors(options => {
    options.WithOrigins(origins)
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.MapControllers();

// Enable Identity APIs.
app.MapGroup("auth")
    .MapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MigrateDatabase();

app.Run();

#endregion
