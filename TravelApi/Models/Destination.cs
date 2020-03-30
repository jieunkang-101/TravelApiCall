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
    [Required]
    public string Country { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Landmark { get; set; }
    [Required]
    public double Rating { get; set; }
    public ICollection<Review> Reviews { get; set; }
  }
}  