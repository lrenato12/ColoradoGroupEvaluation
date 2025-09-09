using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ColoradoGroupEvaluation.WebApp.Models;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
using ColoradoGroupEvaluation.WebApp.Repository;
using System.Text.Json;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;

namespace ColoradoGroupEvaluation.WebApp.Controllers;

public class HomeController : BaseController
{

    #region [ Properties ]
    private readonly ILogger<HomeController> _logger;
    private readonly IClienteRepository _clienteRepository;
    #endregion

    #region [ CTOR ]
    public HomeController([FromServices] IHttpContextAccessor _HttpContextAccessor,
                                     IClienteRepository clienteRepository)
        : base(_HttpContextAccessor)
    {
        _clienteRepository = clienteRepository;
    }
    #endregion

    public IActionResult Index() => View();

    public IActionResult Create() => View();

    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var model = await _clienteRepository.GetClienteById(id);

            var response = JsonSerializer.Deserialize<ClienteResponseModel>(model.JsonResultData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(response);
        }
        catch (Exception ex)
        {
            return Json(new { data = new List<ClienteResponseModel>() });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    #region GET - [ GetAllCliente ]
    [HttpGet]
    public async Task<JsonResult> GetAllCliente()
    {
        try
        {
            var result = await _clienteRepository.GetAllCliente();
            if (result.Success)
            {
                result.ApiResultData = JsonSerializer.Deserialize<List<ClienteResponseModel>>(result.JsonResultData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Json(result);
            }
            else
                return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { data = new List<ClienteResponseModel>() });
        }
    }
    #endregion

    #region POST - [ Create ]
    [HttpPost]
    public async Task<JsonResult> Create([FromBody] ClienteRequestModel requestModel)
    {
        try
        {
            requestModel.UsuarioInsercao = "System";
            var result = await _clienteRepository.CreateCliente(requestModel);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { data = new List<ClienteResponseModel>() });
        }
    }
    #endregion

    #region POST - [ Update ]
    [HttpPost]
    public async Task<JsonResult> Update([FromBody] ClienteRequestModel requestModel)
    {
        try
        {
            var result = await _clienteRepository.UpdateCliente(requestModel);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { data = new List<ClienteResponseModel>() });
        }
    }
    #endregion

    #region DELETE - [ Delete ]
    [HttpGet]
    public async Task<JsonResult> Delete([FromRoute] int id)
    {
        try
        {
            var result = await _clienteRepository.DeleteCliente(id);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { data = new List<ClienteResponseModel>() });
        }
    }
    #endregion

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}