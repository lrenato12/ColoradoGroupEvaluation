using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Infra.TipoTelefone;

public interface ITipoTelefoneDAL
{
    #region [ GET DROPDOWN DATA ]
    Task<IEnumerable<TipoTelefoneModel>> GetDropdownData();
    #endregion

    #region [ GET BY ID ]
    Task<TipoTelefoneModel?> GetById(string tipoTelefoneId);
    #endregion

    #region [ GET ALL ]
    Task<IEnumerable<TipoTelefoneModel>> GetAll();
    #endregion

    #region [ CREATE ]
    Task<int> Create(TipoTelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<int> Update(TipoTelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<bool> Delete(string tipoTelefoneId);
    #endregion
}