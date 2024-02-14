using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace FrontEnd.Model.DTO;

public static class GenericAutoMapper<TSource, TDestination> 
{
        private static Mapper genMapper = new Mapper(new MapperConfiguration(
            cfg =>
                cfg.CreateMap<TSource, TDestination>().ReverseMap()
        ));
    public static TDestination Map(TSource source)
    {
        return genMapper.Map<TDestination>(source);
    }
}

