using ColoradoGroupEvaluation.Infra.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Infra.Telefone;

public class TelefoneDAL : BaseDAL, ITelefoneDAL
{
    private readonly ApplicationDbContext _context;

    #region [ CTOR ]
    public TelefoneDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, ApplicationDbContext context, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
        _context = context;
    }
    #endregion

    #region [ METHODS ]
    #region [ GET DROPDOWN DATA ]
    public async Task<IEnumerable<TelefoneModel>> GetDropdownData()
    {
        return await _context.Telefones.AsNoTracking().ToListAsync();
    }
    #endregion

    #region [ GET BY ID ]
    public async Task<TelefoneModel?> GetById(string TelefoneId)
    {
        return await _context.Telefones.FindAsync(TelefoneId);
    }
    #endregion

    #region [ GET ALL ]
    public async Task<IEnumerable<TelefoneModel>> GetAll()
    {
        return await _context.Telefones.AsNoTracking().ToListAsync();
    }
    #endregion

    #region [ CREATE ]
    public async Task<int> Create(TelefoneModel requestModel)
    {
        requestModel.DataInsercao = DateTime.Now;
        requestModel.CodigoTipoTelefone = 1;
        await _context.Telefones.AddAsync(requestModel);
        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ UPDATE ]
    public async Task<int> Update(TelefoneModel requestModel)
    {
        var existItem = await _context.Telefones.FindAsync(requestModel.CodigoTelefone);
        if (existItem == null)
            throw new Exception("Tipo de Telefone não encontrado.");

        requestModel.DataInsercao = existItem.DataInsercao;

        _context.Entry(existItem).CurrentValues.SetValues(requestModel);

        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ DELETE ]
    public async Task<bool> Delete(string TelefoneId)
    {
        var currentItem = await _context.Telefones.FindAsync(TelefoneId);
        if (currentItem == null)
            throw new Exception("Nao foi possivel localizar o registro para deletar.");

        _context.Telefones.Remove(currentItem);

        return await _context.SaveChangesAsync() >= 1;
    }
    #endregion
    #endregion
}