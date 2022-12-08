using AutoMapper;
using ApiCompraventa.DTOs;
using ApiCompraventa.Entidades;

namespace ApiCompraventa.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Marca, MarcaDTOs>().ReverseMap();
            CreateMap<MarcaDTOsCreation, Marca>();

            CreateMap<TipoDocumento, TipoDocumentoDTOs>().ReverseMap();
            CreateMap<TipoDocumentoDTOsCreation, TipoDocumento>();

            CreateMap<Historial, HistorialDTOs>().ReverseMap();
            CreateMap<HistorialDTOsCreation, Historial>();

            CreateMap<Estado, EstadoDTOs>().ReverseMap();
            CreateMap<EstadoDTOsCreation, Estado>();

            CreateMap<Articulo, ArticuloDTOs>().ReverseMap();
            CreateMap<ArticuloDTOsCreation, Articulo>();

            CreateMap<Categorias, CategoriasDTOs>().ReverseMap();
            CreateMap<CategoriasDTOsCreation, Categorias>();

            CreateMap<Detalles, DetallesDTOs>().ReverseMap();
            CreateMap<DetallesDTOsCreation, Detalles>();

            CreateMap<FotoArticulo, FotoArticuloDTOs>().ReverseMap();
            CreateMap<FotoArticuloDTOsCreation, FotoArticulo>();
        }
    }
}
