using ColoradoGroupEvaluation.Api.Controllers.Base;
using ColoradoGroupEvaluation.Core.Managers.TipoTelefone;
using Microsoft.AspNetCore.Mvc;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Api.Controllers.TipoTelefone;

[Route("[controller]")]
[ApiController]
public class TipoTelefoneController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] ITipoTelefoneManager tipoTelefoneManager) : BaseController(configuration, environment, httpContextAccessor)
{
    #region [ PROPERTIES ]
    private readonly ITipoTelefoneManager _tipoTelefoneManager = tipoTelefoneManager;
    #endregion

    #region [ METHODS ]
    #region [ GET BY ID ]
    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
        => Ok(await _tipoTelefoneManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok(await _tipoTelefoneManager.GetAll());
    #endregion

    #region [ CREATE ]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] TipoTelefoneModel requestModel)
        => Ok(await _tipoTelefoneManager.Create(requestModel));
    #endregion

    #region [ UPDATE ]
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] TipoTelefoneModel requestModel)
    => Ok(await _tipoTelefoneManager.Update(requestModel));
    #endregion

    #region [ DELETE ]
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    => Ok(await _tipoTelefoneManager.Delete(id));
    #endregion
    #endregion
}