using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Core.Managers.Telefone;

public interface ITelefoneManager
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApiResultModel> GetById(int id);
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
    Task<ApiResultModel> Create(TelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> Update(TelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApiResultModel> Delete(int id);
    #endregion
}