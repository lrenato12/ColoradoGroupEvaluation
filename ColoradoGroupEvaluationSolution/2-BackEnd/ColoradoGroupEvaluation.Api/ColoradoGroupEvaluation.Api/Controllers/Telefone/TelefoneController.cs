using ColoradoGroupEvaluation.Api.Controllers.Base;
using ColoradoGroupEvaluation.Core.Managers.Telefone;
using Microsoft.AspNetCore.Mvc;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Api.Controllers.Telefone;

/// <summary>
/// Telefone Controller
/// </summary>
/// <param name="configuration"></param>
/// <param name="environment"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="telefoneManager"></param>
[Route("[controller]")]
[ApiController]
public class TelefoneController([FromServices] IConfiguration configuration,
                            [FromServices] IWebHostEnvironment environment,
                            [FromServices] IHttpContextAccessor httpContextAccessor,
                            [FromServices] ITelefoneManager telefoneManager) : BaseController(configuration, environment, httpContextAccessor)
{
    #region [ PROPERTIES ]
    private readonly ITelefoneManager _telefoneManager = telefoneManager;
    #endregion

    #region [ METHODS ]
    #region [ GET BY ID ]
    /// <summary>
    /// Recupera um item por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
        => Ok(await _telefoneManager.GetById(id));
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Recupera todos os itens
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok(await _telefoneManager.GetAll());
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// Cria um novo item
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] TelefoneModel requestModel)
        => Ok(await _telefoneManager.Create(requestModel));
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] TelefoneModel requestModel)
    => Ok(await _telefoneManager.Update(requestModel));
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    => Ok(await _telefoneManager.Delete(id));
    #endregion
    #endregion
}