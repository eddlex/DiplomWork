using AutoMapper;

namespace FrontEnd.Model.DTO;

public class MappingProfile<TSource, TDestination> : Profile
{
    public MappingProfile()
    {
        CreateMap<TSource, TDestination>();
        CreateMap<TDestination, TSource>();
    }

    public static IMapper CreateMapper<TSource, TDestination>()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile<TSource, TDestination>());
        });
        return config.CreateMapper();
    }
}