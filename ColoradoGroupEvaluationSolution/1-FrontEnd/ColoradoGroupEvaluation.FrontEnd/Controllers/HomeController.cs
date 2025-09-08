using ColoradoGroupEvaluation.FrontEnd.Models;
using ColoradoGroupEvaluation.FrontEnd.Repository;
using ColoradoGroupEvaluation.Shared.Models.Base.Extension;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ColoradoGroupEvaluation.FrontEnd.Controllers;

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
                var items = result.JsonResultData.JsonToObject<List<ClienteResponseModel>>();

                result.ApiResultData = items;

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
