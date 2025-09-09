using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Infra.TipoTelefone;

public interface ITipoTelefoneDAL
{
    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    Task<TipoTelefoneModel?> GetById(string tipoTelefoneId);
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// GET ALL
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TipoTelefoneModel>> GetAll();
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Create(TipoTelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    Task<int> Update(TipoTelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    Task<bool> Delete(string tipoTelefoneId);
    #endregion
}