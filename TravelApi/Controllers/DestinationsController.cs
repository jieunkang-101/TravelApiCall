using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private TravelApiContext _db;

    public DestinationsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/destinations
    [HttpGet]
    public ActionResult<IEnumerable<Destination>> Get(string country, string city, string landmark)
    {
      var query = _db.Destinations.AsQueryable();

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (landmark != null)
      {
        query = query.Where(entry => entry.Landmark == landmark);
      }

      return query.Include(destination => destination.Reviews).OrderByDescending(desitnation => desitnation.Rating).ToList();
    }

    // POST api/destinations
    [HttpPost]
    public void Post([FromBody] Destination destination)
    {
      _db.Destinations.Add(destination);
      _db.SaveChanges();
    }

    // GET api/destinations/3
    [HttpGet("{id}")]
    public ActionResult<Destination> Get(int id)
    {
      var thisDestination = _db.Destinations.Include(destination => destination.Reviews).FirstOrDefault(entry => entry.DestinationId == id);
      return thisDestination;
    }

    // PUT api/destinations/3
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Destination destination)
    {
      destination.DestinationId = id;
      _db.Entry(destination).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/destinations/3
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var destinationToDelete = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
      _db.Destinations.Remove(destinationToDelete);
      _db.SaveChanges();
    }
  }
}    