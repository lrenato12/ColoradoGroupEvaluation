using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Core.Managers.TipoTelefone;

public interface ITipoTelefoneManager
{
    #region [ GET DROPDOWN DATA ]
    Task<ApiResultModel> GetDropdownData();
    #endregion

    #region [ GET BY ID ]
    Task<ApiResultModel> GetById(string tipoTelefoneId);
    #endregion

    #region [ GET ALL ]
    Task<ApiResultModel> GetAll();
    #endregion

    #region [ CREATE ]
    Task<ApiResultModel> Create(TipoTelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<ApiResultModel> Update(TipoTelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<ApiResultModel> Delete(string tipoTelefoneId);
    #endregion
}