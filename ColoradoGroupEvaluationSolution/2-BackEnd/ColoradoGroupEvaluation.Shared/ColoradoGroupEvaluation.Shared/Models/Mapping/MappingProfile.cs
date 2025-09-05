using AutoMapper;
using ColoradoGroupEvaluation.Shared.Models.Cliente.Request;
using ClienteModel = ColoradoGroupEvaluation.Shared.Models.Cliente.Domain.Cliente;
using TelefoneModel = ColoradoGroupEvaluation.Shared.Models.Telefone.Domain.Telefone;
using TipoTelefoneModel = ColoradoGroupEvaluation.Shared.Models.TipoTelefone.Domain.TipoTelefone;

namespace ColoradoGroupEvaluation.Shared.Models.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClienteRequestModel, ClienteModel>()
            .ForMember(dest => dest.CodigoCliente, opt => opt.Ignore())
            .ForMember(dest => dest.DataInsercao, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UsuarioInsercao, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.UsuarioInsercao) ? "System" : src.UsuarioInsercao ));

        CreateMap<ClienteRequestModel, TelefoneModel>()
            .ForMember(dest => dest.CodigoTelefone, opt => opt.Ignore())
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.TipoTelefone, opt => opt.Ignore())
            .ForMember(dest => dest.DataInsercao, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UsuarioInsercao, opt => opt.Ignore());
        
        CreateMap<ClienteRequestModel, TipoTelefoneModel>()
            .ForMember(dest => dest.DataInsercao, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UsuarioInsercao, opt => opt.Ignore());
    }
}