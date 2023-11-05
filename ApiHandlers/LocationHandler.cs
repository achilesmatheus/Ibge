using IbgeApi.Services.Interfaces;
using IbgeApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IbgeApi.ApiHandlers;

public abstract class LocationHandler
{
    /// <summary>
    /// Cria uma nova localidade
    /// </summary>
    /// <param name="service"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="201">Caso a localidade seja criada com sucesso</response>
    /// <response code="400">Caso não seja possível criar uma localidade</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public static Task<IResult> Create(ILocationService service, LocationViewModel model)
    {
        return service.Create(model);
    }

    /// <summary>
    /// Retorna todas as localidades utilizando paginação
    /// </summary>
    /// <param name="service"></param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    /// <response code="200">Caso uma lista de localidades seja retornada</response>
    /// <response code="404">Caso não seja possível retornar uma lista de localidades</response>
    /// <response code="500">Caso aconteça algum erro desconhecido</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static Task<IResult> GetAll(ILocationService service, int skip, int take)
    {
        return service.GetAll(skip, take);
    }

    /// <summary>
    /// Retorna uma localidade com base na Cidade
    /// </summary>
    /// <param name="service"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    /// <response code="200">Caso a localidade seja encotrada</response>
    /// <response code="404">Caso não seja possível encontrar a localidade</response>
    /// <response code="500">Caso aconteça algum erro desconhecido</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static Task<IResult> GetByCity(ILocationService service, string city)
    {
        return service.GetByCity(city);
    }

    /// <summary>
    /// Retorna uma lista de localidades com base no Estado 
    /// </summary>
    /// <param name="service"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    /// <response code="200">Caso a localidade seja encontrada</response>
    /// <response code="404">Caso não seja possível encontrar uma localidade</response>
    /// <response code="500">Caso aconteça algum erro desconhecido</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static Task<IResult> GetByState(ILocationService service, string state)
    {
        return service.GetByState(state);
    }

    /// <summary>
    /// Retorna uma localidade com base no Código
    /// </summary>
    /// <param name="service"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    /// <response code="200">Caso a localidade seja encontrada</response>
    /// <response code="404">Caso não seja possível encontrar uma localidade</response>
    /// <response code="500">Caso aconteça algum erro desconhecido</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static Task<IResult> GetByIbgeCode(ILocationService service, int code)
    {
        return service.GetByCode(code);
    }

    /// <summary>
    /// Atualiza uma localidade com os dados fornecidos no corpo da requisição
    /// </summary>
    /// <param name="service"></param>
    /// <param name="model"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    /// <response code="200">Caso a localidade seja encontrada e atualizada com sucesso</response>
    /// <response code="400">Caso a localidade seja encontrada e atualizada com sucesso</response>
    /// <response code="404">Caso não seja possível atualizar uma localidade</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static Task<IResult> Update(ILocationService service, LocationViewModel model, int code)
    {
        return service.Update(model, code);
    }

    /// <summary>
    /// Remove uma localidade
    /// </summary>
    /// <param name="service"></param>
    /// <param name="code"></param>
    /// <returns>Uma mensagem confirmando o remoção da localidade e o objeto removido</returns>
    /// <response code="200">Caso a localidade informada seja encontrada e removida com sucesso</response>
    /// <response code="400">Caso não seja possível atualizar a localidade</response>
    /// <response code="404">Caso a localidade informada não seja encontrada</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static Task<IResult> Remove(ILocationService service, int code)
    {
        return service.Remove(code);
    }
}