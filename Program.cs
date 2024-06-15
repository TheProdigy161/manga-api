using System.Text.Json.Serialization;
using MangaApi.Database;
using Microsoft.EntityFrameworkCore;
using MangaApi.Services;

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.UseDateOnlyTimeOnlyStringConverters();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

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
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<MangaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

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

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
