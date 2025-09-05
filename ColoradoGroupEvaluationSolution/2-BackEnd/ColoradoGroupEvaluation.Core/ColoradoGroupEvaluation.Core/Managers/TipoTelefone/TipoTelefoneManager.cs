using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.TipoTelefone;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using Microsoft.AspNetCore.Http;

namespace ColoradoGroupEvaluation.Core.Managers.TipoTelefone;

public class TipoTelefoneManager : BaseManager, ITipoTelefoneManager
{
    #region [ PROPERTIES ]
    private readonly ITipoTelefoneDAL _tipoTelefoneDAL;
    #endregion

    #region [ CTOR ]
    public TipoTelefoneManager(IHttpContextAccessor httpContextAccessor, ITipoTelefoneDAL tipoTelefoneDAL)
        : base(httpContextAccessor)
    {
        _tipoTelefoneDAL = tipoTelefoneDAL;
    }
    #endregion

    public async Task<ApiResultModel> GetDropdownData()
    {
        var result = await _tipoTelefoneDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetById(string tipoTelefoneId)
    {
        var result = await _tipoTelefoneDAL.GetById(tipoTelefoneId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAll()
    {
        var result = await _tipoTelefoneDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Create(Shared.Models.TipoTelefone.Domain.TipoTelefone requestModel)
    {
        var result = await _tipoTelefoneDAL.Create(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Update(Shared.Models.TipoTelefone.Domain.TipoTelefone requestModel)
    {
        var result = await _tipoTelefoneDAL.Update(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Delete(string tipoTelefoneId)
    {
        var result = await _tipoTelefoneDAL.Delete(tipoTelefoneId);

        return new ApiResultModel().WithSuccess(result);
    }
}