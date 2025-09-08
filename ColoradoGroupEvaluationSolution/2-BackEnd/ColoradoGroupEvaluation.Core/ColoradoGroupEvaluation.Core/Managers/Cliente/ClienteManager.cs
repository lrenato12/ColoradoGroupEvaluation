using AutoMapper;
using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using ColoradoGroupEvaluation.Infra.Cliente;
using ColoradoGroupEvaluation.Infra.Telefone;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;

namespace ColoradoGroupEvaluation.Core.Managers.Cliente;

public class ClienteManager : BaseManager, IClienteManager
{
    #region [ PROPERTIES ]
    private readonly IClienteDAL _clienteDAL;
    private readonly ITelefoneDAL _telefoneDAL;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    #endregion

    #region [ CTOR ]
    public ClienteManager(IHttpContextAccessor httpContextAccessor, IClienteDAL clienteDAL, ITelefoneDAL telefoneDAL, IMapper mapper, ApplicationDbContext context)
        : base(httpContextAccessor)
    {
        _clienteDAL = clienteDAL;
        _telefoneDAL = telefoneDAL;
        _mapper = mapper;
        _context = context;
    }

    public async Task<ApiResultModel> GetById(int clienteId)
    {
        var result = await _clienteDAL.GetById(clienteId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> GetAll()
    {
        var result = await _clienteDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Create(ClienteRequestModel requestModel)
    {
        var clienteModel = new ClienteModel
        {
            RazaoSocial = requestModel.RazaoSocial,
            NomeFantasia = requestModel.NomeFantasia,
            TipoPessoa = requestModel.TipoPessoa,
            Documento = requestModel.Documento,
            Endereco = requestModel.Endereco,
            Complemento = requestModel.Complemento,
            Bairro = requestModel.Bairro,
            Cidade = requestModel.Cidade,
            CEP = requestModel.CEP,
            UF = requestModel.UF,
            UsuarioInsercao = requestModel.UsuarioInsercao,
            DataInsercao = DateTime.Now,
            Telefones = new List<TelefoneModel>()
        };

        if (!string.IsNullOrEmpty(requestModel.NumeroTelefone))
        {
            var phoneModel = new TelefoneModel
            {
                NumeroTelefone = requestModel.NumeroTelefone,
                Operadora = requestModel.Operadora,
                Ativo = true,
                CodigoTipoTelefone = requestModel.CodigoTipoTelefone,
                UsuarioInsercao = requestModel.UsuarioInsercao,
                DataInsercao = DateTime.Now
            };

            clienteModel.Telefones.Add(phoneModel);
        }

        var result = await _clienteDAL.Create(clienteModel);

        return new ApiResultModel().WithSuccess(requestModel);
    }

    public async Task<ApiResultModel> Delete(int clienteId)
    {
        var result = await _clienteDAL.Delete(clienteId);

        return new ApiResultModel().WithSuccess(result);
    }

    public async Task<ApiResultModel> Update(ClienteRequestModel requestModel)
    {
        var result = await _clienteDAL.Update(_mapper.Map<ClienteModel>(requestModel));

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion
}