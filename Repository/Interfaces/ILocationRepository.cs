using IbgeApi.Models;

namespace IbgeApi.Repository.Interfaces;

public interface ILocationRepository : IGenericRepository<LocationModel>
{
    Task<LocationModel> GetByCode(int code);
    Task<IList<LocationModel>> GetByState(string state);
    Task<LocationModel> GetByCity(string city);
}