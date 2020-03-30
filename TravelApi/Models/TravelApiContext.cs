using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class TravelApiContext : DbContext
  {
    public TravelApiContext(DbContextOptions<TravelApiContext> options)
        : base(options)
    {
    }

    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Destination>()
          .HasData(
              new Destination { DestinationId = 1, Country = "France", City = "Paris", Landmark = "Louvre Museum" },
              new Destination { DestinationId = 2, Country = "Australia", City = "Sydney", Landmark = "Opera House" },
              new Destination { DestinationId = 3, Country = "USA", City = "Portland", Landmark = "Pittock Mansion" },
              new Destination { DestinationId = 4, Country = "Thailand", City = "Bangkok", Landmark = "Temple of the Emerald Buddha" },
              new Destination { DestinationId = 5, Country = "Korea", City = "Seoul", Landmark = "Gyeongbokgung Palace" }
          );

      builder.Entity<Review>()
          .HasData(
              new Review { ReviewId =1, UserName = "user1", Description = "Amazing architecture! Plan to spend a whole day here if you are really into art. There are so many halls to see. There is also a line to see the Mona Lisa and you have to be quick to take your picture with the painting." , Rating = 5, DestinationId = 1 },
              new Review { ReviewId =2, UserName = "user2", Description = "I loved this place. If your are an art lover, this place is a paradise for you. One day is not enough to visit the entire museum. But still you can visit the main attractions including the famous Mona Lisa." , Rating = 4.7, DestinationId = 1 },
              new Review { ReviewId =3, UserName = "user2", Description = "Wow! Sydney Opera House is absolutely FABULOUS! What an elegant, gorgeous, impressive display of truly artistic architecture.  The beauty of this site is enhanced with each different view. " , Rating = 5, DestinationId = 2 },
              new Review { ReviewId =4, UserName = "user1", Description = "This was a great way to get to know the city of Portland! It was fascinating to learn about one of the first wealthy families to live there. The mansion is really cool and the hike through forest park is a fun way to get there! " , Rating = 4.6, DestinationId = 3 },
              new Review { ReviewId =5, UserName = "user3", Description = "It is one of the best places on South Korea to see the old architecture of a palace. Even traditional events are demonstrate times to time. The most interesting thing in this place is that you can take photographs with soldiers with traditional costumes." , Rating = 4.8, DestinationId = 5 }
          );    
    }
  }
}  