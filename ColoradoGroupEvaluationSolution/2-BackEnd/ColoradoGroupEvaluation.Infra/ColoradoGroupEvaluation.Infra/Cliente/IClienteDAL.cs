using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Infra.Cliente;

public interface IClienteDAL
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ClienteResponseModel?> GetById(int id);
    #endregion

    #region [ EXISTS ITEM ]
    /// <summary>
    /// EXISTS ITEM
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ClienteModel?> ExistsItem(int id);
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// GET ALL
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ClienteResponseModel>> GetAll();
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Create(ClienteModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Update(ClienteModel requestModel);
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(int id);
    #endregion
}