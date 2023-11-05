using IbgeApi.ViewModels;

namespace IbgeApi.Services.Interfaces;

public interface ILocationService
{
    Task<IResult> Create(LocationViewModel model);
    Task<IResult> GetAll(int skip, int take);
    Task<IResult> GetByCode(int code);
    Task<IResult> GetByCity(string city);
    Task<IResult> GetByState(string city);
    Task<IResult> Update(LocationViewModel model, int code);
    Task<IResult> Remove(int code);
}