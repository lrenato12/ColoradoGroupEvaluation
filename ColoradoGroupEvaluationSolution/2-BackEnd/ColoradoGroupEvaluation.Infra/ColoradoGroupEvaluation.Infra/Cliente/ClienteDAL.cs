using ColoradoGroupEvaluation.Infra.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;

namespace ColoradoGroupEvaluation.Infra.Cliente;

public class ClienteDAL : BaseDAL, IClienteDAL
{
    private readonly ApplicationDbContext _context;

    #region [ CTOR ]
    public ClienteDAL(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHostEnvironment environment, ApplicationDbContext context, DbSession dbSession = null)
        : base(configuration, environment, httpContextAccessor, dbSession: dbSession)
    {
        _context = context;
    }
    #endregion

    #region [ METHODS ]
  
    #region [ GET BY ID ]
    public async Task<ClienteModel?> GetById(int telefoneId)
    {
        return await _context.Clientes.FindAsync(telefoneId);
    }
    #endregion

    #region [ GET ALL ]
    public async Task<IEnumerable<ClienteModel>> GetAll()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }
    #endregion

    #region [ CREATE ]
    public async Task<int> Create(ClienteModel requestModel)
    {
        requestModel.DataInsercao = DateTime.Now;
        await _context.Clientes.AddAsync(requestModel);
        await _context.SaveChangesAsync();
        return requestModel.CodigoCliente;
    }
    #endregion

    #region [ UPDATE ]
    public async Task<int> Update(ClienteModel requestModel)
    {
        var existItem = await _context.Clientes.FindAsync(requestModel.CodigoCliente);
        if (existItem == null)
            throw new Exception("Tipo de Telefone não encontrado.");

        requestModel.DataInsercao = existItem.DataInsercao;

        _context.Entry(existItem).CurrentValues.SetValues(requestModel);

        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ DELETE ]
    public async Task<bool> Delete(int telefoneId)
    {
        var currentItem = await _context.Clientes.FindAsync(telefoneId);
        if (currentItem == null)
        {
            //TODO - RETORNAR ERRO
        }

        _context.Clientes.Remove(currentItem);

        return await _context.SaveChangesAsync() >= 1;
    }
    #endregion
    #endregion
}