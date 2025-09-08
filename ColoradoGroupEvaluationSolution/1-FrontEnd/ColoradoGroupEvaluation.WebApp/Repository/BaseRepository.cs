using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.WebApp.Services.API.Application;

namespace ColoradoGroupEvaluation.WebApp.Repository;

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