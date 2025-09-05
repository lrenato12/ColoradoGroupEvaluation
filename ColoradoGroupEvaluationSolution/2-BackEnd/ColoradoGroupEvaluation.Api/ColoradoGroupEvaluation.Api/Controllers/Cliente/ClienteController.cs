using ColoradoGroupEvaluation.Api.Controllers.Base;
using ColoradoGroupEvaluation.Core.Managers.Cliente;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using Microsoft.AspNetCore.Mvc;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Api.Controllers.Cliente;

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
    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _clienteManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok(await _clienteManager.GetAll());
    #endregion

    #region [ CREATE ]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] ClienteRequestModel requestModel)
        => Ok(await _clienteManager.Create(requestModel));
    #endregion

    #region [ UPDATE ]
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] ClienteRequestModel requestModel)
        => Ok(await _clienteManager.Update(requestModel));
    #endregion

    #region [ DELETE ]
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => Ok(await _clienteManager.Delete(id));
    #endregion
    #endregion
}