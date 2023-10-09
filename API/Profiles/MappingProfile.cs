using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //crea un mapeo entre las propiedades de Producto y ProductoDto.
            CreateMap<Producto, ProductoDto>()
                // forMember especifica como se debe mapear una propiedad específica.
                .ForMember(x => x.Marca, dest => dest.MapFrom(r => r.Marca.Descripcion))
                //reverseMap permite la inversa del mapeo, de ProductoDto a Producto.
                .ReverseMap();

            // createMap para el mapeo simple entre Marca y MarcaDto
            CreateMap<Marca, MarcaDto>().ReverseMap();
        }
    }
}
