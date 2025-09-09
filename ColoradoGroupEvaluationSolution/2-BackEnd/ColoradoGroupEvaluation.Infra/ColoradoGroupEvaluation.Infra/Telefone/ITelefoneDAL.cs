using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Infra.Telefone;

public interface ITelefoneDAL
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TelefoneModel?> GetById(int id);
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// GET ALL
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TelefoneModel>> GetAll();
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Create(TelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Update(TelefoneModel requestModel);
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