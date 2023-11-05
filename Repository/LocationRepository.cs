using IbgeApi.Data;
using IbgeApi.Models;
using IbgeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IbgeApi.Repository;

public class LocationRepository(IbgeDbContext context) : GenericRepository<LocationModel>(context), ILocationRepository
{
    public async Task<LocationModel> GetByCode(int code)
    {
        return await context.Locations.FirstOrDefaultAsync(x => x.Id == code);
    }

    public async Task<IList<LocationModel>> GetByState(string state)
    {
        return await context.Locations.Where(x => x.State.StateName == state).ToListAsync();
    }

    public async Task<LocationModel> GetByCity(string city)
    {
        return await context.Locations.FirstOrDefaultAsync(x => x.City.CityName.ToLower() == city.ToLower());
    }
}