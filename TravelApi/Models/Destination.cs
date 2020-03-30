using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Destination
  {
    public Destination()
    {
      this.Reviews = new HashSet<Review>();
    }

    public int DestinationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Landmark { get; set; }
    public ICollection<Review> Reviews { get; set; }
  }
}  