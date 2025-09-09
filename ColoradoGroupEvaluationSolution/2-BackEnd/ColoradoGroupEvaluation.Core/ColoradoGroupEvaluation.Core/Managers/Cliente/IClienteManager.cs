using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;

namespace ColoradoGroupEvaluation.Core.Managers.Cliente;

public interface IClienteManager
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="clienteId"></param>
    /// <returns></returns>
    Task<ApiResultModel> GetById(int clienteId);
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
    Task<ApiResultModel> Create(ClienteRequestModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<ApiResultModel> Update(ClienteRequestModel requestModel);
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="clienteId"></param>
    /// <returns></returns>
    Task<ApiResultModel> Delete(int clienteId);
    #endregion
}