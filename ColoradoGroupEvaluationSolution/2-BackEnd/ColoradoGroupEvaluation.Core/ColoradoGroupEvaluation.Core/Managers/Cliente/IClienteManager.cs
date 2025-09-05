using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Core.Managers.Cliente;

public interface IClienteManager
{
    #region [ GET BY ID ]
    Task<ApiResultModel> GetById(int clienteId);
    #endregion

    #region [ GET ALL ]
    Task<ApiResultModel> GetAll();
    #endregion

    #region [ CREATE ]
    Task<ApiResultModel> Create(ClienteModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<ApiResultModel> Update(ClienteModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<ApiResultModel> Delete(int clienteId);
    #endregion
}