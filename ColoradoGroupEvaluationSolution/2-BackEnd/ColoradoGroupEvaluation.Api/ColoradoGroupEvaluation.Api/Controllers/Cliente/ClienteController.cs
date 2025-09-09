using ColoradoGroupEvaluation.Api.Controllers.Base;
using ColoradoGroupEvaluation.Core.Managers.Cliente;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoGroupEvaluation.Api.Controllers.Cliente;

/// <summary>
/// Cliente Controller
/// </summary>
/// <param name="configuration"></param>
/// <param name="environment"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="clienteManager"></param>
[Route("[controller]")]
[ApiController]
public class ClienteController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] IClienteManager clienteManager) : BaseController(configuration, environment, httpContextAccessor)
{
    #region [ PROPERTIES ]
    private readonly IClienteManager _clienteManager = clienteManager;
    #endregion

    #region [ METHODS ]
    #region [ GET BY ID ]
    /// <summary>
    /// Recupera um registro pelo ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _clienteManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Recupera todos os registros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok(await _clienteManager.GetAll());
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria um novo registro
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] ClienteRequestModel requestModel)
        => Ok(await _clienteManager.Create(requestModel));
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// Altera um registro
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] ClienteRequestModel requestModel)
        => Ok(await _clienteManager.Update(requestModel));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Exclui um registro
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _clienteManager.Delete(id));
    #endregion
    #endregion
}