using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Infra.Cliente;

public interface IClienteDAL
{
    #region [ GET BY ID ]
    Task<ClienteModel?> GetById(int id);
    #endregion

    #region [ GET ALL ]
    Task<IEnumerable<ClienteModel>> GetAll();
    #endregion

    #region [ CREATE ]
    Task<int> Create(ClienteModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<int> Update(ClienteModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<bool> Delete(int id);
    #endregion
}