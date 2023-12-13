using Microsoft.EntityFrameworkCore;

namespace _8_1_TripLog.Models
{
    public class TripsContext:DbContext
    {

        public TripsContext(DbContextOptions<TripsContext> options) : base(options) { }

        public DbSet<Trips> Trip { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Trips>().HasData(

                new Trips
                {
                    TripsId = 1,
                    Destination = "Paris",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    ThingToDo1 = "Revolution stuff",
                    ThingToDo2 = "Queen Marie Stuff",
                    ThingToDo3 = "Look at Art"

                }

                );

        }
    }
}
