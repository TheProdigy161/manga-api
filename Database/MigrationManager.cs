using Microsoft.EntityFrameworkCore;

namespace MangaApi.Database;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        IServiceScope scope = app.Services.CreateScope();
        MangaContext appContext = scope.ServiceProvider.GetRequiredService<MangaContext>();

        try
        {
            appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            throw;
        }

        return app;
    }
}