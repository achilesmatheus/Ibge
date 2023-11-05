using IbgeApi.Repository.Interfaces;
using IbgeApi.Services.Interfaces;
using IbgeApi.ViewModels;

namespace IbgeApi.Services;

public class LocationService(ILocationRepository repository) : ILocationService
{
    public async Task<IResult> Create(LocationViewModel model)
    {
        model.Validate();
        if (!model.IsValid)
            return Results.BadRequest(model.Notifications);

        try
        {
            await repository.Create(model.ToModel());
            var result = new ResultViewModel()
            {
                Message = "Location created successfully",
                Data = model
            };

            return Results.Created("/location", result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Errors = e.InnerException,
                Message = e.Message
            };

            return Results.BadRequest(result);
        }
    }

    public async Task<IResult> GetAll(int skip, int take)
    {
        try
        {
            var locations = await repository.GetAll(skip, take);
            var result = new ResultViewModel()
            {
                Data = locations
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.BadRequest(result);
        }
    }

    public async Task<IResult> GetByCode(int code)
    {
        try
        {
            var location = await repository.GetByCode(code);

            var result = new ResultViewModel()
            {
                Data = location
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.BadRequest(result);
        }
    }

    public async Task<IResult> GetByCity(string city)
    {
        try
        {
            var location = await repository.GetByCity(city);
            ResultViewModel result;
            
            if (location is null)
            {
                result = new ResultViewModel()
                {
                    Message = "Não foi possível encontrar esta cidade!"
                };

                return Results.NotFound(result);
            }

            result = new ResultViewModel()
            {
                Data = location
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.BadRequest(result);
        }
    }

    public async Task<IResult> GetByState(string state)
    {
        try
        {
            var location = await repository.GetByState(state);
            if (location is null)
                return Results.NotFound();

            var result = new ResultViewModel()
            {
                Data = location
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.NotFound(result);
        }
    }

    public async Task<IResult> Update(LocationViewModel viewModel, int code)
    {
        viewModel.Validate();
        if (!viewModel.IsValid)
            return Results.BadRequest(viewModel.Notifications);
        try
        {
            var location = await repository.GetByCode(code);
            if (location is null)
                return Results.NotFound();

            var locationFromRequest = viewModel.ToModel();
            location.City = locationFromRequest.City;
            location.State = locationFromRequest.State;

            await repository.Update(location);
            var result = new ResultViewModel()
            {
                Message = $"Location updated successfully",
                Data = locationFromRequest
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.BadRequest(result);
        }
    }
    
    public async Task<IResult> Remove(int code)
    {
        try
        {
            var location = await repository.GetByCode(code);
            if (location is null)
                return Results.NotFound();

            await repository.Remove(location);
            var result = new ResultViewModel()
            {
                Message = "Location removed successfully",
                Data = location
            };

            return Results.Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResultViewModel()
            {
                Message = e.Message,
                Errors = e.InnerException
            };

            return Results.BadRequest(result);
        }
    }
}