using ColoradoGroupEvaluation.Infra.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Infra.TipoTelefone;

public class TipoTelefoneDAL : BaseDAL, ITipoTelefoneDAL
{
    private readonly ApplicationDbContext _context;

    #region [ CTOR ]
    public TipoTelefoneDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, ApplicationDbContext context, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
        _context = context;
    }
    #endregion

    #region [ METHODS ]

    #region [ GET BY ID ]
    /// <summary>
    /// GET BY ID
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    public async Task<TipoTelefoneModel?> GetById(string tipoTelefoneId)
    {
        return await _context.TiposTelefone.FindAsync(tipoTelefoneId);
    }
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// GET ALL
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<TipoTelefoneModel>> GetAll()
    {
        return await _context.TiposTelefone.AsNoTracking().ToListAsync();
    }
    #endregion

    #region [ CREATE ]
    /// <summary>
    /// CREATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    public async Task<int> Create(TipoTelefoneModel requestModel)
    {
        requestModel.DataInsercao = DateTime.Now;
        await _context.TiposTelefone.AddAsync(requestModel);
        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// UPDATE
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<int> Update(TipoTelefoneModel requestModel)
    {
        var existItem = await _context.TiposTelefone.FindAsync(requestModel.CodigoTipoTelefone);
        if (existItem == null)
            throw new Exception("Tipo de Telefone não encontrado.");

        requestModel.DataInsercao = existItem.DataInsercao;

        _context.Entry(existItem).CurrentValues.SetValues(requestModel);

        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// DELETE
    /// </summary>
    /// <param name="tipoTelefoneId"></param>
    /// <returns></returns>
    public async Task<bool> Delete(string tipoTelefoneId)
    {
        var currentItem = await _context.TiposTelefone.FindAsync(tipoTelefoneId);
        if (currentItem == null)
            throw new Exception("Tipo de Telefone não encontrado.");

        _context.TiposTelefone.Remove(currentItem);

        return await _context.SaveChangesAsync() >= 1;
    }
    #endregion 
    #endregion
}