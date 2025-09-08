using Microsoft.AspNetCore.Mvc;

namespace ColoradoGroupEvaluation.WebApp.Controllers;

public class BaseController : Controller
{
    #region Properties
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion Properties

    #region Contructor
    public BaseController([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}