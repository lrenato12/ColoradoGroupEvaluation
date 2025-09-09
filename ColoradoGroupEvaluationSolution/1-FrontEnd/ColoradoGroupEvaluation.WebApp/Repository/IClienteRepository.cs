using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;

namespace ColoradoGroupEvaluation.WebApp.Repository;

public interface IClienteRepository
{
    /// <summary>
    /// GetClienteById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApiResultModel> GetClienteById(int id);

    /// <summary>
    /// GetAllCliente
    /// </summary>
    /// <returns></returns>
    Task<ApiResultModel> GetAllCliente();

    /// <summary>
    /// CreateCliente
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> CreateCliente(ClienteRequestModel requestModel);

    /// <summary>
    /// UpdateCliente
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> UpdateCliente(ClienteRequestModel requestModel);

    /// <summary>
    /// DeleteCliente
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApiResultModel> DeleteCliente(int id);
}