using AutoMapper;
using ColoradoGroupEvaluation.Core.Base;
using ColoradoGroupEvaluation.Infra.Base.Database;
using ColoradoGroupEvaluation.Infra.Cliente;
using ColoradoGroupEvaluation.Infra.Telefone;
using ColoradoGroupEvaluation.Shared.Models.Base.Result;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using Microsoft.AspNetCore.Http;
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

    #region [ GET BY ID ]
    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ApiResultModel> GetById(int id)
    {
        var result = await _clienteDAL.GetById(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ GET ALL ]
    /// <summary>
    /// Get All
    /// </summary>
    /// <returns></returns>
    public async Task<ApiResultModel> GetAll()
    {
        var result = await _clienteDAL.GetAll();

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ Create ]
    /// <summary>
    /// Create
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
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
    #endregion

    #region [ DELETE ]
    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ApiResultModel> Delete(int id)
    {
        var result = await _clienteDAL.Delete(id);

        return new ApiResultModel().WithSuccess(result);
    }
    #endregion

    #region [ UPDATE ]
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<ApiResultModel> Update(ClienteRequestModel requestModel)
    {
        var currentData = await _clienteDAL.ExistsItem(requestModel.CodigoCliente);
        if (currentData == null)
            throw new Exception("Nao foi possivel localizar o registro para alterar.");

        currentData.RazaoSocial = requestModel.RazaoSocial;
        currentData.NomeFantasia = requestModel.NomeFantasia;
        currentData.TipoPessoa = requestModel.TipoPessoa;
        currentData.Documento = requestModel.Documento;
        currentData.Endereco = requestModel.Endereco;
        currentData.Complemento = requestModel.Complemento;
        currentData.Bairro = requestModel.Bairro;
        currentData.Cidade = requestModel.Cidade;
        currentData.CEP = requestModel.CEP;
        currentData.UF = requestModel.UF;

        var currentDataTel = await _telefoneDAL.GetById(requestModel.CodigoTelefone);
        if (currentDataTel == null)
            throw new Exception("Nao foi possivel localizar o registro para alterar.");

        currentDataTel.NumeroTelefone = requestModel.NumeroTelefone;
        currentDataTel.CodigoTipoTelefone = requestModel.CodigoTipoTelefone;
        currentDataTel.CodigoTelefone = requestModel.CodigoTelefone;

        var result = await _telefoneDAL.Update(currentDataTel);

        result = await _clienteDAL.Update(currentData);

        return new ApiResultModel().WithSuccess(requestModel);
    }
    #endregion
    #endregion
}