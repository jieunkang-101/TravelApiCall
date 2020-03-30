using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string UserName { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }

    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
  }
}  