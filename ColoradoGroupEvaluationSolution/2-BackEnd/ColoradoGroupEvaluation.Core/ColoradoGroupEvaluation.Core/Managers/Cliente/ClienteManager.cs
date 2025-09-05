using AutoMapper;
using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.Cliente;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using Microsoft.AspNetCore.Http;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Core.Managers.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    private readonly IMapper _mapper;

    #endregion

    #region [ CTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor, IClienteDAL clienteDAL, IMapper mapper)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _mapper = mapper;
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

    public async Task<ApiResultModel> Create(ClienteRequestModel requestModel)
    {
        var result = await _clienteDAL.Create(_mapper.Map<ClienteModel>(requestModel));

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Delete(int clienteId)
    {
        var result = await _clienteDAL.Delete(clienteId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Update(ClienteRequestModel requestModel)
    {
        var result = await _clienteDAL.Update(_mapper.Map<ClienteModel>(requestModel));

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}