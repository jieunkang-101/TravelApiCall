//ASP.NET Core User DTO (Data Transfer Object)

namespace TravelApi.Dtos
{
  public class UserDto
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}