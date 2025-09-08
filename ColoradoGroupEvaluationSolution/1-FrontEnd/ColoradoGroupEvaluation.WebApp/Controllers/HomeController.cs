using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ColoradoGroupEvaluation.WebApp.Models;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
using ColoradoGroupEvaluation.WebApp.Repository;
using System.Text.Json;

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
                // Configurações para desserialização: ignorar maiúsculas/minúsculas
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Desserialização
                var resposta = JsonSerializer.Deserialize<List<ClienteResponseModel>>(result.JsonResultData, options);

                //List<ClienteResponseModel> clientes = resposta.ApiResultData;

                result.ApiResultData = resposta;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}