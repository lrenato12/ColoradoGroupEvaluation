using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.WebApp.Services.Config;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ColoradoGroupEvaluation.WebApp.Services.API.Application;

public class ApplicationFactory : IApplicationFactory
{
    #region Properties
    private readonly HttpClient _client;
    private readonly AppSettings _appSettings;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private const string ERROR_MESSAGE = "Ocorreu um erro. Por favor, tente novamente.";
    #endregion Properties

    #region Contructor
    public ApplicationFactory(HttpClient client
                            , IOptions<AppSettings> appSettings
                            , IHttpContextAccessor httpContextAccessor
                            , IConfiguration configuration)
    {
        _client = client;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _appSettings = appSettings.Value;

        this._client.BaseAddress = new Uri(_appSettings.ApiIpAddress);
        this._client.DefaultRequestHeaders.Accept.Clear();
        this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    #endregion

    #region Call Web Service
    /// <summary>
    /// Call Web Service (GET, POST, PUT or DELETE)
    /// </summary>
    /// <param name="endPoint">Set End Point</param>
    /// <param name="requestTypeEnum">Request Type (GET, POST, PUT or DELETE)</param>
    /// <param name="obj">Object to serealize</param>
    public async Task<ApiResultModel> CallWebService(string endPoint, RequestTypeEnum requestTypeEnum, object obj = default(object))
    {
        try
        {
            var resul = new ApiResultModel();
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            switch (requestTypeEnum)
            {
                case RequestTypeEnum.GET:
                    httpResponse = await GetAsync(endPoint);
                    break;

                case RequestTypeEnum.POST:
                    httpResponse = await PostAsync(endPoint, obj);
                    break;

                case RequestTypeEnum.PUT:
                    httpResponse = await PutAsync(endPoint, obj);
                    break;

                case RequestTypeEnum.DELETE:
                    httpResponse = await DeleteAsync(endPoint);
                    break;

                default:
                    new ApiResultModel
                    {
                        Success = false,
                        Error = new ApiErrorModel()
                        {
                            Message = "No request type selected."
                        }
                    };
                    break;
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                if (((int)httpResponse.StatusCode) >= 400 && ((int)httpResponse.StatusCode) < 500)
                {
                    var contentResult = await httpResponse.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(contentResult))
                        throw new Exception(contentResult);
                    else
                        throw new Exception(httpResponse.ReasonPhrase);
                }

                throw new Exception(ERROR_MESSAGE);
            }

            var json = await httpResponse.Content.ReadAsStringAsync();
            var resultModel = JsonConvert.DeserializeObject<ApiResultModel>(json);

            return resultModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region Post Async
    /// <summary>
    /// Call Post Async
    /// </summary>
    /// <param name="endPoint">Set End Point</param>
    /// <param name="obj">Object to serealize</param>
    private async Task<HttpResponseMessage> PostAsync<T>(string endPoint, T obj)
        => await new HttpClientHelper(_client)
            .SetEndpoint($"{endPoint}")
            .WithContentSerialized(obj)
            .PostAsync();
    #endregion

    #region Put Async
    /// <summary>
    /// Call Put Async
    /// </summary>
    /// <param name="endPoint">Set End Point</param>
    /// <param name="obj">Object to serealize</param>
    private async Task<HttpResponseMessage> PutAsync<T>(string endPoint, T obj)
        => await new HttpClientHelper(_client)
            .SetEndpoint($"{endPoint}")
            .WithContentSerialized(obj)
            .PutAsync();
    #endregion

    #region Get Async
    /// <summary>
    /// Call Get Async
    /// </summary>
    /// <param name="endPoint">Set End Point</param>
    private async Task<HttpResponseMessage> GetAsync(string endPoint)
        => await new HttpClientHelper(_client)
            .SetEndpoint($"{endPoint}")
            .GetAsync();
    #endregion

    #region Delete Async
    /// <summary>
    /// Call Get Async
    /// </summary>
    /// <param name="endPoint">Set End Point</param>
    private async Task<HttpResponseMessage> DeleteAsync(string endPoint)
        => await new HttpClientHelper(_client)
            .SetEndpoint($"{endPoint}")
            .DeleteAsync();
    #endregion

}