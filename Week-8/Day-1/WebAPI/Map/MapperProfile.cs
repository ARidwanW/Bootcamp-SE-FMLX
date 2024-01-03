using AutoMapper;
using WebAPI.Model;
using WebAPI.Model.Request;
using WebAPI.Model.Response;

namespace WebAPI.Map;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category,CategoryResponse>();
        // CreateMap<Category,CategoryResponse>().ReverseMap();
        CreateMap<CategoryRequest, Category>();
    }
}
