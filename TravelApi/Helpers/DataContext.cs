using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Helpers
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
  }
}