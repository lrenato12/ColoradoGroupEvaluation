using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.Cliente;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using Microsoft.AspNetCore.Http;

namespace ColoradoGroupEvaluation.Core.Managers.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    #endregion

    #region [ CTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor, IClienteDAL clienteDAL)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
    }

    public async Task<ApiResultModel> GetById(int clienteId)
    {
        var result = await _clienteDAL.GetById(clienteId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAll()
    {
        var result = await _clienteDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Create(Shared.Models.Cliente.Domain.Cliente requestModel)
    {
        var result = await _clienteDAL.Create(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Delete(int clienteId)
    {
        var result = await _clienteDAL.Delete(clienteId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Update(Shared.Models.Cliente.Domain.Cliente requestModel)
    {
        var result = await _clienteDAL.Update(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}