using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripsByUsername(string username);

        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string username);
        

        void AddTrip(Trip trip);
        void AddStop(string tripName, string username, Stop newStop);

        Task<bool> SaveChangesAsync();
        
    }
}