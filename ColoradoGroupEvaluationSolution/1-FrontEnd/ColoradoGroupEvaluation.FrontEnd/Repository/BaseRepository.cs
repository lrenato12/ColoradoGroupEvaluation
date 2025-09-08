using ColoradoGroupEvaluation.FrontEnd.Services.API.Application;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;

namespace ColoradoGroupEvaluation.FrontEnd.Repository;

public class BaseRepository
{
    #region Properties
    public readonly IApplicationFactory _applicationFactory;
    #endregion

    #region Constructor
    public BaseRepository(IApplicationFactory applicationFactory)
    {
        _applicationFactory = applicationFactory;
    }
    #endregion

    #region Set Custom Exception
    public ApiResultModel SetCustomException(ApiErrorModel error = null, string defaultMessage = "An unexpected error occurred") => new ApiResultModel().WithError(defaultMessage);
    #endregion
}