using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Core.Managers.TipoTelefone;

public interface ITipoTelefoneManager
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    Task<ApiResultModel> GetById(string tipoTelefoneId);
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// GET ALL
    /// </summary>
    /// <returns></returns>
    Task<ApiResultModel> GetAll();
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> Create(TipoTelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> Update(TipoTelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    Task<ApiResultModel> Delete(string tipoTelefoneId);
    #endregion
}