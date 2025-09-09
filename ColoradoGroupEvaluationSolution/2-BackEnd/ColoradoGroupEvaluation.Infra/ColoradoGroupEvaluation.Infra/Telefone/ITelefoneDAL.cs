using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Infra.Telefone;

public interface ITelefoneDAL
{
    #region [ GET DROPDOWN DATA ]
    Task<IEnumerable<TelefoneModel>> GetDropdownData();
    #endregion

    #region [ GET BY ID ]
    Task<TelefoneModel?> GetById(int id);
    #endregion

    #region [ GET ALL ]
    Task<IEnumerable<TelefoneModel>> GetAll();
    #endregion

    #region [ CREATE ]
    Task<int> Create(TelefoneModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<int> Update(TelefoneModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<bool> Delete(int id);
    #endregion
}