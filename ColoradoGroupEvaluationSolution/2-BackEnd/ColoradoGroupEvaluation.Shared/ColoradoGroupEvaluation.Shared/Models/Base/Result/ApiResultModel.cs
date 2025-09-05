using System.Text.Json.Serialization;

namespace ColoradoGroupEvaluation.Shared.Models.Base.Result;

public class ApiResultModel
{
    #region Properties
    public bool Success { get; set; }
    public bool HasErrors => !string.IsNullOrEmpty(Error?.Message) || Errors.Count > 0;
    public ApiErrorModel Error { get; set; } = new ApiErrorModel();
    public List<ApiErrorModel> Errors { get; set; } = new List<ApiErrorModel>();
    public dynamic ApiResultData { get; set; }

    [JsonIgnore]
    public string JsonResultData => ApiResultData == null ? "" : $"{ApiResultData}";
    #endregion

    #region Constructor
    public ApiResultModel()
    {
        Error = new ApiErrorModel();
    }
    #endregion

    #region Methods
    private void SetSucces(dynamic resultData)
    {
        Success = true;
        ApiResultData = resultData;
        Errors.Clear();
    }

    private void SetError(ApiErrorModel error)
    {
        Success = false;
        Error = error;
        Errors.Add(error);
    }

    private void SetErrors(List<ApiErrorModel> errors)
    {
        Success = false;
        Errors = errors;
    }

    public ApiResultModel WithError(string errorMessage)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(new ApiErrorModel { Message = errorMessage });
        return ApiResultModel;
    }

    public ApiResultModel WithError(string code, string message)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(new ApiErrorModel { Code = code, Message = message });
        return ApiResultModel;
    }

    public ApiResultModel WithError(ApiErrorModel error)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(error);
        return ApiResultModel;
    }

    public ApiResultModel WithErrors(List<ApiErrorModel> errors)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetErrors(errors);
        return ApiResultModel;
    }

    public ApiResultModel WithSuccess(dynamic resultData)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetSucces(resultData);
        return ApiResultModel;
    }
    #endregion
}