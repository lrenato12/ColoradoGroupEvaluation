using ColoradoGroupEvaluation.Shared.Models.Base.Result;

namespace ColoradoGroupEvaluation.WebApp.Repository;

public interface IClienteRepository
{
    Task<ApiResultModel> GetClienteById(string ClienteId);
    Task<ApiResultModel> GetAllCliente();
    Task<ApiResultModel> CreateCliente(Shared.Models.Cliente.Domain.Cliente requestModel);
    Task<ApiResultModel> UpdateCliente(Shared.Models.Cliente.Domain.Cliente requestModel);
    Task<ApiResultModel> DeleteCliente(string ClienteId);
}