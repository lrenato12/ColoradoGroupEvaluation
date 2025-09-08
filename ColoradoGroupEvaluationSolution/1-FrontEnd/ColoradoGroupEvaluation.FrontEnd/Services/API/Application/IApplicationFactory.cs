using ColoradoGroupEvaluation.Shared.Models.Base.Result;

namespace ColoradoGroupEvaluation.FrontEnd.Services.API.Application;

public interface IApplicationFactory
{
    Task<ApiResultModel> CallWebService(string endPoint, RequestTypeEnum requestTypeEnum, object obj = default(object));
}