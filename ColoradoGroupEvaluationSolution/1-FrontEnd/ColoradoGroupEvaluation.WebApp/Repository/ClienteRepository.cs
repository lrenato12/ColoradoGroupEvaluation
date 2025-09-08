using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using ColoradoGroupEvaluation.WebApp.Services.API;
using ColoradoGroupEvaluation.WebApp.Services.API.Application;

namespace ColoradoGroupEvaluation.WebApp.Repository;

public class ClienteRepository : BaseRepository, IClienteRepository
{
    #region CTOR
    public ClienteRepository(IApplicationFactory applicationFactory) : base(applicationFactory) { }
    #endregion

    public async Task<ApiResultModel> GetClienteById(int id)
    {
        var resultModel = await _applicationFactory.CallWebService($"Cliente/GetClienteById/{id}", RequestTypeEnum.GET);

        return resultModel;
    }
    public async Task<ApiResultModel> GetAllCliente()
    {
        var resultModel = await _applicationFactory.CallWebService($"Cliente/GetAll", RequestTypeEnum.GET);

        return resultModel;
    }
    public async Task<ApiResultModel> CreateCliente(ClienteRequestModel requestModel)
    {
        var resultModel = await _applicationFactory.CallWebService($"Cliente/Create", RequestTypeEnum.POST, requestModel);

        return resultModel;
    }
    public async Task<ApiResultModel> UpdateCliente(ClienteRequestModel requestModel)
    {
        var resultModel = await _applicationFactory.CallWebService($"Cliente/Edit", RequestTypeEnum.PUT, requestModel);

        return resultModel;
    }
    public async Task<ApiResultModel> DeleteCliente(int id)
    {
        var resultModel = await _applicationFactory.CallWebService($"Cliente/Delete/{id}", RequestTypeEnum.DELETE);

        return resultModel;
    }
}