using AutoMapper;

namespace BLL.Infrastructure.Mapping
{
    public interface IMapConfig
    {
        IMapper GetMapper();
    }
}