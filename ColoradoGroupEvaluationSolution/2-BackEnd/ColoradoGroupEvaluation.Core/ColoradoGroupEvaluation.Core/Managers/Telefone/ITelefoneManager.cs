using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Core.Managers.Telefone;

public interface ITelefoneManager
{
    #region [ GET DROPDOWN DATA ]
    Task<ApiResultModel> GetDropdownData();
    #endregion

    #region [ GET BY ID ]
    Task<ApiResultModel> GetById(string telefoneId);
    #endregion

    #region [ GET ALL ]
    Task<ApiResultModel> GetAll();
    #endregion

    #region [ CREATE ]
    Task<ApiResultModel> Create(TelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<ApiResultModel> Update(TelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<ApiResultModel> Delete(string telefoneId);
    #endregion
}