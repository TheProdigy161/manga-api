using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.UseDateOnlyTimeOnlyStringConverters();
    });

builder.Services.AddDbContext<MangaContext>(options =>
{
    options.UseNpgsql(builder.Configuration["Database:ConnectionString"]);
});
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

app.UseCors(options => {
    options.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
