using AspNetCoreWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWorld.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreWorld.Controllers.Api
{
    //[Authorize]
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripsController> _logger;

        public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var result = _repository.GetTripsByUsername(this.User.Identity.Name);

                Console.WriteLine("----------------------------");
                foreach (var vr in result)
                {
                    Console.WriteLine($"Name: {vr.Name}");
                    foreach (var st in vr.Stops)
                    {
                        Console.WriteLine($"ID: {st.Id}, stop name:{st.Name}");
                    }
                }
                Console.WriteLine("----------------------------");
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all trips: {0}", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel trip)
        {
            if(ModelState.IsValid)
            {
                // save data in dataBase
                var newTrip =  Mapper.Map<Trip>(trip);

                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/trips/{trip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }
                else
                {
                    return BadRequest("Failed to save changes to DataBase.");
                }
            }

            return BadRequest("Failed to save the trip.");
        }

    }
}
