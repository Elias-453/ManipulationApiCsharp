using Context.Data.Films;
using Microsoft.EntityFrameworkCore;

namespace Data.Extention;

public static class ExtentionData
{
    public static void MigrationData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider
            .GetRequiredService<DataFilm>();

        dbContext.Database.Migrate();
    }
}