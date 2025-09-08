using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;

namespace ColoradoGroupEvaluation.WebApp.Repository;

public interface IClienteRepository
{
    Task<ApiResultModel> GetClienteById(int id);
    Task<ApiResultModel> GetAllCliente();
    Task<ApiResultModel> CreateCliente(ClienteRequestModel requestModel);
    Task<ApiResultModel> UpdateCliente(ClienteRequestModel requestModel);
    Task<ApiResultModel> DeleteCliente(int id);
}