using Microsoft.EntityFrameworkCore;
using Measurement.WebApi.Data;
using Measurement.WebApi;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MeasurementWebApiContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MeasurementWebApiContext")));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<MeasurementWebApiContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("MeasurementWebApiContext")));

        var app = builder.Build();

        app.MigrateDatabase<MeasurementWebApiContext>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.Urls.Add("http://localhost:80");
        app.Run();
    }


}

public static class ProgramExtension
{
    public static WebApplication MigrateDatabase<T>(this WebApplication webHost) where T : DbContext
    {
        using (var scope = webHost.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<T>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
        return webHost;
    }
}
