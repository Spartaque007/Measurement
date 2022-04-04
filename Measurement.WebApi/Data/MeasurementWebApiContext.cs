#nullable disable
using Microsoft.EntityFrameworkCore;
using Measurement.WebApi.Models;

namespace Measurement.WebApi.Data
{
    public class MeasurementWebApiContext : DbContext
    {
        public MeasurementWebApiContext (DbContextOptions<MeasurementWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<SensorState> Measurement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorState>().HasData(
              new SensorState { Id = 1, Value = "111" },
              new SensorState { Id = 2, Value = "222" },
              new SensorState { Id = 3, Value = "333" },
              new SensorState { Id = 4, Value = "444" }

            );
        }
    }
}
