using ColoradoGroupEvaluation.Api.Controllers.Base;
using ColoradoGroupEvaluation.Core.Managers.TipoTelefone;
using Microsoft.AspNetCore.Mvc;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Api.Controllers.TipoTelefone;

/// <summary>
/// 
/// </summary>
/// <param name="configuration"></param>
/// <param name="environment"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="tipoTelefoneManager"></param>
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
    /// <summary>
    /// Recupera um item pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
        => Ok(await _tipoTelefoneManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Lista todos os itens
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok(await _tipoTelefoneManager.GetAll());
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria um novo item
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] TipoTelefoneModel requestModel)
        => Ok(await _tipoTelefoneManager.Create(requestModel));
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] TipoTelefoneModel requestModel)
    => Ok(await _tipoTelefoneManager.Update(requestModel));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Deleta um item pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    => Ok(await _tipoTelefoneManager.Delete(id));
    #endregion
    #endregion
}