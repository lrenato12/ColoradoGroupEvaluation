using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.Telefone;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using Microsoft.AspNetCore.Http;

namespace ColoradoGroupEvaluation.Core.Managers.Telefone;

public class TelefoneManager : BaseManager, ITelefoneManager
{
    #region [ PROPERTIES ]
    private readonly ITelefoneDAL _telefoneDAL;
    #endregion

    #region [ CTOR ]
    public TelefoneManager(IHttpContextAccessor httpContextAccessor, ITelefoneDAL telefoneDAL)
        : base(httpContextAccessor)
    {
        _telefoneDAL = telefoneDAL;
    }
    #endregion

    public async Task<ApiResultModel> GetDropdownData()
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _telefoneDAL.GetById(id);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAll()
    {
        var result = await _telefoneDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Create(Shared.Models.Telefone.Domain.Telefone requestModel)
    {
        var result = await _telefoneDAL.Create(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Update(Shared.Models.Telefone.Domain.Telefone requestModel)
    {
        var result = await _telefoneDAL.Update(requestModel);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _telefoneDAL.Delete(id);

        return new ApiResultModel().WithSuccess(result);
    }
}