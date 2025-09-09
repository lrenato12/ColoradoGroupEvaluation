using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Infra.Cliente;

public interface IClienteDAL
{
    #region [ GET BY ID ]
    Task<ClienteResponseModel?> GetById(int id);
    #endregion
    Task<ClienteModel?> ExistsItem(int id);

    #region [ GET ALL ]
    Task<IEnumerable<ClienteResponseModel>> GetAll();
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