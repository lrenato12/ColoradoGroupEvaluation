using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
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
    Task<ApiResultModel> Create(ClienteRequestModel requestModel);
    #endregion

    #region [ UPDATE ]
    Task<ApiResultModel> Update(ClienteRequestModel requestModel);
    #endregion

    #region [ DELETE ]
    Task<ApiResultModel> Delete(int clienteId);
    #endregion
}