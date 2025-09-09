using ColoradoGroupEvaluation.Infra.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Response;
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
    public async Task<ClienteResponseModel?> GetById(int id)
    {
        var query = _context.Clientes
            .Where(c => c.CodigoCliente == id)
            .SelectMany(
                cliente => cliente.Telefones.DefaultIfEmpty(),
                (cliente, telefone) => new { cliente, telefone }
            );

        var resultado = await query.Select(x => new ClienteResponseModel
        {
            CodigoCliente = x.cliente.CodigoCliente,
            RazaoSocial = x.cliente.RazaoSocial,
            NomeFantasia = x.cliente.NomeFantasia,
            TipoPessoa = x.cliente.TipoPessoa,
            Documento = x.cliente.Documento,
            Endereco = x.cliente.Endereco,
            Complemento = x.cliente.Complemento,
            Bairro = x.cliente.Bairro,
            Cidade = x.cliente.Cidade,
            CEP = x.cliente.CEP,
            UF = x.cliente.UF,
            DataInsercao = x.cliente.DataInsercao,
            UsuarioInsercao = x.cliente.UsuarioInsercao,

            CodigoTelefone = (x.telefone == null) ? 0 : x.telefone.CodigoTelefone,
            NumeroTelefone = (x.telefone == null) ? null : x.telefone.NumeroTelefone,
            Operadora = (x.telefone == null) ? null : x.telefone.Operadora,
            CodigoTipoTelefone = (x.telefone == null) ? 0 : x.telefone.CodigoTipoTelefone,
        })
        .FirstOrDefaultAsync();

        return resultado;
    }
    #endregion

    public async Task<ClienteModel?> ExistsItem(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    #region [ GET ALL ]
    public async Task<IEnumerable<ClienteResponseModel>> GetAll()
    {
        var query = _context.Clientes
            .SelectMany(
                cliente => cliente.Telefones.DefaultIfEmpty(),
                (cliente, telefone) => new { cliente, telefone }
            );

        var resultado = await query.Select(x => new ClienteResponseModel
        {
            CodigoCliente = x.cliente.CodigoCliente,
            RazaoSocial = x.cliente.RazaoSocial,
            NomeFantasia = x.cliente.NomeFantasia,
            TipoPessoa = x.cliente.TipoPessoa,
            Documento = x.cliente.Documento,
            Endereco = x.cliente.Endereco,
            Complemento = x.cliente.Complemento,
            Bairro = x.cliente.Bairro,
            Cidade = x.cliente.Cidade,
            CEP = x.cliente.CEP,
            UF = x.cliente.UF,
            DataInsercao = x.cliente.DataInsercao,
            UsuarioInsercao = x.cliente.UsuarioInsercao,

            CodigoTelefone = (x.telefone == null) ? 0 : x.telefone.CodigoTelefone,
            NumeroTelefone = (x.telefone == null) ? null : x.telefone.NumeroTelefone,
            Operadora = (x.telefone == null) ? null : x.telefone.Operadora,
            CodigoTipoTelefone = (x.telefone == null) ? 0 : x.telefone.CodigoTipoTelefone,
        })
        .ToListAsync();

        return resultado;
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
            throw new Exception("Nao foi possivel localizar o registro para deletar.");

        _context.Entry(existItem).CurrentValues.SetValues(requestModel);

        return await _context.SaveChangesAsync();
    }
    #endregion

    #region [ DELETE ]
    public async Task<bool> Delete(int id)
    {
        var currentItem = await _context.Clientes.FindAsync(id);
        if (currentItem == null)
            throw new Exception("Nao foi possivel localizar o registro para deletar.");

        _context.Clientes.Remove(currentItem);

        return await _context.SaveChangesAsync() >= 1;
    }
    #endregion
    #endregion
}