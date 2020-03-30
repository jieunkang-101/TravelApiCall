using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    [Required]
    [StringLength(20)]
    public string UserName { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
  }
}  